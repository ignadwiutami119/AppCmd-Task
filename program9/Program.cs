using System;
using McMaster.Extensions.CommandLineUtils;
using PuppeteerSharp;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace soal9
{
    class Program
    {
          public static async Task screenshot(string url ,string format)
          {
            await new BrowserFetcher().DownloadAsync(BrowserFetcher.DefaultRevision);
            var browser = await Puppeteer.LaunchAsync(new LaunchOptions
            {
                Headless = true
            });
            var page = await browser.NewPageAsync();
            await page.GoToAsync(url);

            var screenshot_option = new ScreenshotOptions()
            {
                FullPage = true
            };

            if(format == "jpg" || format == "png")
            {
                if(format == "jpg")
                {
                    string repl = url.Replace("/","_").Replace(":","_");
                    await page.ScreenshotAsync($"{repl}.{format}",screenshot_option);
                    await page.CloseAsync();
                }
                else if (format == "png")
                {
                    string repl = url.Replace("/","_").Replace(":","_");
                    await page.ScreenshotAsync($"{repl}.{format}",screenshot_option);
                    await page.CloseAsync();
                }
            }
            else if(format =="pdf")
            {
                string repl = url.Replace("/","_").Replace(":","_");
                await page.PdfAsync($"{repl}.{format}");
                await page.CloseAsync();
            }
        }
        static async Task<int> Main(string[] args)
        {
            var Sc2 = new CommandLineApplication()
            {
                Name = "get screenshot2",
                Description = "get screenshot from list file",
                ShortVersionGetter = () => "1.0.0",
            };

            Sc2.Command("screenshot-list",app => 
            {
                app.Description = "get screenshot from list file";

                var input = app.Argument("Text","Masukkan Text");
                var format = app.Option("--format","formatfile",CommandOptionType.SingleOrNoValue);
                
                app.OnExecuteAsync(async cancellationToken => 
                {
                    if(format.HasValue())
                    {
                        var fl = File.ReadLines(input.Value);
                        foreach(var item in fl)
                        {
                            await screenshot(item,format.Value());
                        }
                    }
                });
            });

            return Sc2.Execute(args);
        }
    }
}