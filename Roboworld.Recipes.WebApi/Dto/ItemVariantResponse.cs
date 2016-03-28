namespace Roboworld.Recipes.WebApi.Dto
{
    public class ItemVariantResponse
    {
        public virtual int Id { get; set; }

        public virtual string ItemModSlug { get; set; }

        public virtual string ItemSlug { get; set; }

        public virtual string Metadata { get; set; }
    }
}