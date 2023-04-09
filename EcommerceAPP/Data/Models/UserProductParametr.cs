using EcommerceAPP.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceAPP.Data.Models
{
    public record class UserProductParameter(User User, Product Product) : ISendable 
    {
    }
}
