using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vargasol.Graph.Mailer
{
	/// <summary>
	/// This class helps to build up the GraphMailer object
	/// </summary>
	public class GraphMailerOptionBuilder : IWithClientCredential, ICreateInstances, IWithSenderAddress
	{
		private string _TenantID;
		private string _ApplicationID;
		private X509Certificate2 _Certificate;
		private string _ClientSecret;
		private string _SenderAddress;
		private bool _UserCertificateForAuth = false;

		/// <summary>
		/// This property contains the built configuration if you want to either save, or pass to a different instance of mail sender object.
		/// </summary>
		public GraphMailerOptions Options { get; private set; }

		/// <summary>
		/// Private construtctor of object
		/// </summary>
		/// <param name="tenantID">ID of Azure AD Tenant</param>
		/// <param name="applicationID">ID of Azure AD Application</param>
		private GraphMailerOptionBuilder(string tenantID, string applicationID)
		{
			this._TenantID = tenantID;
			this._ApplicationID = applicationID;
		}

		private void _CreateAzureADMailerOptions()
		{
			this.Options = new GraphMailerOptions()
			{
				ApplicationID = this._ApplicationID,
				ClientCertificate = this._Certificate,
				ClientSecret = this._ClientSecret,
				IsCertificateAuthentication = this._UserCertificateForAuth,
				SenderAddress = this._SenderAddress,
				TenantID = this._TenantID
			};
		}

		/// <inheritdoc/>
		public static IWithClientCredential Create(string AzureADTenantID, string AzureADApplicationID)
		{
			return new GraphMailerOptionBuilder(AzureADTenantID, AzureADApplicationID);
		}

		/// <inheritdoc/>
		public IWithSenderAddress WithClientCertificate(X509Certificate2 certificate)
		{
			this._UserCertificateForAuth = true;
			this._Certificate = certificate;
			return this;
		}
		/// <inheritdoc/>
		public IWithSenderAddress WithClientSecret(string clientSecret)
		{
			this._ClientSecret = clientSecret;
			return this;
		}
		
		
		/// <inheritdoc/>	
		public MicrosoftGraphMailer CreateAzureADMailerInstance()
		{
			this._CreateAzureADMailerOptions();
			return new MicrosoftGraphMailer(this.Options);
		}

		/// <inheritdoc/>
		public GraphMailerOptionBuilder CreateAzureADOptionBuilder()
		{
			this._CreateAzureADMailerOptions();
			return this;
		}

		/// <inheritdoc/>
		public ICreateInstances WithSenderAddress(string SenderAddress)
		{
			this._SenderAddress = SenderAddress;
			return this;
		}
	}
}
