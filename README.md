# Jiguang.JPush.Extensions

[中文文档](README-CN.md)

Jiguang.JPush.Extensions is an extension library that allows you to use JPush easier in Asp.net core / .Net Stadard 2.0+

### Supported platforms

- .Net Standard 2.0+

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

> You can also just call `AddJPush()` without any parameters, by doing this, you need to configure `JPushOptions` with `services.Configure<JPushOptions>(configuration)` in `Startup.ConfigureServices` method.

Now, you can use `JPushClient` in your classes.

```c#
private readonly JPushClient _client;

public Constructor(JPushClient client)
{
    _client = client;
}
```

### Other information

-  The package version like v1.1.0 is related to [Jiguang.JPush](https://www.nuget.org/packages/Jiguang.JPush/)'s v1.1.0, and so on.
-  Newer version of [Jiguang.JPush](https://www.nuget.org/packages/Jiguang.JPush/) will be covered by Azure Pipelines automatically every month.
-  Please raise an issue or contact me directly if some version hasn't been covered.
