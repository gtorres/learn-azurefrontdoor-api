targetScope = 'subscription'

@description('The name given to the deloyment to be used as an identifier for related deployments')
param deploymentNamePrefix string = '0000000000'

@description('Name of the resource group for the resource. It is recommended to put resources under same resource group for better tracking.')
param resourceNameCommonPart string = 'rg-learn-freewebapp1'

@description('Location of the resource group. Resource groups could have different location than resources, however by default we use API versions from latest hybrid profile which support all locations for resource types we support.')
param resourceGroupLocation string = 'westus2'

param appPlanLocation string = 'eastus'

param stage string = 'learn'

var resourceGroupName = 'rg-${resourceNameCommonPart}'

@description('Name of the app plan that will host the web API')
var apiServiceName = '${resourceNameCommonPart}-as'

var appPlanName = '${resourceNameCommonPart}-asp-${uniqueString(apiServiceName, subscription().subscriptionId)}'
// var appServicePlanResourceId = '/subscriptions/${subscription().subscriptionId}/resourceGroups/${resourceGroupName}/providers/Microsoft.Web/serverFarms/${appPlanName}'

module resourceGroupModule 'resourceGroup.bicep' = {
  name: '${deploymentNamePrefix}_${resourceGroupName}'
  scope: subscription()
  params: {
    name: resourceGroupName
    location: resourceGroupLocation
    stage: stage
  }
}

module apiServiceModule 'appServiceFreePlan.bicep' = {
  name: '${deploymentNamePrefix}_${apiServiceName}'
  scope: resourceGroup(resourceGroupName)
  params: {
    apiServiceName: apiServiceName
    appPlanLocation: appPlanLocation
    appPlanName: appPlanName
    stage: stage
  }
  dependsOn: [ resourceGroupModule ]
}

output resourceGroupName string = resourceGroupModule.outputs.resourceGroupName
output apiServiceName string = apiServiceModule.outputs.apiServiceName
