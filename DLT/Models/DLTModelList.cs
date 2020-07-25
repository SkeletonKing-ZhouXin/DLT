using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DLT.Models
{
    public class DLTModelList
    {
        public DLTModelList()
        {
            modelList = new List<DLTModel>();
        }

        public List<DLTModel> modelList { get; set; }
    }
}
