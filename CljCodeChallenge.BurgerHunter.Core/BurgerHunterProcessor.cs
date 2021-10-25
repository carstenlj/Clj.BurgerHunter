using CljCodeChallenge.BurgerHunter.Core.Model;
using CljCodeChallenge.BurgerHunter.Core.Validation;
using System;

namespace CljCodeChallenge.BurgerHunter.Core
{
	public class BurgerHunterProcessor
	{
		protected IBurgerReviewStore BurgerReviewStore { get; }
		protected IBurgerImageCdn BurgerImageCdn { get; }
		protected IBurgerVendorLocator BurgerStoreLocator { get; }
		protected IUserAuthenticator UserAuthenticator { get; }

		protected BurgerReviewValidator BurgerReviewValidator { get; }

		public BurgerHunterProcessor(IBurgerReviewStore burgerReviewStore, IBurgerImageCdn burgerImageStore, IBurgerVendorLocator burgerStoreLocator, IUserAuthenticator userAuthenticator)
		{
			BurgerReviewStore = burgerReviewStore;
			BurgerImageCdn = burgerImageStore;
			BurgerStoreLocator = burgerStoreLocator;
			UserAuthenticator = userAuthenticator;
			BurgerReviewValidator = new BurgerReviewValidator();
		}

		public AccessToken UserLogin(string email, string securityToken)
		{
			return UserAuthenticator.IssueAccessToken(email, securityToken);
		}

		public SubmitReviewResult SubmitReview(BurgerReviewSubmission review, AccessToken accessToken)
		{
			// Authenticate the user
			var authenticateResult = UserAuthenticator.AuthenticateAccessToken(review.ReviewerEmail, accessToken);
			if (authenticateResult == null || !authenticateResult.Success)
				return SubmitReviewResult.AuthenticationFailed();

			// Validate the review input
			var validationResult = BurgerReviewValidator.Validate(review);
			if (!validationResult.Success)
				return SubmitReviewResult.FailureInvalidReview(validationResult);

			// Persist the review
			var reviewId = BurgerReviewStore.SubmitReview(review);
			if (reviewId == null || reviewId == Guid.Empty)
				return SubmitReviewResult.UnknownInternalError();

			// Start uploading images to the CDN async
			BurgerImageCdn.UploadImagesToCdn(reviewId.Value, review.ImageSources);

			// Indicate success
			return SubmitReviewResult.Successful(reviewId.Value);
		}

		public BurgerReview GetReview(Guid reviewId)
		{
			if (reviewId == Guid.Empty)
				throw new ArgumentException("Must supply a reviewId");

			// Get the burger review base data
			var burgerReview = BurgerReviewStore.GetReviewMetadata(reviewId);
			var burgerImageUrls = BurgerImageCdn.GetBurgerReviewImages(burgerReview.Id);

			// Create and return the full Review object.
			return burgerReview.WithCdnImages(burgerImageUrls);
		}
	}
}
