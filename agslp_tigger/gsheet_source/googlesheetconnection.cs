using agslp_tigger.GoogleSecret;
using agslp_tigger.Models;
using Google.Apis.Sheets.v4;
using System.Collections.Generic;

namespace agslp_tigger.gsheet_source
{
    public class googlesheetconnection
    {
        private readonly googlepara _googlepara;
        public googlesheetconnection(googlepara googlepara)
        {
            _googlepara = googlepara;

        }
        
        public List<PlayerCatch> Players()
        {
            try
            {
                var googleSecretJsonFilePath = $"{System.AppDomain.CurrentDomain.BaseDirectory}\\keys\\agslpx3-a1a8455e2d05.json";
               // var applicationName = "Scrape Export";
               // var spreadSheetId = "1y9554RIYSL9Kw9Eez7OCPTw2qHckMRE9gNsJtej6pK4";

                var applicationName = _googlepara.spreadSheetId;
                var spreadSheetId = _googlepara.spreadSheetAppName;

                string[] scopes = { SheetsService.Scope.SpreadsheetsReadonly };
                var googleService = new GoogleService(googleSecretJsonFilePath, applicationName, scopes);
                var range = "B:C";
                var reader = new GoogleSpreadSheetReader(googleService);
                var spreadSheet = reader.GetSpreadSheet(spreadSheetId, range);
                var lst = spreadSheet.Rows;
                var players = new List<PlayerCatch>();
                foreach (var ll in lst)
                {
                    PlayerCatch pc = new PlayerCatch();
                    pc.player_admin = ll.Value0;
                    pc.player_name = ll.Value1;
                    players.Add(pc);
                }
                return players;
            }
            catch 
            {
                return new List<PlayerCatch>();
            }
        }
    }
}
