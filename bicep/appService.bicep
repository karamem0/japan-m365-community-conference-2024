//
// Copyright (c) 2024 karamem0
//
// This software is released under the MIT License.
//
// https://github.com/karamem0/japan-m365-community-conference-2024
//

param appPlanName string
param appServiceName string

var location = resourceGroup().location

resource appPlan 'Microsoft.Web/serverfarms@2022-03-01' = {
  name: appPlanName
  location: location
  sku: {
    tier: 'Basic'
    name: 'B1'
  }
}

resource appService 'Microsoft.Web/sites@2022-03-01' = {
  name: appServiceName
  location: location
  properties: {
    serverFarmId: appPlan.id
    httpsOnly: true
    siteConfig: {
      netFrameworkVersion: 'v8.0'
      http20Enabled: true
      alwaysOn: true
      ftpsState: 'Disabled'
      use32BitWorkerProcess: false
      virtualApplications: [
        {
          virtualPath: '/'
          physicalPath: 'site\\wwwroot'
          preloadEnabled: true
        }
        {
          virtualPath: 'api'
          physicalPath: 'site\\wwwroot\\api'
        }
        {
          virtualPath: 'bot'
          physicalPath: 'site\\wwwroot\\bot'
        }
      ]
    }
  }
}

resource appServiceconfig 'Microsoft.Web/sites/config@2024-04-01' = {
  parent: appService
  name: 'metadata'
  kind: 'string'
  properties: {
    CURRENT_STACK: 'dotnetcore'
  }
}
