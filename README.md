# PriceAggregator
E-commerce engine

## Useful Command Lines
#### EF Migration
In this case the migration is already created, just update the database.
###### 1- Create the migration
`dotnet ef Migrations add CreateAndSeedTablesV1 --project PriceAggregator.Infrastructure --startup-project PriceAggregatorAPI  --verbose `
###### 2- Update the database
`dotnet ef database update --project PriceAggregator.Infrastructure --startup-project PriceAggregatorAPI  --verbose`


## CORS Policy:
This configuration allows any origin, method, and header, which is suitable for development on localhost. For production environments, you should restrict these to only what's necessary for your application.

If you want to apply CORS to specific controllers or action methods, you can still use the [EnableCors] attribute:
```csharp
[EnableCors("AllowAll")]
[ApiController]
[Route("[controller]")]
public class MyController : ControllerBase
{
    // Controller methodsg...
}

```