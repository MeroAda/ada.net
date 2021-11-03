using Microsoft.VisualStudio.TestTools.UnitTesting;
using Ada.Net.Lib.Models.Blockfrost;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ada.Net.Lib.Models.Blockfrost.Tests
{
    [TestClass()]
    public class PoolRelaysTests
    {
        [TestMethod()]
        public async Task GetPoolRelaysTest()
        {
            var apiToken = Environment.GetEnvironmentVariable("BLOCKFROST_API_KEY");
            var poolId = "059b4217a24a8c67a363968ff1db13a17ed96e611362450c115b2415";

            PoolRelays pr = new PoolRelays(apiToken);

            var relays = await pr.GetPoolRelays(poolId);

            if(relays == null)
                Assert.Fail();
        }
    }
}