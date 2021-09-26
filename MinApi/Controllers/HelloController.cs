namespace MinApi.Controllers;

// Creates endpoint at https://localhost:5001/hello
[ApiController("GET", "hello")]
public class HelloController : IController
{
    public string Invoked(HttpContext context)
    {
        return "hello";
    }
}
