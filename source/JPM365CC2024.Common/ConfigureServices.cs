//
// Copyright (c) 2024 karamem0
//
// This software is released under the MIT License.
//
// https://github.com/karamem0/japan-m365-community-conference-2024
//

using Azure;
using Azure.Search.Documents;
using JPM365CC2024.Common.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JPM365CC2024.Common;

public static class ConfigureServices
{

    public static IServiceCollection AddServices(this IServiceCollection services, IConfiguration configuration)
    {
        var searchServiceEndpoint = configuration.GetValue<string>("AzureSearchServiceEndpoint") ?? throw new InvalidOperationException();
        var searchServiceApiKey = configuration.GetValue<string>("AzureSearchServiceApiKey") ?? throw new InvalidOperationException();
        var searchServiceIndexName = configuration.GetValue<string>("AzureSearchServiceIndexName") ?? throw new InvalidOperationException();
        _ = services.AddSingleton(new SearchClient(
            new Uri(searchServiceEndpoint),
            searchServiceIndexName,
            new AzureKeyCredential(searchServiceApiKey)
        ));
        _ = services.AddSingleton<FaqCardService>();
        _ = services.AddSingleton<FaqSearchService>();
        return services;
    }

}
