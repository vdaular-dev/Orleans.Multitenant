#pragma warning disable CS1591 // XML documentation is generated for the sample API, but these public MVC helper types are not intended to be documented as a reusable public API.

using Orleans.Multitenant;
using Orleans4Multitenant.Contracts.TenantContract;

namespace Orleans4Multitenant.Apis;

public abstract partial class ControllerBase(IClusterClient orleans) : Microsoft.AspNetCore.Mvc.ControllerBase
{
    protected ITenant RequestTenant
    {
        get
        {
            string tenantId = HttpContext.Request.Headers.TryGetValue(TenantHeader.Name, out var tenantHeaderValue) ? tenantHeaderValue.ToString() : string.Empty;
            return orleans.ForTenant(tenantId).GetGrain<ITenant>(ITenant.Id);
        }
    }
}

#pragma warning restore CS1591
