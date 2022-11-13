using System.ComponentModel.DataAnnotations;

namespace SquidMathQuiz.Entities
{
    public class Players
    {
        [Key]
        public int ID { get; set; }

        public string FirstName { get; set; }    

        public DateTime DateTime { get; set; }

    }
}
