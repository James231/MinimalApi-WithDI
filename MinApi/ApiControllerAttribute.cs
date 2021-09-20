namespace MinApi;

[System.AttributeUsage(System.AttributeTargets.Class)]
public class ApiControllerAttribute : System.Attribute
{
    public string endpoint;

    public ApiControllerAttribute(string endpoint)
    {
        this.endpoint = endpoint;
    }
}
