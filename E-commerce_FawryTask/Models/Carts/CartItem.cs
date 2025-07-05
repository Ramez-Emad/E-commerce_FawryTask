using E_commerce_FawryTask.Models.Products;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_commerce_FawryTask.Models.Carts;
public class CartItem(Product product, int quantity)
{
    public Product Product { get; } = product;
    public int Quantity { get; } = quantity;
}
