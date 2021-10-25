using CljCodeChallenge.BurgerHunter.Core;
using CljCodeChallenge.BurgerHunter.Core.Abstractions;
using CljCodeChallenge.BurgerHunter.Core.Model;
using CljCodeChallenge.BurgerHunter.Mocking;
using CljCodeChallenge.BurgerHunter.Mocking.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace CljCodeChallenge.BurgerHunter.Tests
{
	[Trait("End-to-end", "BurgerHunterProcessor")]
	public class BurgerHunterProcessorTests
	{
		[Fact(DisplayName = "Success sceario #01")]
		public void Test0001()
		{
			// Initialize the service host
			var burgerHunterHost = MockBurgerHunterHost.BuildTransientHost();
			var processor = burgerHunterHost.Services.GetService<BurgerHunterProcessor>();

			// Step 1: Log-in the user
			var accessToken = processor.UserLogin("test@emailprovider.io", "password123");

			// Assert an access token was retrieve
			Assert.NotNull(accessToken);

			// Step 2: Create a review
			var reviewSubmission = new BurgerReviewSubmission
			{
				Summary = "Everything was nice but the taste",
				Content = "The burger looked really nice so my expectations were high, but the flavor did not live up to the promise :(",
				Rating = new BurgerRating
				{
					Taste = new Rating(1),
					Texture = new Rating(5),
					Presentation = new Rating(5),
				},
				BurgerName = "CalorieCarnival3000",
				Timestamp = DateTimeOffset.UtcNow,
				ReviewerEmail = "test@emailprovider.io",
				VendorId = Guid.Parse("fa5b2d0f-db98-4f41-82aa-c851d391c772"),
				ImageSources = new List<IImageSource> { 
					new MockImageSource("burgerimg12312.jpg")  
				}
			};

			// Step 3:  Submit the review
			var submissionResult = processor.SubmitReview(reviewSubmission, accessToken);

			// Assert that the submission was a success
			Assert.True(submissionResult.Success);

			// Step 4: Lookup the review to verify
			var review = processor.GetReview(submissionResult.ReviewId);

			// Assert that the review stored matches was what submitted
			Assert.Equal(submissionResult.ReviewId, review.Id);
			Assert.Equal("test@emailprovider.io", review.ReviewerEmail);
			Assert.Equal(Guid.Parse("fa5b2d0f-db98-4f41-82aa-c851d391c772"), review.VendorId);
			Assert.EndsWith("burgerimg12312.jpg", review.Images.Single().ToString());
		}

		[Fact(DisplayName = "Implement more end-to-end scenarios...", Skip = "Not implemented")]
		public void Test0002()
		{
			throw new NotImplementedException();
		}
	}
}
