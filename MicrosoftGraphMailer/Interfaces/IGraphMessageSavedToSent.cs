
namespace Vargasol.Graph.Mailer.Interfaces
{
	/// <summary>
	/// This interface is for creating the final message objects
	/// </summary>
	public interface IGraphMessageSavedToSent
	{
		/// <summary>
		/// This method Generates the final Message object
		/// </summary>
		/// <returns>GraphMessage object which can be directly attach to MailSender</returns>
		GraphMessage GenerateMessage();
	}
}
