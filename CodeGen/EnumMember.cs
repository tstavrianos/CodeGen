using CodeGen.Building;

namespace CodeGen
{
    /// <summary>
    /// Represent an enum member.
    /// </summary>
    public sealed class EnumMember : Item
    {
        public string Value { get; set; }

        public EnumMember(string name, string value) : base(name)
        {
            BuilderHelper.ValidateMemberName(name);

            this.Value = value;
        }

        public override void BuildCode(Builder builder)
        {
            base.BuildCode(builder);

            builder.Append("{0} = {1}", this.Name, this.Value);
        }
    }
}