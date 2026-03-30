#pragma warning disable CS1591 // XML documentation is generated for the sample API, but these public OpenAPI helper types are not intended to be documented as a reusable public API.

using Microsoft.OpenApi;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace Orleans4Multitenant.Apis;

public static class TenantHeader
{
    public const string Name = "tenant";

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Performance", "CA1812:Avoid uninstantiated internal classes", Justification = "Instantiated late-bound")]
    internal sealed class AddAsOpenApiParameter : IOperationFilter
    {
        public void Apply(OpenApiOperation operation, OperationFilterContext context)
         => (operation.Parameters ??= []).Add(new OpenApiParameter
         {
             Name = Name,
             In = ParameterLocation.Header,
             Schema = new OpenApiSchema { Type = JsonSchemaType.String }
         });
    }
}

#pragma warning restore CS1591
