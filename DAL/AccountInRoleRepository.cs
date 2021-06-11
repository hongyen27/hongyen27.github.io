using DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace DAL
{
    public class AccountInRoleRepository : BaseRepository<AccountInRole>
    {
        internal AccountInRoleRepository(IDbConnection connection) : base(connection)
        {
        }

        protected override AccountInRole Fetch(IDataReader reader)
        {
            return new AccountInRole
            {
                AccountId = (long)reader["AccountId"],
                RoleId = (int)reader["RoleId"]
            };
        }
        public int Save(AccountInRole obj)
        {
            Parameter[] parameters =
            {
                new Parameter{ Name = "@AccountId", Value = obj.AccountId, DbType = DbType.Int64},
                new Parameter{ Name = "@RoleId", Value = obj.RoleId, DbType = DbType.Int32}
            };
            return Save("SaveMemberInRole", parameters);
        }
    }
}
