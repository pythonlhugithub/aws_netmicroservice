using Google.Apis.Auth.OAuth2;
using Google.Apis.Services;
using Google.Apis.Sheets.v4;
using Google.Apis.Sheets.v4.Data;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Web;

namespace agslppigx00.Models
{
    public class entitycollect
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
        public class Wallets
        {
            public int id { get; set; }
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
        }
        public class GooglesheetProcessing
        {
        }
        public class GoogleService
        {

            private readonly string _googleSecretJsonFilePath;
            private readonly string _applicationName;
            private readonly string[] _scopes;

            public GoogleService(string googleSecretJsonFilePath, string applicationName, string[] scopes)
            {
                _googleSecretJsonFilePath = googleSecretJsonFilePath;
                _applicationName = applicationName;
                _scopes = scopes;
            }

            public GoogleCredential GetGoogleCredential()
            {
                GoogleCredential credential;
                using (var stream =
                    new FileStream(_googleSecretJsonFilePath, FileMode.Open, FileAccess.Read))
                {

                    credential = GoogleCredential.FromStream(stream).CreateScoped(_scopes);
                }
                return credential;
            }

            public SheetsService GetSheetsService()
            {
                var credential = GetGoogleCredential();
                var sheetsService = new SheetsService(new BaseClientService.Initializer()
                {
                    HttpClientInitializer = credential,
                    ApplicationName = _applicationName,
                });
                return sheetsService;
            }
        }
        public class SpreadSheet
        {
            public SpreadSheetRow HeaderRow { get; set; }
            public List<SpreadSheetRow> Rows { get; set; }
        }
        public class SpreadSheetRow
        {
            private readonly IList<Object> _values;
            public SpreadSheetRow(IList<Object> values)
            {
                _values = values;
            }

            public string Value0 => _getValue(0);

            public string Value1 => _getValue(1);

            private string _getValue(int columnIndex)
            {
                try
                {
                    var s = _values[columnIndex].ToString();
                    return s;
                }
                catch (Exception ex)
                {
                    return String.Empty;
                }
            }
        }
        public class SpreadSheetConnector
        {
            private string[] _scopes = { SheetsService.Scope.Spreadsheets }; // Change this if you're accessing Drive or Docs
                                                                             // private string _applicationName = "Scholar Account Consolidation";
                                                                             // private string _spreadsheetId = "1dSWmEoMtxl2qWbc84kU9hZF5kM_iCtgF_11hk9yDEb0";
            private string _applicationName = ConfigurationManager.AppSettings["spreadSheetAppName"].ToString();
            private string _spreadsheetId = ConfigurationManager.AppSettings["spreadSheetId"].ToString();
            private SheetsService _sheetsService;

            public void ConnectToGoogle()
            {
                GoogleCredential credential;
                // Put your credentials json file in the root of the solution and make sure copy to output dir property is set to always copy 
                using (var stream = new FileStream(Path.Combine(HttpRuntime.BinDirectory, "agslpx3-a1a8455e2d05.json"),
                    FileMode.Open, FileAccess.Read))
                {
                    credential = GoogleCredential.FromStream(stream).CreateScoped(_scopes);
                }
                // Create Google Sheets API service.
                _sheetsService = new SheetsService(new BaseClientService.Initializer()
                {
                    HttpClientInitializer = credential,
                    ApplicationName = _applicationName
                });
                //  String range = "CopyConsolidation";
                String range = ConfigurationManager.AppSettings["spreadStactivesheetName"].ToString();


                SpreadsheetsResource.ValuesResource.GetRequest request =
                                            _sheetsService.Spreadsheets.Values.Get(_spreadsheetId, range);
                ValueRange response = request.Execute();
                IList<IList<Object>> values = response.Values;
            }

        }
        public class GoogleSpreadSheetReader
        {
            private readonly SheetsService _sheetService;
            public GoogleSpreadSheetReader(GoogleService googleService)
            {
                _sheetService = googleService.GetSheetsService();
            }
            public SpreadSheet GetSpreadSheet(string spreadSheetId, string range)
            {
                SpreadsheetsResource.ValuesResource.GetRequest request = _sheetService.Spreadsheets.Values.Get(spreadSheetId, range);

                ValueRange response = request.Execute();
                IList<IList<Object>> values = response.Values;
                var rows = new List<SpreadSheetRow>();
                for (int i = 1; i < values.Count; i++)
                {
                    var row = new SpreadSheetRow(values[i]);
                    rows.Add(row);
                }
                var headerRow = new SpreadSheetRow(values[0]);
                var spreadSheet = new SpreadSheet();
                spreadSheet.HeaderRow = headerRow;
                spreadSheet.Rows = new List<SpreadSheetRow>();
                spreadSheet.Rows.AddRange(rows);
                return spreadSheet;
            }
        }
    }

}
