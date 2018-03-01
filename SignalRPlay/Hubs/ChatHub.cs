using System.Collections.Generic;
using Microsoft.AspNet.SignalR;
namespace SignalRPlay
{
	public class ChatHub : Hub
	{
		private static readonly Dictionary<string, dynamic> _registeredUsers = new Dictionary<string, dynamic>();
		public void Send(string name, string message)
		{
			// Call the addNewMessageToPage method to update clients.
			Clients.All.addNewMessageToPage(name, message, false);
		}

		public void Register(string username)
		{
			_registeredUsers[username] = Clients.Caller;
		}

		public void SendPrivate(string from, string to, string message)
		{
			if (_registeredUsers.ContainsKey(to))
			{
				dynamic toUser = _registeredUsers[to];
				toUser.addNewMessageToPage(from, message, true);
			}
		}
	}
}