using Newtonsoft.Json;
using System.Data;

namespace EShop.ViewModels
{
    public class CalendarViewModel
    {
        public CalendarViewModel()
        {
            allDay = false;
            multi = 0;
            extension_id = 0;
            durationEditable = true;
            constraint = null;
            groupId = string.Empty;
            constraint = null;
            rendering = null;
            startRecur = null;
            endRecur = null;
        }
        public long id { get; set; }
        public string start { get; set; }
        public string end { get; set; }
        public string title { get; set; }
        public string body { get; set; }
        public int multi { get; set; }
        public bool allDay { get; set; }
        public string color { get; set; }
        public string categoryDescription { get; set; }
        public bool isCopy { get; set; }
        public long extension_id { get; set; }
        public bool durationEditable { get; set; }
        public string constraint { get; set; }
        public string groupId { get; set; }
        public string rendering { get; set; }
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string startRecur { set; get; }
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string endRecur { set; get; }
    }
}
