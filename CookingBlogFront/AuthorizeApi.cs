using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components.Authorization;
using System.Linq.Dynamic.Core.Tokenizer;

public class AuthorizeApi 
{
	private readonly ILocalStorageService _localStorageService;
	private IdentutyAuthenticationStateProvider _stateProvider;
	public AuthorizeApi(AuthenticationStateProvider authenticationStateProvider, ILocalStorageService localStorage)
	{
		_stateProvider = (IdentutyAuthenticationStateProvider)authenticationStateProvider;
		_localStorageService = localStorage;
	}

	public async Task<bool> Login(string login, string password)
	{
		var token = "awdwadwa";



		await _localStorageService.SetItemAsStringAsync("token", token);

		_stateProvider.MarkAsAuthenticated(token);

		return true;
	}


	public async Task<bool> Register(string username, string password)
	{
		//try
		//{
		//	var tokenResponse = await _accountClient.RegisterAsync(new RegisterRequest
		//	{
		//		Login = username,
		//		Password = password
		//	});

		//	if (tokenResponse.ResultCase == LoginResponse.ResultOneofCase.Login)
		//	{
		//		var token = tokenResponse.Login.Token;

		//		await _localStorage.SetItemAsync("token", token);
		//		_authenticationStateProvider.MarkUserAsAuthenticated(token);

		//		return true;
		//	}
		//}
		//catch (Exception e)
		//{
		//}

		//return false;

		var tokenRespons = "1231453";
		_stateProvider.MarkAsAuthenticated(tokenRespons);

		return true;


	}
}
