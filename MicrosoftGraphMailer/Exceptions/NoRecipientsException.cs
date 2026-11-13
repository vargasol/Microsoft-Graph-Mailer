using System;
using System.Collections.Generic;
using System.Text;

namespace Vargasol.Graph.Mailer.Exceptions
{
	public class NoRecipientsException : Exception
	{
		public NoRecipientsException() : base("No recipients were added to the message. Please add at least one recipient before sending the message.")
		{
		}
	}
}
