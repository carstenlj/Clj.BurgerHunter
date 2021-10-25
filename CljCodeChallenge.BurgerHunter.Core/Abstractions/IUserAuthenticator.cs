using CljCodeChallenge.BurgerHunter.Core.Model;

namespace CljCodeChallenge.BurgerHunter.Core
{
	/// <summary>
	/// The user authentication service. It is responsible for:
	/// <list type="bullet">
	/// <item>Issuing access tokens to users (required to perform user specific actions)</item>
	/// <item>Authenticating previously issued access tokens</item>
	/// </list>
	/// </summary>
	public interface IUserAuthenticator
	{
		public AccessToken IssueAccessToken(string email, string password);
		public AuthenticateResult AuthenticateAccessToken(string email, AccessToken accessToken);
	}
}