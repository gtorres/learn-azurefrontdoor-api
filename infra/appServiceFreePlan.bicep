@description('Name of the main resource to be created by this template.')
param apiServiceName string

param appPlanName string
param appPlanLocation string

param stage string

resource apiService 'Microsoft.Web/sites@2022-03-01' = {
  name: replace(apiServiceName, '.', '')
  location: appPlanLocation
  tags: {
    'hidden-related:${appPlan.id}': 'empty'
    environment: stage != null ? stage : ''
  }
  kind: 'app'
  properties: {
    httpsOnly: true
    reserved: false
    serverFarmId: appPlan.id
    siteConfig: {
      netFrameworkVersion: 'v6.0'
    }
  }
  identity: {
    type: 'SystemAssigned'
  }
}

resource appPlan 'Microsoft.Web/serverfarms@2022-03-01' = {
  name: appPlanName
  location: appPlanLocation
  sku: {
    name: 'F1'
    tier: 'Free'
    family: 'F'
    size: 'F1'
  }
}

output apiServiceName string = apiService.name
