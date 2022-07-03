
namespace Vargasol.Graph.Mailer.Interfaces
{
	/// <summary>
	/// This interface is for adding the sender address to the mailer object class
	/// </summary>
	public interface IWithSenderAddress
	{
		/// <summary>
		/// Configures the sender address for the mailer instance
		/// </summary>
		/// <param name="SenderAddress">Sender address as string parameter</param>
		/// <returns>ICreateInstances instances to generate the final objects</returns>
		ICreateInstances WithSenderAddress(string SenderAddress);
	}
}
