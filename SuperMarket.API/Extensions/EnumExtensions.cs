using System.Reflection;
using System.ComponentModel;

namespace SuperMarket.API.Extensions

{
    public static class EnumExtensions
    {
        public static string ToDescriptionString<TEnum>(this TEnum @enum)
        {
            FieldInfo info = @enum.GetType().GetField(@enum.ToString());
            var attributes = (DescriptionAttribute[]) info.GetCustomAttributes(
                typeof(DescriptionAttribute), false);
            return attributes?[0].Description ?? @enum.ToString();
        }
    }
}