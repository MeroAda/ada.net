using Microsoft.VisualStudio.TestTools.UnitTesting;
using Ada.Net.Lib.Models.AdaPools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ada.Net.Lib.Models.AdaPools.Tests
{
    [TestClass()]
    public class StakePoolTests
    {
        [TestMethod()]
        public async Task LoadStakePooleDetailsAsyncTest()
        {

            var pool = await StakePool.LoadStakePooleDetailsAsync("72770c5d9dbf120676a6293d921fd7eeee454409620c3fdb671a405a");

            if (pool == null)
                Assert.Fail();
        }
    }
}