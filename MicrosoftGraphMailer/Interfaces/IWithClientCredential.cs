namespace Vargasol.Graph.Mailer.Interfaces
{
	/// <summary>
	/// This interface is for adding either the authentication secret or certificate
	/// </summary>
	public interface IWithClientCredential
	{
		/// <summary>
		/// Adds certificate for Entra Certificate authentication of the application
		/// </summary>
		/// <param name="certificate">X509Certificate2 object</param>
		/// <returns>IWithSenderAddress object for configuring the SenderAddress</returns>
		IWithSenderAddress WithClientCertificate(X509Certificate2 certificate);

		/// <summary>
		/// Search certificate for Entra authentication based on thumbprint
		/// </summary>
		/// <param name="thumbprint">Thumbprint of certificate</param>
		/// <returns>IWithSenderAddress object for configuring the SenderAddress</returns>
		IWithSenderAddress WithClientCertificateThumbprint(string thumbprint);

		/// <summary>
		/// Adds client secret for Entra authentication of the application
		/// </summary>
		/// <param name="clientSecret">Secret data as string</param>
		/// <returns>IWithSenderAddress object for configuring the SenderAddress</returns>
		IWithSenderAddress WithClientSecret(string clientSecret);
	}
}
