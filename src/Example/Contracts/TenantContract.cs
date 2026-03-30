#pragma warning disable CS1591 // XML documentation is generated for the sample contracts assembly, but these sample DTOs and interfaces are not fully documented.

namespace Orleans4Multitenant.Contracts.TenantContract;

[GenerateSerializer, Immutable]
public record Tenant([property: Id(0)] string Name);

[GenerateSerializer, Immutable]
public record User([property: Id(0)] Guid Id, [property: Id(1)] string Name);

public interface ITenant : IGrainWithStringKey
{
    /// <summary>Identifies the only instance of this grain</summary>
    const string Id = "";
    Task Update(Tenant tenant);
    Task<Tenant> Get();

    Task<UserResult> CreateUser(User user);
    Task<UserResult> GetUser(Guid id);
    Task<ImmutableArray<User>> GetUsers();
    Task<Result> UpdateUser(User user);
    Task<Result> DeleteUser(Guid id);
}

#pragma warning restore CS1591
