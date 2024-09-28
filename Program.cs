using apekade.Configuration;
using apekade.Middleware;

var builder = WebApplication.CreateBuilder(args);

//the service configs are handled
ServiceConfiguration.Configure(builder.Services, builder.Configuration);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// the default cors option
app.UseCors();
// defined cors option
// app.UseCors("AllowAll");

// comented to avoid redirect to https in not secure servers.
// app.UseHttpsRedirection();

// use Custom middlewares
app.UseMiddleware<EndpointException>();
app.UseMiddleware<ExceptionMiddleware>();
// app.UseMiddleware<ValidationMiddleware>();

// mapping controllers
app.MapControllers();

// root server online status
app.MapGet("/", () => new {
    Code = 200,
    Status = true,
    Data = new { Message = "server Online" }
});

app.Run();