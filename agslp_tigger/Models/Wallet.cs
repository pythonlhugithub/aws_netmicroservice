using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace agslp_tigger.Models
{
    public class Wallet
    {
        public string client_id { get; set; }
        public int item_id { get; set; }
        public string last_claimed_item_at { get; set; }
        public string next_claimed_item_at { get; set; }
        public int success { get; set; }
        public int total { get; set; }
        public int claimable_total { get; set; }
        public int balance { get; set; }
        public int block_number { get; set; }
        public int chekpoint { get; set; }
        public int amount { get; set; }
        public string ssignature { get; set; }
        public int itemid { get; set; }
        public string itemname { get; set; }
        public string itemdescription { get; set; }
        public string itemcreated_at { get; set; }
        public string itemupdated_at { get; set; }
        public string createddate { get; set; }
        public string MyUnknownColumn { get; set; }
    }

}
