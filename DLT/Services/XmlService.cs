using DLT.Models;
using NPOI.SS.UserModel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace DLT.Services
{
    public class XmlService : IFileService<DLTModel>
    {
        private string name = "Info.xlsx";

        private string xlsxPath = "";

        public XmlService(string path)
        {
            xlsxPath = path + name;
        }

        public List<DLTModel> GetList()
        {

            var modelList = new List<DLTModel>();

            if (!File.Exists(xlsxPath))
            {
                return modelList;
            }


            FileStream fs = new FileStream(xlsxPath, FileMode.Open, FileAccess.Read);
            //根据文件流创建excel数据结构
            IWorkbook workbook = WorkbookFactory.Create(fs);

            var sheet = workbook.GetSheetAt(0);

            if (sheet != null)
            {
                int startRow = 0;

                int rowCount = sheet.LastRowNum;
                for (int i = startRow; i <= rowCount; ++i)
                {
                    IRow row = sheet.GetRow(i);
                    if (row == null)
                        continue; //没有数据的行默认是null　　　　　　　

                    DLTModel model = new DLTModel();

                    model.PhaseNumber = row.GetCell(0).StringCellValue;
                    if (string.IsNullOrWhiteSpace(model.PhaseNumber))
                    {
                        break;
                    }
                    model.PrizeDate = Convert.ToDateTime(row.GetCell(1).StringCellValue);
                    model.FrontArea = new FrontArea()
                    {
                        First = (int)row.GetCell(2).NumericCellValue,
                        Second = (int)row.GetCell(3).NumericCellValue,
                        Third = (int)row.GetCell(4).NumericCellValue,
                        Fourth = (int)row.GetCell(5).NumericCellValue,
                        Fifth = (int)row.GetCell(6).NumericCellValue
                    };

                    model.BackArea = new BackArea()
                    {

                        Sixth = (int)row.GetCell(7).NumericCellValue,
                        Seventh = (int)row.GetCell(8).NumericCellValue
                    };

                    modelList.Add(model);
                }
            }
            return modelList;
        }

        public void Insert(DLTModel model)
        {
            throw new NotImplementedException();
        }

        public void Save(List<DLTModel> ts)
        {
            throw new NotImplementedException();
        }
    }
}
