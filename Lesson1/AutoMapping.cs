using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Entities;
using DTO;
using AutoMapper;


namespace Lesson1
{
    public class AutoMapping: Profile
    {
        public AutoMapping()
        {
            CreateMap<Category,CategoryDTO>().ReverseMap();
            CreateMap<Order, OrderDTO>().ReverseMap();
            CreateMap<OrderItem, OrderItemDTO>().ReverseMap();
            CreateMap<Product, ProductDTO>().ReverseMap();
            CreateMap<User, UserDTO>().ReverseMap();

        }

    }
}
