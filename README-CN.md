Jiguang.JPush.Extensions 是一个 JPush 扩展类库，方便你在 .Net core 2.0+ 中更方便地使用 JPush 。

### 支持的平台

- .Net core 2.0+

### 安装

[Nuget package](https://www.nuget.org/packages/Jiguang.JPush.Extensions/)

### 使用方法

在 `Startup.ConfigureServices` 中添加 JPush：

```c#
services.AddJPush(options =>
{
    options.AppKey = "Your AppKey";
    options.MasterSecret = "Your MasterSecret";
});
```

或者，也可以通过配置文件添加：

```c#
var configuration = new ConfigurationBuilder()
    .AddJsonFile("随便什么名.json")
    .Build();
services.AddJPush(configuration);
```

然后在 json 文件中添加如下数据：

```json
{
  "AppKey": "Your AppKey",
  "MasterSecret": "Your MasterSecret"
}
```

然后，就可以愉快的使用 JPush 了😝。

```c#
private readonly JPushClient _client;

public Constructor(JPushClient client)
{
    _client = client;
}
```

### 注意事项

默认的 [Jiguang.JPush](https://www.nuget.org/packages/Jiguang.JPush/1.0.0) package 版本是 1.0.0, 你可以手动升级高版本。当然在未来会在后续版本中覆盖 JPush 的主要版本。