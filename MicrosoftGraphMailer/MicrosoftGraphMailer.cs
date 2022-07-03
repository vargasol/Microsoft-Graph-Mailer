using Microsoft.Identity.Client;
using System.Security.Cryptography.X509Certificates;

namespace Vargasol.Graph.Mailer
{
	/// <summary>
	/// E-mail sender class which uses Microsoft Graph service for sending an e-mail message on behalf of any existing company e-mail address which is registered within the Exchange Online of the tenant. In order to use it, at least one Exchange Online license must be actively assigned to a user within the tenant.
	/// </summary>
	public class MicrosoftGraphMailer
	{
		private GraphMailerOptions _Options;
		const string GraphURL = "https://graph.microsoft.com/v1.0";
		readonly string[] AuthScope = new string[] { "https://graph.microsoft.com/.default" };
		string _accessToken;
		IConfidentialClientApplication _confidentialClientApplication;
		GraphMessage _message;


		/// <summary>
		/// Constructor of the Microsoft Graph Mailer
		/// </summary>
		/// <param name="options">Object which contains the options</param>
		public MicrosoftGraphMailer(GraphMailerOptions options)
		{
			this._Options = options;
			if (options.IsCertificateAuthentication)
			{
				_InitializeWithCertificate();
			}
			else
			{
				_InitializeWithSecret();
			}
			_RequestAADToken();
		}

		private void _InitializeWithSecret()
		{
			_confidentialClientApplication = ConfidentialClientApplicationBuilder.Create(this._Options.ApplicationID).WithTenantId(this._Options.TenantID).WithClientSecret(this._Options.ClientSecret).Build();
			_RequestAADToken();

		}

		private void _InitializeWithCertificate()
		{
			_confidentialClientApplication = ConfidentialClientApplicationBuilder.Create(this._Options.ApplicationID).WithTenantId(this._Options.TenantID).WithCertificate(this._Options.ClientCertificate).Build();
			_RequestAADToken();

		}

		private void _RequestAADToken()
		{
			var tokenBuilder = _confidentialClientApplication.AcquireTokenForClient(AuthScope).ExecuteAsync().Result;
			_accessToken = tokenBuilder.AccessToken;
		}

		private HttpRequestMessage _CreateHttpRequest()
		{

			string graphURL = $"{GraphURL}/users/{this._Options.SenderAddress}/sendMail";
			HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Post, graphURL);
			request.Headers.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", _accessToken);
			string content = JsonConvert.SerializeObject(this._message);
			request.Content = new StringContent(content);
			request.Content.Headers.ContentType.MediaType = "application/json";
			return request;
		}

		/// <summary>
		/// Sending the e-mail message added in the parameter
		/// </summary>
		/// <param name="message">GraphMessage object with all details of e-mail message</param>
		/// <returns>(bool, string) tuple. Item1 contains the status of e-mail sending (true if everyhing worked well, false if failed), the Item2 contains the message generated during the sending, and gives more information if some error happened during the sending. This method is an async method.</returns>
		public async Task<(bool, string)> SendMailAsync(GraphMessage message)
		{
			this._message = message;
			using HttpClient http = new HttpClient();
			try
			{
				HttpResponseMessage response = await http.SendAsync(this._CreateHttpRequest());
				if (response.StatusCode != System.Net.HttpStatusCode.Accepted)
				{
					string responseMessage = await response.Content.ReadAsStringAsync();
					return (false, $"Error during mail sending: {responseMessage}");
				}
				else
				{
					return (true, "Email has been sent with success");
				}
			}
			catch (Exception e)
			{
				return (false, $"Exception occurred: {e.Message}");
			}
		}

		/// <summary>
		/// Sending the e-mail message added in the parameter
		/// </summary>
		/// <param name="message">GraphMessage object with all details of e-mail message</param>
		/// <returns>(bool, string) tuple. Item1 contains the status of e-mail sending (true if everyhing worked well, false if failed), the Item2 contains the message generated during the sending, and gives more information if some error happened during the sending.</returns>
		public (bool, string) SendMail(GraphMessage message)
		{
			this._message = message;
			using HttpClient http = new HttpClient();
			try
			{
				HttpResponseMessage response = http.SendAsync(this._CreateHttpRequest()).Result;
				if (response.StatusCode != System.Net.HttpStatusCode.Accepted)
				{
					string responseMessage = response.Content.ReadAsStringAsync().Result;
					return (false, $"Error during mail sending: {responseMessage}");
				}
				else
				{
					return (true, "Email has been sent with success");
				}
			}
			catch (Exception e)
			{
				return (false, $"Exception occurred: {e.Message}");
			}
		}

		public void Dispose()
		{

		}
	}
}