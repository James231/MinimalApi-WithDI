# MinimalApi-WithDI
Example of .NET 6 ([Preview 7](https://devblogs.microsoft.com/dotnet/announcing-net-6-preview-7/) or later) [Minimal APIs](https://devblogs.microsoft.com/aspnet/asp-net-core-updates-in-net-6-preview-4/#introducing-minimal-apis) with Controllers and Dependency Injection.

## Eh? 🥴

Normally APIs built with ASP.NET include a lot of stuff out-of-the-box, which you might not need. And need a lot of boilerplate code to setup properly.

Minimal APIs added in .NET 6 gives you a barebones project template, with all that missing. You can just write a few simple lines of code to define route mappings to C# methods which return strings.

This project takes Minimal APIs and adds a bit more. Specifically, I've added Controllers for endpoints, which can be defined using an `[ApiController]` attribute, and dependency injection with equivalent of the usual `ConfigureServices` method.

## Adding Controllers

Look at the `Controllers` folder. Just add them there. Should be obvious.

## Adding Services to DI Container

Look at `Program.cs`, and add your services to `ConfigureServices` at the end.

## Ideas
- I might replace the reflection code with source generators one day. For nice and speedy startups 🚅
- Could try using the same codebase for Azure Functions?