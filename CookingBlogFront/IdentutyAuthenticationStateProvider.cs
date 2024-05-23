using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components.Authorization;
using System.Security.Claims;

public class IdentutyAuthenticationStateProvider : AuthenticationStateProvider
{
	private readonly ILocalStorageService _localStorageService;
	public IdentutyAuthenticationStateProvider(ILocalStorageService localStorage)
	{
		_localStorageService = localStorage;
	}


	public async override Task<AuthenticationState> GetAuthenticationStateAsync()
    {
		try
		{

			var token = await _localStorageService.GetItemAsStringAsync("token");
			if (!string.IsNullOrEmpty(token))
			{

				MarkAsAuthenticated(token);

				return await this.GetAuthenticationStateAsync();
			}
		}
		catch (Exception ex) { }


		return new AuthenticationState(new System.Security.Claims.ClaimsPrincipal(new ClaimsIdentity()));

    }

	internal void MarkAsAuthenticated(string token)
	{
		var authUser = new ClaimsPrincipal(new  ClaimsIdentity(
			new List<Claim>()
			{
				new Claim(ClaimTypes.Name, "admin")
			}, "jwt"));
		var authState = Task.FromResult(new AuthenticationState(authUser));

		NotifyAuthenticationStateChanged(authState);
	}

    public async Task MarkLogouted()
    {
        await _localStorageService.RemoveItemAsync("token");
        NotifyAuthenticationStateChanged(Task.FromResult(Empty()));
    }

    private static AuthenticationState Empty()
            => new(new ClaimsPrincipal(new ClaimsIdentity()));
}
