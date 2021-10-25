using CljCodeChallenge.BurgerHunter.Core;
using CljCodeChallenge.BurgerHunter.Core.Abstractions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace CljCodeChallenge.BurgerHunter.Mocking
{
	public class MockBurgerImageCdn : IBurgerImageCdn
	{
		private const string DataPath = @"Data\Images.json";
		private IDictionary<Guid, List<Uri>> Cache;

		public MockBurgerImageCdn ()
		{
			Cache = JsonConvert.DeserializeObject<IDictionary<Guid, List<Uri>>>(File.ReadAllText(DataPath));
		}

		public IList<Uri> GetBurgerReviewImages(Guid reviewId)
		{
			if (Cache.TryGetValue(reviewId, out var result))
				return result;

			return new List<Uri>();
		}

		public Task<IList<Uri>> UploadImagesToCdn(Guid reviewId, IList<IImageSource> imageSources)
		{
			var rng = new Random();
			var uris = imageSources.Select(x => new Uri($"https://cdn.myimaginaryburgercompany.io/{x}")).ToList();

			if (Cache.TryGetValue(reviewId, out var existing))
				existing.AddRange(uris);
			else
				Cache.Add(reviewId, uris);

			return Task.FromResult<IList<Uri>>(uris);
		}

	}
}
