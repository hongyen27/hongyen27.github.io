using DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace DAL
{
    public class AccountRepository : BaseRepository<Account>
    {
        internal AccountRepository(IDbConnection connection) : base(connection)
        {
        }

        protected override Account Fetch(IDataReader reader)
        {
            return new Account
            {
                Id = (long)reader["Id"],
                Username = (string)reader["Username"],
                Email = (string)reader["Email"],
                Ho = reader["Ho"]!=DBNull.Value? (string)reader["Ho"]:null,
                Ten = reader["Ten"] != DBNull.Value ? (string)reader["Ten"] : null,
                Address = reader["Address"] != DBNull.Value ? (string)reader["Address"] : null,
                SDT = reader["SDT"] != DBNull.Value ? (string)reader["SDT"] : null,
                Status = reader["Status"] != DBNull.Value ? (string)reader["Status"] : null,
                CompanyId = reader["Company_Id"] !=DBNull.Value ? (string)reader["Company_Id"] : null
            };
        }
        static Account FetchDelivers(IDataReader reader)
        {
            return new Account
            {
                Id = (long)reader["Id"],
                TT_Delivers = (string)reader["TT_Delivers"]
            };
        }
        static Account FetchAccount(IDataReader reader)
        {
            return new Account
            {
                Id = (long)reader["Id"],
                Username = (string)reader["Username"],
                Email = (string)reader["Email"]
            };
        }
        static Role FetchRole(IDataReader reader)
        {
            return new Role
            {
                Id = (int)reader["Id"],
                Name = (string)reader["Name"],
                Checked = (bool)reader["Checked"]
            };
        }
        static List<Role> FetchRoles(IDataReader reader)
        {
            List<Role> list = new List<Role>();
            while (reader.Read())
            {
                list.Add(FetchRole(reader));
            }
            return list;
        }
        static Role FetchOneRole(IDataReader reader)
        {
            return new Role
            {
                Id = (int)reader["Id"],
                Name = (string)reader["Name"]
            };
        }
        static List<Role> FetchAllRole(IDataReader reader)
        {
            List<Role> list = new List<Role>();
            while (reader.Read())
            {
                list.Add(FetchOneRole(reader));
            }
            return list;
        }

        static byte[] Hash(string username, string password)
        {
            return Helper.Hash(username + "$@#%%@@" + password);
        }
        public int Add(Account obj)
        {
            using (IDbCommand command = connection.CreateCommand())
            {
                command.CommandText = "AddMember";
                command.CommandType = CommandType.StoredProcedure;

                Parameter[] parameters =
                {
                    new Parameter{ Name = "@Id", Value = obj.Id , DbType = DbType.Int64},
                    new Parameter{ Name = "@Ho", Value = obj.Ho, DbType = DbType.String},
                    new Parameter{ Name = "@Ten", Value = obj.Ten, DbType = DbType.String},
                    new Parameter{ Name = "@Username", Value = obj.Username, DbType = DbType.String},
                    new Parameter{ Name = "@Password", Value = Hash(obj.Username,obj.Password), DbType = DbType.Binary},
                    new Parameter{ Name = "@Email", Value = obj.Email, DbType = DbType.String},
                    new Parameter{ Name = "@Address", Value = obj.Address, DbType = DbType.String},
                    new Parameter{ Name = "@SDT", Value = obj.SDT, DbType = DbType.String},
                    new Parameter{ Name = "@Company_Id", Value = obj.CompanyId, DbType = DbType.String},
                    new Parameter{ Name = "@Ret", DbType = DbType.Int32, Direction = ParameterDirection.ReturnValue}
                };
                SetParameter(command, parameters);
                if (command.ExecuteNonQuery() > 0)
                {
                    return 2;
                }
                return (int)command.Parameters["@Ret"];
                //return command.ExecuteNonQuery();
            }
        }
        public Account GetMemberById(long id)
        {
            //return QueryOne("GetMemberById", new Parameter { Name = "@Id", Value = id, DbType = DbType.Int64 });
            using (IDbCommand command = connection.CreateCommand())
            {
                command.CommandText = "GetMemberById";
                command.CommandType = CommandType.StoredProcedure;
                Parameter[] parameters =
                {
                    new Parameter{ Name = "@Id", Value = id, DbType = DbType.Int64},
                };
                SetParameter(command, parameters);
                using (IDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        Account obj = Fetch(reader);
                        if (obj != null && reader.NextResult())
                        {
                            obj.Roles = FetchAllRole(reader);
                        }
                        return obj;
                    }
                    return null;
                }
            }
        }
        //Sign In
        public Account SignIn(string usr, string pwd)
        {
            using (IDbCommand command = connection.CreateCommand())
            {
                command.CommandText = "SignIn";
                command.CommandType = CommandType.StoredProcedure;
                Parameter[] parameters =
                {
                    new Parameter{ Name = "@Username", Value = usr, DbType = DbType.String},
                    new Parameter{ Name = "@Password", Value = Hash(usr,pwd), DbType = DbType.Binary}
                };
                SetParameter(command, parameters);
                using (IDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        Account obj = Fetch(reader);
                        if (obj != null && reader.NextResult())
                        {
                            obj.Roles = FetchAllRole(reader);
                        }
                        return obj;
                    }
                    return null;
                }
            }
        }
        public List<Account> GetMembers()
        {
            return Query("GetMembers");
        }
        public Account GetMemberAndRoles(long id)
        {
            using (IDbCommand command = connection.CreateCommand())
            {
                command.CommandText = "GetMemberAndRoles";
                command.CommandType = CommandType.StoredProcedure;
                SetParameter(command, new Parameter { Name = "@Id", Value = id, DbType = DbType.Int64 });
                using (IDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        Account obj = Fetch(reader);
                        if (reader.NextResult())
                        {
                            obj.Roles = FetchRoles(reader);
                        }
                        return obj;
                    }
                    return null;
                }
            }
        }
        public int Delete(long id)
        {
            return Save("DeleteMember", new Parameter { Name = "@Id", Value = id, DbType = DbType.Int64 });
        }
        public int Update(Account obj)
        {
            Parameter[] parameters =
            {
                new Parameter{ Name = "@Username", Value = obj.Username, DbType = DbType.String},
                new Parameter{ Name = "@OldPassword", Value = Hash(obj.Username,obj.OldPassword), DbType = DbType.Binary},
                //new Parameter{ Name = "@Id", Value = obj.Id, DbType = DbType.Int64},
                new Parameter{ Name = "@NewPassword", Value =  Hash(obj.Username,obj.Password), DbType = DbType.Binary}
            };
            return Save("UpdateMember", parameters);
        }

        public List<Account> GetDelivers()
        {
            using (IDbCommand command = connection.CreateCommand())
            {
                command.CommandText = "GetDelivers";
                command.CommandType = CommandType.StoredProcedure;
                using(IDataReader reader = command.ExecuteReader())
                {
                    List<Account> list = new List<Account>();
                    while (reader.Read())
                    {
                        list.Add(FetchDelivers(reader));
                    }
                    return list;
                }
            }
        }
    }
}
