using System;
using System.Collections.Generic;
using System.Text;

namespace Vargasol.Graph.Mailer.Interfaces
{
	public interface IGraphMailer
	{
		Task<(bool, string)> SendMailAsync(GraphMessage message, CancellationToken cancellationToken = default);
	}
}
