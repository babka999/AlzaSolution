﻿using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;

namespace AlzaWebApi
{
    /// <summary>
    /// Starting class
    /// </summary>
    public class Program
    {
        /// <summary>
        /// Main
        /// </summary>
        /// <param name="args"></param>
        public static void Main(string[] args) =>
            CreateWebHostBuilder(args).Build().Run();

        /// <summary>
        /// Create web host builder
        /// </summary>
        /// <param name="args"></param>
        /// <returns></returns>
        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>();
    }
}
