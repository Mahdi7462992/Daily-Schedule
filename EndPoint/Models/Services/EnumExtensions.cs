using System.ComponentModel.DataAnnotations;

namespace EndPoint.Models.Services
{
    public static class EnumExtensions
    {
        public static string GetDisplayName(this Enum enumValue)
        {
            var enumType = enumValue.GetType();
            var member = enumType.GetMember(enumValue.ToString());
            var attributes = member[0].GetCustomAttributes(typeof(DisplayAttribute), false);

            return attributes.Length > 0 ? ((DisplayAttribute)attributes[0]).Name : enumValue.ToString();
        }
    }
}
