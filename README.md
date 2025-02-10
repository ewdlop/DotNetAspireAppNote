# DotNetAspireApp

https://learn.microsoft.com/en-us/dotnet/aspire/get-started/aspire-overview

https://www.docker.com/

https://devblogs.microsoft.com/dotnet/introducing-dotnet-aspire-simplifying-cloud-native-development-with-dotnet-8/

## 

dotnet Command Cheatsheet
=========================

1. **Create a New Project:**
   - `dotnet new console -n MyConsoleApp`
   - `dotnet new webapi -n MyWebApi`
   - `dotnet new mvc -n MyMvcApp`

2. **Build a Project:**
   - `dotnet build`
   - `dotnet build MyProject.csproj`

3. **Run a Project:**
   - `dotnet run`
   - `dotnet run --project MyProject.csproj`

4. **Restore Dependencies:**
   - `dotnet restore`
   - `dotnet restore MyProject.csproj`

5. **Add a Package:**
   - `dotnet add package <package_name>`
   - `dotnet add package Newtonsoft.Json`

6. **Remove a Package:**
   - `dotnet remove package <package_name>`
   - `dotnet remove package Newtonsoft.Json`

7. **List Project Dependencies:**
   - `dotnet list package`
   - `dotnet list package --outdated`

8. **Publish a Project:**
   - `dotnet publish`
   - `dotnet publish -c Release`
   - `dotnet publish --self-contained`

9. **Run Tests:**
   - `dotnet test`
   - `dotnet test MyTestProject.csproj`

10. **Add a Reference to Another Project:**
    - `dotnet add reference <path_to_project>`
    - `dotnet add reference ../MyLibrary/MyLibrary.csproj`

11. **Remove a Reference:**
    - `dotnet remove reference <path_to_project>`
    - `dotnet remove reference ../MyLibrary/MyLibrary.csproj`

12. **List Project References:**
    - `dotnet list reference`

13. **Global Tools:**
    - Install a global tool: `dotnet tool install -g <tool_name>`
    - Update a global tool: `dotnet tool update -g <tool_name>`
    - Uninstall a global tool: `dotnet tool uninstall -g <tool_name>`
    - List installed tools: `dotnet tool list -g`

14. **Project Templates:**
    - List all templates: `dotnet new --list`
    - Install a new template: `dotnet new --install <template_package>`
    - Uninstall a template: `dotnet new --uninstall <template_package>`

15. **Information Commands:**
    - `dotnet --version` (Displays the SDK version)
    - `dotnet --info` (Displays environment information)

16. **Help Commands:**
    - `dotnet --help`
    - `dotnet <command> --help` (e.g., `dotnet build --help`)

Use the `--help` flag with any command to get more detailed information about its usage and options.
