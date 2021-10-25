using CljCodeChallenge.BurgerHunter.Core.Model;
using System;

namespace CljCodeChallenge.BurgerHunter.Core
{
	/// <summary>
	/// The BurgerReview storage service. It is responsible for:
	/// <list type="bullet">
	/// <item>Persisting <see cref="BurgerReviewSubmission"/>s</item>
	/// <item>Retrieving <see cref="BurgerReview"/>s</item>
	/// </list>
	/// </summary>
	public interface IBurgerReviewStore
	{
		Guid? SubmitReview(BurgerReviewMetadata review);
		BurgerReview GetReviewMetadata(Guid reviewId);
		BurgerRating GetAverageRatingForVendor(Guid vendorId);
	}
}
