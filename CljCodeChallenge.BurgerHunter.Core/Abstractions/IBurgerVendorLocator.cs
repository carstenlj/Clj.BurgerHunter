using CljCodeChallenge.BurgerHunter.Core.Model;
using System;
using System.Collections.Generic;

namespace CljCodeChallenge.BurgerHunter.Core
{
	/// <summary>
	/// The burger vendor locator service. It is responsible for:
	/// <list type="bullet">
	/// <item>Retriving information about speific burger vendors</item>
	/// <item>Locating vendors within a given geographical area</item>
	/// </list>
	/// </summary>
	public interface IBurgerVendorLocator
	{
		BurgerVendor GetVendor(Guid storeId);
		IList<BurgerVendor> LocateVendors(GeoCoords origin, int searchRadiusMeters, int? minRating, int? maxRating, int maxResults);
	}
}
