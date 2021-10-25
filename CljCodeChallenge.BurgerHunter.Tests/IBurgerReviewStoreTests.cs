using CljCodeChallenge.BurgerHunter.Core;
using CljCodeChallenge.BurgerHunter.Mocking.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;
using System;
using Xunit;

namespace CljCodeChallenge.BurgerHunter.Tests
{
	[Trait("Unit","IBurgerReviewStore")]
	public class IBurgerReviewStoreTests
	{
		[Fact(DisplayName ="Can get burger review metadata")]
		public void Test0001()
		{
			var burgerReviewStore = MockBurgerHunterHost.BuildTransientHost().Services.GetService<IBurgerReviewStore>();

			var reviewId = Guid.Parse("0a0c8b0c-6e7c-4fbf-9da1-850e2048a093");
			var review = burgerReviewStore.GetReviewMetadata(reviewId);

			Assert.Equal(reviewId, review.Id);
		}

		[Fact(DisplayName = "Implement more tests...", Skip = "Not implemented")]
		public void Test0002()
		{
			throw new NotImplementedException();
		}
	}
}
