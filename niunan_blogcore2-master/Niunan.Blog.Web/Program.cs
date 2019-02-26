using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace Niunan.Blog.Web
{
    public class Program
    {
        public static void Main(string[] args)
        {
            BuildWebHost(args).Run();
        }

        public static IWebHost BuildWebHost(string[] args) =>

            WebHost.CreateDefaultBuilder(args)
            .UseUrls("http://127.0.0.1:" + (args.Length == 0 ? "5002" : args[0]))
                .UseStartup<Startup>()
                .Build();

    }
}
