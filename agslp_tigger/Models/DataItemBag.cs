using agslp_tigger;
using agslp_tigger.EntityCalss;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MVCAxieAPICall.App_Start
{
    public static class CoreItemList
    {
        
        public static string DataItemsbag(List<players> lst) {

            var callgate = new GateRR();
            var listitem = new List<itemd>();
             var player = new List<players>();
            var clients = new List<players>();

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
                    if (item.blockchain_related.signature.signature != null)
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

            return sb.ToString();
        }
    }
}