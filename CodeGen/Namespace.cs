using System.Linq;
using CodeGen.Building;

namespace CodeGen
{
    /// <summary>
    /// Represents a namespace.
    /// </summary>
    public sealed class Namespace : Item
    {
        /// <summary>
        /// Gets the collection of types in this namespace.
        /// </summary>
        public TypeCollection Types { get; }

        public Namespace(string name) : base(name)
        {
            BuilderHelper.ValidateNamespaceName(name);

            this.Types = new TypeCollection(this);
        }

        public override void BuildCode(Builder builder)
        {
            base.BuildCode(builder);

            builder.AppendLine("namespace {0}", this.Name);
            builder.AppendLine("{");
            builder.EnterBlock();

            foreach (var e in this.Types.OfType<Enum>())
            {
                e.BuildCode(builder);
            }

            foreach (var cls in this.Types.OfType<Interface>())
            {
                cls.BuildCode(builder);
            }

            foreach (var cls in this.Types.OfType<Class>())
            {
                cls.BuildCode(builder);
            }

            foreach (var cls in this.Types.OfType<Struct>())
            {
                cls.BuildCode(builder);
            }

            builder.LeaveBlock();
            builder.AppendLine("}");
        }
    }
}