using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Script.Serialization;

namespace agslppigx00.Models
{
    public class gateway
    {
         
            public string EachPlayerCallRR(string clientid, string itemid)
            {
                try
                {
                    string axieapi = "https://game-api.skymavis.com/game-api/clients/" + clientid + "/items/" + itemid;
                    HttpClient hc = new HttpClient();
                    hc.BaseAddress = new Uri(axieapi);
                    hc.MaxResponseContentBufferSize = 200000;
                    JavaScriptSerializer ser = new JavaScriptSerializer();
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
       
        }

    }
