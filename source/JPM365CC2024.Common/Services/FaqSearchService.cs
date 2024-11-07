//
// Copyright (c) 2024 karamem0
//
// This software is released under the MIT License.
//
// https://github.com/karamem0/japan-m365-community-conference-2024
//

using Azure.Search.Documents;
using Azure.Search.Documents.Models;
using JPM365CC2024.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace JPM365CC2024.Common.Services;

public class FaqSearchService(SearchClient searchClient)
{

    private readonly SearchClient searchClient = searchClient;

    public async IAsyncEnumerable<Faq> SearchAsync(
        string searchText,
        [EnumeratorCancellation()]
        CancellationToken cancellationToken = default
    )
    {
        var vectorQuery = new VectorizableTextQuery(searchText);
        vectorQuery.Fields.Add("question_vector");
        var vectorSearchOption = new VectorSearchOptions();
        vectorSearchOption.Queries.Add(vectorQuery);
        var searchOption = new SearchOptions()
        {
            VectorSearch = vectorSearchOption
        };
        var searchResults = await this.searchClient.SearchAsync<Faq>(searchText, searchOption, cancellationToken);
        await foreach (var searchResult in searchResults.Value.GetResultsAsync())
        {
            yield return searchResult.Document;
        }
    }

}
