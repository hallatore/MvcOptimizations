using System.IO;
using System.Text;
using System.Text.RegularExpressions;

namespace MvcOptimizations
{
    public class HtmlMinifierFilter : MemoryStream
    {
        private readonly Stream response;
        public HtmlMinifierFilter(Stream response)
        {
            this.response = response;
        }

        public override void Write(byte[] buffer, int offset, int count)
        {
            var html = Encoding.UTF8.GetString(buffer);
            html = ReplaceTags(html);
            buffer = Encoding.UTF8.GetBytes(html);
            response.Write(buffer, offset, buffer.Length);
        }

        private static readonly Regex RegexRemoveWhitespace = new Regex(">[\r\n][ \r\n\t]*<", RegexOptions.Multiline | RegexOptions.Compiled);
        private static readonly Regex RegexRemoveWhitespace2 = new Regex(">[ \r\n\t]+<", RegexOptions.Multiline | RegexOptions.Compiled);

        private static string ReplaceTags(string html)
        {
            return RegexRemoveWhitespace2.Replace(RegexRemoveWhitespace.Replace(html, "><"), "> <");
        }
    }
}