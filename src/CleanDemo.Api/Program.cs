// --------------------------------------------------------------------------------
// <copyright file="Program.cs" company="Josh Wright">
// Copyright 2021 Josh Wright.
// Use of this source code is governed by an MIT-style, license that can be found
// in the LICENSE file or at https://opensource.org/licenses/MIT.
// </copyright>
// --------------------------------------------------------------------------------

using Serilog;

namespace WrightCodes.CleanDemo.Api;

public static class Program
{
    public static async Task Main(string[] args) =>
        await CreateHostBuilder(args)
            .Build()
            .RunAsync()
            .ConfigureAwait(false);

    private static IHostBuilder CreateHostBuilder(string[] args) =>
        Host.CreateDefaultBuilder(args)
            .ConfigureWebHostDefaults(webBuilder => webBuilder.UseStartup<Startup>())
            .UseSerilog((context, config) =>
                config.ReadFrom.Configuration(context.Configuration));
}