using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Oefening1.Models
{
    public class TrelloBoard
    {
        // dit is om de property names overeen te stemmen met de json keys
        [JsonProperty(propertyName: "id")]
        public string Id { get; set; }
        [JsonProperty(propertyName: "Name")]
        public string Name { get; set; }
        [JsonProperty(propertyName: "Starred")]
        public Boolean IsFavorite { get; set; }
    }
}
