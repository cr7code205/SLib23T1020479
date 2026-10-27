namespace SLib23T1020479.Models.Entities;

/// <summary>
/// Thể loại sách, có thể được tổ chức theo cấu trúc phân cấp.
/// </summary>
public class Category
{
    /// <summary>
    /// Mã định danh thể loại.
    /// </summary>
    public int CategoryId { get; set; }

    /// <summary>
    /// Tên thể loại.
    /// </summary>
    public string CategoryName { get; set; } = string.Empty;

    /// <summary>
    /// Mã thể loại cha; null nếu là thể loại gốc.
    /// </summary>
    public int? ParentCategoryId { get; set; }

    /// <summary>
    /// Mô tả thể loại.
    /// </summary>
    public string? Description { get; set; }

    /// <summary>
    /// Trạng thái hoạt động của thể loại.
    /// </summary>
    public bool IsActive { get; set; } = true;
}
