using Microsoft.AspNetCore.Http.Headers;
using Microsoft.Net.Http.Headers;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSpaStaticFiles(x =>
{
    x.RootPath = "build";
});

var app = builder.Build();

app.UseStaticFiles();
app.UseDirectoryBrowser();

// Serve SPA files excluding index.html
app.UseSpaStaticFiles(new StaticFileOptions
{
    OnPrepareResponse = ctx =>
    {
        ResponseHeaders headers = ctx.Context.Response.GetTypedHeaders();
        headers.CacheControl = new CacheControlHeaderValue
        {
            MaxAge = TimeSpan.FromDays(12 * 30)
        };
    }
});

app.UseSpa(spaBuilder =>
{
    spaBuilder.Options.SourcePath = "build";
    spaBuilder.Options.DefaultPageStaticFileOptions = new StaticFileOptions
    {
        OnPrepareResponse = ctx =>
        {
            ResponseHeaders headers = ctx.Context.Response.GetTypedHeaders();
            headers.CacheControl = new CacheControlHeaderValue
            {
                NoCache = true,
                NoStore = true,
                MustRevalidate = true,
                MaxAge = TimeSpan.Zero
            };
        }
    };
});
app.Run();