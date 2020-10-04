# WhereToEat
Sample project to show the location of San Francisco food trucks

## Getting started
To get started, do the following:\
1. Clone the repo
1. Get a Google Maps API key from https://developers.google.com/maps/documentation/javascript/get-api-key
1. Create an instance of Azure Application Insights: https://docs.microsoft.com/en-us/azure/azure-monitor/app/create-new-resource
1. Create the file appsettings.Development.json in the /src/WhereToEat
## Project history and technical decisions

Why ASP.NET Core MVC?
<br/>
I am fairly familiar with ASP.NET MVC, so this seemed a good starting point. 

Why Google Maps?
<br/>
I last used Google maps about 8 years ago, so it seemed a good opertunity to get familiar with it again. It also provided a number of features that would be useful, such as grouping of markers.

What is missing?
Exception handling
There is not enough exception handling, especially in the javascript on the maps page. 
<br/>
Tests, and more tests! There is some test coverage, but the focus of the next phase should be to get the test coverage up. The quality of the tests could also do with attention - they don't necessarily cover all the cases, or assert enough details


