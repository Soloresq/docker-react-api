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
            // WebPack generates unique file names at every rebuild, so we can cache those files very aggressively
            MaxAge = TimeSpan.FromDays(12 * 30)
        };
    }
});

app.UseSpa(spaBuilder =>
{
    spaBuilder.Options.SourcePath = "build";

    // Avoid caching the index.html since it would reference old javascript files and images after deployments
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