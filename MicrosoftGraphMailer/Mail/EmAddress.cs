using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vargasol.Graph.Mailer.Mail
{
	/// <summary>
	/// This class stores and E-mail address object property
	/// </summary>
	public class EmAddress
	{

		/// <summary>
		/// E-mail address property
		/// </summary>
		public MailAddress EmailAddress { get; set; } = new MailAddress();
	}
}
