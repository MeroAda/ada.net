using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net;
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
        public string ipv6 { get; set; }
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

                        List<PoolRelays> moreRelays = null;
                        foreach (var p in poolRelays)
                        {
                            if(p.ipv4 == null && p.ipv6 == null && p.dns != null)
                            {
                                //try to do a dns lookup
                                var ips = Dns.GetHostAddresses(p.dns);

                                moreRelays = new List<PoolRelays>();
                                foreach(var ip in ips)
                                {
                                    moreRelays.Add(new PoolRelays(null)
                                    {
                                        ipv4 = ip.ToString()
                                    });
                                }
                            }
                        }
                        if(moreRelays != null)
                        {
                            poolRelays.AddRange(moreRelays);
                        }

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
