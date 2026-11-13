
namespace Vargasol.Graph.Mailer.Interfaces
{
	/// <summary>
	/// This interface is for creating the final mailer or optionbuilder objects
	/// </summary>
	public interface ICreateInstances
	{

		/// <summary>
		/// Create the AzureADOptionBuilder instance
		/// </summary>
		/// <returns>Finalized AzureADOptionBuilder instance</returns>
		GraphMailerOptionBuilder CreateAzureADOptionBuilder();
	}
}
