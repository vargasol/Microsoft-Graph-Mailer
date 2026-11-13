using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Microsoft.Identity.Client;
using System.Net;
using System.Reflection.PortableExecutable;
using System.Security.Cryptography.X509Certificates;
using Vargasol.Graph.Mailer.Exceptions;

namespace Vargasol.Graph.Mailer
{
	/// <summary>
	/// E-mail sender class which uses Microsoft Graph service for sending an e-mail message on behalf of any existing company e-mail address which is registered within the Exchange Online of the tenant. In order to use it, at least one Exchange Online license must be actively assigned to a user within the tenant.
	/// </summary>
	public class MicrosoftGraphMailer : IGraphMailer
	{
		private readonly GraphMailerOptions _Options;
		private readonly Func<HttpClient> _httpClient;
		private readonly IConfidentialClientApplication _confidentialClientApplication;

		const string GraphURL = "https://graph.microsoft.com/v1.0";
		readonly string[] AuthScope = new string[] { "https://graph.microsoft.com/.default" };
		string _accessToken;

		GraphMessage _message;


		/// <summary>
		/// Constructor of the Microsoft Graph Mailer with DI support
		/// </summary>
		/// <param name="options">Object which contains the options</param>
		[ActivatorUtilitiesConstructor]
		public MicrosoftGraphMailer(IOptions<GraphMailerOptions> options, IHttpClientFactory factory) : this(options.Value, () => factory.CreateClient(GraphMailerServiceCollectionExtensions.HttpClientName))
		{

		}

		private MicrosoftGraphMailer(GraphMailerOptions options, Func<HttpClient> httpClient)
		{
			this._Options = options;
			this._httpClient = httpClient;
			var b = ConfidentialClientApplicationBuilder.Create(this._Options.ApplicationID).WithTenantId(this._Options.TenantID);
			_confidentialClientApplication = this._Options.IsCertificateAuthentication ? b.WithCertificate(this._Options.ClientCertificate).Build() : b.WithClientSecret(this._Options.ClientSecret).Build();
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
		public async Task<(bool, string)> SendMailAsync(GraphMessage message, CancellationToken cancellationToken)
		{
			ValidateMessage(message);
			var token = await _confidentialClientApplication.AcquireTokenForClient(AuthScope).ExecuteAsync(cancellationToken);
			using var request = new HttpRequestMessage(HttpMethod.Post, $"{GraphURL}/users/{this._Options.SenderAddress}/sendMail")
			{

				Content = new StringContent(JsonConvert.SerializeObject(message), Encoding.UTF8, "application/json")
			};
			request.Headers.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token.AccessToken);
			using HttpResponseMessage response = await _httpClient().SendAsync(request);
			return response.StatusCode == HttpStatusCode.Accepted ? (true, "Email has been sent with success") : (false, $"Error during mail sending: {await response.Content.ReadAsStringAsync()}");
		}

		/// <summary>
		/// Sending the e-mail message added in the parameter
		/// </summary>
		/// <param name="message">GraphMessage object with all details of e-mail message</param>
		/// <returns>(bool, string) tuple. Item1 contains the status of e-mail sending (true if everyhing worked well, false if failed), the Item2 contains the message generated during the sending, and gives more information if some error happened during the sending.</returns>
		public (bool, string) SendMail(GraphMessage message)
		{
			ValidateMessage(message);
			var token = _confidentialClientApplication.AcquireTokenForClient(AuthScope).ExecuteAsync().Result;
			using var request = new HttpRequestMessage(HttpMethod.Post, $"{GraphURL}/users/{this._Options.SenderAddress}/sendMail")
			{

				Content = new StringContent(JsonConvert.SerializeObject(message), Encoding.UTF8, "application/json")
			};
			request.Headers.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token.AccessToken);
			using HttpResponseMessage response = _httpClient().SendAsync(request).Result;
			return response.StatusCode == HttpStatusCode.Accepted ? (true, "Email has been sent with success") : (false, $"Error during mail sending: {response.Content.ReadAsStringAsync().Result}");
		}

		public void Dispose()
		{

		}

		private void ValidateMessage(GraphMessage message)
		{
			if (message == null)
				throw new MessageIsNullException();
			if (message.Message == null)
				throw new MessageIsNullException();
			if (message.Message.ToRecipients == null || message.Message.ToRecipients.Count() == 0)
				throw new NoRecipientsException();
			if (string.IsNullOrEmpty(message.Message.Subject))
				throw new NoSubjectAddedException();
			if (string.IsNullOrEmpty(message.Message.Body?.Content))
				throw new NoBodyAddedException();
		}
	}
}