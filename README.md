# serilog-sinks-avalonia-browser

It almost the same package Serilog.Sinks.BrowserConsole but use [JSImport] instead IJSRuntime (because it's working without Blazor and additional registrations).

```csharp

// dotnet add package Serilog.Sinks.Avalonia.Browser

 Log.Logger = new LoggerConfiguration()
            .MinimumLevel.Debug()
            .WriteTo.Browser()
            .CreateLogger();
```
![image](https://raw.githubusercontent.com/Tsaritsin/serilog-sinks-avalonia-browser/main/.github/images/readme_1.png)

![image](https://raw.githubusercontent.com/Tsaritsin/serilog-sinks-avalonia-browser/main/.github/images/readme_2.png)

A more detailed example is available [in this repository](https://github.com/Tsaritsin/serilog-sinks-avalonia-browser/tree/main/sample/AvaloniaSample).
