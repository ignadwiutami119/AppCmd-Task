using System;
using System.Text;
using McMaster.Extensions.CommandLineUtils;

namespace Task {
    class Program {
        static int Main (string[] args) {
            var StringTrans = new CommandLineApplication () {
                Name = "StringTransformation",
                Description = "it should modify the string",
                ShortVersionGetter = () => "1.0.0"
            };

            StringTrans.Command ("lowercase", app => {
                app.Description = "lowercasing every uppercase character";
                var text = app.Argument ("text", "Enter text");
                app.OnExecute (() => {
                    Console.WriteLine (text.Value.ToLower ());
                });
            });

            StringTrans.Command ("uppercase", app => {
                app.Description = "uppercasing every lowcase character";
                var text = app.Argument ("text", "Enter text");
                app.OnExecute (() => {
                    Console.WriteLine (text.Value.ToUpper ());
                });
            });

            StringTrans.Command ("capitalize", app => {
                app.Description = "uppercasing every first character";
                var input = app.Argument ("text", "Enter text");
                app.OnExecute (() => {
                    var word = input.Value;
                    string str = "";
                    StringBuilder final = new StringBuilder ();
                    if (word == String.Empty) {
                        Console.WriteLine ("cannot process");
                    } else {
                        for (int i = 0; i < word.Length; i++) {
                            if (i == 0) {
                                str = word[i].ToString ().ToUpper ();
                                final.Append (str);
                            } else if (word[i] == ' ') {
                                str = " " + word[i + 1].ToString ().ToUpper ();
                                final.Append (str);
                            } else if (word[i - 1] != ' ' && word[i] != ' ') {
                                str = word[i].ToString ().ToLower ();
                                final.Append (str);
                            }
                        }
                    }
                    Console.WriteLine (final);
                });
            });

            StringTrans.OnExecute (() => {
                StringTrans.ShowHelp ();
            });
            return StringTrans.Execute (args);
        }
    }
}