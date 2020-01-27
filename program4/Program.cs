using System;
using McMaster.Extensions.CommandLineUtils;
using System.Text;

namespace program4 {
    class Program {
        static int Main (string[] args) {
            var Obfuscator = new CommandLineApplication () {
                Name = "Obfuscator",
                Description = "Obfuscator",
                ShortVersionGetter = () => "1.0.0"
            };

            Obfuscator.Command ("obfuscate", app => {
                app.Description = "modify the text";
                var text = app.Argument ("text", "Enter text");
                app.OnExecute (() => {
                    var input = text.Value;
                    Encoding encode = Encoding.ASCII;
                    Byte[] bit = encode.GetBytes(input);
                    foreach (var chr in bit)
                    {
                        Console.Write("&#{0};",chr);
                    }
                });
            });

            Obfuscator.OnExecute (() => {
                Obfuscator.ShowHelp ();
            });

            return Obfuscator.Execute (args);
        }
    }
}