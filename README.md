# Adobe Reporting API for .NET

![.NET 2.2 CD](https://github.com/dentsudatalab/adobe/workflows/.NET%202.2%20CD/badge.svg) ![.NET 2.2 CI](https://github.com/dentsudatalab/adobe/workflows/.NET%202.2%20CI/badge.svg)

A .NET project written to make using the Adobe Reporting API easy.

## Getting Started

These instructions will guide you through installing and using the package to access the Adobe Reporting API.

### Installing

First, [install NuGet](http://docs.nuget.org/docs/start-here/installing-nuget). Then, install [Adobe Reporting API](https://www.nuget.org/packages/DentsuDataLab.Adobe/) from the package manager console:

```
PM> Install-Package DentsuDataLab.Adobe
```

### Using the services

The easiest way to get started using the API wrapper is by using the `IServiceCollection` extension that the project includes. All the required dependencies can be configured with the following:

```csharp
public void ConfigureServices(IServiceCollection services)
{
    services.AddAdobeServices();
}
```

Alternatively you can manually create a service like this:

```csharp
var httpClient = new HttpClient();
var clientStore = new AdobeClientStore(); // Keep this, as it stores tokens, so you won't have to authorize for every call
var authService = new AdobeAuthorizationService(clientStore);
var reportService = new ReportService(httpClient, authService);
```

### Services available

The following services are available:

- [DimensionService](Adobe/Documentation/DimensionService.md)
- [MetricService](Adobe/Documentation/MetricService.md)
- [ReportService](Adobe/Documentation/ReportService.md)
- [ReportSuiteService](Adobe/Documentation/ReportSuiteService.md)
- [SegmentService](Adobe/Documentation/SegmentService.md)
- [UserService](Adobe/Documentation/UserService.md)

## Authors

- **Frederik Baun Hansen** - _Initial work_

## License

This project is licensed under the MIT License - see the [LICENSE.txt](LICENSE.txt) file for details.
