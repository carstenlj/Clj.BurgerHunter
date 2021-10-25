using CljCodeChallenge.BurgerHunter.Core.Model;
using System.Linq;

namespace CljCodeChallenge.BurgerHunter.Core.Validation
{
	internal static class ValidationResultExtensions
	{
		public static ValidationResult WithConditionalError(this ValidationResult result, string error, bool condition)
		{
			if (condition)
				result.Errors.Add(error);

			return result;
		}
	}
}
