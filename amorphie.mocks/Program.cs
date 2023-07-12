using Microsoft.AspNetCore.SignalR;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddSignalR().AddMessagePackProtocol();


var app = builder.Build();

// Configure the HTTP request pipeline.

    app.UseSwagger();
    app.UseSwaggerUI();


// app.UseHttpsRedirection();

app.MapHub<MessageHub>("/hubs/messageHub");


app.MapPost("/SendMessage",

async ValueTask<IResult> (IHubContext<MessageHub> hubContext, string method, string message) =>
{
    await hubContext.Clients.All.SendAsync(method, message);
    return Results.Ok("");
});


app.Run();
