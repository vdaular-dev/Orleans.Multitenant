﻿using OrleansMultitenant.Tests.Examples.AuthorizedStreaming;

namespace OrleansMultitenant.Tests.UnitTests;

[Collection(MultiPurposeCluster.Name)]
public class NoTenantIdTests(ClusterFixture fixture)
{
    readonly Orleans.TestingHost.TestCluster cluster = fixture.Cluster;

    public static TheoryData<string /*key*/, string /*tenantQualifiedKey*/> KeyQualifiedKeys() => new() {
        { "1"     , "1"       },
        { "Key2"  , "Key2"    },
        { "|"     , "||"      },
        { "||"    , "||||"    },
        { "|Key3" , "||Key3"  },
        { "K|ey4" , "K||ey4"  },
        { "Key5|" , "Key5||"  },
        { "~Key6" , "~Key6"   },
        { "|~Key7", "||~Key7" }
    };

    [Theory]
    [MemberData(nameof(KeyQualifiedKeys))]
    public void GetGrain_ForNoTenantWithKey_FormatsKeyCorrectly(string key, string tenantQualifiedKey)
    {
        var grain = GetGrain(key);
        string roundtrippedKey = grain.GetPrimaryKeyString();
        Assert.Equal(tenantQualifiedKey, roundtrippedKey);
    }

    [Theory]
    [MemberData(nameof(KeyQualifiedKeys))]
    [SuppressMessage("Usage", "xUnit1026:Theory methods should use all of their parameters", Justification = "Avoid code duplication")]
    public void GetTenantIdString_ForGrainWithNoTenant_ReturnsNull(string key, string _)
    {
        var grain = GetGrain(key);
        string? roundtrippedTenantId = grain.GetTenantId();
        Assert.Null(roundtrippedTenantId);
    }

    [Theory]
    [MemberData(nameof(KeyQualifiedKeys))]
    [SuppressMessage("Usage", "xUnit1026:Theory methods should use all of their parameters", Justification = "Avoid code duplication")]
    public void GetKeyWithinTenant_ForGrainWithTenant_ReturnsCorrectKeyWithinTenant(string key, string _)
    {
        var grain = GetGrain(key);
        string roundtrippedKeyWithinTenant = grain.GetKeyWithinTenant();
        Assert.Equal(key, roundtrippedKeyWithinTenant);
    }

    IGrainWithStringKey GetGrain(string key)
    => cluster.Client.ForTenant(null!).GetGrain<IStreamProducerGrain>(key);
}
