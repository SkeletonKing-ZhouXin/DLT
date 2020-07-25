using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DLT.Services
{
    public interface IPrizeService<T>
    {
        void Insert(T t);

        List<T> GetList();
    }
}
