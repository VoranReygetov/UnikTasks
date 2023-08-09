using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Лаба_прога_4
{
    class Cage
    {
        public List<Bird> birds { get; set; }
        public Cage()
        {
            birds = new List<Bird>();
        }
        public void AddBird(Bird bird)
        {
            birds.Add(bird);
        }
        public void SortByAge()
        {
            int indx;
            Bird temp;
            for (int i = 0; i < birds.Count; i++)
            {
                indx = i;
                for (int j = i; j < birds.Count; j++)
                {
                    if (birds[j].age < birds[indx].age)
                        indx = j;
                    if (birds[i].age == birds[indx].age)
                        continue;
                    if (birds[i].age > birds[j].age)
                    {
                        temp = birds[i];
                        birds[i] = birds[indx];
                        birds[indx] = temp;
                    }
                }
            }
        }
    }
}
