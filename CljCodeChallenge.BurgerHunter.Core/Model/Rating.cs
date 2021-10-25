using System;

namespace CljCodeChallenge.BurgerHunter.Core.Model
{
	public struct Rating
	{
		public double Value { get; }

		public Rating(double value)
		{
			if (value <= 0 || value > 5)
				throw new ArgumentOutOfRangeException($"{value} is not a valid value for {nameof(value)}: The value must be a positive non-zero number <= 5");

			Value = value;
		}

		public static implicit operator double(Rating rating) => rating.Value;
		public static implicit operator Rating(double rating) => new Rating(rating);
	}
}
