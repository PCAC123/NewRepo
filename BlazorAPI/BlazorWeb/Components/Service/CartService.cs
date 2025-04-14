using BlazorWeb.Models;
using Microsoft.JSInterop;

namespace BlazorWeb.Components.Service
{
    public class CartService
    {
        private readonly IJSRuntime _js;
        public List<CartItemModel> CartItems { get; private set; } = new();

        public CartService(IJSRuntime js)
        {
            _js = js;
        }

        public async Task LoadCartFromStorageAsync()
        {
            CartItems = await _js.InvokeAsync<List<CartItemModel>>("cartStorage.getCart");
        }

        public async Task AddToCartAsync(CartItemModel item)
        {
            var existingItem = CartItems.FirstOrDefault(p => p.CarId == item.CarId && p.UserId == item.UserId);
            if (existingItem != null)
            {
                existingItem.Quantity += item.Quantity;
            }
            else
            {
                CartItems.Add(item);
            }

            await SaveCartToStorageAsync();
        }

        public async Task RemoveFromCartAsync(int carId, int userId)
        {
            var item = CartItems.FirstOrDefault(p => p.CarId == carId && p.UserId == userId);
            if (item != null)
            {
                CartItems.Remove(item);
                await SaveCartToStorageAsync();
            }
        }

        public async Task ClearCartAsync()
        {
            CartItems.Clear();
            await _js.InvokeVoidAsync("cartStorage.clearCart");
        }

        public async Task SaveCartToStorageAsync()
        {
            await _js.InvokeVoidAsync("cartStorage.saveCart", CartItems);
        }

        public decimal GetTotal(int userId) =>
            CartItems
                .Where(item => item.UserId == userId)
                .Sum(item => item.Price * item.Quantity);
    }
}
