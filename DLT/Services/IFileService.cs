using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DLT.Services
{
    public interface IFileService<T>
    {

        List<T> GetList();

        void Insert(T t);

        void Save(List<T> ts);
    }
}
