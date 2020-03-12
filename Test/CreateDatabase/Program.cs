using System;

namespace CreateDatabase
{
    using Data;
    using Data.Models;
    class Program
    {
        static void Main(string[] args)
        {
            using var db = new QuestionsDbContext();
            db.Database.EnsureDeleted();
            db.Database.EnsureCreated();

            var question = new Question
            {
                Content = "Коя е столицата на България?",
                Answers = new Answers
                {
                    AnswerA = "Москва",
                    AnswerB = "София",
                    AnswerC = "Пловдив",
                    AnswerD = "Варна",
                    RightAnswer = "B"
                }
            };
            db.Questions.Add(question);

            question = new Question
            {
                Content = "Колко прави 2 + 2 * 2 + 2 * 3 ?",
                Answers = new Answers
                {
                    AnswerA = "12",
                    AnswerB = "30",
                    AnswerC = "14",
                    AnswerD = "Друг отговор",
                    RightAnswer = "A"
                }
            };
            db.Questions.Add(question);

            question = new Question
            {
                Content = "Кой триъгълник има хипотенуза?",
                Answers = new Answers
                {
                    AnswerA = "равнобедрения",
                    AnswerB = "равностранния",
                    AnswerC = "правоъгълния",
                    AnswerD = "разностранния",
                    RightAnswer = "C"
                }
            };
            db.Questions.Add(question);

            question = new Question
            {
                Content = "На колко години в България се навършва пълнолетие?",
                Answers = new Answers
                {
                    AnswerA = "14",
                    AnswerB = "16",
                    AnswerC = "18",
                    AnswerD = "21",
                    RightAnswer = "C"
                }
            };
            db.Questions.Add(question);

            question = new Question
            {
                Content = "Къде се намира град Враца",
                Answers = new Answers
                {
                    AnswerA = "Североизточна България",
                    AnswerB = "Северозападна България",
                    AnswerC = "Югоизточна България",
                    AnswerD = "Югозападна България",
                    RightAnswer = "B"
                }
            };
            db.Questions.Add(question);

            db.SaveChanges();
        }
    }
}
