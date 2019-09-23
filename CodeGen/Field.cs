using CodeGen.Building;

namespace CodeGen
{
    /// <summary>
    /// Represents a class field.
    /// </summary>
    public sealed class Field : Member
    {
        /// <summary>
        /// Gets or sets the value used to initialize this field or null if the field is not initialized.
        /// </summary>
        public string Value { get; set; }

        public Field(string type, string name) : base(type, name)
        {
            this.Modifiers = Modifiers.Private;
        }

        public override void BuildCode(Builder builder)
        {
            base.BuildCode(builder);

            builder.Append("{0} {1}", this.Type, this.Name);

            if (!string.IsNullOrEmpty(this.Value))
            {
                builder.Append(this.Type == "string" ? " = \"{0}\"" : " = {0}", this.Value);
            }
            builder.AppendLine(";");
        }
    }
}