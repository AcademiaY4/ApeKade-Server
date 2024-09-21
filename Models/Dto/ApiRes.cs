namespace apekade.Models.Dto;

public class ApiRes<T>{
    public Boolean? Status {get;set;}
    public int Code {get;set;}
    public T? Data {get;set;}
    public string? Message { get; set; }
}