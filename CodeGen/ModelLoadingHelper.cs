using System.Collections.Generic;
using System.Linq;

namespace CodeGen
{
    public static class ModelLoadingHelper
    {
        private static readonly Dictionary<string, System.Type> EnumTypes = new Dictionary<string, System.Type>
        {
            { "int", typeof(int) },
            { "uint", typeof(uint) },
            { "short", typeof(short) },
            { "ushort", typeof(ushort) },
            { "byte", typeof(byte) },
            { "sbyte", typeof(sbyte) }
        };

        public static string GetEnumTypeName(System.Type type)
        {
            return EnumTypes.Where(t => t.Value == type).Select(t => t.Key).FirstOrDefault();
        }
    }
}