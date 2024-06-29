namespace Thanos.Common.Datastore;

public record Category (
    string CategoryId,
    string Display
){
    public List<Category> SubCategory { get; set; } = [];
};

public record Tag (
    string TagId,
    string Display
){
    public List<Tag> SubTag { get; set; } = [];
}
