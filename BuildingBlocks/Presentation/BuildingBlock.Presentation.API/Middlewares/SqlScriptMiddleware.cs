using BuildingBlock.Presentation.API.Extensions;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Npgsql;

namespace BuildingBlock.Presentation.API.Middlewares;

public static class SqlScriptMiddleware
{
    public static void RunSqlScripts(this IApplicationBuilder app, IConfiguration configuration)
    {
        var connectionString = configuration.GetRequiredConnectionString("Postgres");
        var scriptFileNames = configuration.GetSection("SqlScripts").Get<List<string>>();

        if (scriptFileNames == null) return;

        foreach (var script in scriptFileNames
                     .Select(scriptFileName => Path.Combine(Directory.GetCurrentDirectory(), scriptFileName))
                     .Select(scriptFilePath => File.ReadAllText(scriptFilePath)))
            ExecuteSqlScript(connectionString, script);
    }

    private static void ExecuteSqlScript(string connectionString, string script)
    {
        using var connection = new NpgsqlConnection(connectionString);
        connection.Open();
        using var command = new NpgsqlCommand(script, connection);
        command.ExecuteNonQuery();
    }
}