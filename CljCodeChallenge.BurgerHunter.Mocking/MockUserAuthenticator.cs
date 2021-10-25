using CljCodeChallenge.BurgerHunter.Core;
using CljCodeChallenge.BurgerHunter.Core.Model;
using System;
using System.Collections.Generic;

namespace CljCodeChallenge.BurgerHunter.Mocking
{
	public class MockUserAuthenticator : IUserAuthenticator
	{
		private IDictionary<string, AccessToken> AccessTokens { get; }
		private Random Random { get; }

		public MockUserAuthenticator()
		{
			Random = new Random();
			AccessTokens = new Dictionary<string, AccessToken>();
		}

		public AccessToken IssueAccessToken(string email, string password)
		{
			var token = new AccessToken(Random.Next(1000, 9999).ToString(), DateTimeOffset.UtcNow.AddMinutes(30));
			AccessTokens.Add(email, token);

			return token;
		}

		public AuthenticateResult AuthenticateAccessToken(string email, AccessToken accessToken)
		{
			if (AccessTokens.TryGetValue(email, out var token))
			{
				if (token.Value.Equals(accessToken.Value) && token.Expiration > DateTimeOffset.UtcNow)
					return AuthenticateResult.Successful();
			}

			return AuthenticateResult.Failure();
		}


	}
}
