using System;
using McMaster.Extensions.CommandLineUtils;

namespace program10 {
    class Program {
        static int Main (string[] args) {
            var infiniteInput = new CommandLineApplication () {
                Name = "infiniteInput",
                Description = "it should modify the string",
                ShortVersionGetter = () => "1.0.0"
            };

            infiniteInput.Command ("sum", app => {
                app.Description = "sum all number";
                app.OnExecute (() => {
                    int counter=1;
                    int number = 0;
                    for(int i =0;i<counter;i++) {
                        Console.Write("insert "+counter+"st number : ");
                        string input = Console.ReadLine();
                        if(input!= null) {
                            number += Convert.ToInt32(input);
                            counter++;
                        }
                        else {
                            break;
                        }
                    }
                    Console.WriteLine("Result : "+number);
                });
            });

            infiniteInput.OnExecute (() => {
                infiniteInput.ShowHelp ();
            });
            return infiniteInput.Execute (args);
        }
    }
}