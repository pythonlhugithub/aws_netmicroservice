using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace cloudaws.precition
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();

var app=builder.Build();

app.mapGet('/observe/zip', (string zip, [FromQuery] int? days))>{
return result.ok(zip);

};  //fromquery use orm to mapping object in c# class with tabel column...

        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}


//create dataaccess so create dbconext (map datbase)
//code first to create db abd tables in database
//