using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ClassLibrary1.Models;

namespace Assign2
{
    public interface IAdult
    {
       
        Task<Adult> AddAdult(Adult adult);
        Task RemoveAdult(int adult);
        Task<Adult> UpdateAsync(Adult adult);
        Task<IList<Adult>> GetAdultsAsync();


    }
}

