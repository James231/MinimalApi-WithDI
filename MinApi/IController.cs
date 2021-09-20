namespace MinApi;

public interface IController
{
    string Invoked(HttpContext httpContext);
}
