using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Models;

namespace Assign1.Data
{
    public interface IAdult
    {
        IList<Adult> GetAdults();
        void AddAdult(Adult adult);
        Adult Get(int id);
        void Update(Adult adult);


    }
}

