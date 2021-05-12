using System;
using System.Collections.Generic;

#nullable disable

namespace LSFProject
{
    public partial class AspNetTestResult
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public int TestId { get; set; }
        public int LastResultTest { get; set; }
        public int BestResultTest { get; set; }
        public DateTime LastPlaythrough { get; set; }
        public bool IsBlocked { get; set; }
        public int CountPasses { get; set; }
    }
}
