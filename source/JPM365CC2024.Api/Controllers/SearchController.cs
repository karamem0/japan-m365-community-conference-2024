//
// Copyright (c) 2024 karamem0
//
// This software is released under the MIT License.
//
// https://github.com/karamem0/japan-m365-community-conference-2024
//

using JPM365CC2024.Common.Models;
using JPM365CC2024.Common.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace JPM365CC2024.Api.Controllers;

[ApiController()]
[Route("search")]
public class SearchController(FaqSearchService searchService) : ControllerBase
{

    private readonly FaqSearchService searchService = searchService;

    [HttpGet()]
    [ProducesResponseType(typeof(FaqCollectionResult), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetAsync(string query, CancellationToken cancellationToken = default)
    {
        return await Task.FromResult(this.Ok(new FaqCollectionResult()
        {
            Value = await this.searchService
                .SearchAsync(query, cancellationToken)
                .ToListAsync(cancellationToken)
        }));
    }

}
