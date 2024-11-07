//
// Copyright (c) 2024 karamem0
//
// This software is released under the MIT License.
//
// https://github.com/karamem0/japan-m365-community-conference-2024
//

param openaiServiceName string

var location = 'eastus'

resource openaiService 'Microsoft.CognitiveServices/accounts@2024-10-01' = {
  name: openaiServiceName
  location: location
  sku: {
    name: 'S0'
  }
  kind: 'OpenAI'
  properties: {
    customSubDomainName: openaiServiceName
  }
}
