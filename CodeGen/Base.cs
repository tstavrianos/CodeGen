using System.Collections.Generic;
using System.Collections.ObjectModel;
using CodeGen.Building;

namespace CodeGen
{
    /// <summary>
    /// Represents the whole code base.
    /// </summary>
    public sealed class Base
    {
        /// <summary>
        /// Gets the collection of namespace names to be built into using statements.
        /// </summary>
        public ICollection<string> Using { get; }

        /// <summary>
        /// Gets the collection of all namespaces in this code base.
        /// </summary>
        public NamespaceCollection Namespaces { get; }
        
        /// <summary>
        /// The comment printed above this artifact.
        /// </summary>
        public string Comment { get; set; }

        public Base()
        {
            this.Using = new Collection<string>();
            this.Namespaces = new NamespaceCollection(this);
        }

        public string BuildCode(bool singleFile)
        {
            var builder = new Builder();
            builder.Options.SingleFile = singleFile;

            builder.AppendComment(this.Comment);
            if (this.Using.Count > 0)
            {
                foreach (var u in this.Using)
                {
                    builder.AppendLine("using {0};", u);
                }
                builder.AppendLine();
            }

            foreach (var ns in this.Namespaces)
            {
                ns.BuildCode(builder);
            }

            return builder.ToString();
        }
    }
}