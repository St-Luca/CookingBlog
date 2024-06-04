using CookingBlog.Models.Core;
using CookingBlog.Models.Requests;
using CookingBlog.Models.Responses;
using CookingBlog.Models;
using CookingBlog.Services.Interfaces;
using Microsoft.Extensions.Logging;
using System.Net.Mail;
using CookingBlog.Infrastructure;
using System.Security.Principal;
using CookingBlog.Services.Mappers;

namespace CookingBlog.Services;

public class RegistrationService : IRegistrationService
{
    private readonly IUserService userService;
    private readonly IPasswordHashService passwordHashService;

    private readonly ILogger<RegistrationService> logger;

    //private readonly IUserEmailProducer emailProducer; //todo: make email 

    public RegistrationService(IUserService userService, IPasswordHashService passwordHashService, ILogger<RegistrationService> logger)
    {
        this.userService = userService;
        this.passwordHashService = passwordHashService;
        this.logger = logger;
    }

    public async Task<RegisterUserResult> RegisterUser(int userId, RegisterUserRequest registerUserRequest)
    {
        return await RegisterUserImpl(userId, registerUserRequest);
    }

    private async Task<RegisterUserResult> RegisterUserImpl(int userId, RegisterUserRequest registerUserRequest)
    {
        using var transaction = await userService.BeginTransaction();

        var user = registerUserRequest.Map(new List<Role> { Role.User});
        user.PasswordHash = passwordHashService.HashPassword(registerUserRequest.Password);

        await userService.Add(user.Map(), transaction);


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
            await userService.Update(user.Map(), transaction);
        }
        catch (Exception e)
        {
            logger.LogError(e.Message);

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
            Status = RegisterStatus.Created,
            Token = passwordHashService.HashPassword(user.Email)
        };
    }

    public async Task Complete(CompleteUserRequest completeUserRequest)
    {
        var user = await userService.GetByEmail(completeUserRequest.Email);

        if (user == null)
        {
            throw new CookingHttpRequestException($"user {completeUserRequest.Email} doesn't exist");
        }

        if (!passwordHashService.Verify(completeUserRequest.Email, completeUserRequest.Token))
        {
            throw new CookingHttpRequestException($"incorrect token when trying to complete registration of {completeUserRequest.Email}");
        }


        if (user.Status != UserStatus.Pending)
        {
            throw new CookingHttpRequestException($"user {completeUserRequest.Email} status is not pending");
        }

        user.Status = UserStatus.Approved;

        await userService.Update(user);
    }
}
