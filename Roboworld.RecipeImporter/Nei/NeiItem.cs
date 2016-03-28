// --------------------------------------------------------------------------------------------------------------------
// <copyright file="NeiItem.cs" company="Matthew Longworth">
//   (c) Matthew Longworth 2016
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Roboworld.RecipeImporter.Nei
{
    /// <summary>
    /// An item from NEI
    /// </summary>
    public class NeiItem
    {
        public string Mod { get; set; }

        public string Name { get; set; }

        public int ItemId { get; set; }

        protected bool Equals(NeiItem other)
        {
            return string.Equals(this.Mod, other.Mod) && string.Equals(this.Name, other.Name) && this.ItemId == other.ItemId;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj))
            {
                return false;
            }
            if (ReferenceEquals(this, obj))
            {
                return true;
            }
            if (obj.GetType() != this.GetType())
            {
                return false;
            }
            return this.Equals((NeiItem)obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = (this.Mod != null ? this.Mod.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (this.Name != null ? this.Name.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ this.ItemId;
                return hashCode;
            }
        }
    }
}