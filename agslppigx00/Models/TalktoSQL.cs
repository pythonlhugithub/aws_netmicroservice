using MySql.Data.MySqlClient;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using static agslppigx00.Models.entitycollect;

namespace agslppigx00.Models
{
    public class TalktoSQL
    {
           public void PushtoSQL()
            {
                foreach (var strsql in fetchItemswallet())
                {
                    var constr = "'Server=34.116.89.4;Database=agslpxx01;Uid=root;Pwd=Trump#$%^3456Der' providerName = 'MySql.Data.MySqlClient'";
                    MySqlConnection scon = new MySqlConnection(constr);
                    scon.Open();
                    MySqlCommand cmd = new MySqlCommand(strsql, scon);
                    cmd.ExecuteNonQuery();
                    cmd.Dispose();
                    scon.Close();
                }
            }

        public List<string> fetchItemswallet() {

            try
            {
                googleSheet pl = new googleSheet();//connect to google excel
                var callgate = new gateway();
                var constr = new List<string>();

                //foreach (var playerid in pl.Players())
                //{
                //    var pid = playerid.player_name;

                var pid = "0x888d4b64d02b399ea333d814369d36e7e472c762";
                    var j = 2;
                    for (int i = 1; i < j; i++)
                    {
                        var playid = pid;
                        var singrd = callgate.EachPlayerCallRR(playid, i.ToString());
                        if (singrd != null)
                        {
                            itemd item = JsonConvert.DeserializeObject<itemd>(singrd.ToString());

                            var walletitem = new Wallets();
                            walletitem.client_id = item.client_id.ToString();
                            walletitem.itemid = int.Parse(item.item.id.ToString());
                            long ds1 = item.last_claimed_item_at;
                            walletitem.last_claimed_item_at = DateTimeOffset.FromUnixTimeSeconds(ds1).UtcDateTime;
                            walletitem.next_claimed_item_at = DateTimeOffset.FromUnixTimeSeconds(ds1).UtcDateTime.AddDays(14);
                            walletitem.success = item.success;
                            walletitem.total = item.total;
                            walletitem.claimable_total = item.claimable_total;
                            if (item.blockchain_related.balance > 0)
                            {
                                walletitem.balance = item.blockchain_related.balance;
                            }
                            else
                            {
                                walletitem.balance = 0;
                            }
                            if (item.blockchain_related.block_number != null)
                            {
                                if (item.blockchain_related.block_number > 0)
                                {
                                    walletitem.block_number = item.blockchain_related.block_number;
                                }
                                else
                                {
                                    walletitem.block_number = 0;
                                }
                            }
                            else
                            {
                                walletitem.block_number = 0;
                            }

                            if (item.blockchain_related.checkpoint != null)
                            {
                                if (item.blockchain_related.checkpoint > 0)
                                {
                                    walletitem.chekpoint = item.blockchain_related.checkpoint;
                                }
                                else
                                {
                                    walletitem.chekpoint = 0;
                                }
                            }
                            else
                            {
                                walletitem.chekpoint = 0;
                            }
                            if (item.blockchain_related.signature != null)
                            {
                                if (item.blockchain_related.signature.amount != null)
                                {
                                    if (item.blockchain_related.signature.amount > 0)
                                    {
                                        walletitem.amount = item.blockchain_related.signature.amount;
                                    }
                                    else
                                    {
                                        walletitem.amount = 0;

                                    }
                                }
                                else
                                {
                                    walletitem.amount = 0;
                                }
                            }
                            else
                            {
                                walletitem.amount = 0;
                            }

                            if (item.blockchain_related.signature != null)
                            {
                                if (!string.IsNullOrEmpty(item.blockchain_related.signature.signature))
                                {
                                    walletitem.ssignature = item.blockchain_related.signature.signature.ToString();
                                }
                                else
                                {
                                    walletitem.ssignature = "no-sign";
                                }
                            }
                            else
                            {
                                walletitem.ssignature = "no-sign";
                            }

                            walletitem.item_id = item.item_id;
                            walletitem.itemname = item.item.name;
                            walletitem.itemdescription = item.item.description;
                            long ds3 = item.item.created_at;
                            walletitem.itemcreated_at = DateTimeOffset.FromUnixTimeSeconds(ds3).UtcDateTime.ToUniversalTime();
                            long ds4 = item.item.updated_at;
                            walletitem.itemupdated_at = DateTimeOffset.FromUnixTimeSeconds(ds4).UtcDateTime.ToUniversalTime();
                            walletitem.createddate = DateTime.Today;
                            var sqlconstr =
                                       "INSERT INTO[dbo].[WalletDailyCollect]" +
                                       "VALUES"
                                      + "(" +
                                        walletitem.client_id + "," +
                                        walletitem.item_id + "," +
                                        walletitem.last_claimed_item_at + "," +
                                       walletitem.next_claimed_item_at + "," +
                                       walletitem.success + "," +
                                      walletitem.total + "," +
                                       walletitem.claimable_total + "," +
                                       walletitem.balance + "," +
                                       walletitem.block_number + "," +
                                       walletitem.chekpoint + "," +
                                       walletitem.amount + "," +
                                       walletitem.ssignature + "," +
                                       walletitem.itemid + "," +
                                       walletitem.itemname + "," +
                                       walletitem.itemdescription + "," +
                                       walletitem.itemcreated_at + "," +
                                       walletitem.itemupdated_at + "," +
                                       walletitem.createddate + ")";
                            constr.Add(sqlconstr);
                        }
                    }
                //}
                return constr;
            }
            catch
            {
                return new List<string>();
            }
           

        }
    }
    }
