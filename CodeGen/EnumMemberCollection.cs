using System.Collections.ObjectModel;
using CodeGen.Building;

namespace CodeGen
{
    /// <summary>
    /// Represents a collection of enum members.
    /// </summary>
    public sealed class EnumMemberCollection : Collection<EnumMember>
    {
        /// <summary>
        /// Gets the enum that owns this collection of enum members.
        /// </summary>
        public Enum Owner { get; }

        public EnumMemberCollection(Enum owner)
        {
            this.Owner = owner;
        }

        protected override void InsertItem(int index, EnumMember item)
        {
            BuilderHelper.ValidateNameNotEqualToOwner(item.Name, this.Owner);

            base.InsertItem(index, item);
        }
    }
}