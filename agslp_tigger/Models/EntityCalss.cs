using System;
using System.Collections.Generic;

namespace agslp_tigger.EntityCalss
{
    public class players
    {
        public string client_id { get; set; }
     }
    public class AxieHeaderItems
    {

        public string client_id { get; set; }
        public int win_total { get; set; }
        public int draw_total { get; set; }
        public int lose_total { get; set; }
        public int elo { get; set; }
        public int rank { get; set; }
        public string name { get; set; }

    }
    public class AxieHeader
    {
        public List<AxieHeaderItems> items { get; set; }
        public int offset { get; set; }
        public int limit { get; set; }

    }
    public class eroninstat
    {
        public string ronin_address { get; set; }
        public int updated_on { get; set; }
        public decimal last_claim_amount { get; set; }
        public int last_claim_timestamp { get; set; }
        public int ronin_slp { get; set; }
        public int total_slp { get; set; }
        public int in_game_slp { get; set; }
        public bool slp_success { get; set; }
        public object ign { get; set; }
        public int rank { get; set; }
        public int mmr { get; set; }
        public int total_matches { get; set; }
        public int win_rate { get; set; }
        public bool game_stats_success { get; set; }

    }
    public class SlpStat
    {

        public DateTime updated_on { get; set; }
        public eroninstat estat { get; set; }

    }
    public class itemd
    {
        public bool success { get; set; }
        public string client_id { get; set; }
        public int? item_id { get; set; }
        public int? total { get; set; }
        public blockchain_related blockchain_related { get; set; }
        public int? claimable_total { get; set; }
        public long last_claimed_item_at { get; set; }
        public itemdetail item { get; set; }
    }
    public class itemdetail
    {
        public int? id { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public string image_url { get; set; }
        public long updated_at { get; set; }
        public long created_at { get; set; }
    }
    public class blockchain_related
    {
        public Signature signature { get; set; }
        public int? balance { get; set; }
        public int? checkpoint { get; set; }
        public int? block_number { get; set; }

    }
    public class Signature
    {
        public string signature { get; set; }
        public int? amount { get; set; }
        public long timestamp { get; set; }
    }
    public class First
    {
        public List<Second> item { get; set; }
    }
    public class Second
    {
        public int? Id { get; set; }
        public string Name { get; set; }
    }
}