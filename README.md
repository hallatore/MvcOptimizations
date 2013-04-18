Author: Tore Lervik - http://mindre.net

Download: https://nuget.org/packages/MvcOptimizations or ```PM> Install-Package MvcOptimizations```

# Documentation

## HtmlMinifierAttribute

Minifies the html-output to remove whitespace. Usually removes 15-20% of the content on MVC pages and only has about 1ms overhead.

```csharp
[HtmlMinifier]
public ActionResult Index() { ... }
```


## CompressFilterAttribute

Used on JsonResult because Mvc doesn't gzip Json-output. Can also be used on other actions that doesn't compress by default.

```csharp
[CompressFilter]
public JsonResult Articles() { ... }
```


## Utilities.Cache

Helper method for easier object caching.

```csharp
var articles = MvcOptimizations.Utilities.Cache("Articles", TimeSpan.FromMinutes(10), () =>
{
    var result = Service.GetArticles();
    SortArticles(result);
    return result;
});
```
