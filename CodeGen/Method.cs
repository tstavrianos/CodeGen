using CodeGen.Building;

namespace CodeGen
{
    /// <summary>
        /// Represents a method.
        /// </summary>
        public sealed class Method : Member
        {
            /// <summary>
            /// Gets the CodeBuilder instance used to build the body of this method.
            /// </summary>
            public Builder Body { get; set; }
    
            /// <summary>
            /// Gets or sets the parameters of this method.
            /// </summary>
            public string Parameters { get; set; }
    
            public string ConstructorInvocation { get; set; }
    
            public Method(string type, string name) : base(type, name)
            {
            }
    
            public override void BuildCode(Builder builder)
            {
                base.BuildCode(builder);
    
                if (this.Type != null)
                {
                    builder.Append(this.Type + " ");
                }
    
                if (this.Name != null)
                {
                    builder.Append(this.Name);
                }
    
                builder.Append("({0})", this.Parameters);
    
                if (this.ConstructorInvocation != null)
                {
                    builder.Append(" : " + this.ConstructorInvocation);
                }
                builder.AppendLine();
    
                builder.AppendLine("{");
                builder.EnterBlock();
    
                if (this.Body != null)
                {
                    builder.Append(this.Body.ToString());
                }
                builder.LeaveBlock();
                builder.AppendLine("}");
            }
        }
}