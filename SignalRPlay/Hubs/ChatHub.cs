using Microsoft.AspNet.SignalR;

namespace SignalRPlay
{
	public class ChatHub : Hub
	{
		/// <summary>
		/// Broadcast the message to all users.
		/// </summary>
		/// <param name="name">Name of user who sent the message</param>
		/// <param name="message">The message</param>
		public void Send(string name, string message)
		{
			// Call the addNewMessageToPage method to update clients.
			Clients.All.addNewMessageToPage(name, message, false);
		}

		/// <summary>
		/// Register a group with the user name, to enable receiving private messages.
		/// </summary>
		/// <param name="username">The username</param>
		public void Register(string username)
		{
			Groups.Add(Context.ConnectionId, username);
		}

		/// <summary>
		/// Sends a private message to the user 
		/// </summary>
		/// <param name="from">Sender of the message</param>
		/// <param name="to">Receiver of the message</param>
		/// <param name="message">The message</param>
		public void SendPrivate(string from, string to, string message)
		{
			Clients.Group(to).addNewMessageToPage(from, message, true);
		}
	}
}