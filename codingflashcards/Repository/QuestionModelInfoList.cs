using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using codingflashcards.Models;

namespace codingflashcards.Repository
{
    public class QuestionModelInfoList
    {
       static readonly Regex _rgx = new Regex(@"\t");

        public static IEnumerable<FlashCardModel> GetFalsCards()
        {

           var assembly = Assembly.GetExecutingAssembly();
   
           // var path = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().GetName().CodeBase), @"\Resources\feed.txt");
            var list = string.Empty;
            using (var reader = new StreamReader(assembly.GetManifestResourceStream("codingflashcards.feed.txt")))
            {
                list = reader.ReadToEnd();
            }
            return Regex.Split(list, "<dividder>").Select(s => GetFlashCard(Regex.Split(s, "</\\w+>")));

        }

        public static FlashCardModel GetFlashCard(string[] parts)
        {
            
            return new FlashCardModel
                {
                    QuestionId = 0,
                    Question = parts[0].Replace("<question>", ""),
                    Hint = parts[1].Replace("<hint>", ""),
                    Answer = parts[2].Replace("<answer>", "")
                };

        }


    }
}
