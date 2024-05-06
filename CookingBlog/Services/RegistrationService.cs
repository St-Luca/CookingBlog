using CookingBlog.Models.Core;
using CookingBlog.Models.Requests;
using CookingBlog.Models.Responses;
using CookingBlog.Models;
using CookingBlog.Services.Interfaces;
using Microsoft.Extensions.Logging;
using System.Net.Mail;

namespace CookingBlog.Services;

public class RegistrationService : IRegistrationService
{
    private readonly IUserService userService;
    private readonly IPasswordHashService passwordHashService;

    private readonly ILogger logger;

    //private readonly IUserEmailProducer emailProducer; //todo: make email 

    public RegistrationService(IUserService userService, IPasswordHashService passwordHashService, ILogger logger)
    {
        this.userService = userService;
        this.passwordHashService = passwordHashService;
        this.logger = logger;
    }

    public async Task<RegisterUserResult> RegisterUser(int userId, RegisterUserRequest registerUserRequest)
    {
        return await RegisterUserImpl(managerId, registerUserRequest);
    }

    private async Task<RegisterUserResult> RegisterUserImpl(int userId, RegisterUserRequest registerUserRequest)
    {
        using var transaction = await userService.BeginTransaction();

        var user = await userService.Add(new CreateUserRequest
        {
            Email = registerUserRequest.Email,
            UserRole = Role.User,
        }, transaction);

        //if (!await emailProducer.Produce(new EmailMessage
        //{
        //    UserId = managerId,
        //    TemplateType = EmailTemplateType.RegistrationComplete,
        //    EmailTo = registerUserRequest.Email,
        //    GlobalMergeVars = new List<GlobalMergeVar>
        //        {
        //            new()
        //            {
        //                Name = "RegistrationCompleteRef",
        //                Content = CompletePasswordUrl(user)
        //            }
        //        }
        //}))
        //{
        //    logger.Error($"failed to send an email with type={EmailTemplateType.RegistrationComplete} to {registerUserRequest.Email}");
        //}

        user.Status = UserStatus.Pending;

        try
        {
            await userService.Update(user, transaction);
        }
        catch (Exception e)
        {
            logger.Error(e);

            return new RegisterUserResult
            {
                Email = registerUserRequest.Email,
                Status = RegisterStatus.Failed
            };
        }

        transaction.Commit();

        return new RegisterUserResult
        {
            Email = registerUserRequest.Email,
            Status = RegisterStatus.Created
        };
    }

    public async Task Complete(CompleteUserRequest completeUserRequest)
    {
        var user = await userService.GetByEmail(completeUserRequest.Email);

        if (user == null)
        {
            throw new YolwiseHttpRequestException($"user {completeUserRequest.Email} doesn't exist");
        }

        try
        {
            if (!passwordHashService.Verify(completeUserRequest.Email, completeUserRequest.Token))
            {
                throw new YolwiseHttpRequestException($"incorrect token when trying to complete registration of {completeUserRequest.Email}");
            }
        }
        catch (Exception ex)
        {
            throw new YolwiseHttpRequestException(ex, "invalid token");
        }

        if (user.Status != UserStatus.Pending)
        {
            throw new YolwiseHttpRequestException($"user {completeUserRequest.Email} status is not pending");
        }

        user.Status = UserStatus.Approved;
        user.PasswordHash = passwordHashService.HashPassword(completeUserRequest.Password);

        await userService.Update(user);
    }

    private string CompletePasswordUrl(User user)
    {
        return $"{settings.GetValue("WorkplaceDomain")}/set-password?email={user.Email}&token={passwordHashService.HashPassword(user.Email)}";
    }
}
