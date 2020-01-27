using System;
using System.Net.Http;
using McMaster.Extensions.CommandLineUtils;

namespace program7 {
    class Program {
        static int Main (string[] args) {
            var ExternalIp = new CommandLineApplication () {
                Name = "ExternalIp",
                Description = "it should get the external ip address",
                ShortVersionGetter = () => "1.0.0"
            };
            
            string ip ="";
            ExternalIp.Command ("ip-external", app => {
                app.Description = "get the external ip";
                app.OnExecute (() => {
                    string url = "http://checkip.dyndns.org/";

                    using (var client = new HttpClient ()) {
                        var get = client.GetAsync (url)
                            .Result.Content.ReadAsStringAsync ().Result;
                            ip =get.Split(':')[1].Split('<')[0];
                    }
                        Console.WriteLine ("External ip is : "+ip);
                });
            });

            ExternalIp.OnExecute (() => {
                ExternalIp.ShowHelp ();
            });
            return ExternalIp.Execute (args);
        }
    }
}