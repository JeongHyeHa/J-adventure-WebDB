using System.ComponentModel.DataAnnotations;

namespace HitBallWebServer.Models
{
    public class Score
    {
        [Key]
        public int GameId { get; set; }
        public int TotalScore { get; set; }
        public int HitCount { get; set; }
        public int RemainTime { get; set; }
        public DateTime Date { get; set; }

        //player info
        public string Id { get; set; }
        public string Major { get; set; }
        public string Name { get; set; }
    }
}
