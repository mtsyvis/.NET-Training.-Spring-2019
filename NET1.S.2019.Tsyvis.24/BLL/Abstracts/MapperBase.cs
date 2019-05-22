using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Abstracts
{
    public abstract class MapperBase<TFirst, TSecond>
    {
        public abstract TFirst Map(TSecond element);
        public abstract TSecond Map(TFirst element);

        public List<TFirst> Map(List<TSecond> elements)
        {
            var objectCollection = new List<TFirst>();
            if (elements != null)
            {
                foreach (TSecond element in elements)
                {
                    TFirst newObject = Map(element);
                    if (newObject != null)
                    {
                        objectCollection.Add(newObject);
                    }
                }
            }

            return objectCollection;
        }

        public List<TSecond> Map(List<TFirst> elements)
        {
            var objectCollection = new List<TSecond>();

            if (elements != null)
            {
                foreach (TFirst element in elements)
                {
                    TSecond newObject = Map(element);
                    if (newObject != null)
                    {
                        objectCollection.Add(newObject);
                    }
                }
            }

            return objectCollection;
        }
    }
}
