using System;
using System.Text.Json.Serialization;

namespace CljCodeChallenge.BurgerHunter.Core.Model
{
	public class AccessToken
	{
		public string Value { get; }
		
		[JsonIgnore] public DateTimeOffset? Expiration { get; }

		public AccessToken(string value) : this(value, null) { }
		public AccessToken(string value, DateTimeOffset? expiration)
		{
			Value = value;
			Expiration = expiration;
		}

		public override string ToString() => Value;
	}
}
