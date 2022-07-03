
namespace Vargasol.Graph.Mailer.Mail
{
	/// <summary>
	/// This class contains the possible values of Importance field of the e-mail message
	/// </summary>
	public static class MailImportance
	{
		/// <summary>
		/// For High importance messages
		/// </summary>
		public static string High
		{
			get
			{
				return "high";
			}
		}

		/// <summary>
		/// For Low importance messages
		/// </summary>
		public static string Low
		{
			get
			{
				return "low";
			}
		}

		/// <summary>
		/// For Normal importance messages
		/// </summary>
		public static string Normal
		{
			get
			{
				return "normal";
			}
		}
	}
}
