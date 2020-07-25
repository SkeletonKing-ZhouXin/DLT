using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DLT.Models
{
    public class DLTModel : PrizeBaseModel
    {

        public DLTModel()
        {
            FrontArea = new FrontArea();
            BackArea = new BackArea();
        }

        public FrontArea FrontArea { get; set; }

        public BackArea BackArea { get; set; }
    }

    public class FrontArea
    {
        public int First { get; set; }

        public int Second { get; set; }

        public int Third { get; set; }

        public int Fourth { get; set; }

        public int Fifth { get; set; }
    }

    public class BackArea
    {
        public int Sixth { get; set; }

        public int Seventh { get; set; }
    }
}
