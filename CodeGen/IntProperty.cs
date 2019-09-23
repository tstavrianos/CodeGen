using CodeGen.Building;

namespace CodeGen
{
    /// <summary>
    /// Represents a property.
    /// </summary>
    public sealed class IntProperty : IntMember
    {
        /// <summary>
        /// Gets the StringBuilder instance used to build the body of the getter of this method.
        /// </summary>
        public bool Getter { get; set; }

        /// <summary>
        /// Gets the StringBuilder instance used to build the body of the setter of this method.
        /// </summary>
        public bool Setter { get; set; }

        public IntProperty(string type, string name) : base(type, name)
        {
            this.Modifiers = Modifiers.Public;
        }

        public override void BuildCode(Builder builder)
        {
            //base.BuildCode(builder);

            builder.AppendLine("{0} {1} {{ {2} {3} }}", this.Type, this.Name, this.Getter ? "get;" : "", this.Setter ? "set;" : "");
        }
    }
}