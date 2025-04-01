using System.ComponentModel.DataAnnotations;

namespace ApplicationHelper.Domain
{
    public class InterviewNote
    {
        public string id { get; set; }

        public DateTime date { get; set; }
        public string eventHour { get; set; }
        public string eventMinute { get; set; }
        public string company { get; set; }
        public string note { get; set; }
    }
}
