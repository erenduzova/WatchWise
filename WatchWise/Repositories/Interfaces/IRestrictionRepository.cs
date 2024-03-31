using Microsoft.EntityFrameworkCore;
using WatchWise.Models;

namespace WatchWise.Repositories.Interfaces
{
    public interface IRestrictionRepository
    {
        IQueryable<Restriction> GetAllRestrictions();
        Restriction? GetRestrictionById(byte id);
        Restriction? GetRestrictionByName(string name);
        void AddRestriction(Restriction restriction);
        void UpdateRestriction(Restriction restriction);
    }
}