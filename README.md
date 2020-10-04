# WhereToEat
Sample project to show the location of San Francisco food trucks

## Getting started
To get started, do the following:
- Clone this repo
- Get a Google Maps API key from https://developers.google.com/maps/documentation/javascript/get-api-key
- Create an instance of Azure Application Insights: https://docs.microsoft.com/en-us/azure/azure-monitor/app/create-new-resource
- Create the file appsettings.Development.json in the /src/WhereToEat folder. Give it this content:
```
{
  "AppConfig": {
    "FoodTruckUrl": "https://data.sfgov.org/resource/rqzj-sfat.json",
    "MapApiKey": "Your Google Maps API Key"
  },
  "ApplicationInsights": {
    "InstrumentationKey": "Your App Insights Key"
  }
}

```
- Compile the application in either Visual Studio of VS Code. This was built with Visual Studio 2019 16.7.5.
- Run the application

## Project history and technical decisions

Why ASP.NET Core MVC?
<br/>
I am fairly familiar with ASP.NET MVC, so this seemed a good starting point. 

Why Google Maps?
<br/>
I last used Google maps about 8 years ago, so it seemed a good opertunity to get familiar with it again. It also provided a number of features that would be useful, such as grouping of markers.

What is missing?
<br/>
1. Exception handling
<br/>
   There is not enough exception handling, especially in the javascript on the maps page. 
<br/>
1. Tests, and more tests! There is some test coverage, but the focus of the next phase should be to get the test coverage up. The quality of the tests could also do with attention - they don't necessarily cover all the cases, or assert enough details
1. Automated Deployment - there is currently no automated deployment pipeline for the project. This should be created as a priority, with a way to manage the api keys securely. 
