using Imcomere.Pages.Component;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using static Imcomere.Pages.Cart;

namespace Imcomere.Pages
{
    public class Cart(LocalStorage localStorage)
    {

        public async Task<List<CartItem>> getCartItems()
        {
            return (await localStorage.get<List<CartItem>>("CartItems")) ?? new();
        }
        public async Task add(Product product)
        {
            var cartItems = await getCartItems();
            var cartItem = cartItems.FirstOrDefault(item => item.product.id == product.id);
            if (cartItem != null)
            {
                cartItem.quantity++;
            }
            else
            {
                cartItems.Add(new CartItem(product));
            }

            await localStorage.set("CartItems", cartItems);
        }

        public async Task down(Product product)
        {
            var cartItems = await getCartItems();
            var cartItem = cartItems.FirstOrDefault(item => item.product.id == product.id);
            if (cartItem != null) cartItem.quantity--;
            await localStorage.set("CartItems", cartItems);
        }

        public async Task remove(Product product)
        {
            var cartItems = await getCartItems();
            cartItems.RemoveAll(item => item.product.id == product.id);
            await localStorage.set("CartItems", cartItems);
        }

        public async Task changeQuantity(Product product, int quantity)
        {
            var cartItems = await getCartItems();
            var cartItem = cartItems.FirstOrDefault(item => item.product.id == product.id);
            if (cartItem != null) cartItem.quantity = quantity;
            await localStorage.set("CartItems", cartItems);
        }
        public class CartItem(Product product)
        {
            public Product product { get; set; } = product;
            public int quantity { get; set; } = 1;
            public decimal amount => product.price * quantity;
        }

    }
}
