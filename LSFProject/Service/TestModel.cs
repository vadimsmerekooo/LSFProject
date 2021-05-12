using System;
using System.Collections.Generic;
using System.Linq;

namespace LSFProject
{
    public class RadioTest
    {
        public List<string> radios { get; set; }
    }
    public class TestModel
    {
        
        public string Title { get; set; } 
        public List<QuestionTest> QuestionTest { get; set; }
        
        static List<TestModel> childTest =
            new List<TestModel>()
            {
                new TestModel()
                {
                    Title = "Выбери из предоставленного списка того, для кого предназначен тротуар.", 
                    QuestionTest = new List<QuestionTest>()
                    {
                        new QuestionTest()
                        {
                            Question = "для водителя", Answer = false
                        },
                        new QuestionTest()
                        {
                            Question = "для пешехода", Answer = true
                        },
                        new QuestionTest()
                        {
                            Question = "для пассажира", Answer = false
                        }
                    }
                },
                new TestModel(){
                    Title = "Отметь ту часть дороги, по которой тебе как пешеходу запрещено двигаться.", 
                    QuestionTest = new List<QuestionTest>()
                    {
                        new QuestionTest()
                        {
                            Question = "по проезжей части", Answer = true
                        },
                        new QuestionTest()
                        {
                            Question = "по обочине", Answer = false
                        },
                        new QuestionTest()
                        {
                            Question = "по тротуару", Answer = false
                        }
                    }
                },
                new TestModel(){
                    Title = "Представь, что ты переходишь проезжаю часть. Какого цвета в это время должен гореть сигнал светофора для пешеходов? Отметь цвет сигнала.", 
                    QuestionTest = new List<QuestionTest>()
                    {
                        new QuestionTest()
                        {
                            Question = "красный", Answer = false
                        },
                        new QuestionTest()
                        {
                            Question = "желтый", Answer = false
                        },
                        new QuestionTest()
                        {
                            Question = "зеленый", Answer = true
                        }
                    }
                },
                new TestModel(){
                    Title = "Какому автомобилю разрешено движение на красный цвет? Отметь это транспортное средство.", 
                    QuestionTest = new List<QuestionTest>()
                    {
                        new QuestionTest()
                        {
                            Question = "троллейбус", Answer = false
                        },
                        new QuestionTest()
                        {
                            Question = "самосвал", Answer = false
                        },
                        new QuestionTest()
                        {
                            Question = "автомобиль МЧС", Answer = true
                        }
                    }
                },
                new TestModel(){
                    Title = "Отметь предметы, которые ты наденешь для безопасного катания на роликах.",
                    QuestionTest = new List<QuestionTest>()
                    {
                        new QuestionTest()
                        {
                            Question = "наколенники", Answer = true
                        },
                        new QuestionTest()
                        {
                            Question = "кепку", Answer = false
                        },
                        new QuestionTest()
                        {
                            Question = "очки", Answer = false
                        }
                    }
                },
                new TestModel(){
                    Title = "Выбери правильный вариант ответа, как ты поступишь, если звонят в дверь.", 
                    QuestionTest = new List<QuestionTest>()
                    {
                        new QuestionTest()
                        {
                            Question = "спросишь, кто там, и откроешь дверь", Answer = false
                        },
                        new QuestionTest()
                        {
                            Question = "сразу откроешь дверь", Answer = false
                        },
                        new QuestionTest()
                        {
                            Question = "посмотришь в дверной глазок и откроешь, только если убедишься, что гость тебе хорошо знаком", Answer = true
                        }
                    }
                },
                new TestModel(){
                    Title = "К кому ты обартишься в опасной ситуации? Выбери правильный вариант ответа.",
                    QuestionTest = new List<QuestionTest>()
                    {
                        new QuestionTest()
                        {
                            Question = "к родителям, учителям, друзьям", Answer = false
                        },
                        new QuestionTest()
                        {
                            Question = "к милиционеру, охраннику, человеку в форме", Answer = true
                        },
                        new QuestionTest()
                        {
                            Question = "к любому человеку (мужчине, женщине), кого встретишь на улице", Answer = false
                        }
                    }
                },
                new TestModel(){
                   Title = "Ты вышел на прогулку. Куда надежнее положить ключ (ключи) от квартиры.", 
                   QuestionTest = new List<QuestionTest>()
                    {
                        new QuestionTest()
                        {
                            Question = "в карман куртки на ключице", Answer = false
                        },
                        new QuestionTest()
                        {
                            Question = "в карман брюк на брелоке", Answer = false
                        },
                        new QuestionTest()
                        {
                            Question = "в отдельный застегивающийся кармашек на ключице", Answer = true
                        }
                    }
                },
                new TestModel(){
                    Title = "Представь, что ты потерял ключ от квартиры. Что будешь делать?", 
                    QuestionTest = new List<QuestionTest>()
                    {
                        new QuestionTest()
                        {
                            Question = "немедленно сообщить родителям о потере", Answer = true
                        },
                        new QuestionTest()
                        {
                            Question = "в поисках ключа обратишься за помощью к незнакомым людям", Answer = false
                        },
                        new QuestionTest()
                        {
                            Question = "попытаешься попасть в квартиру через форточку (балкон), потому что жывешь на первом этаже", Answer = false
                        }
                    }
                },
                new TestModel(){
                    Title = "Для чего предназначены спички?", 
                    QuestionTest = new List<QuestionTest>()
                    {
                        new QuestionTest()
                        {
                            Question = "для обучения счету предметов", Answer = false
                        },
                        new QuestionTest()
                        {
                            Question = "для получения огня", Answer = true
                        },
                        new QuestionTest()
                        {
                            Question = "для настольной игры в качестве сторительного материала", Answer = false
                        }
                    }
                }
            };

        public static List<TestModel> GetTestChild()
        {
            List<TestModel> oldChildTest = childTest.ToList();
            List<TestModel> newChildTest =
                new List<TestModel>();

            while (oldChildTest.Count != 0)
            {
                int intRand = new Random().Next(oldChildTest.Count - 1);
                List<QuestionTest> oldQuestionTest = oldChildTest[intRand].QuestionTest;
                List<LSFProject.QuestionTest> newQuestionTest = new List<QuestionTest>();
                while (oldQuestionTest.Count != 0)
                {
                    int intRand2 = new Random().Next(oldQuestionTest.Count - 1);
                    newQuestionTest.Add(oldQuestionTest[intRand2]);
                    oldQuestionTest.Remove(oldQuestionTest[intRand2]);
                }

                oldChildTest[intRand].QuestionTest = newQuestionTest;
                newChildTest.Add(oldChildTest[intRand]);
                oldChildTest.Remove(oldChildTest[intRand]);
            }
            
            return newChildTest;
        }
    }


    public class QuestionTest
    {
        public string Question { get; set; }
        public bool Answer { get; set; }
    }
}