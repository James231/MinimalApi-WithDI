namespace MinApi.Services;

/// <summary>
/// Example custom service. Added in Program.cs -> ConfigureServices method. Used in ExampleController.cs
/// </summary>
public class MyService
{
    public string Echo(string value)
    {
        return value;
    }
}
