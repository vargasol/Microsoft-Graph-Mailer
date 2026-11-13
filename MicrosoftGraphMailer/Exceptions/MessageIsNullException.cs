using System;
using System.Collections.Generic;
using System.Text;

namespace Vargasol.Graph.Mailer.Exceptions
{
	public class MessageIsNullException : Exception
	{
		public MessageIsNullException() : base("The message is null. Please provide a valid message before sending.") { }
	}
}
