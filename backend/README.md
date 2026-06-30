# Backend Batel MS

API do Batel MS criada com ASP.NET Core em .NET 10.

## Padrões

- Use controllers tradicionais.
- Não use Minimal API.
- Use Entity Framework Core com PostgreSQL para acesso ao banco de dados.
- Mantenha a estrutura do microserviço dentro de `src/BatelMS.Api`.

## Comandos

```powershell
dotnet restore
dotnet build
dotnet run --project src/BatelMS.Api
```

## Banco de dados

A API usa PostgreSQL via Entity Framework Core. A connection string inicial fica em `src/BatelMS.Api/appsettings.json`:

```json
"DefaultConnection": "Host=localhost;Port=5432;Database=batel_ms;Username=postgres;Password=postgres"
```

Endpoint de saúde:

```http
GET /api/health
```

Documentação Swagger em desenvolvimento:

```http
GET /swagger
```
