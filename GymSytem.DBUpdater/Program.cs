using System.Reflection;
using DbUp;

#pragma warning disable CS7022 // The entry point of the program is global code; ignoring entry point
static int Main(string[] args)
{
    var connectionString =
        args.FirstOrDefault()
        ?? "Server=localhost\\MSSQLSERVER01;Database=GymSystem;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False;MultipleActiveResultSets=true";

    EnsureDatabase.For.SqlDatabase(connectionString);

    var upgrader =
        DeployChanges.To
            .SqlDatabase(connectionString)
            .WithScriptsEmbeddedInAssembly(Assembly.GetExecutingAssembly())
            .LogToConsole()
            .WithVariablesDisabled()
            .Build();

    var result = upgrader.PerformUpgrade();

    if (!result.Successful)
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine(result.Error);
        Console.ResetColor();
#if DEBUG
        Console.ReadLine();
#endif
        return -1;
    }

    Console.ForegroundColor = ConsoleColor.Green;
    Console.WriteLine("Success!");
    Console.ResetColor();
    return 0;
}
#pragma warning restore CS7022 // The entry point of the program is global code; ignoring entry point

Main(args);
