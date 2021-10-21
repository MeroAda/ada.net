using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Ada.Net.Lib.Models.Blockfrost
{
    public class PoolRelays : BaseBlockfrost
    {
        public PoolRelays(string ApiToken) : base(ApiToken)
        {}

        public string ipv4 { get; set; }
        public string piv6 { get; set; }
        public string dns { get; set; }
        public string dns_srv { get; set; }
        public int port { get; set; }

        public async Task<List<PoolRelays>> GetPoolRelays(string PoolId)
        {
            string path = "/pools/<<POOL_ID>>/relays";

            try
            {
                using (HttpClient client = new HttpClient())
                {
                    //Create headers
                    client.DefaultRequestHeaders.UserAgent.ParseAdd("Mozilla/5.0");
                    client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                    client.DefaultRequestHeaders.Add("project_id", _apiToken);

                    var res = await client.GetAsync(BaseUrl + path.Replace("<<POOL_ID>>", PoolId));

                    if (res.IsSuccessStatusCode)
                    {
                        var poolRelays = JsonConvert.DeserializeObject<List<PoolRelays>>(await res.Content.ReadAsStringAsync());

                        return poolRelays;
                    }
                    else
                    {
                        return null;
                    }
                }
            }
            catch (Exception err)
            {
                throw new Exception($"Could not load stake pool relays with pool id {PoolId} - {err.Message}");
            }

        }



    }
}
