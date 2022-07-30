using Google.Apis.Sheets.v4;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace Webgooglesheet.GoogleSecret
{
    public class PlayerList
    {
        public List<PlayerCatch> Players() {
            //https://docs.google.com/spreadsheets/d/1K_B7KwWnKj7PBhMX6UynwOq4CBO9qd1p-cN4uHDTp1I/edit?usp=sharing
            //   System.AppDomain.CurrentDomain.BaseDirectory.ToString();
            //after d is the shared spreedsheet id
            var googleSecretJsonFilePath = $"{System.AppDomain.CurrentDomain.BaseDirectory}\\GoogleSecret\\GoogleSecret.json";
            var applicationName = ConfigurationManager.AppSettings["gsheetappname"].ToString();//--in my sheet
            string[] scopes = { SheetsService.Scope.SpreadsheetsReadonly };
            var googleService = new GoogleService(googleSecretJsonFilePath, applicationName, scopes);
            var spreadSheetId = ConfigurationManager.AppSettings["spreadSheetId"].ToString();
            //share link

            var range = "A:B";
            var reader = new GoogleSpreadSheetReader(googleService);
            var spreadSheet = reader.GetSpreadSheet(spreadSheetId, range);

           var lst= spreadSheet.Rows;
            PlayerCatch pc = new PlayerCatch();
            var players = new List<PlayerCatch>();
            foreach (var ll in lst)
            {
                if (!string.IsNullOrEmpty(ll.Value0))
                {
                    pc.player_admin = ll.Value0;
                    pc.player_name = ll.Value1;
                    players.Add(pc);
                }
            }

            return players;
        }
    }
}