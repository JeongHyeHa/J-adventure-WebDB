using System.ComponentModel.DataAnnotations;

namespace HitBallWebServer.Models
{
    public class Score
    {
        [Key]
        public int user_id { get; set; }
        public string department { get; set; } = string.Empty;
        public string user_name { get; set; } = string.Empty;
        public int tryCount { get; set; } = 0;
        public int user_score { get; set; }
    }
}
