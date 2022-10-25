using Nizami.Migrations;
using System.Collections.Generic;

namespace Nizami.Models
{
    public interface IOrderRepository
    {
        IEnumerable<Orders> Orders { get; }
        void SaveOrder(Orders order);
    }
}
