
namespace Vargasol.Graph.Mailer
{
	public class MessageBuilder : IWithSubject, IWithBodyType, IWithBody, IGraphMessage
	{
		private Message _Message = new Message();
		private bool _SaveToSentItems = false;

		private MessageBuilder(string from)
		{
			this._Message.From = new EmAddress()
			{
				EmailAddress = new MailAddress()
				{
					Address = from
				}
			};
			this._Message.Sender = new EmAddress()
			{
				EmailAddress = new MailAddress()
				{
					Address = from
				}
			};
		}

		private MessageBuilder(EmAddress from)
		{
			this._Message.From = from;
			this._Message.Sender = from;
		}

		/// <summary>
		/// Starts message builder procedure with configuring the from value of the message
		/// </summary>
		/// <param name="from"></param>
		/// <returns></returns>
		public static IWithSubject Start(string from)
		{
			return new MessageBuilder(from);
		}

		/// <summary>
		/// Starts message builder procedure with configuring the from value of the message
		/// </summary>
		/// <param name="from"></param>
		/// <returns></returns>
		public static IWithSubject Start(EmAddress from)
		{
			return new MessageBuilder(from);
		}

		public IWithBody AddAttachment(FileAttachment attachment)
		{
			this._Message.Attachments.Add(attachment);
			return this;
		}

		public IWithBody AddAttachments(IEnumerable<FileAttachment> attachments)
		{
			foreach (FileAttachment file in attachments)
			{
				this._Message.Attachments.Add(file);
			}
			return this;
		}

		public IWithBody AddBCCRecipient(string mailAddress)
		{
			this._Message.BCCRecipients.Add(new EmAddress()
			{
				EmailAddress = new MailAddress()
				{
					Address = mailAddress
				}
			});
			return this;
		}

		public IWithBody AddBCCRecipient(EmAddress mailAddress)
		{
			this._Message.BCCRecipients.Add(mailAddress);
			return this;
		}

		public IWithBody AddBCCRecipients(IEnumerable<string> mailAddresses)
		{
			foreach (string addr in mailAddresses)
			{
				this.AddBCCRecipient(addr);
			}
			return this;
		}

		public IWithBody AddBCCRecipients(IEnumerable<EmAddress> mailAddresses)
		{
			foreach (EmAddress addr in mailAddresses)
			{
				this._Message.BCCRecipients.Add(addr);
			}

			return this;
		}

		public IGraphMessage AddBody(string Body)
		{
			this._Message.Body.Content = Body;
			return this;
		}

		public IWithBody AddCCRecipient(string mailAddress)
		{
			this._Message.CCRecipients.Add(new EmAddress()
			{
				EmailAddress = new MailAddress()
				{
					Address = mailAddress
				}
			});
			return this;
		}

		public IWithBody AddCCRecipient(EmAddress mailAddress)
		{
			this._Message.CCRecipients.Add(mailAddress);
			return this;
		}

		public IWithBody AddCCRecipients(IEnumerable<string> mailAddresses)
		{
			foreach (var addr in mailAddresses)
			{
				this.AddCCRecipient(addr);
			}
			return this;
		}

		public IWithBody AddCCRecipients(IEnumerable<EmAddress> mailAddresses)
		{
			foreach (var addr in mailAddresses)
			{
				this.AddCCRecipient(addr);
			}
			return this;
		}

		public IWithBody AddRecipient(string mailAddress)
		{
			this._Message.ToRecipients.Add(new EmAddress()
			{
				EmailAddress = new MailAddress()
				{
					Address = mailAddress
				}
			});
			return this;
		}

		public IWithBody AddRecipient(EmAddress mailAddress)
		{
			this._Message.ToRecipients.Add(mailAddress);
			return this;
		}

		public IWithBody AddRecipients(IEnumerable<string> mailAddresses)
		{
			foreach (var addr in mailAddresses)
			{
				this.AddRecipient(addr);
			}
			return this;
		}

		public IWithBody AddRecipients(IEnumerable<EmAddress> mailAddresses)
		{
			foreach (var addr in mailAddresses)
			{
				this.AddRecipient(addr);
			}
			return this;
		}

		public IWithBody AddReplyTo(EmAddress mailAddress)
		{
			this._Message.ReplyTo.Add(mailAddress);
			return this;
		}

		public IWithBody AddReplyTo(IEnumerable<EmAddress> mailAddresses)
		{
			foreach (var addr in mailAddresses)
			{
				this.AddReplyTo(addr);
			}
			return this;
		}

		public IWithBody AddReplyTo(string mailAddress)
		{
			this._Message.ReplyTo.Add(new EmAddress()
			{
				EmailAddress = new MailAddress()
				{
					Address = mailAddress
				}
			});
			return this;
		}

		public IWithBody AddReplyTo(IEnumerable<string> mailAddresses)
		{
			foreach (var addr in mailAddresses)
			{
				this.AddReplyTo(addr);
			}
			return this;
		}

		public GraphMessage GenerateMessage()
		{
			return new GraphMessage()
			{
				Message = this._Message,
				SaveToSentItems = this._SaveToSentItems
			};
		}

		public IWithBody IsHTML()
		{
			this._Message.Body.ContentType = "html";
			return this;
		}

		public IWithBody IsPlainText()
		{
			this._Message.Body.ContentType = "text";
			return this;
		}

		public IWithBody RequestDeliveryReceipt()
		{
			this._Message.IsDeliveryReceiptRequested = true;
			return this;
		}

		public IWithBody RequestReadReceipt()
		{
			this._Message.IsReadReceiptRequested = true;
			return this;
		}

		public IGraphMessage SaveToSent()
		{
			this._SaveToSentItems = true;
			return this;
		}



		public IWithBodyType Subject(string subject)
		{
			this._Message.Subject = subject;
			return this;
		}

		IGraphMessageSavedToSent IGraphMessage.SaveToSent()
		{
			return this.SaveToSent();
		}
	}
}
