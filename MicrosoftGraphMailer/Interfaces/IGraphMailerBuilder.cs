using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace Vargasol.Graph.Mailer.Interfaces
{
	public interface IGraphMailerBuilder
	{
		IServiceCollection Services { get; }
		IHttpClientBuilder HttpClient { get; }
	}
}
