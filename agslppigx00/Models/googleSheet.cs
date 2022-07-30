using Google.Apis.Sheets.v4;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using static agslppigx00.Models.entitycollect;

namespace agslppigx00.Models
{
    public class googleSheet
    {
        public List<player> Players()
        {

            try
            {
                var googleSecretJsonFilePath = $"{System.AppDomain.CurrentDomain.BaseDirectory}\\keys\\agslpx3-a1a8455e2d05.json";
                var applicationName = ConfigurationManager.AppSettings["spreadSheetAppName"].ToString();//--in my sheet
                string[] scopes = { SheetsService.Scope.SpreadsheetsReadonly };
                var googleService = new GoogleService(googleSecretJsonFilePath, applicationName, scopes);
                var spreadSheetId = ConfigurationManager.AppSettings["spreadSheetId"].ToString();
                //share link
                var range = "B:C";
                var reader = new GoogleSpreadSheetReader(googleService);
                var spreadSheet = reader.GetSpreadSheet(spreadSheetId, range);
                var lst = spreadSheet.Rows;
                var players = new List<player>();
                foreach (var ll in lst)
                {
                    player pc = new player();
                    pc.player_admin = ll.Value0;
                    pc.player_name = ll.Value1;
                    players.Add(pc);
                }
                return players;
            }
            catch (Exception ex)
            {
                return new List<player>();
            }
        }
    }
}