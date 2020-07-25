using DLT.Models;
using Microsoft.Extensions.Caching.Memory;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DLT.Services
{
    public class PrizeService : IPrizeService<DLTModel>
    {
        MemoryCache memoryCache = new MemoryCache(new MemoryCacheOptions() { });
        public List<DLTModel> GetList()
        {
            return memoryCache.Get<List<DLTModel>>("DLT");
        }

        public void Insert(DLTModel t)
        {
            var list = GetList();
            list.Add(t);

            MemoryCache memoryCache = new MemoryCache(new MemoryCacheOptions() { });


        }
    }
}
