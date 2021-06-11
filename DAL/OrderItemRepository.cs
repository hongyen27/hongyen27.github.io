using DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace DAL
{
    public class OrderItemRepository : BaseRepository<OrderItems>
    {
        internal OrderItemRepository(IDbConnection connection) : base(connection) { }
        protected override OrderItems Fetch(IDataReader reader)
        {
            return new OrderItems
            {
                Id = (long)reader["Id"],
                ProductId = (int)reader["ProductId"],
                Quantity = (int)reader["Quantity"],
                Price = (int)reader["Price"],
                ProductName = (string)reader["Name"],
                ImageUrl = reader["ImageUrl"] != DBNull.Value ? (string)reader["ImageUrl"] : null
            };
        }
        public int Add(OrderItems obj)
        {
            Parameter[] parameters =
            {
                new Parameter { Name = "@Id", Value = obj.Id, DbType = DbType.Int64},
                new Parameter { Name = "@ProductId", Value = obj.ProductId, DbType = DbType.Int32},
                new Parameter { Name = "@Quantity", Value = obj.Quantity, DbType = DbType.Int32},
                new Parameter { Name = "@Price", Value = obj.Price, DbType = DbType.Int32}
            };
            return Save("AddCart", parameters);
        }
        public List<OrderItems> GetCarts(long id)
        {
            return Query("GetCarts", new Parameter { Name = "@Id", Value = id, DbType = DbType.Int64 });
        }
        public int Delete(long id, int productid)
        {
            Parameter[] parameters =
            {
                new Parameter { Name = "@Id", Value = id, DbType = DbType.Int64},
                new Parameter { Name = "@ProductId", Value = productid, DbType = DbType.Int32}
            };
            return Save("DeleteCart", parameters);
        }
        public int Edit(OrderItems obj)
        {
            Parameter[] parameters =
            {
                new Parameter { Name = "@Id", Value = obj.Id, DbType = DbType.Int64},
                new Parameter { Name = "@ProductId", Value = obj.ProductId, DbType = DbType.Int32},
                new Parameter { Name = "@Quantity", Value = obj.Quantity, DbType = DbType.Int16}
            };
            return Save("EditCart", parameters);
        }

        public List<OrderItems> GetOrderItemsById(long id)
        {
            return Query("GetOrderItemsByAccountId", new Parameter { Name = "@Id", Value = id, DbType = DbType.Int64 });
        }
    }
}
