using System;
using System.Collections.Generic;
using System.Linq;

namespace CodeGen.Building
{
    public static class BuilderHelper
    {
        public static string ModifiersToString(Modifiers modifiers)
        {
            return string.Join("",
                System.Enum.GetValues(modifiers.GetType()).Cast<System.Enum>()
                    .Where(v => modifiers.HasFlag(v) && Convert.ToInt64(v) != 0)
                    .Select(v => v.ToString().ToLower() + " "));
        }

        public static void ValidateTypeName(string name)
        {
            // TODO: Ensure type name is valid
        }

        public static void ValidateMemberName(string name)
        {
            // TODO: Ensure member name is valid
        }

        public static void ValidateNamespaceName(string name)
        {
            // TODO: Ensure namespace name is valid
        }

        public static void ValidateNameUniqueInCollection(string name, ICollection<Item> collection)
        {
            // TODO: Ensure name is unique in the collection
        }

        public static void ValidateNameNotEqualToOwner(string name, Item owner)
        {
            // TODO: Ensure name is not equal to that of the owner
        }
    }
}