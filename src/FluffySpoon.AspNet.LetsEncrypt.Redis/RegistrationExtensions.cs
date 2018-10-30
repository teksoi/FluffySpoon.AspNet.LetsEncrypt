﻿using FluffySpoon.AspNet.LetsEncrypt.Redis;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Threading.Tasks;

namespace FluffySpoon.AspNet.LetsEncrypt
{
	public static class RegistrationExtensions
	{
		public static void AddFluffySpoonLetsEncryptDistributedCacheCertificatePersistence(
			this IServiceCollection services,
			TimeSpan expiry)
		{
			services.AddFluffySpoonLetsEncryptCertificatePersistence(
				(provider) => new DistributedCachePersistenceStrategy(
					provider.GetRequiredService<IDistributedCache>(), expiry));
		}

		public static void AddFluffySpoonLetsEncryptDistributedCacheChallengePersistence(
			this IServiceCollection services,
			TimeSpan expiry)
		{
			services.AddFluffySpoonLetsEncryptChallengePersistence(
				(provider) => new DistributedCachePersistenceStrategy(
					provider.GetRequiredService<IDistributedCache>(), expiry));
		}
	}
}
