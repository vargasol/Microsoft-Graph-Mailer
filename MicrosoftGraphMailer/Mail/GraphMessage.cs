

namespace Vargasol.Graph.Mailer.Mail
{
	/// <summary>
	/// This class contains the structure of Microsoft Graph 
	/// </summary>
	public class GraphMessage
	{
		/// <summary>
		/// Complete Message object to be sent via Microsoft Graph
		/// </summary>
		public Message Message { get; set; } = new Message();

		/// <summary>
		/// Set true if you want to save the outgoing message to the Sent folder of the mailbox of sender address
		/// </summary>
		public bool SaveToSentItems { get; set; } = false;
	}
}
