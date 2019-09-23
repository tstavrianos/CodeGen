using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using CodeGen.Building;

namespace CodeGen
{
    /// <summary>
    /// Represets a class type.
    /// </summary>
    public sealed class Class : Type
    {
        /// <summary>
        /// Gets the collection of types that are nested within this class.
        /// </summary>
        public TypeCollection Types { get; }

        /// <summary>
        /// Gets the collection of members of this class.
        /// </summary>
        public MemberCollection Members { get; }

        /// <summary>
        /// Gets the collection of type names this class implements or inherits.
        /// </summary>
        public ICollection<string> Extends { get; }

        public Class(string name) : base(name)
        {
            this.Extends = new Collection<string>();
            this.Types = new TypeCollection(this);
            this.Members = new MemberCollection(this);

            this.Modifiers = Modifiers.Public;
        }

        public override void BuildCode(Builder builder)
        {
            base.BuildCode(builder);

            builder.Append("class {0}", this.Name);

            if (this.Extends.Count > 0)
            {
                builder.Append(" : " + string.Join(",", this.Extends) + " ");
            }
            builder.AppendLine();

            builder.AppendLine("{");
            builder.EnterBlock();

            foreach (var field in this.Members.OfType<Field>())
            {
                field.BuildCode(builder);
            }

            foreach (var prop in this.Members.OfType<Property>())
            {
                prop.BuildCode(builder);
            }

            foreach (var method in this.Members.OfType<Method>())
            {
                method.BuildCode(builder);
            }

            foreach (var type in this.Types)
            {
                type.BuildCode(builder);
            }

            builder.LeaveBlock();
            builder.AppendLine("}");
        }

    }
}