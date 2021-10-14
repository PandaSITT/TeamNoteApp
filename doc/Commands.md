
# Entity Framework

```
dotnet ef dbcontext scaffold Name=ConnectionStrings:MySQL MySql.EntityFrameworkCore -o Models
```

https://docs.microsoft.com/en-us/ef/core/managing-schemas/scaffolding?tabs=dotnet-core-cli



## Tabelle updaten

```
dotnet ef dbcontext scaffold Name=ConnectionStrings:MySQL MySql.EntityFrameworkCore -o Models -f -t Tabelle 
```

Kann anscheinend einigen kaputt machen...