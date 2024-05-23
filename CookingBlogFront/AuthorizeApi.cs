using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components.Authorization;

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
}
