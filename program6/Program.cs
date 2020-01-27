using System;
using McMaster.Extensions.CommandLineUtils;
using System.Net;
using System.Net.Sockets;
using System.Linq;

namespace program6 {
    class Program {
        static int Main (string[] args) {
            var IpPrivate = new CommandLineApplication () {
                Name = "IpPrivate",
                    Description = "it get the private Ip Address",
                    ShortVersionGetter = () => "1.0.0"
            };

            IpPrivate.Command ("ip", app => {
                app.Description = "get private ip address";
                var text = app.Argument ("text", "Enter text");
                app.OnExecute (() => {
                    var host = Dns.GetHostEntry(Dns.GetHostName());
                    var ip_address = host.AddressList.FirstOrDefault(ip => ip.AddressFamily == AddressFamily.InterNetwork);
                        Console.WriteLine("Private IP Address = "+ip_address);
                });
            });

            IpPrivate.OnExecute (() => {
                IpPrivate.ShowHelp ();
            });
            return IpPrivate.Execute (args);
        }
    }
}