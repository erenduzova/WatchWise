using Microsoft.EntityFrameworkCore;
using WatchWise.Models;

namespace WatchWise.Repositories.Interfaces
{
    public interface IRestrictionRepository
    {
        IQueryable<Restriction> GetAllRestrictions(bool includeMedias = false);
        Restriction? GetRestrictionById(byte id, bool includeMedias = false);
        Restriction? GetRestrictionByName(string name, bool includeMedias = false);
        void AddRestriction(Restriction restriction);
        void UpdateRestriction(Restriction restriction);
    }
}