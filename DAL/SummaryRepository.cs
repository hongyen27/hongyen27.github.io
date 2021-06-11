using DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace DAL
{
    public class SummaryRepository : BaseRepository<Summary>
    {
        internal SummaryRepository(IDbConnection connection) : base(connection)
        {
        }

        protected override Summary Fetch(IDataReader reader)
        {
            return new Summary
            {
                Name = reader["CategoryName"] != DBNull.Value ? (string)reader["CategoryName"] : null,
                Total = (int)reader["Total"]
            };
        }
        public List<Summary> GetSummaryCategories()
        {
            return Query("GetSummaryCategories");
        }
    }
}
