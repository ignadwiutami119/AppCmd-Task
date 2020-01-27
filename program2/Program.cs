using System;
using System.Linq;
using System.Text;
using McMaster.Extensions.CommandLineUtils;

namespace program2 {
    class Program {
        static int Main (string[] args) {
            var Aritmath = new CommandLineApplication () {
                Name = "Aritmath",
                Description = "it should calculate number",
                ShortVersionGetter = () => "1.0.0"
            };

            Aritmath.Command ("add", app => {
                app.Description = "sum all number";
                var text = app.Argument ("text", "Enter text");
                app.OnExecute (() => {
                    int sum = 0;
                    string[] input = text.Value.Split (' ').ToArray ();
                    int[] num = Array.ConvertAll (input, Int32.Parse);
                    for (int i = 0; i < num.Length; i++) {
                        sum += num[i];
                    }
                    Console.WriteLine ("Sum of all number : " + sum);
                });
            });

            Aritmath.Command ("subtract", app => {
                app.Description = "subtract first number";
                var text = app.Argument ("text", "Enter text");
                app.OnExecute (() => {
                    string[] input = text.Value.Split (' ').ToArray ();
                    int[] num = Array.ConvertAll (input, Int32.Parse);
                    int firstNum = num[0];
                    for (int i = 1; i < num.Length; i++) {
                        firstNum = firstNum - num[i];
                    }
                    Console.WriteLine ("Subtract of all number : " + firstNum);
                });
            });

            Aritmath.Command ("multiply", app => {
                app.Description = "subtract first number";
                var text = app.Argument ("text", "Enter text");
                app.OnExecute (() => {
                    string[] input = text.Value.Split (' ').ToArray ();
                    int[] num = Array.ConvertAll (input, Int32.Parse);
                    int result = num[0];
                    for (int i = 1; i < num.Length; i++) {
                        // result = num[i-1]*num[i];
                        result = result * num[i];
                    }
                    Console.WriteLine ("Multiply of all number : " + result);
                });
            });

            Aritmath.Command ("divide", app => {
                app.Description = "subtract first number";
                var text = app.Argument ("text", "Enter text");
                app.OnExecute (() => {
                    string[] input = text.Value.Split (' ').ToArray ();
                    int[] num = Array.ConvertAll (input, Int32.Parse);
                    int result = num[0];
                    for (int i = 1; i < num.Length; i++) {
                        // result = num[i-1]*num[i];
                        result = result / num[i];
                    }
                    Console.WriteLine ("Divide of all number : " + result);
                });
            });

            Aritmath.OnExecute (() => {
                Aritmath.ShowHelp ();
            });
            return Aritmath.Execute (args);
        }
    }
}