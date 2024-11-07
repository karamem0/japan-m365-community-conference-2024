//
// Copyright (c) 2024 karamem0
//
// This software is released under the MIT License.
//
// https://github.com/karamem0/japan-m365-community-conference-2024
//

using JPM365CC2024.Common.Models;
using Microsoft.Bot.Schema;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JPM365CC2024.Common.Services;

public class FaqCardService
{

    public HeroCard CreateHeroCard(Faq? document)
    {
        return new HeroCard()
        {
            Title = document?.Question,
            Subtitle = document?.Url,
            Text = document?.Answer,
            Tap = new CardAction()
            {
                Type = "openUrl",
                Value = document?.Url
            }
        };
    }

    public ThumbnailCard CreateThumbnailCard(Faq? document)
    {
        return new ThumbnailCard()
        {
            Title = document?.Question,
            Text = document?.Answer,
            Tap = new CardAction()
            {
                Type = "invoke",
                Value = document
            }
        };
    }

}
