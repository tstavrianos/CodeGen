using System.Collections.ObjectModel;
using CodeGen.Building;

namespace CodeGen
{
    /// <summary>
    /// Represents a mixed collection of members including fields, properties and methods.
    /// </summary>
    public sealed class IntMemberCollection : Collection<IntMember>
    {
        /// <summary>
        /// Gets the owner of this collection of members.
        /// </summary>
        public Type Owner { get; }

        public IntMemberCollection(Type owner)
        {
            this.Owner = owner;
        }

        protected override void InsertItem(int index, IntMember item)
        {
            BuilderHelper.ValidateNameNotEqualToOwner(item.Name, this.Owner);

            base.InsertItem(index, item);
        }
    }
}