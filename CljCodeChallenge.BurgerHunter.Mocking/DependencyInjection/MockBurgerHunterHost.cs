using CljCodeChallenge.BurgerHunter.Core;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace CljCodeChallenge.BurgerHunter.Mocking.DependencyInjection
{
	public static class MockBurgerHunterHost
	{
		public enum Type
		{
			Singleton,
			Transient
		}

		public static IHost BuildSingletonHost()
		{
			return new HostBuilder().ConfigureServices(services => services.AddBurgerHunterMock(Type.Singleton)).Build();
		}

		public static IHost BuildTransientHost()
		{
			return new HostBuilder().ConfigureServices(services => services.AddBurgerHunterMock(Type.Transient)).Build();

		}

		public static IServiceCollection AddBurgerHunterMock(this IServiceCollection services, Type hostType = Type.Singleton)
		{
			return services
				.AddSingletonOrTransient<BurgerHunterProcessor, BurgerHunterProcessor>(hostType)
				.AddSingletonOrTransient<IBurgerImageCdn, MockBurgerImageCdn>(hostType)
				.AddSingletonOrTransient<IBurgerReviewStore, MockBurgerReviewStore>(hostType)
				.AddSingletonOrTransient<IBurgerVendorLocator, MockBurgerVendorLocator>(hostType)
				.AddSingletonOrTransient<IUserAuthenticator, MockUserAuthenticator>(hostType);
		}

		private static IServiceCollection AddSingletonOrTransient<TService, TImplementation>(this IServiceCollection services, Type type = Type.Singleton) where TService : class where TImplementation : class, TService
		{
			if (type == Type.Singleton)
				return services.AddSingleton<TService, TImplementation>();
			else
				return services.AddTransient<TService, TImplementation>();
		}
	}
}
