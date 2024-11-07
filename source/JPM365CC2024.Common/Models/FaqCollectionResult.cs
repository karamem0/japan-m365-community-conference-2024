//
// Copyright (c) 2024 karamem0
//
// This software is released under the MIT License.
//
// https://github.com/karamem0/japan-m365-community-conference-2024
//

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace JPM365CC2024.Common.Models;

public class FaqCollectionResult
{

    [JsonPropertyName("value")]
    public IReadOnlyCollection<Faq>? Value { get; set; }

}
