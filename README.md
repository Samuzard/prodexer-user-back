# PriceAggregator
E-commerce engine

## CORS Policy:
This configuration allows any origin, method, and header, which is suitable for development on localhost. For production environments, you should restrict these to only what's necessary for your application.

If you want to apply CORS to specific controllers or action methods, you can still use the [EnableCors] attribute:

csharpCopy[EnableCors("AllowAll")]
[ApiController]
[Route("[controller]")]
public class MyController : ControllerBase
{
    // Controller methods...
}

## Useful Command Lines
#### EF Migration
...

## TODO
- Add Dates and fix UTC problem
- Remove/Exclude Asp Web app project
- Remove excluded files?
- Exclude MinProductDTO
- Add missing properties to ProductDTO