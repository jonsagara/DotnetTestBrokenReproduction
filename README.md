# `dotnet test path/to/project.csproj` no longer works in .NET 11 RC1

After upgrading to .NET 11 RC1, running `dotnet test` from the command line in the solution root no longer works. To reproduce:

1. Clone this repository
1. Switch to branch `feature/net11rc1`
1. From the solution root, try to run `dotnet test`

Examples:

> &gt; dotnet test src/AwesomeLibrary.Tests/AwesomeLibrary.Tests.csproj
> 
> hi

> &gt; dotnet test --project src/AwesomeLibrary.Tests/AwesomeLibrary.Tests.csproj
> 
> hi