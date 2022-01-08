using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace CVGS_Site.Models
{
    public class CaptchaSolver
    {

        private readonly HttpClient client;

        public CaptchaSolver(HttpClient client)
        {
            this.client = client;
        }
        public async Task<bool> IsValid(string captcha)
        {
            try
            {
                var post = await client.PostAsync($"?secret=6LdisQEdAAAAAF3f8d3eNhDJ0tTzRxZzz4r1bx1d&response={captcha}", new StringContent(""));
                var result = await post.Content.ReadAsStringAsync();
                var resultObj = JObject.Parse(result);
                dynamic success = resultObj["success"];
                return (bool)success;
            }
            catch(Exception ex)
            {
                return false;
            }
        }
    }
}
