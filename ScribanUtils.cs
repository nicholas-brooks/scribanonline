using System;
using System.Linq;
using Scriban;

namespace scribanonline
{
    public static class ScribanUtils
    {
        public static string Render(string templateStr, object obj = null)
        {
            var template = Template.Parse(templateStr);
            if (template.HasErrors)
                throw new Exception(string.Join("\n", template.Messages.Select(x => $"{x.Message} at {x.Span.ToStringSimple()}")));
            return template.Render(obj, member => LowerFirstCharacter(member.Name));
        }

        private static string LowerFirstCharacter(string value)
        {
            if (value.Length > 1)
                return char.ToLower(value[0]) + value.Substring(1);
            return value;
        }
    }
}