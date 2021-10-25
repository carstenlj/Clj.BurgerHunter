using CljCodeChallenge.BurgerHunter.Core;
using CljCodeChallenge.BurgerHunter.Core.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace CljCodeChallenge.BurgerHunter.Mocking
{
	public class MockBurgerReviewStore : IBurgerReviewStore
	{
		private const string DataPath = @"Data\Reviews.json";
		private IList<BurgerReview> Cache { get; }

		public MockBurgerReviewStore()
		{
			var json = File.ReadAllText(DataPath);
			Cache = JsonConvert.DeserializeObject<IList<BurgerReview>>(json);
		}

		public BurgerReview GetReviewMetadata(Guid reviewId)
		{
			return Cache.SingleOrDefault(x => x.Id == reviewId);
		}

		public Guid? SubmitReview(BurgerReviewMetadata review)
		{
			var reviewId = Guid.NewGuid();

			Cache.Add(new BurgerReview {
				Id = reviewId,
				VendorId = review.VendorId,
				Summary = review.Summary,
				BurgerName = review.BurgerName,
				Content = review.Content,
				ReviewerEmail= review.ReviewerEmail,
				Rating = review.Rating,
				Timestamp = review.Timestamp
			});

			return reviewId;
		}

		public BurgerRating GetAverageRatingForVendor(Guid vendorId)
		{
			throw new NotImplementedException();
		}
	}
}
