using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tests
{
    [TestClass()]
    public class AllianceMembersTests
    {
        [TestMethod()]
        public async Task LoadxSpoAllianceMembersTest()
        {
            var members = await AllianceMembers.LoadxSpoAllianceMembers();

            if(members == null)
                Assert.Fail();
        }
    }
}