using System.Collections.Generic;

namespace LiveTddTotalAmount
{
    public interface IRepository<T>
    {
        List<T> GetAll();
    }
}