using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using Nizami.Migrations;

namespace Nizami.Models
{
    public class EFOrderRepository : IOrderRepository
    {
        private NizamiDbContext context;
        public EFOrderRepository(NizamiDbContext ctx)
        {
            context = ctx;
        }
        public IEnumerable<Orders> Orders => context.Orders
        .Include(o => o.Lines)
        .ThenInclude(l => l.Product);
        public void SaveOrder(Orders order)
        {
            context.AttachRange(order.Lines.Select(l => l.Product));
            // if (order.OrderID == 0){context.Orders.Add(order);}
            context.Orders.Add(order);
            context.SaveChanges();
        }

    }
}
