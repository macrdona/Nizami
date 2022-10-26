using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using System.Diagnostics;

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

            //get Max(OrderId) from table
            var maxOrderID = context.Orders.Max(o => o.OrderID);
            //assign current orderID to Max(OrderId)+1
            order.OrderID = maxOrderID+1;
            
            context.Orders.Add(order);
            context.SaveChanges();
        }

        public void UpdateOrder(Orders order, int orderID)
        {
            context.AttachRange(order.Lines.Select(l => l.Product));

            context.SaveChanges();
        }

    }
}
