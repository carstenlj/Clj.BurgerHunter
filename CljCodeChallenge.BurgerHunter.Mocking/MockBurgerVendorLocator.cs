using CljCodeChallenge.BurgerHunter.Core;
using CljCodeChallenge.BurgerHunter.Core.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace CljCodeChallenge.BurgerHunter.Mocking
{
	public class MockBurgerVendorLocator : IBurgerVendorLocator
	{
		private const string DataPath = @"Data\Vendors.json";
		private IList<BurgerVendor> Cache;

		public MockBurgerVendorLocator()
		{
			Cache = JsonConvert.DeserializeObject<IList<BurgerVendor>>(File.ReadAllText(DataPath));
		}

		public BurgerVendor GetVendor(Guid storeId)
		{
			return Cache.SingleOrDefault(x => x.Id == storeId);
		}

		public IList<BurgerVendor> LocateVendors(GeoCoords origin, int searchRadiusMeters, int? minRating, int? maxRating, int maxResults)
		{
			return Cache.Where(x => x.Name.Contains("omni", StringComparison.OrdinalIgnoreCase)).ToList();
		}
	}
}
