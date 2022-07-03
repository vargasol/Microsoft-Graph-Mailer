using System.Security.Cryptography.X509Certificates;
using Vargasol.Graph.Mailer;
using Vargasol.Graph.Mailer.Mail;

X509Store store = new X509Store("My", StoreLocation.CurrentUser);
store.Open(OpenFlags.ReadOnly);
X509Certificate2 cert = store.Certificates.Single(a => a.Thumbprint == "8dfd7f80d033cd411ba5ae0cb1ac3573bd7562cc".ToUpper());
store.Close();



(bool status, string message) result = mailer.SendMail(msg);

Console.WriteLine();