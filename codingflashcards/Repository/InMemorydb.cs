using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using codingflashcards.Models;

namespace codingflashcards.Repository
{
    public class InMemorydb
    {

        public static readonly ConcurrentDictionary<int, FlashCardModel> QuestionsDb =
            new ConcurrentDictionary<int, FlashCardModel>();



        public static FlashCardModel Get(int id)
        {
            FlashCardModel question;
            if (QuestionsDb.TryGetValue(id, out question)) return question;
            
            QuestionsDb.TryGetValue(1, out question);
            return question;
        }

        public static void Init()
        {
            var items = QuestionModelInfoList.GetFalsCards().ToList();
            for (var i = 0; i < items.Count; i++)
            {
                var id = i + 1;
                items[i].QuestionId = id;
                QuestionsDb.TryAdd(id,items[i]);
            }

        }
    }
}