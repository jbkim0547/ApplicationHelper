using System.ComponentModel.DataAnnotations;

namespace ApplicationHelper.Domainn
{
    public class Calendar
    {
        [Key]
        public string Id { get; set; }

        public string CompanyName { get; set; }
        public string InterviewTimeHours { get; set; }
        public string InterviewTimeMinutes { get; set; }
        public string Note { get; set; }
    }
}
