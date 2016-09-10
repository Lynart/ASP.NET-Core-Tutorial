using System.Collections.Generic;

namespace NETCoreWebExample.Models
{
    public interface IWorldRepository
    {
        IEnumerable<Trip> GetAllTrips();
    }
}