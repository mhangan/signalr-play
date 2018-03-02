using Microsoft.AspNet.SignalR;
using Owin;
using Microsoft.Owin;

[assembly: OwinStartup(typeof(SignalRPlay.Startup))]
namespace SignalRPlay
{
	public class Startup
	{
		public void Configuration(IAppBuilder app)
		{
			// Any connection or hub wire up and configuration should go here
			// Use Redis for scaling out to multiple servers.
			GlobalHost.DependencyResolver.UseRedis("NMT-RED-202", 6379, "", "SignalRPlay");
			app.MapSignalR();
		}
	}
}