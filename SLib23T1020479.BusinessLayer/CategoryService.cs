using SLib23T1020479.DataLayer;
using SLib23T1020479.Models.Entities;

namespace SLib23T1020479.BusinessLayer;

/// <summary>
/// Cung cấp các chức năng nghiệp vụ quản lý thể loại sách.
/// </summary>
public class CategoryService
{
    private readonly CategoryRepository _categoryRepository;

    /// <summary>
    /// Khởi tạo CategoryService với CategoryRepository.
    /// </summary>
    public CategoryService(CategoryRepository categoryRepository)
    {
        _categoryRepository = categoryRepository
            ?? throw new Exception("CategoryRepository không được null.");
    }

    /// <summary>
    /// Lấy danh sách thể loại sách.
    /// </summary>
    public async Task<List<Category>> ListAsync()
    {
        return await _categoryRepository.ListAsync();
    }

    /// <summary>
    /// Lấy thông tin thể loại theo mã.
    /// </summary>
    public async Task<Category> GetAsync(int categoryId)
    {
        if (categoryId <= 0)
            throw new Exception("Mã thể loại phải lớn hơn 0.");

        var category = await _categoryRepository.GetAsync(categoryId);
        if (category == null)
            throw new Exception("Không tìm thấy thể loại.");

        return category;
    }

    /// <summary>
    /// Thêm thể loại mới và trả về mã thể loại vừa tạo.
    /// </summary>
    public async Task<int> AddAsync(Category category)
    {
        ValidateCategory(category);
        await ValidateParentCategoryAsync(category.ParentCategoryId, null);

        return await _categoryRepository.AddAsync(category);
    }

    /// <summary>
    /// Cập nhật thông tin thể loại.
    /// </summary>
    public async Task<bool> UpdateAsync(Category category)
    {
        ValidateCategory(category);

        if (category.CategoryId <= 0)
            throw new Exception("Mã thể loại phải lớn hơn 0.");

        await ValidateParentCategoryAsync(category.ParentCategoryId, category.CategoryId);

        return await _categoryRepository.UpdateAsync(category);
    }

    /// <summary>
    /// Xóa thể loại nếu không được sử dụng và không có thể loại con.
    /// </summary>
    public async Task<bool> DeleteAsync(int categoryId)
    {
        if (categoryId <= 0)
            throw new Exception("Mã thể loại phải lớn hơn 0.");

        if (await _categoryRepository.InUsedAsync(categoryId))
            throw new Exception("Không thể xóa thể loại vì đang được sách tham chiếu hoặc còn thể loại con.");

        return await _categoryRepository.DeleteAsync(categoryId);
    }

    /// <summary>
    /// Kiểm tra tính hợp lệ của thể loại cha
    /// </summary>
    private async Task ValidateParentCategoryAsync(int? parentCategoryId, int? currentCategoryId)
    {
        if (!parentCategoryId.HasValue)
            return;

        if (parentCategoryId.Value <= 0)
            throw new Exception("Mã thể loại cha phải lớn hơn 0.");

        if (currentCategoryId.HasValue && parentCategoryId.Value == currentCategoryId.Value)
            throw new Exception("Thể loại không thể là thể loại cha của chính nó.");

        var parent = await _categoryRepository.GetAsync(parentCategoryId.Value);
        if (parent == null)
            throw new Exception("Không tìm thấy thể loại cha.");
    }

    /// <summary>
    /// Kiểm tra tính hợp lệ của dữ liệu thể loại sách
    /// </summary>
    private static void ValidateCategory(Category category)
    {
        if (category == null)
            throw new Exception("Thông tin thể loại không được null.");

        if (string.IsNullOrWhiteSpace(category.CategoryName))
            throw new Exception("Tên thể loại không được để trống.");
    }
}
