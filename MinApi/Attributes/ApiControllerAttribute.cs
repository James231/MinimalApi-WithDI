namespace MinApi;

[System.AttributeUsage(System.AttributeTargets.Class)]
public class ApiControllerAttribute : System.Attribute
{
    public string method;
    public string endpoint;

    public ApiControllerAttribute(string method, string endpoint)
    {
        this.method = method;
        this.endpoint = endpoint;
    }
}
