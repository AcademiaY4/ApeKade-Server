public class ApiRes<T>{
    public string? Status {get;set;}
    public int Code {get;set;}
    public T? Data {get;set;}
}