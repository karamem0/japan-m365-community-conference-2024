//
// Copyright (c) 2024 karamem0
//
// This software is released under the MIT License.
//
// https://github.com/karamem0/japan-m365-community-conference-2024
//

using Azure.Storage;
using JPM365CC2024.Bot.Adapters;
using JPM365CC2024.Bot.Bots;
using Microsoft.Bot.Builder;
using Microsoft.Bot.Builder.Azure.Blobs;
using Microsoft.Bot.Builder.Integration.AspNet.Core;
using Microsoft.Bot.Connector.Authentication;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JPM365CC2024.Bot;

public static class ConfigureServices
{

    public static IServiceCollection AddBots(this IServiceCollection services, IConfiguration configuration)
    {
        var storageConnectionString = configuration.GetValue<string>("AzureStorageAccountConnectionString") ?? throw new InvalidOperationException();
        var storageContainerName = configuration.GetValue<string>("AzureStorageAccountContainerName") ?? throw new InvalidOperationException();
        _ = services.AddSingleton<BotFrameworkAuthentication, ConfigurationBotFrameworkAuthentication>();
        _ = services.AddSingleton<IBotFrameworkHttpAdapter, AdapterWithErrorHandler>();
        _ = services.AddSingleton<IStorage>(new BlobsStorage(
            storageConnectionString,
            storageContainerName,
            new StorageTransferOptions()
        ));
        _ = services.AddSingleton<ConversationState>();
        _ = services.AddScoped<IBot, TeamsBot>();
        return services;
    }

}
