using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Прога_лаба_3
{
    class Aeroport
    {
        public List<Plane> planes { get; set; }
        public Aeroport()
        {
            planes = new List<Plane>();
        }
        public void AddPlane(Plane plane)
        {
            planes.Add(plane);
        }
        public void SortByEngine()
        {
            int indx;
            Plane temp;
            for (int i = 0; i < planes.Count; i++)
            {
                indx = i;
                for (int j = i; j < planes.Count; j++)
                {
                    if (planes[j].E.start == true)
                        indx = j;
                    if (planes[i].E.start == planes[indx].E.start)
                        continue;
                    if (planes[i].E.start == false)
                    {
                        temp = planes[i];
                        planes[i] = planes[indx];
                        planes[indx] = temp;
                    }
                }
            }
        }
    }
}
