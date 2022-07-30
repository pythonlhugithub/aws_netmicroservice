using Google.Apis.Auth.OAuth2;
using Google.Apis.Services;
using Google.Apis.Sheets.v4;
using Google.Apis.Sheets.v4.Data;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;

namespace agslp_tigger.GoogleSecret
{
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
          //  var googleSecretJsonFilePath = $"{System.AppDomain.CurrentDomain.BaseDirectory}\\keys\\agslpx3-a1a8455e2d05.json";
            // Put your credentials json file in the root of the solution and make sure copy to output dir property is set to always copy 
            using (var stream = new FileStream(Path.Combine(System.AppDomain.CurrentDomain.BaseDirectory+"\\keys\\", "agslpx3-a1a8455e2d05.json"),
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