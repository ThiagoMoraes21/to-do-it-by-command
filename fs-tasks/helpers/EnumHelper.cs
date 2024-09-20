
using System.ComponentModel;

namespace to_do_it_by_command.fs_tasks.helpers
{
    public static class EnumHelper
    {

        public static T GetEnumValueFromDescription<T>(string description) where T : Enum
        {

            foreach (var field in typeof(T).GetFields())
            {
                var attribute = (DescriptionAttribute)Attribute.GetCustomAttribute(field, typeof(DescriptionAttribute));

                if (attribute != null && attribute.Description == description)
                {
                    return (T)field.GetValue(null);
                }
            }

            throw new ArgumentException("Not found", nameof(description));


        }

        public static string GetEnumDescription(Enum data)
        {
            var field = data.GetType().GetField(data.ToString());
            var desAttribute = field?.GetCustomAttributes(typeof(DescriptionAttribute), false) as DescriptionAttribute[];

            if (desAttribute?.Length > 0)
            {
                return desAttribute[0].Description;
            }

            return string.Empty;
        }
    }
}