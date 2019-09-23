using CodeGen.Building;

namespace CodeGen
{
    /// <summary>
    /// Represents a property.
    /// </summary>
    public sealed class Property : Member
    {
        /// <summary>
        /// Gets the StringBuilder instance used to build the body of the getter of this method.
        /// </summary>
        public PropertyAccessor Getter { get; set; }

        /// <summary>
        /// Gets the StringBuilder instance used to build the body of the setter of this method.
        /// </summary>
        public PropertyAccessor Setter { get; set; }

        public Property(string type, string name) : base(type, name)
        {
            this.Modifiers = Modifiers.Public;
        }

        public override void BuildCode(Builder builder)
        {
            base.BuildCode(builder);

            builder.AppendLine("{0} {1}", this.Type, this.Name);

            builder.AppendLine("{");
            builder.EnterBlock();
            if (this.Getter != null)
            {
                builder.Append(BuilderHelper.ModifiersToString(this.Getter.Modifiers));
                builder.Append("get");
                string body = this.Getter.Body.ToString();
                if (body.Length == 0)
                {
                    builder.AppendLine("; ");
                }
                else
                {
                    builder.AppendLine();
                    builder.AppendLine("{");
                    builder.EnterBlock();
                    builder.Append(body);
                    builder.LeaveBlock();
                    builder.AppendLine("}");
                }
            }
            if (this.Setter != null)
            {
                builder.Append(BuilderHelper.ModifiersToString(this.Setter.Modifiers));
                builder.Append("set");
                string body = this.Setter.Body.ToString();
                if (body.Length == 0)
                {
                    builder.AppendLine("; ");
                }
                else
                {
                    builder.AppendLine();
                    builder.AppendLine("{");
                    builder.EnterBlock();
                    builder.Append(body);
                    builder.LeaveBlock();
                    builder.AppendLine("}");
                }
            }
            builder.LeaveBlock();
            builder.AppendLine("}");
        }
    }
}