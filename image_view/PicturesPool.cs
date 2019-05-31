using System;
using System.Collections.Generic;

namespace image_view
{
    public class PicturesPool
    {
        private List<string> pool = new List<string>();
        private Int16 index;

        public PicturesPool()
        {

        }

        public bool SetPool(String name)
        {
            if (String.IsNullOrWhiteSpace(name) == false)
            {
                pool.Add(name);
            }
            return false;
        }

        public String GetNext()
        {
            Console.WriteLine("x");
            return "";
        }

        public String GetPrev()
        {
            Console.WriteLine("x");
            return "";
        }
    }
}
