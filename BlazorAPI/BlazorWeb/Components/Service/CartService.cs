using BlazorWeb.Models;
using Microsoft.JSInterop;
using System.Text.Json;

public class CartService
{
    private readonly HttpClient _httpClient;
    private readonly IJSRuntime _jsRuntime;
    private const string CartStorageKey = "mycart";

    public CartService(IHttpClientFactory httpClientFactory, IJSRuntime jsRuntime)
    {
        _httpClient = httpClientFactory.CreateClient("BlazorAPI");
        _jsRuntime = jsRuntime;
    }

    public async Task<List<CartItemModel>> GetCartAsync()
    {
        var json = await _jsRuntime.InvokeAsync<string>("localStorage.getItem", CartStorageKey);

        if (string.IsNullOrEmpty(json))
        {
            Console.WriteLine("No data found in localStorage.");
            return new List<CartItemModel>(); // Nếu không có dữ liệu trong localStorage, trả về danh sách rỗng
        }

        try
        {
            // Kiểm tra dữ liệu trước khi deserializing
            Console.WriteLine($"Retrieved data from localStorage: {json}");

            var cartItems = JsonSerializer.Deserialize<List<CartItemModel>>(json);

            if (cartItems == null || !cartItems.Any())
            {
                Console.WriteLine("Deserialized cart is empty.");
            }

            return cartItems ?? new List<CartItemModel>(); // Nếu cartItems là null, trả về danh sách rỗng
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error deserializing cart items: {ex.Message}");
            return new List<CartItemModel>(); // Trả về danh sách rỗng nếu có lỗi
        }
    }


    public async Task AddToCartAsync(CartItemModel item)
    {
        var cartItems = await GetCartAsync();

        var existing = cartItems.FirstOrDefault(c => c.CarId == item.CarId);
        if (existing != null)
        {
            existing.Quantity += item.Quantity ?? 1;
        }
        else
        {
            item.Quantity = item.Quantity ?? 1;
            cartItems.Add(item);
        }

        await SaveCartAsync(cartItems);
        // Điều hướng đến trang Cart
    }


    public async Task RemoveFromCartAsync(int carId)
    {
        var cartItems = await GetCartAsync();
        var item = cartItems.FirstOrDefault(c => c.CarId == carId);
        if (item != null)
        {
            cartItems.Remove(item);
            await SaveCartAsync(cartItems);
        }
    }

    public async Task ClearCartAsync()
    {
        await _jsRuntime.InvokeVoidAsync("localStorage.removeItem", CartStorageKey);
    }

    private async Task SaveCartAsync(List<CartItemModel> items)
    {
        var json = JsonSerializer.Serialize(items);
        await _jsRuntime.InvokeVoidAsync("localStorage.setItem", CartStorageKey, json);
    }
}
