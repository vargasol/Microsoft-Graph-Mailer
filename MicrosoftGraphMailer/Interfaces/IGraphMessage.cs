
namespace Vargasol.Graph.Mailer.Interfaces
{
	/// <summary>
	/// This interface is for creating the final message objects
	/// </summary>
	public interface IGraphMessage : IGraphMessageSavedToSent
	{
		/// <summary>
		/// Sets if the e-mail should be saved to the sender's mailbox Sent folder
		/// </summary>
		/// <returns>MessageBuilder object</returns>
		IGraphMessageSavedToSent SaveToSent();
	}
}
