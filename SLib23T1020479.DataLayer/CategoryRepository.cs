using Dapper;
using Microsoft.Data.SqlClient;
using SLib23T1020479.Models.Entities;
using System.Data;

namespace SLib23T1020479.DataLayer;

/// <summary>
/// Thực hiện các thao tác dữ liệu trên bảng Categories.
/// </summary>
public class CategoryRepository
{
    private readonly string _connectionString;

    /// <summary>
    /// Khởi tạo CategoryRepository với chuỗi kết nối cơ sở dữ liệu.
    /// </summary>
    /// <param name="connectionString">Chuỗi kết nối SQL Server.</param>
    public CategoryRepository(string connectionString)
    {
        _connectionString = connectionString;
    }

    /// <summary>
    /// Lấy danh sách tất cả thể loại sách.
    /// </summary>
    /// <returns>Danh sách thể loại sách.</returns>
    public async Task<List<Category>> ListAsync()
    {
        const string sql = @"
            SELECT CategoryId, CategoryName, ParentCategoryId, Description, IsActive
            FROM Categories
            ORDER BY CategoryName;";

        using IDbConnection connection = new SqlConnection(_connectionString);
        return (await connection.QueryAsync<Category>(sql)).ToList();
    }

    /// <summary>
    /// Lấy thông tin thể loại theo mã.
    /// </summary>
    /// <param name="categoryId">Mã thể loại.</param>
    /// <returns>Thể loại nếu tìm thấy; ngược lại trả về null.</returns>
    public async Task<Category?> GetAsync(int categoryId)
    {
        const string sql = @"
            SELECT CategoryId, CategoryName, ParentCategoryId, Description, IsActive
            FROM Categories
            WHERE CategoryId = @CategoryId;";

        using IDbConnection connection = new SqlConnection(_connectionString);
        return await connection.QueryFirstOrDefaultAsync<Category>(
            sql, new { CategoryId = categoryId });
    }

    /// <summary>
    /// Thêm một thể loại sách mới.
    /// </summary>
    /// <param name="category">Thông tin thể loại cần thêm.</param>
    /// <returns>Mã thể loại vừa được tạo.</returns>
    public async Task<int> AddAsync(Category category)
    {
        const string sql = @"
            INSERT INTO Categories (CategoryName, ParentCategoryId, Description, IsActive)
            VALUES (@CategoryName, @ParentCategoryId, @Description, @IsActive);

            SELECT CAST(SCOPE_IDENTITY() AS INT);";

        using IDbConnection connection = new SqlConnection(_connectionString);
        return await connection.ExecuteScalarAsync<int>(sql, category);
    }

    /// <summary>
    /// Cập nhật thông tin thể loại sách.
    /// </summary>
    /// <param name="category">Thông tin thể loại cần cập nhật.</param>
    /// <returns>True nếu cập nhật được bản ghi, ngược lại là False.</returns>
    public async Task<bool> UpdateAsync(Category category)
    {
        const string sql = @"
            UPDATE Categories
            SET CategoryName = @CategoryName,
                ParentCategoryId = @ParentCategoryId,
                Description = @Description,
                IsActive = @IsActive
            WHERE CategoryId = @CategoryId;";

        using IDbConnection connection = new SqlConnection(_connectionString);
        int rowsAffected = await connection.ExecuteAsync(sql, category);
        return rowsAffected > 0;
    }

    /// <summary>
    /// Xóa thể loại sách theo mã.
    /// </summary>
    /// <param name="categoryId">Mã thể loại cần xóa.</param>
    /// <returns>True nếu xóa được bản ghi, ngược lại là False.</returns>
    public async Task<bool> DeleteAsync(int categoryId)
    {
        const string sql = @"DELETE FROM Categories WHERE CategoryId = @CategoryId;";

        using IDbConnection connection = new SqlConnection(_connectionString);
        int rowsAffected = await connection.ExecuteAsync(
            sql, new { CategoryId = categoryId });
        return rowsAffected > 0;
    }

    /// <summary>
    /// Kiểm tra thể loại có đang được sách hoặc thể loại con tham chiếu hay không.
    /// </summary>
    /// <param name="categoryId">Mã thể loại cần kiểm tra.</param>
    /// <returns>True nếu có tham chiếu, ngược lại là False.</returns>
    public async Task<bool> InUsedAsync(int categoryId)
    {
        const string sql = @"
            SELECT CASE WHEN EXISTS (
                SELECT 1 FROM BookCategories WHERE CategoryId = @CategoryId
            ) OR EXISTS (
                SELECT 1 FROM Categories WHERE ParentCategoryId = @CategoryId
            ) THEN 1 ELSE 0 END;";

        using IDbConnection connection = new SqlConnection(_connectionString);
        return await connection.ExecuteScalarAsync<bool>(
            sql, new { CategoryId = categoryId });
    }
}
