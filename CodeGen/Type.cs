using CodeGen.Building;

namespace CodeGen
{
    public abstract class Type : Item
    {
        protected Type(string name) : base(name)
        {
            BuilderHelper.ValidateTypeName(name);
        }

        public override void BuildCode(Builder builder)
        {
            base.BuildCode(builder);
        }
    }
}