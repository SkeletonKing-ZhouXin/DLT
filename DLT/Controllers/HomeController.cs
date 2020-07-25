using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using DLT.Models;
using System.Runtime.Caching;

namespace DLT.Controllers
{
    public class HomeController : Controller
    {

        private static List<DLTModel> dLTModel;

        public HomeController()
        {
            var mcd = MemoryCache.Default["DLT"] as List<DLTModel>;
            mcd.Reverse();

            dLTModel = new List<DLTModel>();

            dLTModel.AddRange(mcd);
        }


        public ActionResult Index()
        {
            DLTModelList modelList = new DLTModelList();
            modelList.modelList.AddRange(dLTModel);

            return View(modelList);
        }

        public ActionResult Privacy()
        {
            return View();
        }

        public ActionResult Create()
        {
            int groupNum = 5;

            int groupCount = 4;

            var list = new DLTModelList();

            for (int i = 0; i < groupCount; i++)
            {
                for (int j = 0; j < groupNum; j++)
                {
                    var item = CreateRandom(list.modelList);

                    list.modelList.Add(item);
                }
            }

            return View(list);
        }

        private DLTModel CreateRandom(List<DLTModel> dltModels)
        {
            List<int> frontItem = new List<int>();

            for (int i = 0; i < 5; i++)
            {
                frontItem.Add(new Random().Next(1, 35));
            }


            if (frontItem.GroupBy(g => g).Where(s => s.Count() > 1).Count() > 0)
            {
                return CreateRandom(dltModels);
            }

            frontItem =frontItem.OrderBy(o=>o).ToList();

            FrontArea frontArea = new FrontArea();
            frontArea.First = frontItem[0];
            frontArea.Second = frontItem[1];
            frontArea.Third = frontItem[2];
            frontArea.Fourth = frontItem[3];
            frontArea.Fifth = frontItem[4];

            List<int> backItem = new List<int>();

            for (int i = 0; i < 2; i++)
            {
                backItem.Add(new Random().Next(1, 12));
            }

            if (backItem.GroupBy(g => g).Where(s => s.Count() > 1).Count() > 0)
            {
                return CreateRandom(dltModels);
            }

            backItem = backItem.OrderBy(o => o).ToList();

            BackArea backArea = new BackArea();
            backArea.Sixth = backItem[0];
            backArea.Seventh = backItem[1];

            var query = dltModels.Where(w =>
            w.FrontArea.First == frontArea.First
            && w.FrontArea.Second == frontArea.Second
            && w.FrontArea.Third == frontArea.Third
            && w.FrontArea.Fourth == frontArea.Fourth
            && w.FrontArea.Fifth == frontArea.Fifth
            && w.BackArea.Sixth == backArea.Sixth
            && w.BackArea.Seventh == backArea.Seventh
            ).Count();

            if (query > 0)
            {
                return CreateRandom(dltModels);
            }

            var getdtls = dLTModel;

            query = dLTModel.Where(w =>
          w.FrontArea.First == frontArea.First
          && w.FrontArea.Second == frontArea.Second
          && w.FrontArea.Third == frontArea.Third
          && w.FrontArea.Fourth == frontArea.Fourth
          && w.FrontArea.Fifth == frontArea.Fifth
          && w.BackArea.Sixth == backArea.Sixth
          && w.BackArea.Seventh == backArea.Seventh
          ).Count();

            if (query > 0)
            {
                return CreateRandom(dltModels);
            }


            DLTModel model = new DLTModel();
            model.FrontArea = frontArea;
            model.BackArea = backArea;

            return model;
        }
    }
}
