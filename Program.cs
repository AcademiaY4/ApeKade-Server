using apekade.Configuration;
using apekade.Models.Dto;

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

app.UseHttpsRedirection();

// mapping controllers
app.MapControllers();

// root server online status
app.MapGet("/", () => new ApiRes<object>
{
    Status = true,
    Code = 200,
    Data = new { Message = "server_online" }
});

app.Run();