using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;


namespace HTML_Extractor
{
    public class HtmlExtract
    {
        private HttpClient _client;


        public async Task<List<string>> CallURL(String url)
        {
            _client = new HttpClient();
            HttpResponseMessage response = await _client.GetAsync(url)
                .ConfigureAwait(false);
            response.EnsureSuccessStatusCode(); // 200 response
            string resposnebody = await response.Content.ReadAsStringAsync();
            List<string> listvalues = seperateValues(resposnebody);
            return listvalues;
        }

        public List<string> seperateValues(string s)
        {
            List<string> list = new List<string>();
            string regexImgSrc = @"<img[^>]*?src\s*=\s*[""']?([^'"" >]+?)[ '""][^>]*?>";
            MatchCollection collection =
                Regex.Matches(s, regexImgSrc, RegexOptions.IgnoreCase | RegexOptions.Singleline);
            foreach (Match item in collection)
            {
                string refernce = item.Groups[1].Value;
                list.Add(refernce);
            }
            return list;
        }

    }
}
