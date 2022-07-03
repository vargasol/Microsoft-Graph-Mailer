namespace Vargasol.Graph.Mailer.Interfaces
{
	/// <summary>
	/// This interface is for adding either the authentication secret or certificate
	/// </summary>
	public interface IWithClientCredential
	{
		/// <summary>
		/// Adds certificate for Azure AD Certificate authentication of the application
		/// </summary>
		/// <param name="certificate">X509Certificate2 object</param>
		/// <returns>IWithSenderAddress object for configuring the SenderAddress</returns>
		IWithSenderAddress WithClientCertificate(X509Certificate2 certificate);

		/// <summary>
		/// Adds client secret for Azure AD secret authentication of the application
		/// </summary>
		/// <param name="clientSecret">Secret data as string</param>
		/// <returns>IWithSenderAddress object for configuring the SenderAddress</returns>
		IWithSenderAddress WithClientSecret(string clientSecret);
	}
}
