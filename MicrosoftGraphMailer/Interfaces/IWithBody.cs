

namespace Vargasol.Graph.Mailer.Interfaces
{
	/// <summary>
	/// Sets body details
	/// </summary>
	public interface IWithBody
	{
		/// <summary>
		/// Add one recipient to the current recipient list
		/// </summary>
		/// <param name="mailAddress">E-mail address as string</param>
		/// <returns>MessageBuilder object</returns>
		IWithBody AddRecipient(string mailAddress);

		/// <summary>
		/// Add one recipient to the current recipient list
		/// </summary>
		/// <param name="mailAddress">E-mail address as EmAddress object</param>
		/// <returns>MessageBuilder object</returns>
		IWithBody AddRecipient(EmAddress mailAddress);

		/// <summary>
		/// Add more recipients to the current recipient list
		/// </summary>
		/// <param name="mailAddresses">E-mail addresses as string collection</param>
		/// <returns>MessageBuilder object</returns>
		IWithBody AddRecipients(IEnumerable<string> mailAddresses);

		/// <summary>
		/// Add more recipients to the current recipient list
		/// </summary>
		/// <param name="mailAddresses">E-mail addresses as EmAddress collection</param>
		/// <returns>MessageBuilder object</returns>
		IWithBody AddRecipients(IEnumerable<EmAddress> mailAddresses);

		/// <summary>
		/// Add one CC recipient to the current CC recipient list
		/// </summary>
		/// <param name="mailAddress">E-mail address as string object</param>
		/// <returns>MessageBuilder object</returns>
		IWithBody AddCCRecipient(string mailAddress);

		/// <summary>
		/// Add one CCrecipient to the current CC recipient list
		/// </summary>
		/// <param name="mailAddress">E-mail address as EmAddress object</param>
		/// <returns>MessageBuilder object</returns>
		IWithBody AddCCRecipient(EmAddress mailAddress);

		/// <summary>
		/// Add more CC recipients to the current CC recipient list
		/// </summary>
		/// <param name="mailAddresses">E-mail addresses as string collection</param>
		/// <returns>MessageBuilder object</returns>
		IWithBody AddCCRecipients(IEnumerable<string> mailAddresses);

		/// <summary>
		/// Add more CC recipients to the current CC recipient list
		/// </summary>
		/// <param name="mailAddresses">E-mail addresses as EmAddress collection</param>
		/// <returns>MessageBuilder object</returns>
		IWithBody AddCCRecipients(IEnumerable<EmAddress> mailAddresses);

		/// <summary>
		/// Add one BCC recipient to the current BCC recipient list
		/// </summary>
		/// <param name="mailAddress">E-mail address as string object</param>
		/// <returns>MessageBuilder object</returns>
		IWithBody AddBCCRecipient(string mailAddress);

		/// <summary>
		/// Add one BCC recipient to the current recipient list
		/// </summary>
		/// <param name="mailAddress">E-mail address as EmAddress object</param>
		/// <returns>MessageBuilder object</returns>
		IWithBody AddBCCRecipient(EmAddress mailAddress);

		/// <summary>
		/// Add more BCC recipients to the current BCC recipient list
		/// </summary>
		/// <param name="mailAddresses">E-mail addresses as string collection</param>
		/// <returns>MessageBuilder object</returns>
		IWithBody AddBCCRecipients(IEnumerable<string> mailAddresses);

		/// <summary>
		/// Add more BCC recipients to the current BCC recipient list
		/// </summary>
		/// <param name="mailAddresses">E-mail addresses as EmAddress collection</param>
		/// <returns>MessageBuilder object</returns>
		IWithBody AddBCCRecipients(IEnumerable<EmAddress> mailAddresses);

		/// <summary>
		/// Add one ReplyTo addresses to the current ReplyTo list
		/// </summary>
		/// <param name="mailAddress">E-mail address as EmAddress</param>
		/// <returns>MessageBuilder object</returns>
		IWithBody AddReplyTo(EmAddress mailAddress);

		/// <summary>
		/// Add more ReplyTo addresses to the current ReplyTo list
		/// </summary>
		/// <param name="mailAddresses">E-mail addresses as EmAddress collection</param>
		/// <returns>MessageBuilder object</returns>
		IWithBody AddReplyTo(IEnumerable<EmAddress> mailAddresses);

		/// <summary>
		/// Add one ReplyTo addresses to the current ReplyTo list
		/// </summary>
		/// <param name="mailAddress">E-mail address as string</param>
		/// <returns>MessageBuilder object</returns>
		IWithBody AddReplyTo(string mailAddress);

		/// <summary>
		/// Add more ReplyTo addresses to the current ReplyTo list
		/// </summary>
		/// <param name="mailAddresses">E-mail addresses as string collection</param>
		/// <returns>MessageBuilder object</returns>
		IWithBody AddReplyTo(IEnumerable<string> mailAddresses);

		/// <summary>
		/// Adds body to the Message object
		/// </summary>
		/// <param name="Body">Body content as string</param>
		/// <returns>MessageBuilder object</returns>
		IGraphMessage AddBody(string Body);

		/// <summary>
		/// Attaches one file attachment to the message.
		/// </summary>
		/// <param name="attachment">FileAttachment object</param>
		/// <returns>MessageBuilder object</returns>
		IWithBody AddAttachment(FileAttachment attachment);

		/// <summary>
		/// Attaches more file attachments to the message.
		/// </summary>
		/// <param name="attachments">FileAttachment object</param>
		/// <returns>MessageBuilder object</returns>
		IWithBody AddAttachments(IEnumerable<FileAttachment> attachments);

		/// <summary>
		/// This method sets to request Delivery Receipt
		/// </summary>
		/// <returns>MessageBuilder object</returns>
		IWithBody RequestDeliveryReceipt();

		/// <summary>
		/// This method sets to request Read Receipt
		/// </summary>
		/// <returns>MessageBuilder object</returns>
		IWithBody RequestReadReceipt();
	}
}
