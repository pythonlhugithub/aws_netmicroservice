using agslp_tigger.EntityCalss;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Net.Http;

namespace agslp_tigger
{
    public class GateRR
    {
        //public string CallRR(string itemid) {

        //    try
        //    {
        //        string axieapi = "https://game-api.skymavis.com/game-api/clients/0xdeb69adf6bce379b9376d98b0fbe67a1b0d74700/items/" + itemid;

        //        HttpClient hc = new HttpClient();
                
        //        hc.BaseAddress = new Uri(axieapi);

        //        //hc.MaxResponseContentBufferSize = 2000000;

        //        JavaScriptSerializer ser = new JavaScriptSerializer();

        //        var usresulter0 = hc.GetStringAsync(hc.BaseAddress).Result;

        //        if (usresulter0 != null)
        //        {

        //            return usresulter0;
        //        }
        //        else 
        //        {
        //            return null;
        //        }
        //    }
        //    catch (AggregateException ex){

        //        Console.WriteLine(ex.Message.ToString());

        //        return null;
        //    }

        //}
        public string EachClientCallRR(string clientid, string itemid)
        {
            try
            {
                string axieapi = "https://game-api.skymavis.com/game-api/clients/"+clientid+"/items/" + itemid;
                HttpClient hc = new HttpClient();
                hc.BaseAddress = new Uri(axieapi);
                hc.MaxResponseContentBufferSize = 2000000;
                 var usresulter0 = hc.GetStringAsync(hc.BaseAddress).Result;
                if (usresulter0 != null)
                {
                    return usresulter0;
                }
                else
                {
                    return null;
                }
            }
            catch (AggregateException ex)
            {
                Console.WriteLine(ex.Message.ToString());
                return null;
            }
        }
        #region no use
        public string CallRRall(string clientid)
        {
             try
            {
                string axieapi = "https://game-api.skymavis.com/game-api/clients/"+ clientid + "/items/";

                HttpClient hc = new HttpClient();

                hc.BaseAddress = new Uri(axieapi);

                hc.MaxResponseContentBufferSize = 2000000;

                var usresulter0 = hc.GetStringAsync(hc.BaseAddress).Result;

                if (usresulter0 != null)
                {

                    return usresulter0;
                }
                else
                {
                    return null;
                }
            }
            catch (AggregateException ex)
            {

                Console.WriteLine(ex.Message.ToString());

                return null;
            }
        }
         #endregion
    }

}