// AppHost/Program.cs
using Projects;

var builder = DistributedApplication.CreateBuilder(args);

// SQL Server avec un volume Docker nommé
// Les données survivent aux redémarrages de l'AppHost
var sql = builder.AddSqlServer("sqlserver")
                 .WithDataVolume("marketflow-sqldata")   // ← persistance
                 .AddDatabase("marketflowdb");

builder.AddProject<MarketFlow_API>("api")
       .WithReference(sql)    // injecte ConnectionStrings__marketflowdb
       .WaitFor(sql);         // attend que SQL Server soit healthy

builder.Build().Run();