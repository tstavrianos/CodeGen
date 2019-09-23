using System.Collections.ObjectModel;

namespace CodeGen
{
    /// <summary>
    /// Represents a collection of namespaces.
    /// </summary>
    public sealed class NamespaceCollection : Collection<Namespace>
    {
        /// <summary>
        /// Gets the code base that owns this collection of namespaces.
        /// </summary>
        public Base Owner { get; }

        public NamespaceCollection(Base owner)
        {
            this.Owner = owner;
        }

        protected override void InsertItem(int index, Namespace item)
        {
            base.InsertItem(index, item);
        }
    }
}