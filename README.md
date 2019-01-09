# Jiguang.JPush.Extensions

[![Build status](https://wdcdavyc.visualstudio.com/Jiguang.JPush.Extensions/_apis/build/status/Jiguang.JPush.Extensions-ASP.NET%20Core-CI)](https://wdcdavyc.visualstudio.com/Jiguang.JPush.Extensions/_build/latest?definitionId=11)

[中文文档](README-CN.md)

Jiguang.JPush.Extensions is an extension library that allows you to use JPush easier in Asp.net core / .Net core 2.0+

### Supported platforms

- .Net core 2.0+

### Installation

[Nuget package](https://www.nuget.org/packages/Jiguang.JPush.Extensions/)

### Basic use

Add JPush into `Startup.ConfigureServices`:

```c#
services.AddJPush(options =>
{
    options.AppKey = "Your AppKey";
    options.MasterSecret = "Your MasterSecret";
});
```

Or, you can use another method, like below:

```c#
var configuration = new ConfigurationBuilder()
    .AddJsonFile("whatever.json")
    .Build();
services.AddJPush(configuration);
```

If you use this way, you need to add a `whatever.json` file first, and with content:

```json
{
  "AppKey": "Your AppKey",
  "MasterSecret": "Your MasterSecret"
}
```

Now, you can use `JPushClient` in your classes.

```c#
private readonly JPushClient _client;

public Constructor(JPushClient client)
{
    _client = client;
}
```

### Other information

-  The default [Jiguang.JPush](https://www.nuget.org/packages/Jiguang.JPush/1.0.0) package version is 1.0.0, you can upgrade it in your own project if you need a higher version.

### TODO

- Follow the [Jiguang.JPush](https://github.com/jpush/jpush-api-csharp-client)'s main and sub version like 1.0.0, 2.3.0.