using System.Security.Cryptography.X509Certificates;
using Vargasol.Graph.Mailer;
using Vargasol.Graph.Mailer.Mail;

X509Store store = new X509Store("My", StoreLocation.CurrentUser);
store.Open(OpenFlags.ReadOnly);
X509Certificate2 cert = store.Certificates.Single(a => a.Thumbprint == "8dfd7f80d033cd411ba5ae0cb1ac3573bd7562cc".ToUpper());
store.Close();

MicrosoftGraphMailer mailer = GraphMailerOptionBuilder.Create("333f1de6-0b74-42d7-bf01-dd9fa5a83e33", "df3dc762-f88e-45fe-bfed-c3298f4d4f35").WithClientCertificate(cert).WithSenderAddress("superapp@magyarbankholding.hu").CreateAzureADMailerInstance();

GraphMessage msg = MessageBuilder.Start("superapp@magyarbankholding.hu").Subject("Test e-mail").IsHTML().AddRecipient("info@vargasol.cloud").AddCCRecipients(new string[] { "gabor.varga@vargasol.cloud" }).AddBody("Teszt message").GenerateMessage();

(bool status, string message) result = mailer.SendMail(msg);

Console.WriteLine();