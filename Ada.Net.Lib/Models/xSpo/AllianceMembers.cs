using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
public class AllianceMembers
{
    [JsonProperty("adapools")]
    public AdaPoolsInfo AdaPools { get; set; }


    private static string _membersUrlJson = "https://raw.githubusercontent.com/xSPO-Alliance/adapools-xspo-alliance/main/xspo-alliance-members.json";

    public static async Task<AllianceMembers> LoadxSpoAllianceMembers()
    {
        try
        {
            using (HttpClient client = new HttpClient())
            {
                //Create headers
                client.DefaultRequestHeaders.UserAgent.ParseAdd("Mozilla/5.0");
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

                var res = await client.GetAsync(_membersUrlJson);

                if (res.IsSuccessStatusCode)
                {
                    var data = await res.Content.ReadAsStringAsync();

                    var hardData = JsonConvert.DeserializeObject<AllianceMembers>(data);

                    if(hardData != null && hardData.AdaPools != null && hardData.AdaPools.Members != null)
                    {
                        JObject o = JObject.Parse(data);
                        hardData.AdaPools.Members.List = o["adapools"]["members"].ToObject<Dictionary<string, MembersDetails>>();
                        return hardData;
                    }
                    else
                    {
                        return null;
                    }
                }
                else
                {
                    return null;
                }
            }
        }
        catch(Exception err)
        {
            throw new Exception($"Could not load alliance members - {err.Message}");
        }
    }
}


public class AdaPoolsInfo
{
    [JsonProperty("about")]
    public AboutInfo About { get; set; }

    [JsonProperty("types")]
    public PoolTypesInfo PoolType { get; set; }

    [JsonProperty("members")]
    public MembersInfo Members { get; set; }
}

public class AboutInfo
{
    [JsonProperty("name")]
    public string Name { get; set; }

    [JsonProperty("description_short")]
    public string ShortDescription { get; set; }

    [JsonProperty("description_long")]
    public string LongDescription { get; set; }

    [JsonProperty("website")]
    public string Website { get; set; }

    [JsonProperty("url_png_icon_64x64")]
    public string UrlPngIcon64x64 { get; set; }

    [JsonProperty("url_png_logo")]
    public string UrlPngLogo { get; set; }
}

public class SocialMedias
{
    [JsonProperty("twitter_handle")]
    public string Twitter { get; set; }

    [JsonProperty("telegram_handle")]
    public string Telegram { get; set; }

    [JsonProperty("facebook_handle")]
    public string Facebook { get; set; }

    [JsonProperty("youtube_handle")]
    public string Youtube { get; set; }

    [JsonProperty("twitch_handle")]
    public string Twitch { get; set; }

    [JsonProperty("discord_handle")]
    public string Discord { get; set; }

    [JsonProperty("github_handle")]
    public string GitHub { get; set; }
}

public class PoolTypesInfo
{
    [JsonProperty("charity")]
    public string Charity { get; set; }

    [JsonProperty("business")]
    public string Business { get; set; }

    [JsonProperty("beneficial")]
    public string Beneficial { get; set; }
}

public class MembersInfo
{
    [JsonProperty()]
    public Dictionary<string, MembersDetails> List { get; set; }
}

public class MembersDetails
{
    [JsonProperty("pool_id")]
    public string PoolId { get; set; }

    [JsonProperty("member_since")]
    public string MemberSince { get; set; }

    [JsonProperty("name")]
    public string Name { get; set; }
}