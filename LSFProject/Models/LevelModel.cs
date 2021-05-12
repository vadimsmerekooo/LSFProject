using System.Collections.Generic;
namespace LSFProject
{
    public class LevelModel
    {
        public static List<Level> Levels = new List<Level>()
        {
            new Level()
            {
                LevelNumber = 1,
                StartXp = 0,
                EndXp = 50
            },new Level()
            {
                LevelNumber = 2,
                StartXp = 51,
                EndXp = 110
            },new Level()
            {
                LevelNumber = 3,
                StartXp = 111,
                EndXp = 180
            },new Level()
            {
                LevelNumber = 4,
                StartXp = 181,
                EndXp = 260
            },new Level()
            {
                LevelNumber = 6,
                StartXp = 261,
                EndXp = 350
            }
        };
    }

    public class Level
    {
        public int LevelNumber { get; set; }
        public int StartXp { get; set; }
        public int EndXp { get; set; }
    }
}