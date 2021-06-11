using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace DAL
{
    public class AppRepository
    {
        IDbConnection connection;
        public AppRepository(IDbConnection connection)
        {
            this.connection = connection;
        }
        CategoryRepository category;
        ProductRepository product;
        RoleRepository role;
        AccountRepository account;
        AccountInRoleRepository accountInRole;
        OrderItemRepository orderItem;
        OrderRepository order;
        SummaryRepository summary;
        public SummaryRepository Summary
        {
            get
            {
                if(summary is null)
                {
                    summary = new SummaryRepository(connection);
                }
                return summary;
            }
        }
        public OrderItemRepository OderItem
        {
            get
            {
                if (orderItem is null)
                {
                    orderItem = new OrderItemRepository(connection);
                }
                return orderItem;
            }
        }
        public OrderRepository Order
        {
            get
            {
                if (order is null)
                {
                    order = new OrderRepository(connection);
                }
                return order;
            }
        }
        public CategoryRepository Category
        {
            get
            {
                if (category is null)
                {
                    category = new CategoryRepository(connection);
                }
                return category;
            }
        }
        public ProductRepository Product
        {
            get
            {
                if (product is null)
                {
                    product = new ProductRepository(connection);
                }
                return product;
            }
        }
        
        public RoleRepository Role
        {
            get
            {
                if (role is null)
                {
                    role = new RoleRepository(connection);
                }
                return role;
            }
        }
        public AccountRepository Account
        {
            get
            {
                if (account is null)
                {
                    account = new AccountRepository(connection);
                }
                return account;
            }
        }
        public AccountInRoleRepository AccountInRole
        {
            get
            {
                if (accountInRole is null)
                {
                    accountInRole = new AccountInRoleRepository(connection);
                }
                return accountInRole;
            }
        }
    }
}
