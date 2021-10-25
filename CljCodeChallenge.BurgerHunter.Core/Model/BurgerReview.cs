using System;
using System.Collections.Generic;

namespace CljCodeChallenge.BurgerHunter.Core.Model
{
	public class BurgerReview : BurgerReviewMetadata
	{
		public Guid Id { get; set; }
		public IList<Uri> Images { get; set; }

		public BurgerReview WithCdnImages(IList<Uri> imageUrls)
		{
			Images = imageUrls;
			return this;
		}
	}
}
