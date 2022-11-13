using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SquidMathQuiz.Entities
{
    public class Results
    {

        [Key]
        public int ID { get; set; }

        [ForeignKey("PlayerID")]
        public Players Players { get; set; }
        public int PlayerID { get; set; }

        public int  Points { get; set; }

        public DateTime DateTime { get; set; }

    }
}
