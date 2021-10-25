using System;

namespace CljCodeChallenge.BurgerHunter.Core.Model
{
	public class BurgerVendor
	{
		public Guid Id { get; set; }
		public string Name { get; set; }
		public string Description {  get; set; }
		public string Address { get; set; }
		public GeoCoords Location { get; set; }
		public BurgerRating AverageBurgerRating { get; set; }
	}
}
