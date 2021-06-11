using DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace DAL
{
    public class ProductRepository : BaseRepository<Product>
    {
        internal ProductRepository(IDbConnection connection) : base(connection) { }

        protected override Product Fetch(IDataReader reader)
        {
            return new Product
            {
                Id = (int)reader["Id"],
                CategoryId = (int)reader["CategoryId"],
                Name = (string)reader["Name"],
                Price = (int)reader["Price"],
                Quantity = (int)reader["Quantity"],
                Description = (string)reader["Description"],
                /*ImageUrl = (string)reader["ImageUrl"]*/
                ImageUrl = reader["ImageUrl"] != DBNull.Value ? (string)reader["ImageUrl"] : null,
                Discount = reader["Discount"] != DBNull.Value ? (double?)reader["Discount"] : null,
                Status = (string)reader["Status"],
                CreateTime = (DateTime)reader["CreateTime"],
                UpdateTime = reader["UpdateTime"] != DBNull.Value ? (DateTime?)reader["UpdateTime"] : null
            };
        }
        public List<Product> GetProducts()
        {
            return Query("GetProducts");
        }
        public Product GetProductById(int id)
        {
            return QueryOne("GetProductById", new Parameter { Name = "@Id", Value = id, DbType = DbType.Int32 });
        }
        public List<Product> GetProductsByCategory(int id)
        {
            return Query("GetProductsByCategory", new Parameter { Name = "@Id", Value = id, DbType = DbType.Int32 });
        }
        public int Delete(int id)
        {
            return Save("DeleteProduct", new Parameter { Name = "@Id", Value = id, DbType = DbType.Int32 });
        }
        public List<Product> GetProductsPagination(int index, int size)
        {
            using (IDbCommand command = connection.CreateCommand())
            {
                command.CommandText = "ProductsPagination";
                command.CommandType = CommandType.StoredProcedure;
                Parameter[] parameters =
                {
                    new Parameter { Name = "@Start", DbType = DbType.Int32, Value = (index - 1) * size + 1},
                    new Parameter { Name = "@End", DbType = DbType.Int32, Value = index * size},
                    //new Parameter { Name = "@Total", DbType = DbType.Int32, Direction = ParameterDirection.Output}
                };
                SetParameter(command, parameters);
                List<Product> list = FetchAll(command);
                //IDataParameter parameter = (IDataParameter)command.Parameters["@Total"];
                //total = (int)parameter.Value;
                return list;
            }
        }
        public int Delete(int[] a)
        {
            return Save(a, "DeleteProduct", new Parameter { Name = "@Id", DbType = DbType.Int32 });
        }
        public List<Product> SearchAdvance(int? cid, int? price, string name)
        {
            Parameter[] parameters =
            {
                new Parameter { Name = "@CategoryId", Value = cid, DbType = DbType.Int32},
                new Parameter { Name = "@Price", Value = price, DbType = DbType.Int32},
                new Parameter { Name = "@Name", Value = name, DbType = DbType.String}
            };
            return Query("SearchProductsAdvance", parameters);
        }
        public int Add(Product obj)
        {
            Parameter[] parameters =
            {
                new Parameter { Name = "@CategoryId", Value = obj.CategoryId, DbType = DbType.Int32},
                new Parameter { Name = "@Name", Value = obj.Name, DbType = DbType.String},
                new Parameter { Name = "@Price", Value = obj.Price, DbType = DbType.Int32},
                new Parameter { Name = "@Quantity", Value = obj.Quantity, DbType = DbType.Int32},
                new Parameter { Name = "@Description", Value = obj.Description, DbType = DbType.String},
                new Parameter { Name = "@ImageUrl", Value = obj.ImageUrl, DbType = DbType.String},
                new Parameter { Name = "@Discount", Value = obj.Discount, DbType = DbType.Decimal}
            };
            return Save("AddProduct", parameters);
        }
        public int Edit(Product obj)
        {
            Parameter[] parameters =
            {
                new Parameter { Name = "@Id", Value = obj.Id, DbType = DbType.Int32},
                new Parameter { Name = "@CategoryId", Value = obj.CategoryId, DbType = DbType.Int32},
                new Parameter { Name = "@Name", Value = obj.Name, DbType = DbType.String},
                new Parameter { Name = "@Price", Value = obj.Price, DbType = DbType.Int32},
                new Parameter { Name = "@Quantity", Value = obj.Quantity, DbType = DbType.Int32},
                new Parameter { Name = "@Description", Value = obj.Description, DbType = DbType.String},
                new Parameter { Name = "@ImageUrl", Value = obj.ImageUrl, DbType = DbType.String},
                new Parameter { Name = "@Discount", Value = obj.Discount, DbType = DbType.Decimal}
            };
            return Save("EditProduct", parameters);
        }
        public Product GetProductsDetail(int id)
        {
            using (IDbCommand command = connection.CreateCommand())
            {
                command.CommandText = "GetProductsDetail";
                command.CommandType = CommandType.StoredProcedure;
                SetParameter(command, new Parameter { Name = "@Id", Value = id, DbType = DbType.Int32 });
                using (IDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        Product obj = Fetch(reader);
                        if (reader.NextResult())
                        {
                            obj.Relation = FetchAll(reader);
                        }
                        return obj;
                    }
                    return null;
                }
            }
        }
        public List<Product> SearchProductsPaginationByQ(string q, int index, int size)
        {
            using (IDbCommand command = connection.CreateCommand())
            {
                command.CommandText = "SearchProductsPaginationByQ";
                command.CommandType = CommandType.StoredProcedure;

                Parameter[] parameters =
                {
                    new Parameter { Name = "@Q", Value = ('%' + q + '%'), DbType = DbType.String},
                    new Parameter { Name = "@Start", Value = ((index-1)*size+1), DbType = DbType.Int32},
                    new Parameter { Name = "@End", Value = (index*size), DbType = DbType.Int32}
                };
                SetParameter(command, parameters);
                return FetchAll(command);
            }
        }
    }
}
