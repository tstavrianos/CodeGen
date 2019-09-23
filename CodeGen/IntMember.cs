using CodeGen.Building;

namespace CodeGen
{
    /// <summary>
    /// Provides common properties to all class or interface members.
    /// </summary>
    public abstract class IntMember : Item
    {
        /// <summary>
        /// Gets the type of this member.
        /// </summary>
        public string Type { get; }

        protected IntMember(string type, string name) : base(name)
        {
            BuilderHelper.ValidateMemberName(name);

            this.Type = type;
        }

        public override void BuildCode(Builder builder)
        {
            base.BuildCode(builder);
        }
    }
}