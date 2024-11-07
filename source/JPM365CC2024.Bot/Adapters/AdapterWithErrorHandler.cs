//
// Copyright (c) 2024 karamem0
//
// This software is released under the MIT License.
//
// https://github.com/karamem0/japan-m365-community-conference-2024
//

using Microsoft.Bot.Builder.Integration.AspNet.Core;
using Microsoft.Bot.Builder.TraceExtensions;
using Microsoft.Bot.Connector.Authentication;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JPM365CC2024.Bot.Adapters;

public class AdapterWithErrorHandler : CloudAdapter
{

    public AdapterWithErrorHandler(BotFrameworkAuthentication auth, ILogger<IBotFrameworkHttpAdapter> logger)
        : base(auth, logger)
    {
        this.OnTurnError = async (turnContext, exception) =>
        {
            logger.LogError(exception, $"[OnTurnError] unhandled error : {exception.Message}");
            _ = await turnContext.SendActivityAsync("The bot encountered an error or bug.");
            _ = await turnContext.SendActivityAsync("To continue to run this bot, please fix the bot source code.");
            _ = await turnContext.TraceActivityAsync("OnTurnError Trace", exception.Message, "https://www.botframework.com/schemas/error", "TurnError");
        };
    }
}
