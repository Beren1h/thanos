using Thanos.Common.Datastore;

namespace Thanos.Domains.Metadata;

public record Request (
    Account Account,
    Category Category,
    Kind Kind
);
