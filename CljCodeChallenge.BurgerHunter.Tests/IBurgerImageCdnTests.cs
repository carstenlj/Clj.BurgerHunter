using CljCodeChallenge.BurgerHunter.Core;
using CljCodeChallenge.BurgerHunter.Core.Abstractions;
using CljCodeChallenge.BurgerHunter.Mocking;
using CljCodeChallenge.BurgerHunter.Mocking.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using Xunit;

namespace CljCodeChallenge.BurgerHunter.Tests
{
	[Trait("Unit","IBurgerImageCdn")]
	public class IBurgerImageCdnTests
	{
		[Fact(DisplayName ="Can persist and retrieve image CDN urls")]
		public void Test0001()
		{
			var burgerImageCdn = MockBurgerHunterHost.BuildTransientHost().Services.GetService<IBurgerImageCdn>();
			var reviewId = Guid.NewGuid();

			// Upload two images to the CDN
			burgerImageCdn.UploadImagesToCdn(reviewId,new List<IImageSource> { new MockImageSource("A"), new MockImageSource("B") } );
			var result = burgerImageCdn.GetBurgerReviewImages(reviewId);

			// Assert that the review has the images associated
			Assert.Equal(2, result.Count);
			Assert.EndsWith("/A", result[0].ToString());
			Assert.EndsWith("/B", result[1].ToString()); 
		}

		[Fact(DisplayName = "Implement more tests...", Skip = "Not implemented")]
		public void Test0002()
		{
			throw new NotImplementedException();
		}
	}
}
