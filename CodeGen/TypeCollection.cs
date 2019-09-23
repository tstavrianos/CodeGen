using System.Collections.ObjectModel;
using CodeGen.Building;

namespace CodeGen
{
    /// <summary>
    /// Represents a collection of types.
    /// </summary>
    public sealed class TypeCollection : Collection<Type>
    {
        /// <summary>
        /// Gets the namespace or parent type that owns this collection of types.
        /// </summary>
        public Item Owner { get; }

        public TypeCollection(Item owner)
        {
            this.Owner = owner;
        }

        protected override void InsertItem(int index, Type item)
        {
            BuilderHelper.ValidateNameNotEqualToOwner(item.Name, this.Owner);

            base.InsertItem(index, item);
        }
    }
}