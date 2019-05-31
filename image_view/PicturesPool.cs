using System;
using System.Collections.Generic;

namespace image_view
{
    public class PicturesPool
    {
        private List<string> pool = new List<string>();
        private int index = 0;

        public PicturesPool()
        {

        }

        public int SetPool(String name)
        {
            if ((pool != null) && (String.IsNullOrWhiteSpace(name) == false))
            {
                pool.Add(name);
                index = pool.Count - 1;
                Console.WriteLine("select");
                return index;
            }
            return -1;
        }


        public String GetCurrent()
        {
            if (pool.Count > 0)
                return pool[index];
            else
                return "";
        }

        public String GetNext()
        {
            if (index < pool.Count - 1)
                index += 1;
            return GetCurrent();
        }

        public String GetPrev()
        {
            if (index > 0)
                index -= 1;
            return GetCurrent();
        }
    }
}
