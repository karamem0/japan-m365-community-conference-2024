//
// Copyright (c) 2024 karamem0
//
// This software is released under the MIT License.
//
// https://github.com/karamem0/japan-m365-community-conference-2024
//

using JPM365CC2024.Common.Models;
using JPM365CC2024.Common.Services;
using Microsoft.Bot.Builder;
using Microsoft.Bot.Builder.Teams;
using Microsoft.Bot.Schema;
using Microsoft.Bot.Schema.Teams;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace JPM365CC2024.Bot.Bots;

public class TeamsBot(FaqCardService cardService, FaqSearchService searchService) : TeamsActivityHandler
{

    private readonly FaqCardService cardService = cardService;

    private readonly FaqSearchService searchService = searchService;

    protected override async Task<MessagingExtensionResponse> OnTeamsMessagingExtensionQueryAsync(
        ITurnContext<IInvokeActivity> turnContext,
        MessagingExtensionQuery query,
        CancellationToken cancellationToken = default
    )
    {
        var searchText = query?.Parameters?[0]?.Value?.ToString() ?? "";
        var attachments = await this.searchService
            .SearchAsync(searchText, cancellationToken)
            .ToListAsync(cancellationToken)
            .AsTask()
            .ContinueWith(task => task.Result
                .Select(document =>
                {
                    var heroCard = this.cardService.CreateHeroCard(document);
                    var thumbnailCard = this.cardService.CreateThumbnailCard(document);
                    return new MessagingExtensionAttachment()
                    {
                        ContentType = HeroCard.ContentType,
                        Content = heroCard,
                        Preview = thumbnailCard.ToAttachment()
                    };
                })
                .ToList()
            );
        return new MessagingExtensionResponse()
        {
            ComposeExtension = new MessagingExtensionResult()
            {
                Type = "result",
                AttachmentLayout = "list",
                Attachments = attachments
            }
        };
    }

    protected override Task<MessagingExtensionResponse> OnTeamsMessagingExtensionSelectItemAsync(
        ITurnContext<IInvokeActivity> turnContext,
        JObject query,
        CancellationToken cancellationToken = default
    )
    {
        var document = query.ToObject<Faq>();
        var heroCard = this.cardService.CreateHeroCard(document);
        var attachments = new List<MessagingExtensionAttachment>()
        {
            new()
            {
                ContentType = HeroCard.ContentType,
                Content = heroCard,
            }
        };
        return Task.FromResult(new MessagingExtensionResponse()
        {
            ComposeExtension = new MessagingExtensionResult()
            {
                Type = "result",
                AttachmentLayout = "list",
                Attachments = attachments
            }
        });
    }

}
