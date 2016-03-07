namespace Roboworld.Recipes.WebApi.Orm
{
    public class Mod
    {
        public virtual int Id { get; set; }

        public virtual string Slug { get; set; }

        public virtual string Version { get; set; }

        public virtual string Name { get; set; }
    }
}