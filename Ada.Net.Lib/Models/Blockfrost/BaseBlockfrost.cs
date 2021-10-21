using System;
using System.Collections.Generic;
using System.Text;

namespace Ada.Net.Lib.Models.Blockfrost
{
    public class BaseBlockfrost
    {

        protected string BaseUrl = "https://cardano-mainnet.blockfrost.io/api/v0";
        protected readonly string _apiToken;


        public BaseBlockfrost(string ApiToken)
        {
            _apiToken = ApiToken;
        }

    }
}
