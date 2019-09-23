using CodeGen.Building;

namespace CodeGen
{
    /// <summary>
    /// Represets an enum type.
    /// </summary>
    public sealed class Enum : Type
    {
        /// <summary>
        /// Gets or sets the underlying type of this enum.
        /// </summary>
        public System.Type Type { get; set; }

        /// <summary>
        /// Gets the collection of members of this enum.
        /// </summary>
        public EnumMemberCollection Members { get; }

        public Enum(string name) : base(name)
        {
            this.Members = new EnumMemberCollection(this);

            this.Modifiers = Modifiers.Public;
        }

        public override void BuildCode(Builder builder)
        {
            base.BuildCode(builder);

            builder.AppendLine("enum {0} : {1}", this.Name, ModelLoadingHelper.GetEnumTypeName(this.Type));
            builder.AppendLine("{");
            builder.EnterBlock();

            bool first = true;
            foreach (var member in this.Members)
            {
                if (first)
                {
                    first = false;
                }
                else
                {
                    builder.AppendLine(",");
                }

                member.BuildCode(builder);
            }
            builder.AppendLine("");

            builder.LeaveBlock();
            builder.AppendLine("}");
        }

    }
}