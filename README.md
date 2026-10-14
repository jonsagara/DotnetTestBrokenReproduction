# `dotnet test path/to/project.csproj` no longer works in .NET 11 RC 1 and RC 2

After upgrading to .NET 11 RC 1 and 2, running `dotnet test` from the command line in the solution root no longer works. To reproduce:

1. Clone this repository
1. Switch to branch `feature/net11rc1` or `feature/net11rc2`
1. From the solution root, try to run `dotnet test`

## Commands run successfully with .NET SDK 10.0.402:

Switch to branch `main`.

```
> dotnet test src/AwesomeLibrary.Tests/AwesomeLibrary.Tests.csproj
Running tests from src\AwesomeLibrary.Tests\bin\Debug\net8.0\AwesomeLibrary.Tests.dll (net8.0|arm64)
Running tests from src\AwesomeLibrary.Tests\bin\Debug\net9.0\AwesomeLibrary.Tests.dll (net9.0|arm64)
Running tests from src\AwesomeLibrary.Tests\bin\Debug\net10.0\AwesomeLibrary.Tests.dll (net10.0|arm64)
src\AwesomeLibrary.Tests\bin\Debug\net9.0\AwesomeLibrary.Tests.dll (net9.0|arm64) passed (459ms)
src\AwesomeLibrary.Tests\bin\Debug\net8.0\AwesomeLibrary.Tests.dll (net8.0|arm64) passed (473ms)
src\AwesomeLibrary.Tests\bin\Debug\net10.0\AwesomeLibrary.Tests.dll (net10.0|arm64) passed (438ms)

Test run summary: Passed!
  src\AwesomeLibrary.Tests\bin\Debug\net8.0\AwesomeLibrary.Tests.dll (net8.0|arm64) passed (473ms)
  src\AwesomeLibrary.Tests\bin\Debug\net10.0\AwesomeLibrary.Tests.dll (net10.0|arm64) passed (438ms)
  src\AwesomeLibrary.Tests\bin\Debug\net9.0\AwesomeLibrary.Tests.dll (net9.0|arm64) passed (459ms)

  total: 6
  failed: 0
  succeeded: 6
  skipped: 0
  duration: 690ms
```

```
> dotnet test --project src/AwesomeLibrary.Tests/AwesomeLibrary.Tests.csproj
Running tests from src\AwesomeLibrary.Tests\bin\Debug\net10.0\AwesomeLibrary.Tests.dll (net10.0|arm64)
Running tests from src\AwesomeLibrary.Tests\bin\Debug\net9.0\AwesomeLibrary.Tests.dll (net9.0|arm64)
Running tests from src\AwesomeLibrary.Tests\bin\Debug\net8.0\AwesomeLibrary.Tests.dll (net8.0|arm64)
src\AwesomeLibrary.Tests\bin\Debug\net10.0\AwesomeLibrary.Tests.dll (net10.0|arm64) passed (468ms)
src\AwesomeLibrary.Tests\bin\Debug\net9.0\AwesomeLibrary.Tests.dll (net9.0|arm64) passed (476ms)
src\AwesomeLibrary.Tests\bin\Debug\net8.0\AwesomeLibrary.Tests.dll (net8.0|arm64) passed (445ms)

Test run summary: Passed!
  src\AwesomeLibrary.Tests\bin\Debug\net9.0\AwesomeLibrary.Tests.dll (net9.0|arm64) passed (476ms)
  src\AwesomeLibrary.Tests\bin\Debug\net10.0\AwesomeLibrary.Tests.dll (net10.0|arm64) passed (468ms)
  src\AwesomeLibrary.Tests\bin\Debug\net8.0\AwesomeLibrary.Tests.dll (net8.0|arm64) passed (445ms)

  total: 6
  failed: 0
  succeeded: 6
  skipped: 0
  duration: 633ms
```

## Commands run unsuccessfully with .NET 11 RC 1 or 2:

Switch to branch `feature/net11rc1` or `feature/net11rc2`.

```
> dotnet test src/AwesomeLibrary.Tests/AwesomeLibrary.Tests.csproj
Unhandled exception: The project file could not be loaded. Could not find a part of the path 'C:\Dev\SANDBOX\AwesomeLibrary\src\AwesomeLibrary.Tests\src\AwesomeLibrary.Tests\AwesomeLibrary.Tests.csproj'.  C:\Dev\SANDBOX\AwesomeLibrary\src\AwesomeLibrary.Tests\src\AwesomeLibrary.Tests\AwesomeLibrary.Tests.csproj
```

```
> dotnet test --project src/AwesomeLibrary.Tests/AwesomeLibrary.Tests.csproj
Unhandled exception: The project file could not be loaded. Could not find a part of the path 'C:\Dev\SANDBOX\AwesomeLibrary\src\AwesomeLibrary.Tests\src\AwesomeLibrary.Tests\AwesomeLibrary.Tests.csproj'.  C:\Dev\SANDBOX\AwesomeLibrary\src\AwesomeLibrary.Tests\src\AwesomeLibrary.Tests\AwesomeLibrary.Tests.csproj
```

As you can see in the output, something is mangling the path, repeating `src\AwesomeLibrary.Tests`:

> C:\Dev\SANDBOX\AwesomeLibrary\src\AwesomeLibrary.Tests\src\AwesomeLibrary.Tests\AwesomeLibrary.Tests.csproj


## Expected Behavior

Both of these commands succeed in .NET 11 RC 1 and 2:

`dotnet test src/AwesomeLibrary.Tests/AwesomeLibrary.Tests.csproj`

`dotnet test --project src/AwesomeLibrary.Tests/AwesomeLibrary.Tests.csproj`


## Actual Behavior

Both of these commands fail in .NET 11 RC 1 and 2 with the following exception:

> Unhandled exception: The project file could not be loaded. Could not find a part of the path 'C:\Dev\SANDBOX\AwesomeLibrary\src\AwesomeLibrary.Tests\src\AwesomeLibrary.Tests\AwesomeLibrary.Tests.csproj'.  C:\Dev\SANDBOX\AwesomeLibrary\src\AwesomeLibrary.Tests\src\AwesomeLibrary.Tests\AwesomeLibrary.Tests.csproj


## Note about .NET 11 Preview 7

This was working correctly with .NET 11 Preview 7.
