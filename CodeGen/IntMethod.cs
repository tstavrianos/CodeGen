using CodeGen.Building;

namespace CodeGen
{
    /// <summary>
    /// Represents a method.
    /// </summary>
    public sealed class IntMethod : IntMember
    {
        /// <summary>
        /// Gets or sets the parameters of this method.
        /// </summary>
        public string Parameters { get; set; }
    
        public IntMethod(string type, string name) : base(type, name)
        {
        }
    
        public override void BuildCode(Builder builder)
        {
            //base.BuildCode(builder);
    
            builder.AppendLine("{0} {1} ({2});", this.Type, this.Name, this.Parameters);
        }
    }
}