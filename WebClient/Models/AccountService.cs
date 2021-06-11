using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebClient.Models
{
    public class AccountService : BaseService
    {
        public int Add(Account obj)
        {
            return Post<Account>("account", obj);
        }
        public Account SignIn(string usr, string pwd)
        {
            return SignIn<Account>($"auth/{usr}&{pwd}");
        }
        public List<Account> GetMembers()
        {
            return Gets<Account>("account");
        }
        public Account GetMemberAndRoles(long id)
        {
            return Get<Account>($"account/{id}");
        }
        public int Edit(AccountInRole obj)
        {
            return Put<AccountInRole>($"account/{obj.AccountId}", obj);
        }
        public Account GetMemberById(long id)
        {
            return Get<Account>($"account/{id}");
        }
        public int ChangePwd(Account obj)
        {
            return Put<Account>($"account/{obj.Username}&{obj.OldPassword}", obj);
        }
        public List<Account> GetDelivers()
        {
            return Gets<Account>("account/getdeliver");
        }
    }
}
