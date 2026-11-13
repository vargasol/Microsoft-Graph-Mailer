using System;
using System.Collections.Generic;
using System.Text;

namespace Vargasol.Graph.Mailer.Exceptions
{
	public class NoBodyAddedException : Exception
	{
		public NoBodyAddedException() : base("No body was added to the message. Please add a body before sending the message.")
		{
		}
	}
}
