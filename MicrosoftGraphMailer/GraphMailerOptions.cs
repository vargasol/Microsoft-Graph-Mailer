
namespace Vargasol.Graph.Mailer
{
	/// <summary>
	/// This class contains the options for Microsoft Graph mailer
	/// </summary>
	public record GraphMailerOptions
	{
		/// <summary>
		/// Guid of Azure AD Tenant in string format
		/// </summary>
		public string TenantID { get; init; }

		/// <summary>
		/// Guid of Azure AD Application ID in string format
		/// </summary>
		public string ApplicationID { get; init; }

		/// <summary>
		/// Secret of Azure AD Application if secret authentication is used
		/// </summary>
		public string ClientSecret { get; init; }

		/// <summary>
		/// Certificate of Azure AD Application if certificate authentication is used
		/// </summary>
		public X509Certificate2 ClientCertificate { get; init; }

		/// <summary>
		/// Automatically configured to true if certificate authentication is used
		/// </summary>
		public bool IsCertificateAuthentication { get; init; } = false;

		/// <summary>
		/// Sender address which must be an existing e-mail address within the Azure AD Tenant
		/// </summary>
		public string SenderAddress { get; init; }
	}
}
