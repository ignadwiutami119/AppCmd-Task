using System;
using McMaster.Extensions.CommandLineUtils;

namespace program3 {
    class Program {
        static int Main (string[] args) {
            var Palindrome = new CommandLineApplication () {
                Name = "Palindrome",
                Description = "it should detect palindrome string",
                ShortVersionGetter = () => "1.0.0"
            };

            Palindrome.Command ("palindrome", app => {
                app.Description = "detect the palindrome text";
                var text = app.Argument ("text", "Enter text");
                app.OnExecute (() => {
                    var input = text.Value;
                    
                    var get = input.Replace (@".", string.Empty)
                        .Replace (@" ", string.Empty)
                        .Replace (@",", string.Empty);

                    int n = get.Length;
                    int x = n / 2;
                    int res = 0;
                    for (int i = 0; i <= x; i++) {
                        if (get[i] == get[n - (1 + i)]) {
                           res++; }
                        else{
                            Console.WriteLine ("Is palindrome? No");
                            break;
                        }
                    }
                    if (res == x+1) {
                        Console.WriteLine("Is palindrome? Yes");
                    }
                });
            });

            Palindrome.OnExecute (() => {
                Palindrome.ShowHelp ();
            });
            return Palindrome.Execute (args);
        }
    }
}