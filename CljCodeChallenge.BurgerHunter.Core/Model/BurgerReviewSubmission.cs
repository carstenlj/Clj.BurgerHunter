using CljCodeChallenge.BurgerHunter.Core.Abstractions;
using System;
using System.Collections.Generic;

namespace CljCodeChallenge.BurgerHunter.Core.Model
{
	public class BurgerReviewSubmission : BurgerReviewMetadata
	{
		public IList<IImageSource> ImageSources { get; set; }
	}
}
