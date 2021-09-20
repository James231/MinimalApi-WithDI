namespace MinApi;

[ApiController("hello")]
public class HelloController : IController
{
    public string Invoked(HttpContext context)
    {
        return "hello";
    }
}
