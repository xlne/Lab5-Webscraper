using System;
using System.Collections.Generic;
using System.Net.Http;
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
            string responseBody = await response.Content.ReadAsStringAsync();
            List<string> listvalues = seperateValues(responseBody, url);
            return listvalues;
        }

        public List<string> seperateValues(string s, string inputURL)
        {
            List<string> list = new List<string>();

            string regexImgSrc = @"<img[^>]*?src\s*=\s*[""']?([^'"" >]+?)[ '""][^>]*?>";

            MatchCollection collection =
                Regex.Matches(s, regexImgSrc, RegexOptions.IgnoreCase | RegexOptions.Singleline);

            foreach (Match item in collection)
            {
                string imageURL = item.Groups[1].Value;

                //Double slashes indicates that the pictures are downloading from another domain
                bool isAnotherDomain = imageURL.Contains("//"); 
                bool hasHTTPS = imageURL.Contains("https:");
                bool hasHTTP = imageURL.Contains("http:");

                string url = null;
                if (isAnotherDomain)
                {
                    if (hasHTTPS || hasHTTP)
                        url = imageURL;
                    else
                        url = "https:" + imageURL;
                }
                else
                    url = inputURL + imageURL;

                Match formatMatch = Regex.Match(url, @"\.(bmp|png|gif|jpg|jpeg)",
                            RegexOptions.IgnoreCase);

                if (formatMatch.Success)
                    list.Add(url);
            }
            return list;
        }
    }
}
