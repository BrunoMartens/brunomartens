using brunomartens.web.MiddleWare;
using Microsoft.AspNetCore.Rewrite;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();


var options = new RewriteOptions()
    .Add(Rewrites.DoNotRedirectFilesOrApi)
    .AddRewrite(@"areas/(.*)/(.*)", "/areas/$1/index.html", skipRemainingRules: true)
    .AddRewrite(@".*", "/index.html", skipRemainingRules: true);

app.UseRewriter(options);

app.UseStaticFiles();

app.Run();
