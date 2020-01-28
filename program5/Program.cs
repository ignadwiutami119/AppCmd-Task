using System;
using McMaster.Extensions.CommandLineUtils;

namespace program5 {
    class Program {
        static int Main (string[] args) {
            var Randomize = new CommandLineApplication () {
                Name = "Random String",
                Description = "it return the random string",
                ShortVersionGetter = () => "1.0.0",
            };

            Randomize.Command ("random", app => {
                app.Description = "Random String";

                var length = app.Option ("--length", "text length", CommandOptionType.SingleOrNoValue);
                var letter = app.Option ("--letters", "text length", CommandOptionType.SingleOrNoValue);
                var number = app.Option ("--numbers", "text length", CommandOptionType.SingleOrNoValue);
                var upper = app.Option ("--uppercase", "text length", CommandOptionType.SingleOrNoValue);
                var lower = app.Option ("--lowercase", "text length", CommandOptionType.SingleOrNoValue);

                app.OnExecute (() => {
                    int init_length = 32;
                    bool init_letter = true;
                    bool init_number = true;
                    bool init_uppercase = false;
                    bool init_lowercase = false;
                    if (length.HasValue ()) {
                        init_length = Convert.ToInt32 (length.Value ());
                    }
                    if (letter.HasValue ()) {
                        if (Convert.ToBoolean (letter.Value ()) == false) {
                            init_letter = false;
                        }
                    }
                    if (number.HasValue ()) {
                        if (Convert.ToBoolean (number.Value ()) == false) {
                            init_number = false;
                        }
                    }
                    if (upper.HasValue ()) {
                        init_uppercase = true;
                    }
                    if (lower.HasValue ()) {
                        init_lowercase = true;
                    }
                    Console.WriteLine (encrypt (init_length, init_letter, init_number, init_uppercase, init_lowercase));
                });
            });

            return Randomize.Execute (args);
        }
        public static string encrypt (int length, bool letter, bool number, bool uppercase, bool lowercase) {
            var chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            var stringChars = new char[length];
            var random = new Random ();

            if (letter == false) {
                for (int i = 0; i < stringChars.Length; i++) {
                    stringChars[i] = chars[random.Next (chars.Length - 10, chars.Length)];
                }
                return new String (stringChars);
            } else if (number == false) {
                for (int i = 0; i < stringChars.Length; i++) {
                    stringChars[i] = chars[random.Next (chars.Length - 10)];

                }
                if (uppercase == true) {
                    return new String (stringChars).ToUpper ();
                } else if (lowercase == true) {
                    return new String (stringChars).ToLower ();
                }
                return new String (stringChars);
            } else {
                for (int i = 0; i < stringChars.Length; i++) {
                    stringChars[i] = chars[random.Next (chars.Length)];
                }
                if (uppercase == true) {
                    return new String (stringChars).ToUpper ();
                } else if (lowercase == true) {
                    return new String (stringChars).ToLower ();
                }
                return new String (stringChars);
            }
        }

    }
}