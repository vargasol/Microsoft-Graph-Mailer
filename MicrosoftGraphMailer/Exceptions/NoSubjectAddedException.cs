using System;
using System.Collections.Generic;
using System.Text;

namespace Vargasol.Graph.Mailer.Exceptions
{
	public class NoSubjectAddedException : Exception
	{
		public NoSubjectAddedException() : base("No subject was added to the message. Please add a subject before sending the message.")
		{
		}
	}
}
