using CljCodeChallenge.BurgerHunter.Core.Abstractions;
using System.IO;

namespace CljCodeChallenge.BurgerHunter.Mocking
{
	public class MockImageSource : IImageSource
	{
		public string Name { get; set; }

		public MockImageSource(string name)
		{
			Name = name;
		}

		public Stream GetStream()
		{
			return new MemoryStream(0);
		}

		public override string ToString()
		{
			return Name;
		}
	}
}
