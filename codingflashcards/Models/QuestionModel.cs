using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace codingflashcards.Models
{
    public class FlashCardModel
    {
        public int QuestionId { get; set; }
        public string Question { get; set; }
        public string Hint { get; set; }
        public string Answer { get; set; }
    }
}