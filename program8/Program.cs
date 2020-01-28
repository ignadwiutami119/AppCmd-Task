using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json.Serialization;
using System.Threading;
using System.Threading.Tasks;
using McMaster.Extensions.CommandLineUtils;
using PuppeteerSharp;
using System.Text;

namespace app7 {
    class Program {
        public static async Task<int> Main (string[] args) {
            var ScreenShotprog = new CommandLineApplication () {
                Name = "StringTransformation",
                Description = "it should modify the string",
                ShortVersionGetter = () => "1.0.0"
            };

            ScreenShotprog.Command ("screenshot", app => {
                app.Description = "take a screenshot from web and save it in spesific format";
                var input = app.Argument ("text", "Enter text");
                var format = app.Option ("--format", "text length", CommandOptionType.SingleOrNoValue);
                var filename = app.Option ("--output", "text length", CommandOptionType.SingleOrNoValue);
                app.OnExecute (() => {
                    string frm = "png";
                    string url = Convert.ToString (input.Value);
                    if (format.HasValue ()) {
                        frm = Convert.ToString (format.Value ());
                        Task a = ScreenShot (url, frm);
                        a.Wait ();
                    }
                    if (filename.HasValue ()) {
                        string flnm = Convert.ToString (filename.Value ());
                        StringBuilder frmt = new StringBuilder();
                        StringBuilder name = new StringBuilder();
                        for(int i=flnm.Length-4;i<flnm.Length;i++) {
                            frmt.Append(flnm[i]);
                        }
                        for(int i=0;i<flnm.Length-4;i++) {
                            name.Append(flnm[i]);
                        }
                        string nm = Convert.ToString(name);
                        string fm = Convert.ToString(frmt);
                        Task a = fileName (url, nm, fm);
                        a.Wait ();
                    }
                });
            });

            ScreenShotprog.OnExecute (() => {
                ScreenShotprog.ShowHelp ();
            });
            return ScreenShotprog.Execute (args);
        }

        public static async Task ScreenShot (string url, string format) {
            await new BrowserFetcher ().DownloadAsync (BrowserFetcher.DefaultRevision);
            var browser = await Puppeteer.LaunchAsync (new LaunchOptions {
                Headless = false
            });
            var page = await browser.NewPageAsync ();
            await page.GoToAsync (url);
            var optionScreen = new ScreenshotOptions () {
                FullPage = true
            };

            if (format == "pdf") {
                string path = "D:/TRAININGC#/JANUARI/23Januari APP CMD/Task/program8";
                string[] getFile = Directory.GetFiles (path);
                foreach (string item in getFile) {
                    int counter = 1;
                    string file_name = Path.GetFileNameWithoutExtension (item);
                    string final = file_name.Replace ("screenshot-", "");
                    if (final == Convert.ToString (counter)) {
                        counter++;
                        await page.ScreenshotAsync ("screenshot-" + counter + ".pdf");
                    } else {
                        await page.ScreenshotAsync ("screenshot-" + counter + ".pdf");
                    }
                }
            } else if (format == "jpg") {
                string loc = "D:/TRAININGC#/JANUARI/23Januari APP CMD/Task/program8";
                string[] getFile = Directory.GetFiles (loc);
                foreach (string item in getFile) {
                    int count = 1;
                    string file_name = Path.GetFileNameWithoutExtension (item);
                    string final = file_name.Replace ("screenshot-", "");
                    if (final == Convert.ToString (count)) {
                        count++;
                        await page.ScreenshotAsync ("screenshot-" + count + ".jpg");
                    } else {
                        await page.ScreenshotAsync ("screenshot-" + count + ".jpg");
                    }
                }
            } else {
                string path = "D:/TRAININGC#/JANUARI/23Januari APP CMD/Task/program8";
                string[] getFile = Directory.GetFiles (path);
                foreach (string item in getFile) {
                    int count = 1;
                    string file_name = Path.GetFileNameWithoutExtension (item);
                    string final = file_name.Replace ("screenshot-", "");
                    if (final == Convert.ToString (count)) {
                        count++;
                        await page.ScreenshotAsync ("screenshot-" + count + ".png");
                    } else {
                        await page.ScreenshotAsync ("screenshot-" + count + ".png");
                    }
                }
            }
        }

        public static async Task fileName (string url, string nama, string format) {
            await new BrowserFetcher ().DownloadAsync (BrowserFetcher.DefaultRevision);
            var browser = await Puppeteer.LaunchAsync (new LaunchOptions {
                Headless = true
            });
            var page = await browser.NewPageAsync ();
            await page.GoToAsync (url);
            var optionScreen = new ScreenshotOptions () {
                FullPage = true
            };
            await page.ScreenshotAsync ($"{nama}{format}");
            await browser.CloseAsync ();
        }
    }
}