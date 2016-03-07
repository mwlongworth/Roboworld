namespace Roboworld.Recipes.WebApi.Orm
{
    public class CraftingProcess
    {
        public virtual int Id { get; set; }

        public virtual string Name { get; set; }

        public virtual CraftingProcessType Type { get; set; }
    }
}