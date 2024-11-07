//
// Copyright (c) 2024 karamem0
//
// This software is released under the MIT License.
//
// https://github.com/karamem0/japan-m365-community-conference-2024
//

param botServiceName string
param msaAppType string = 'SingleTenant'
param msaAppId string
param msaAppTenantId string

var location = 'global'

resource botService 'Microsoft.BotService/botServices@2023-09-15-preview' = {
  name: botServiceName
  location: location
  sku: {
    name: 'F0'
  }
  kind: 'bot'
  properties: {
    displayName: botServiceName
    endpoint: 'https://api.botframework.com'
    msaAppType: msaAppType
    msaAppId: msaAppId
    msaAppTenantId: msaAppTenantId
    tenantId: msaAppTenantId
  }
}
