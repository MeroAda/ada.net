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
            var poolId = "72770c5d9dbf120676a6293d921fd7eeee454409620c3fdb671a405a";

            PoolRelays pr = new PoolRelays(apiToken);

            var relays = await pr.GetPoolRelays(poolId);

            if(relays == null)
                Assert.Fail();
        }
    }
}