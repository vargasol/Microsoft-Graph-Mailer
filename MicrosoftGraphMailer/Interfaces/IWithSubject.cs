using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vargasol.Graph.Mailer.Interfaces
{
	/// <summary>
	/// This interface forces to set the Subject of the e-mail.
	/// </summary>
	public interface IWithSubject
	{
		/// <summary>
		/// Subject of the e-mail message
		/// </summary>
		/// <param name="subject">Subject content as string</param>
		/// <returns>MessageBuilder for Body setup</returns>
		IWithBodyType Subject(string subject);
	}
}
