//using Microsoft.AspNetCore.Components;
//using Microsoft.AspNetCore.Components.Forms;
//using BlazorWeb.Models;
//using System.Collections.Generic;
//using System.IO;
//using System.Threading.Tasks;
//using Microsoft.JSInterop;

//public partial class ProductComponent : ComponentBase
//{
//    protected List<Product> products = new();
//    protected Product editingProduct = new();
//    protected bool isEditing = false;
//    protected string? imagePreviewUrl;
//    protected IBrowserFile? selectedFile;
//    [Inject] protected IJSRuntime? JS { get; set; }
//    [Inject] protected ProductService? ProductService { get; set; }

//    protected override async Task OnInitializedAsync()
//    {
//        await LoadProducts();
//    }

//    protected async Task LoadProducts()
//    {
//        products = await ProductService.GetProductsAsync();
//    }

//    protected void CreateProduct()
//    {
//        editingProduct = new Product();
//        isEditing = true;
//    }

//    protected void EditProduct(Product product)
//    {
//        editingProduct = new Product
//        {
//            Id = product.Id,
//            Name = product.Name,
//            Price = product.Price,
//            Description = product.Description,
//            Image = product.Image
//        };
//        isEditing = true;
//    }

//    protected void CancelEdit()
//    {
//        // 🟢 Reset lại model và ảnh preview
//        editingProduct = new Product();
//        //imagePreviewUrl = null;
//        selectedFile = null;
//        isEditing = false;
//    }

//    protected async Task DeleteProduct(int id)
//    {
//        await ProductService.DeleteProductAsync(id);
//        await JS.InvokeVoidAsync("alert", "✅ Xóa sản phẩm thành công!");
//        await LoadProducts();
//    }
//    protected async Task SaveProduct()
//    {
//        // 🔹 Nếu có file mới, chỉ upload một lần
//        if (selectedFile != null)
//        {
//            editingProduct.Image = await SaveImageFile(selectedFile);
//            selectedFile = null; // Reset file sau khi lưu
//        }

//        if (editingProduct.Id == 0)
//        {
//            await ProductService.AddProductAsync(editingProduct);
//            await JS.InvokeVoidAsync("alert", "✅ Thêm sản phẩm thành công!");
//        }
//        else
//        {
//            await ProductService.UpdateProductAsync(editingProduct);
//            await JS.InvokeVoidAsync("alert", "✅ Cập nhật sản phẩm thành công!");
//        }

//        await LoadProducts();

//        // 🟢 Reset lại model và ảnh preview
//        editingProduct = new Product();
//        imagePreviewUrl = null;
//        isEditing = false;
//    }
//    protected async Task HandleFileSelected(InputFileChangeEventArgs e)
//    {
//        selectedFile = e.File;
//        if (selectedFile == null) return;

//        string[] allowedExtensions = { ".jpg", ".jpeg", ".png", ".gif" };
//        string fileExtension = Path.GetExtension(selectedFile.Name).ToLower();

//        if (!allowedExtensions.Contains(fileExtension))
//        {
//            await JS.InvokeVoidAsync("alert", "❌ Định dạng file không hợp lệ!");
//            return;
//        }

//        long maxFileSize = 2 * 1024 * 1024;
//        if (selectedFile.Size > maxFileSize)
//        {
//            await JS.InvokeVoidAsync("alert", "❌ File quá lớn! Chỉ cho phép tối đa 2MB.");
//            return;
//        }

//        // 🟢 Hiển thị ảnh preview ngay lập tức (Base64)
//        using var stream = selectedFile.OpenReadStream();
//        using var memoryStream = new MemoryStream();
//        await stream.CopyToAsync(memoryStream);
//        byte[] imageBytes = memoryStream.ToArray();
//        string base64String = Convert.ToBase64String(imageBytes);
//        imagePreviewUrl = $"data:{selectedFile.ContentType};base64,{base64String}";

//        Console.WriteLine("📷 Ảnh đã chọn, nhưng chưa lưu!");
//    }
//    protected async Task<string> SaveImageFile(IBrowserFile file)
//    {
//        var uploadPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "uploads");

//        if (!Directory.Exists(uploadPath))
//        {
//            Directory.CreateDirectory(uploadPath);
//        }

//        // 🟢 Tạo tên file mới bằng GUID
//        string newFileName = $"{Guid.NewGuid()}{Path.GetExtension(file.Name)}";
//        string filePath = Path.Combine(uploadPath, newFileName);

//        using var stream = new FileStream(filePath, FileMode.Create);
//        await file.OpenReadStream().CopyToAsync(stream);

//        return $"/uploads/{newFileName}"; // Chỉ trả về tên file
//    }

//    protected async Task ForceDownloadImage(string fileName)
//    {
//        bool confirmDownload = await JS.InvokeAsync<bool>("confirm", $"Bạn có muốn tải xuống {fileName.Replace("uploads/", "").Replace("/uploads/", "")} không?");
//        if (!confirmDownload) return;
//        // 🟢 ĐƯỜNG DẪN DOWNLOADS CỦA NGƯỜI DÙNG
//        string userDownloadsFolder = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile), "Downloads");

//        // 🟢 Kiểm tra thư mục "Downloads", nếu chưa có thì tạo mới
//        if (!Directory.Exists(userDownloadsFolder))
//        {
//            Directory.CreateDirectory(userDownloadsFolder);
//        }

//        // 🟢 ĐƯỜNG DẪN FILE GỐC TRONG "wwwroot/uploads"
//        var sourcePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "uploads", Path.GetFileName(fileName));

//        if (!File.Exists(sourcePath))
//        {
//            Console.WriteLine("❌ File không tồn tại!");
//            return;
//        }

//        // 🟢 Sao chép file sang thư mục "Downloads"
//        string destinationPath = Path.Combine(userDownloadsFolder, Path.GetFileName(fileName));
//        File.Copy(sourcePath, destinationPath, true);
//        await JS.InvokeVoidAsync("alert", "Tải thành công.");
//        Console.WriteLine($"✅ File đã được tải xuống: {destinationPath}");
//    }

//}
