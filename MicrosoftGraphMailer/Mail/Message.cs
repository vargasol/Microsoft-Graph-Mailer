
namespace Vargasol.Graph.Mailer.Mail
{
	/// <summary>
	/// This class contains the details of the Graph mail
	/// </summary>
	public class Message
	{

		/// <summary>
		/// Subject of the e-mail message
		/// </summary>
		public string Subject { get; set; }

		/// <summary>
		/// Sender address of the e-mail message
		/// </summary>
		public EmAddress Sender { get; set; }

		/// <summary>
		/// From address of the e-mail message
		/// </summary>
		public EmAddress From { get; set; }

		/// <summary>
		/// Body of the e-mail message
		/// </summary>
		public MessageBody Body { get; set; } = new MessageBody();

		/// <summary>
		/// Recipient(s) of the e-mail message
		/// </summary>
		public IList<EmAddress> ToRecipients { get; set; } = new List<EmAddress>();

		/// <summary>
		/// CC recipients of the e-mail message
		/// </summary>
		public IList<EmAddress> CCRecipients { get; set; } = new List<EmAddress>();

		/// <summary>
		/// BCC recipients of the e-mail message
		/// </summary>
		public IList<EmAddress> BCCRecipients { get; set; } = new List<EmAddress>();

		/// <summary>
		/// Attachments of the e-mail message
		/// </summary>
		public IList<FileAttachment> Attachments { get; set; } = new List<FileAttachment>();

		/// <summary>
		/// Setting the importance of e-mail. Possible values are in MailImportance class or use High, Normal, Low values as string
		/// </summary>
		public string Importance { get; set; } = MailImportance.Normal;

		/// <summary>
		/// Set true if you would like to receive a delivery receipt
		/// </summary>
		public bool IsDeliveryReceiptRequested { get; set; }

		/// <summary>
		/// Set true if you would like to receive a read receipt
		/// </summary>
		public bool IsReadReceiptRequested { get; set; }

		/// <summary>
		/// Sets the value of replyTo property. You can add one or more data to replyto
		/// </summary>
		public IList<EmAddress> ReplyTo { get; set; } = new List<EmAddress>();
	}
}
