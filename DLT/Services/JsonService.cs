using DLT.Models;
using Newtonsoft.Json;
using NPOI.SS.UserModel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace DLT.Services
{
    public class JsonService : IFileService<DLTModel>
    {
        private string name = "dlt.json";
        private string jsonPath = "";

        public JsonService(string path)
        {
            jsonPath = path + name;
        }

        public List<DLTModel> GetList()
        {

            var modelList = new List<DLTModel>();

            using (StreamReader r = new StreamReader(jsonPath))
            {
                string json = r.ReadToEnd();
                modelList = JsonConvert.DeserializeObject<List<DLTModel>>(json);
            }

            return modelList;
        }

        public void Insert(DLTModel model)
        {
            throw new NotImplementedException();
        }

        public void Save(List<DLTModel> ts)
        {
            string output = JsonConvert.SerializeObject(ts, Formatting.Indented);
            File.WriteAllText(jsonPath, output);
        }
    }
}
