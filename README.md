# Introduction 
This small package helps you to could send e-mail message using Azure AD modern authentication without using a preconfigured smtp or other mail server. The package simply uses Microsoft Azure AD and uses an Azure AD Application for configuration.

# Getting Started
In order, to could use that solution, you will need the followings:
- Access to an Azure AD tenant and having Global Administrator role within this tenant (this is mandatory)
- At least one user having Exchange Online license, or higher
- Properly configured App Registration within the Azure AD

# Preparation
## Create an App Registration in Azure AD
![](https://vargasolstorage.blob.core.windows.net/blogimages/img1.jpg)
## Configure the necessary API permissions to the Application
    
    Open the Application and select API permissions on the left menu and then click to Add permission
![](https://vargasolstorage.blob.core.windows.net/blogimages/img2.jpg)
## Configure the required API permissions
- Click to Microsoft Graph, select **Delegated permissions** and search the following permissions:
    - Mail.Send - Select its checkbox
- Click select **Application permissions** and search the following permissions:
    - Mail.Send - Select its checkbox
- Click to **Add permission** button at the bottom

![](https://vargasolstorage.blob.core.windows.net/blogimages/img3.jpg)
## Grant admin consent for the Application permissions
This part is required, otherwise you won't be able to send e-mail on behalf of any of registered e-mail addresses in the tenant.
    - Click to the button **Grant admin consent for <your tenant name>**
![](https://vargasolstorage.blob.core.windows.net/blogimages/img4.jpg)
When you are done, Admin consent required column will be greened out.
![](https://vargasolstorage.blob.core.windows.net/blogimages/img5.jpg)
## Generate a secret, or use a certificate for Application authentication
There are two options for authentication: using a secret (such as a password), or use a self-signed certificate.
### Adding a secret
1. Navigate to **Certificates & Secrets** menu
![](https://vargasolstorage.blob.core.windows.net/blogimages/img6.jpg)

2. Click to **+ New client secret** button

Choose when should it expire and if you want, you can add a Description. Then click to **Add** button at the bottom of panel.
![](https://vargasolstorage.blob.core.windows.net/blogimages/img7.jpg)

3. **When the secret has been added, immediately click to Copy icon next to the secret value, and save to somewhere. If you refresh the page, you won't see the secret value anytime!**
![](https://vargasolstorage.blob.core.windows.net/blogimages/img8.jpg)

**Note**: `Do not forget to renew the secret before it expires. When it expired, the secret will no longer working! You also need to configure the new secret within your application!`

### Adding a certificate

You need to generate a self-signed certificate on your machine and its public key must be exported to a *.pem or *.crt file. This file should be uploaded on the **Certificates** tab
When it is uploaded, the certificate is listed and you can confirm its thumbprint.
![](https://vargasolstorage.blob.core.windows.net/blogimages/img9.jpg)

## Find a sender address, who can be used within your company as a sender. If there no any, create an alias on an existing mailbox.

# Usage
## Create MicrosoftGraphMailer object instance
Creating of this object is following the fluent capabilities.

### Create object with secret
```
MicrosoftGraphMailer mailer = GraphMailerOptionBuilder.Create("<Azure AD Tenant ID>", "<Application ID>").WithClientSecret("<secret generated on Application>").WithSenderAddress("<valid sender address>").CreateAzureADMailerInstance();
```


### Create object with Certificate
**Note**: the thumbprints in Certificate store are stored with uppercase, and the whole process is **case sensitive**! If you write the thumbprint with lowercase, you won't able to find the certificate. You need to either make your thumbprint to uppercase, or convert the thumbprints to lowercase. 
```
X509Store store = new X509Store("My", StoreLocation.CurrentUser);
store.Open(OpenFlags.ReadOnly);
X509Certificate2 cert = store.Certificates.Single(a => a.Thumbprint == "<thumbprint of certificate in lowercase>".ToUpper());
store.Close();

MicrosoftGraphMailer mailer = GraphMailerOptionBuilder.Create("<Azure AD Tenant ID>", "<Application ID>").WithClientSecret("<secret generated on Application>").WithClientCertificate(cert).CreateAzureADMailerInstance();
```
This process automatically creates a new object what can be used for sending e-mails. If it is done, it means all your configuration for application authentication works (at this point there is no guarantee that e-mail sending works as well).

# Create mail object
This process follows fluent approach as well. You can chain the proper commands after each other.

```
Message message = MessageBuilder.Start("<From>").Subject("<subject>").IsHTML().AddRecipient("<recipient>").AddCCRecipients(new string[] { "<multiple recipients>" }).AddBody(<Message Body>).GenerateMessage();

```