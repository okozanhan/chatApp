using System;

namespace AppCore
{
    public class Audit
    {
        public int CUserId { get; set; }
        public DateTime CDate { get; set; }

        public int MUserId { get; set; }
        public DateTime MDate { get; set; }

    }
}
