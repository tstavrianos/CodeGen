using CodeGen.Building;

namespace CodeGen
{
    public sealed class PropertyAccessor
    {
        public Builder Body { get; }
        public Modifiers Modifiers { get; set; }

        public PropertyAccessor()
        {
            this.Body = new Builder();
        }

        public PropertyAccessor(string code)
        {
            this.Body = new Builder(code);
        }

        public static implicit operator PropertyAccessor(string code)
        {
            return new PropertyAccessor(code);
        }
    }
}