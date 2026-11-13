using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using System;
using System.Collections.Generic;
using System.Net.Sockets;
using System.Text;

namespace Vargasol.Graph.Mailer
{
	internal sealed class GraphMailerBuilder(IServiceCollection services, IHttpClientBuilder http) : IGraphMailerBuilder
	{
		public IServiceCollection Services { get; } = services;

		public IHttpClientBuilder HttpClient { get; } = http;

	}

	public static class GraphMailerServiceCollectionExtensions
	{
		internal const string HttpClientName = "Vargasol.Graph.Mailer";

		public static IGraphMailerBuilder AddGraphMailer(this IServiceCollection services, Action<GraphMailerOptions> configure)
		{
			services.AddOptions<GraphMailerOptions>().Configure(configure);
			return services.AddGraphMailerCore();
		}

		public static IGraphMailerBuilder AddGraphMailer(this
  IServiceCollection services, IConfiguration section)
		{
			services.AddOptions<GraphMailerOptions>().Bind(section);
			return services.AddGraphMailerCore();
		}

		public static IGraphMailerBuilder AddGraphMailer(this
  IServiceCollection services, GraphMailerOptions options)
		  => services.AddGraphMailer(o =>
		  {
			  o.TenantID = options.TenantID;
			  o.ApplicationID = options.ApplicationID;
			  o.ClientSecret = options.ClientSecret;
			  o.ClientCertificate = options.ClientCertificate;
			  o.IsCertificateAuthentication =
  options.IsCertificateAuthentication;
			  o.SenderAddress = options.SenderAddress;
		  });

		private static IGraphMailerBuilder AddGraphMailerCore(this
  IServiceCollection services)
		{
			services.AddOptions<GraphMailerOptions>()
				.Validate(o => !string.IsNullOrWhiteSpace(o.TenantID)
							&&
	!string.IsNullOrWhiteSpace(o.ApplicationID)
							&&
	!string.IsNullOrWhiteSpace(o.SenderAddress)
							&& (o.ClientCertificate is not null ||
	!string.IsNullOrWhiteSpace(o.ClientSecret)),
						  "GraphMailer: TenantID, ApplicationID, SenderAddress and a secret or certificate are required.")
				.ValidateOnStart();

			var http = services.AddHttpClient(HttpClientName,
				c => c.BaseAddress = new
	Uri("https://graph.microsoft.com/v1.0/"));

			services.TryAddSingleton<IGraphMailer, MicrosoftGraphMailer>();
			return new GraphMailerBuilder(services, http);
		}

		public static IGraphMailerBuilder ConfigureHttpClient(this
  IGraphMailerBuilder builder, Action<HttpClient> configure)
		{
			builder.HttpClient.ConfigureHttpClient(configure);
			return builder;
		}
	}
}
