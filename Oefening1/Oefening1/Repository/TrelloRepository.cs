using Newtonsoft.Json;
using Oefening1.NewFolder1;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Oefening1.NewFolder
{
    public static class TrelloRepository
    {
        private const string _APIKEY = "767b6e7e2f74c8aa197325aa40d28362";
        // met volgende kan je een token generen https://trello.com/1/authorize?key=767b6e7e2f74c8aa197325aa40d28362&scope=read%2Cwrite&name=Oefening1&expiration=never&response_type=token
        private const string _USERTOKEN = "a482e4d77b9344656064130cfcbc1723b9d301589c50bb8435ec6f9aad69f6f9";

        private static HttpClient getClient()
        {
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Add("accept", "application/json");
            return client;
        }

        //helper method
        private static string AddKeyToken(string url)
        {
            return $"{url}?key={_APIKEY}&token={_USERTOKEN}";
        }
        // https://trello.com/1/members/my/boards?key=767b6e7e2f74c8aa197325aa40d28362&token=a482e4d77b9344656064130cfcbc1723b9d301589c50bb8435ec6f9aad69f6f9

        // 1 trelloboard op halen

        public static async Task <List<TrelloBoard>> GetTrelloBoardsAsync()
        {
            using (HttpClient client = getClient())
            {
                try
                {
                    // check URL om boards op te vragen
                    string URL = AddKeyToken("https://trello.com/1/members/my/boards");

                    //api oproepen en het resultaat bijhouden in een variable
                    string json = await client.GetStringAsync(URL);

                    if (json != null)
                    {
                        return JsonConvert.DeserializeObject<List<TrelloBoard>>(json);
                    }
                    return null;
                }
                catch (Exception ex)
                {
                    Debug.WriteLine("Error repository: ", ex.ToString());
                    return null;
                }
            }
        }

        // 2 trellolists ophalen aan de hand van een gekozen trelloboard

        // 3 trellocards ophalen aan de hand van een gekozen trellolist

        // 4 Tellocard ophalen aan de hand van een trellocardId

    }
}
