using System.Collections.Generic;
using System.Linq;

namespace CljCodeChallenge.BurgerHunter.Core.Model
{
	public class ValidationResult
	{
		public IList<string> Errors {  get; } = new List<string>();
		public bool Success => Errors == null || !Errors.Any();
	}
}
