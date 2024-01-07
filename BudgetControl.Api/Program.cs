using BudgetControl.Api;
using BudgetControl.Application;

var builder = WebApplication.CreateBuilder(args);
{
    builder.Services
    .AddPresentation()
    .AddApplication();
}


var app = builder.Build();
{
    app.UseHttpsRedirection();
    app.MapControllers();
    app.Run();
}


