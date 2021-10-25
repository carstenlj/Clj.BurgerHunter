using System.IO;

namespace CljCodeChallenge.BurgerHunter.Core.Abstractions
{
	/// <summary>
	/// Represents an image that has a source which can be obstained through a stream.
	/// </summary>
	public interface IImageSource
	{
		Stream GetStream();
	}
}
