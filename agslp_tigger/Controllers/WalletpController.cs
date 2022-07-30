using agslp_tigger.EntityCalss;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

 
namespace agslp_tigger.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WalletpController : ControllerBase
    {
         [HttpGet]
        public IEnumerable<string> Get()
        {
                try
                {
                gsheet_source.googlesheetconnection pl = new gsheet_source.googlesheetconnection();//connect to google excel
                    var lst = new List<players>();
                    foreach (var playerid in pl.Players())
                    {
                        var pid = playerid.player_name;
                        var plys = new players();
                        plys.client_id = pid;
                        lst.Add(plys);
                    }  ///complete google search close it
                    //if we can get this from mysql will not connect to google
                    //then we call api from game only 
                    // then we can upload to my sql 

                    //localhost
                    //get player from mysql
                    //go to game ortal get wallet
                    //insert into mysql

                    //save as window service
                    //run weekly


                    var callgate = new GateRR();
                    var listitem = new List<itemd>();
                    var player = new List<players>();

                    foreach (var clt in lst)
                    {
                        var j = 2;
                        for (int i = 1; i < j; i++)
                        {
                            var playid = clt.client_id;
                            var singrd = callgate.EachClientCallRR(playid, i.ToString());
                            if (singrd != null)
                            {
                                itemd dataslp = JsonConvert.DeserializeObject<itemd>(singrd.ToString());
                                listitem.Add(dataslp);
                            }
                        }
                    }
                    var names = typeof(WallerItem).GetProperties()
                                .Select(property => property.Name)
                                .ToArray();  //class property name is the column name of a table
                    StringBuilder sb = new StringBuilder();
                    sb.Clear();
                    foreach (var hd in names)
                    {
                        sb.Append(hd + ",");
                    }
                    sb.Append("\r\n");
                    foreach (var item in listitem)
                    {
                        sb.Append(item.client_id.ToString() + ',');
                        sb.Append(item.item.id.ToString() + ',');
                        long ds1 = item.last_claimed_item_at;
                        var last_claimed_item_at = DateTimeOffset.FromUnixTimeSeconds(ds1).UtcDateTime;
                        sb.Append(last_claimed_item_at.ToUniversalTime().ToString() + ',');
                        var next_claimed_item_at = DateTimeOffset.FromUnixTimeSeconds(ds1).UtcDateTime.AddDays(14);
                        sb.Append(next_claimed_item_at.ToUniversalTime().ToString() + ',');
                        sb.Append(item.success.ToString() + ',');
                        sb.Append(item.total.ToString() + ',');
                        sb.Append(item.claimable_total.ToString() + ',');
                        if (item.blockchain_related.balance > 0)
                        {
                            sb.Append(item.blockchain_related.balance.ToString() + ',');
                        }
                        else
                        {
                            sb.Append(0.ToString() + ',');
                        }
                        if (item.blockchain_related.block_number != null)
                        {
                            if (item.blockchain_related.block_number > 0)
                            {
                                sb.Append(item.blockchain_related.block_number.ToString() + ',');
                            }
                            else
                            {
                                sb.Append(0.ToString() + ',');
                            }
                        }
                        else
                        {
                            sb.Append(0.ToString() + ',');
                        }
                        if (item.blockchain_related.checkpoint != null)
                        {
                            if (item.blockchain_related.checkpoint > 0)
                            {
                                sb.Append(item.blockchain_related.checkpoint.ToString() + ',');
                            }
                            else
                            {
                                sb.Append(0.ToString() + ',');
                            }
                        }
                        else
                        {
                            sb.Append(0.ToString() + ',');
                        }
                        if (item.blockchain_related.signature != null)
                        {
                            if (item.blockchain_related.signature.amount != null)
                            {
                                if (item.blockchain_related.signature.amount > 0)
                                {
                                    sb.Append(item.blockchain_related.signature.amount.ToString() + ',');
                                }
                                else
                                {
                                    sb.Append(0.ToString() + ',');

                                }
                            }
                            else
                            {
                                sb.Append(0.ToString() + ',');
                            }
                        }
                        else
                        {
                            sb.Append(0.ToString() + ',');
                        }

                        if (item.blockchain_related.signature != null)
                        {
                            if (!string.IsNullOrEmpty(item.blockchain_related.signature.signature))
                            {
                                sb.Append(item.blockchain_related.signature.signature.ToString() + ',');
                            }
                            else
                            {
                                sb.Append("no-sign" + ',');
                            }
                        }
                        else
                        {
                            sb.Append("no-sign" + ',');
                        }
                        sb.Append(item.item_id.ToString() + ',');
                        sb.Append(item.item.name + ',');
                        sb.Append(item.item.description + ',');
                        long ds3 = item.item.created_at;
                        var created_at = DateTimeOffset.FromUnixTimeSeconds(ds3).UtcDateTime;
                        sb.Append(created_at.ToUniversalTime().ToString() + ',');
                        long ds4 = item.item.updated_at;
                        var updated_at = DateTimeOffset.FromUnixTimeSeconds(ds4).UtcDateTime;
                        sb.Append(updated_at.ToUniversalTime().ToString() + ',');
                        var createddate = DateTime.Today;
                        sb.Append(createddate.ToString() + ',');
                        sb.Append("\r\n");
                    }
                   // return File(Encoding.ASCII.GetBytes(sb.ToString()), "text/csv", "Walleritems.csv");
                }
                catch (Exception ex)
                {
                    //return File(Encoding.ASCII.GetBytes("error from ExportToCSV method: " + ex.Message.ToString()), "text/csv", "Walleritems.csv");
                }
             
            return new string[] { "value1", "value2" };
        }

         [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<WalletpController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<WalletpController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<WalletpController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
