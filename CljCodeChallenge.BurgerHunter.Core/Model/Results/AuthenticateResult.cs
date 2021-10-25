namespace CljCodeChallenge.BurgerHunter.Core.Model
{
	public class AuthenticateResult
	{
		public bool Success { get; }

		private AuthenticateResult(bool success)
		{
			Success = success;
		}

		public static AuthenticateResult Successful() => new AuthenticateResult(true);
		public static AuthenticateResult Failure() => new AuthenticateResult(false);
	}
}
