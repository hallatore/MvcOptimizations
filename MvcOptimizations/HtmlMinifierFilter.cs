using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;

namespace MvcOptimizations
{
    public class HtmlMinifierFilter : MemoryStream
    {
        private readonly Stream _response;
        public HtmlMinifierFilter(Stream response)
        {
            _response = response;
        }

        public override void Write(byte[] buffer, int offset, int count)
        {
            var resp = HttpContext.Current.Response;
            var charset = resp.Charset ?? "utf-8";
            var encoding = Encoding.GetEncoding(charset);
            var html = encoding.GetString(buffer);
            html = RegexRemoveWhitespace2.Replace(RegexRemoveWhitespace.Replace(html, "><"), "> <");
            buffer = encoding.GetBytes(html);
            _response.Write(buffer, offset, buffer.Length);
        }

        private static readonly Regex RegexRemoveWhitespace = new Regex(">[\r\n][ \r\n\t]*<", RegexOptions.Multiline | RegexOptions.Compiled);
        private static readonly Regex RegexRemoveWhitespace2 = new Regex(">[ \r\n\t]+<", RegexOptions.Multiline | RegexOptions.Compiled);
    }
}