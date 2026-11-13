
namespace Vargasol.Graph.Mailer
{
	/// <summary>
	/// This class contains the options for Microsoft Graph mailer
	/// </summary>
	public record GraphMailerOptions
	{
		/// <summary>
		/// Guid of Entra Tenant in string format
		/// </summary>
		public string TenantID { get; set; }

		/// <summary>
		/// Guid of Entra Application ID in string format
		/// </summary>
		public string ApplicationID { get; set; }

		/// <summary>
		/// Secret of Entra Application if secret authentication is used
		/// </summary>
		public string ClientSecret { get; set; }

		/// <summary>
		/// Certificate thumbprint of Entra Application if certificate authentication is used
		/// </summary>
		public string CertificateThumbprint { get; set; }

		/// <summary>
		/// Certificate of Entra Application if certificate authentication is used
		/// </summary>
		public X509Certificate2 ClientCertificate { get; set; }

		/// <summary>
		/// Automatically configured to true if certificate authentication is used
		/// </summary>
		public bool IsCertificateAuthentication { get; set; } = false;

		/// <summary>
		/// Sender address which must be an existing e-mail address within the Entra Tenant
		/// </summary>
		public string SenderAddress { get; set; }
	}
}
