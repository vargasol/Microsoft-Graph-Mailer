using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vargasol.Graph.Mailer.Mail
{
	/// <summary>
	/// This class contains the body of e-mail message
	/// </summary>
	public class MessageBody
	{
		/// <summary>
		/// Content type of the attachment. Possible values: Text = text e-mail message, Html = html e-mail message
		/// </summary>
		public string ContentType { get; set; } = "Text";

		/// <summary>
		/// Contains the body of e-mail which is fitting to content type configured in ContentType property.
		/// </summary>
		public string Content { get; set; }
	}
}
