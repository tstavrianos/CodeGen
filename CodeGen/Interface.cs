using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using CodeGen.Building;

namespace CodeGen
{
    /// <summary>
    /// Represents an interface type.
    /// </summary>
    public sealed class Interface : Type
    {
        /// <summary>
        /// Gets the collection of members of this interface.
        /// </summary>
        // ReSharper disable once UnusedAutoPropertyAccessor.Local
        public IntMemberCollection Members { get; }
        public ICollection<string> Extends { get; }

        public Interface(string name) : base(name)
        {
            this.Extends = new Collection<string>();
            this.Members = new IntMemberCollection(this);

            this.Modifiers = Modifiers.Public;
        }

        public override void BuildCode(Builder builder)
        {
            base.BuildCode(builder);

            builder.Append("interface {0}", this.Name);

            if (this.Extends.Count > 0)
            {
                builder.Append(" : " + string.Join(",", this.Extends) + " ");
            }
            builder.AppendLine();

            builder.AppendLine("{");
            builder.EnterBlock();

            foreach (var prop in this.Members.OfType<IntProperty>())
            {
                prop.BuildCode(builder);
            }

            foreach (var method in this.Members.OfType<IntMethod>())
            {
                method.BuildCode(builder);
            }

            builder.LeaveBlock();
            builder.AppendLine("}");
        }
    }
}