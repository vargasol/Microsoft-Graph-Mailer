using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Vargasol.Graph.Mailer.Mail
{
	/// <summary>
	/// This class stores information of attachments of e-mail
	/// </summary>
	public class FileAttachment
	{
		/// <summary>
		/// Type of attachment. This is a fixed value, cannot be changed.
		/// </summary>
		[JsonProperty("@odata.type")]
		public string Type { get; } = "#microsoft.graph.fileAttachment";

		/// <summary>
		/// Name of the attachment.
		/// </summary>
		public string Name { get; set; }

		/// <summary>
		/// Content type of the attachment. Default: text/plain, but can be anything following the right Media Type guide: http://www.iana.org/assignments/media-types/media-types.xhtml
		/// </summary>
		public string ContentType { get; set; } = "text/plain";

		/// <summary>
		/// Content of the attachment as byte array
		/// </summary>
		public byte[] ContentBytes { get; set; }

	}
}
