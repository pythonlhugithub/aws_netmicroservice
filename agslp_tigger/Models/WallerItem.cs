using System;

namespace agslp_tigger
{
    public class WallerItem
    {
        public string client_id { get; set; }
        public Nullable<int> item_id { get; set; }
        public Nullable<System.DateTime> last_claimed_item_at { get; set; }
        public Nullable<System.DateTime> next_claimed_item_at { get; set; }
        public Nullable<bool> success { get; set; }
        public Nullable<decimal> total { get; set; }
        public Nullable<decimal> claimable_total { get; set; }
        public Nullable<decimal> balance { get; set; }
        public Nullable<int> block_number { get; set; }
        public Nullable<int> chekpoint { get; set; }
        public Nullable<decimal> amount { get; set; }
         public string ssignature { get; set; }
        public Nullable<int> itemid { get; set; }
        public string itemname { get; set; }
        public string itemdescription { get; set; }
        public Nullable<System.DateTime> itemcreated_at { get; set; }
        public Nullable<System.DateTime> itemupdated_at { get; set; }
        public Nullable<System.DateTime> createddate { get; set; }

        //  no change

    }
}