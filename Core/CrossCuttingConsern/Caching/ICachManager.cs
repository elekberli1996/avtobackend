using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.CrossCuttingConsern.Caching
{
   public  interface ICachManager
    {

        T Get<T>(string key);

        object Get(string key);

        void Add(string key, object data, int duration);

        bool isAdd(string key);

        void Remove(string key);

        void RemoveByPatern(string pattern);
    }
}
