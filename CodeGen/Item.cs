using CodeGen.Building;

namespace CodeGen
{
    /// <summary>
    /// Provides common properties to all code artifacts.
    /// </summary>
    public abstract class Item
    {
        /// <summary>
        /// The name of this code artifact.
        /// </summary>
        public string Name { get; }

        /// <summary>
        /// The comment printed above this artifact.
        /// </summary>
        public string Comment { get; set; }

        /// <summary>
        /// Gets or sets the modifiers of this artefact.
        /// </summary>
        public Modifiers Modifiers { get; set; }

        protected Item(string name)
        {
            this.Name = name;
        }

        public virtual void BuildCode(Builder builder)
        {
            builder.AppendComment(this.Comment);
            builder.Append(BuilderHelper.ModifiersToString(this.Modifiers));
        }
    }
}