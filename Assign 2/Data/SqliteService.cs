using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ClassLibrary1.Access;
using ClassLibrary1.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace Assign2.Data
{
    public class SqliteService : IAdult
    {
        private ViaDBContext vdc;

        public SqliteService(ViaDBContext vdc)
        {
            this.vdc = vdc;
        }


        public async Task<Adult> AddAdult(Adult adult)
        {
            EntityEntry<Adult> newlyAdded = await vdc.Adults.AddAsync(adult);
            await vdc.SaveChangesAsync();
            return newlyAdded.Entity;
        }

        public async Task RemoveAdult(int adultId)
        {
            Adult adult = await vdc.Adults.FindAsync(adultId);
            vdc.Adults.Remove(adult);
        }

        public async Task<Adult> UpdateAsync(Adult adult)
        {
            try
            {
                Adult toUpdate = await vdc.Adults.FirstAsync(a => a.Id == adult.Id);
                toUpdate = adult;
                vdc.Update(toUpdate);
                await vdc.SaveChangesAsync();
                return toUpdate;

            }
            catch (Exception e)
            {
                throw new Exception($"Did not find adult with id{adult.Id}");
            }
        }

        public async Task<IList<Adult>> GetAdultsAsync()
        {
            List<Adult> adults = await vdc.Adults.ToListAsync();
            return adults;
        }
    }
}