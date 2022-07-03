

namespace Vargasol.Graph.Mailer.Interfaces
{
	/// <summary>
	/// Sets the content type of body
	/// </summary>
	public interface IWithBodyType
	{
		/// <summary>
		/// If body is HTML
		/// </summary>
		/// <returns></returns>
		IWithBody IsHTML();

		/// <summary>
		/// If body is PlainText
		/// </summary>
		/// <returns></returns>
		IWithBody IsPlainText();
	}
}
