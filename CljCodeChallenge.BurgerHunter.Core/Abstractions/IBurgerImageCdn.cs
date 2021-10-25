using CljCodeChallenge.BurgerHunter.Core.Abstractions;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CljCodeChallenge.BurgerHunter.Core
{
	/// <summary>
	/// The Burger Image CDN service. It is responsible for: 
	/// <list type="bullet">
	/// <item>Pusing <see cref="IImageSource"/>s to the image cdn</item>
	/// <item>Listing all image urls in the CDN associated to a specific <see cref="BurgerReview"/></item>
	/// </list>
	/// </summary>
	public interface IBurgerImageCdn
	{
		Task<IList<Uri>> UploadImagesToCdn(Guid reviewId, IList<IImageSource> imageSources);
		IList<Uri> GetBurgerReviewImages(Guid reviewId);
	}
}
