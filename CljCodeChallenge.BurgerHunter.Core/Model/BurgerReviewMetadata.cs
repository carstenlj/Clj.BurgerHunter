using System;

namespace CljCodeChallenge.BurgerHunter.Core.Model
{
	public class BurgerReviewMetadata
	{
		public string BurgerName { get; set; }
		public string Summary { get; set; }
		public string Content { get; set; }
		public DateTimeOffset Timestamp { get; set; }
		public BurgerRating Rating { get; set; }
		public string ReviewerEmail { get; set; }
		public Guid VendorId { get; set; }
	}
}
