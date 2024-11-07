//
// Copyright (c) 2024 karamem0
//
// This software is released under the MIT License.
//
// https://github.com/karamem0/japan-m365-community-conference-2024
//

using JPM365CC2024.Bot;
using JPM365CC2024.Common;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

var builder = WebApplication.CreateBuilder(args);

var configuration = builder.Configuration;
var services = builder.Services;
_ = services.AddHttpClient();
_ = services
    .AddControllers()
    .AddNewtonsoftJson();
_ = services.AddBots(configuration);
_ = services.AddServices(configuration);

var app = builder.Build();
if (app.Environment.IsDevelopment())
{
    _ = app.UseDeveloperExceptionPage();
}
_ = app.UseDefaultFiles();
_ = app.UseStaticFiles();
_ = app.UseWebSockets();
_ = app.UseRouting();
_ = app.UseAuthorization();
_ = app.MapControllers();

await app.RunAsync();
