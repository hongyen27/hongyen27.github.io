using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebClient.Models
{
    public class AppService
    {
        CategoryService category;
        ProductService product;
        RoleService role;
        AccountService member;
        OrderItemService cart;
        OrderService order;
        public OrderService Order
        {
            get
            {
                if (order is null)
                {
                    order = new OrderService();
                }
                return order;
            }
        }
        public OrderItemService Cart
        {
            get
            {
                if (cart is null)
                {
                    cart = new OrderItemService();
                }
                return cart;
            }
        }
        public CategoryService Category
        {
            get
            {
                if (category is null)
                {
                    category = new CategoryService();
                }
                return category;
            }
        }
        public ProductService Product
        {
            get
            {
                if (product is null)
                {
                    product = new ProductService();
                }
                return product;
            }
        }
        public RoleService Role
        {
            get
            {
                if (role is null)
                {
                    role = new RoleService();
                }
                return role;
            }
        }
        public AccountService Member
        {
            get
            {
                if (member is null)
                {
                    member = new AccountService();
                }
                return member;
            }
        }
    }
}
