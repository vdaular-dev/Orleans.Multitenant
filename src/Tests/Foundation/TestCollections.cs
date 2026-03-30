#pragma warning disable CS1591 // XML documentation is generated for the test assembly, but collection fixtures are not intended to be documented as a public API.

namespace OrleansMultitenant.Tests;

[CollectionDefinition(Name)]
public class MultiPurposeCluster : ICollectionFixture<ClusterFixture>
{
    public const string Name = nameof(MultiPurposeCluster);
}

#pragma warning restore CS1591
