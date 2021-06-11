using DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace DAL
{
    public class OrderRepository : BaseRepository<Orders>
    {
        internal OrderRepository(IDbConnection connection) : base(connection)
        {
        }

        protected override Orders Fetch(IDataReader reader)
        {
            return new Orders
            {
                Id = (long)reader["Id"],
                AccountId = (long)reader["AccountId"],
                Address = reader["Address"]!=DBNull.Value? (string)reader["Address"]:null,
                SDT = reader["SDT"]!=DBNull.Value? (string)reader["SDT"] : null,
                //ImageUrl = reader["ImageUrl"] != DBNull.Value ? (string)reader["ImageUrl"] : null,
               // DeliverID = reader["DeliverID"] != DBNull.Value ? (long?)reader["DeliverID"] : null,
                DeliverDT = reader["DeliverDT"] != DBNull.Value ? (DateTime?)reader["DeliverDT"] : null,
                //Staff_ID = reader["Staff_ID"] != DBNull.Value ? (long?)reader["Staff_ID"] : null,
                Staff_DT = reader["Staff_DT"] != DBNull.Value ? (DateTime?)reader["Staff_DT"] : null,               
                Notes = reader["Notes"] != DBNull.Value ? (string)reader["Notes"] : null,
                CreateTime = (DateTime)reader["CreateTime"],
                UpdateTime = reader["UpdateTime"] != DBNull.Value ? (DateTime?)reader["UpdateTime"] : null,
                HOTEN = reader["HOTEN"] != DBNull.Value ? (string)reader["HOTEN"] : null,
                HOTEN_DL = reader["HOTEN_DL"] !=DBNull.Value ? (string)reader["HOTEN_DL"]:null,
                HOTEN_ST = reader["HOTEN_ST"]!=DBNull.Value?(string)reader["HOTEN_ST"] : null,
                //Quantity = reader["Quantity"] != DBNull.Value ? (int?)reader["Quantity"] : null,
                //Price = reader["Price"] != DBNull.Value ? (int?)reader["Price"] : null,
                //ProductName = reader["Name"] != DBNull.Value ? (string)reader["Name"] : null,
                SDT_DL = reader["SDT_DL"] != DBNull.Value ? (string)reader["SDT_DL"] : null,
                Status = reader["Status"] != DBNull.Value ? (string)reader["Status"] : null,
                Status_code = reader["Status_code"] != DBNull.Value ? (string)reader["Status_code"] : null
            };
        }
        static Orders FetchOrders(IDataReader reader)
        {
            return new Orders
            {
                Id = (long)reader["Id"],
                AccountId = (long)reader["AccountId"],
                Status = reader["Status"] != DBNull.Value ? (string)reader["Status"] : null,
                CreateTime = (DateTime)reader["CreateTime"],
                UpdateTime = reader["UpdateTime"] != DBNull.Value ? (DateTime?)reader["UpdateTime"] : null,
                Notes = reader["Notes"] != DBNull.Value ? (string)reader["Notes"] : null,
                DeliverID = reader["DeliverID"] != DBNull.Value ? (long?)reader["DeliverID"] : null,
                DeliverDT = reader["DeliverDT"] != DBNull.Value ? (DateTime?)reader["DeliverDT"] : null,
                Staff_ID = reader["Staff_ID"] != DBNull.Value ? (long?)reader["Staff_ID"] : null,
                Staff_DT = reader["Staff_DT"] != DBNull.Value ? (DateTime?)reader["Staff_DT"] : null,
                Address = reader["Address"] != DBNull.Value ? (string)reader["Address"] : null,
                SDT = reader["SDT"] != DBNull.Value ? (string)reader["SDT"] : null,
                
            };
        }
        public int Pay(Orders obj)
        {
            Parameter[] parameters =
            {
                new Parameter { Name = "@Id", Value = obj.Id, DbType = DbType.Int64},
                new Parameter { Name = "@AccountId", Value = obj.AccountId, DbType = DbType.Int64},
                new Parameter { Name = "@Notes", Value = obj.Notes, DbType = DbType.String},
                new Parameter { Name = "@Address", Value = obj.Address, DbType = DbType.String},
                new Parameter { Name = "@SDT", Value = obj.SDT, DbType = DbType.String}
            };
            return Save("Pay_OrderItems", parameters);
        }
        public List<Orders> GetOrders(long id)
        {
            return Query("GetOrderByAccountId", new Parameter { Name = "@AccountId", Value = id, DbType = DbType.Int64 });
        }

        public Orders GetOrdersById(long id)
        {
            using (IDbCommand command = connection.CreateCommand())
            {
                command.CommandText = "GetOrderById";
                command.CommandType = CommandType.StoredProcedure;
                SetParameter(command, new Parameter { Name = "@Id", Value = id, DbType = DbType.Int64 });
                using (IDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        Orders obj = FetchOrders(reader);
                        return obj;
                    }
                    return null;
                }
            }
        }
        public int OrderProcess(Orders obj)
        {
            
            Parameter[] parameters =
            {
                new Parameter{ Name = "@Id", Value = obj.Id, DbType = DbType.Int64},
                new Parameter{ Name = "@AccountId", Value = obj.AccountId, DbType = DbType.Int64},
                new Parameter{ Name = "@DeliverId", Value = obj.DeliverID, DbType = DbType.Int64},
                new Parameter{ Name = "@Status", Value = obj.Status, DbType = DbType.String},
            };
            return Save("OrderProcess", parameters);
        }
    }
}
