using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Ada.Net.Lib.Models.AdaPools
{
    public class StakePool
    {

        private static string _poolDetailsUrl = "https://js.adapools.org/pools/<<POOL_ID>>/summary.json";

        public static async Task<StakePool> LoadStakePooleDetailsAsync(string PoolId)
        {
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    //Create headers
                    client.DefaultRequestHeaders.UserAgent.ParseAdd("Mozilla/5.0");
                    client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

                    var res = await client.GetAsync(_poolDetailsUrl.Replace("<<POOL_ID>>", PoolId));

                    if (res.IsSuccessStatusCode)
                    {
                        var stakePoolDets = JsonConvert.DeserializeObject<StakePool>(await res.Content.ReadAsStringAsync());

                        return stakePoolDets;
                    }
                    else
                    {
                        return null;
                    }
                }
            }
            catch (Exception err)
            {
                throw new Exception($"Could not load stake pool with id {PoolId} - {err.Message}");
            }
        }

        [JsonProperty("created")]
        public DateTime Created { get; set; }

        [JsonProperty("data")]
        public Data Data { get; set; }

        [JsonProperty("updated")]
        public DateTime Updated { get; set; }
    }

    public class Data
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("pool_id")]
        public string PoolId { get; set; }

        [JsonProperty("pool_id_bech32")]
        public string PoolIdBech32 { get; set; }

        [JsonProperty("db_ticker")]
        public string DbTicker { get; set; }

        [JsonProperty("db_name")]
        public string DbName { get; set; }

        [JsonProperty("db_url")]
        public string DbUrl { get; set; }

        [JsonProperty("total_stake")]
        public long TotalStake { get; set; }

        [JsonProperty("rewards_epoch")]
        public string RewardsEpoch { get; set; }

        [JsonProperty("tax_ratio")]
        public double TaxRatio { get; set; }

        [JsonProperty("tax_fix")]
        public long TaxFix { get; set; }

        [JsonProperty("roa")]
        public string Roa { get; set; }

        [JsonProperty("blocks_epoch")]
        public long BlocksEpoch { get; set; }

        [JsonProperty("bocks_lifetime")]
        public long BlocksLifetime { get; set; }

        [JsonProperty("blocks_est_lifetime")]
        public long BlocksEstLifetime { get; set; }

        [JsonProperty("stamp_strike")]
        public string StampStrike { get; set; }

        [JsonProperty("hist_roa")]
        public string HistRoa { get; set; }

        [JsonProperty("hist_bpe")]
        public string HistBpe { get; set; }

        [JsonProperty("pledge")]
        public long Pledge { get; set; }

        [JsonProperty("hash_id")]
        public string HashId { get; set; }

        [JsonProperty("ticker_orig")]
        public string TickerOrig { get; set; }

        [JsonProperty("metric")]
        public int Metric { get; set; }

        [JsonProperty("delegators")]
        public string Delegators { get; set; }

        [JsonProperty("pledged")]
        public string Pledged { get; set; }

        [JsonProperty("roa_lifetime")]
        public string RoaLifetime { get; set; }

        [JsonProperty("luck_lifetime")]
        public string LuckLifetime { get; set; }

        [JsonProperty("group_basic")]
        public string GroupBasic { get; set; }

        [JsonProperty("tax_ratio_old")]
        public string TaxRatioOld { get; set; }

        [JsonProperty("tax_fix_old")]
        public string TaxFixOld { get; set; }

        [JsonProperty("tax_real")]
        public double TaxReal { get; set; }

        [JsonProperty("active_stake")]
        public long ActiveStake { get; set; }

        [JsonProperty("active_blocks")]
        public int ActiveBlocks { get; set; }

        [JsonProperty("direct")]
        public bool Direct { get; set; }

        [JsonProperty("saturated")]
        public double Saturated { get; set; }

        [JsonProperty("patreon")]
        public int Patreon { get; set; }

        [JsonProperty("rank")]
        public int Rank { get; set; }

        [JsonProperty("handles")]
        public Handles Handles { get; set; }

        [JsonProperty("blocks_estimated")]
        public int BlocksEstimated { get; set; }

        [JsonProperty("stake_x_deleg")]
        public double StakeXDeleg { get; set; }

        [JsonProperty("db_description")]
        public string DbDescription { get; set; }

        [JsonProperty("owners")]
        public string Owners { get; set; }
    }

    public class Handles
    {
        [JsonProperty("tw")]
        public string Twitter { get; set; }

        [JsonProperty("tg")]
        public string Telegram { get; set; }

        [JsonProperty("fb")]
        public string Facebook { get; set; }

        [JsonProperty("yt")]
        public string YouTube { get; set; }

        [JsonProperty("tc")]
        public string Twitch { get; set; }

        [JsonProperty("di")]
        public string Discord { get; set; }

        [JsonProperty("gh")]
        public string GitHub { get; set; }

        [JsonProperty("icon")]
        public string Icon { get; set; }
    }
}
