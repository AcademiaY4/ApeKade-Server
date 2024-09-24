using System;
using System.Text.Json;

namespace apekade.Models.Response;

public class ErrorRes
{
    public bool Status { get; set; }
    public int Code { get; set; }
    public string? Message { get; set; }
    public object? Data { get; set; }
    public string TimeStamp { get; set; }

    public ErrorRes()
    {
        TimeStamp = DateTime.UtcNow.ToString("o"); // "o" for ISO 8601 format
    }
    public override string ToString()
    {
        return JsonSerializer.Serialize(this);
    }
}
