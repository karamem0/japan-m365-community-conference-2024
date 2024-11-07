//
// Copyright (c) 2024 karamem0
//
// This software is released under the MIT License.
//
// https://github.com/karamem0/japan-m365-community-conference-2024
//

using JPM365CC2024.Api;
using JPM365CC2024.Common;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

var builder = WebApplication.CreateBuilder(args);

var services = builder.Services;
var configuration = builder.Configuration;
_ = services.AddControllers();
_ = services.AddSwaggerGen(options =>
{
    options.AddSecurityDefinition(
        "bearerAuth",
        new OpenApiSecurityScheme()
        {
            Scheme = "bearer",
            Type = SecuritySchemeType.Http
        }
    );
    options.AddSecurityRequirement(new OpenApiSecurityRequirement()
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference()
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "bearerAuth"
                }
            },
            Array.Empty<string>()
        }
    });
});
_ = services.AddServices(configuration);

var app = builder.Build();
if (app.Environment.IsDevelopment())
{
    _ = app.UseSwagger();
    _ = app.UseSwaggerUI();
}
_ = app.UseHttpsRedirection();
_ = app.MapControllers();
_ = app.Use(async (context, next) =>
{
    var authorization = context.Request.Headers.Authorization.FirstOrDefault();
    if (authorization == null)
    {
        context.Response.StatusCode = 401;
        return;
    }
    var apiKey = configuration.GetValue<string>("AzureSearchServiceApiKey");
    if (authorization != $"Bearer {apiKey}")
    {
        context.Response.StatusCode = 401;
        return;
    }
    await next(context);
});

await app.RunAsync();
