using DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace DAL
{
    public class CategoryRepository : BaseRepository<Category>
    {
        internal CategoryRepository(IDbConnection connection) : base(connection) { }
        protected override Category Fetch(IDataReader reader)
        {
            return new Category
            {
                Id = (int)reader["Id"],
                Name = (string)reader["Name"],
                Description = (string)reader["Description"]
            };
        }
        static Product FetchProduct(IDataReader reader)
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
                UpdateTime = reader["UpdateTime"] != DBNull.Value ? (DateTime?)reader["UpdateTime"]:null
            };
        }
        static List<Product> GetProducts(IDataReader reader)
        {
            List<Product> list = new List<Product>();
            while (reader.Read())
            {
                list.Add(FetchProduct(reader));
            }
            return list;
        }
        public List<Category> GetCategories()
        {
            return Query("GetCategories");
        }
        public int Add(Category obj)
        {
            Parameter[] parameters =
            {
                new Parameter { Name = "@Name", Value = obj.Name, DbType = DbType.String},
                new Parameter { Name = "@Description", Value = obj.Description, DbType = DbType.String}
            };
            return Save("AddCategory", parameters);

        }
        public Category GetCategoryById(int id)
        {
            return QueryOne("GetCategoryById", new Parameter { Name = "@Id", Value = id, DbType = DbType.Int32 });
        }
        public int Delete(int id)
        {
            return Save("DeleteCategory", new Parameter { Name = "@Id", Value = id, DbType = DbType.Int32 });
        }
        public int Delete(int[] a)
        {
            return Save(a, "DeleteCategory", new Parameter { Name = "@Id", DbType = DbType.Int32 });
        }
        public int Edit(Category obj)
        {
            Parameter[] parameters =
            {
                new Parameter{ Name = "@Id", Value = obj.Id, DbType = DbType.Int32},
                new Parameter{ Name = "@Name", Value = obj.Name, DbType = DbType.String},
                new Parameter{ Name = "@Description", Value = obj.Description, DbType = DbType.String}
            };
            return Save("EditCategory", parameters);
        }
        public Category GetCategoryDetail(int id)
        {
            using (IDbCommand command = connection.CreateCommand())
            {
                command.CommandText = "GetCategoryDetail";
                command.CommandType = CommandType.StoredProcedure;
                SetParameter(command, new Parameter { Name = "@Id", Value = id, DbType = DbType.Int32 });
                using (IDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        Category obj = Fetch(reader);
                        if (reader.NextResult())
                        {
                            obj.Products = GetProducts(reader);
                        }
                        return obj;
                    }
                    return null;
                }
            }
        }
    }
}
