using Dapper;
using Microsoft.Data.SqlClient;
using SLib23T1020479.Models.Entities;
using System.Data;

namespace SLib23T1020479.DataLayer;

/// <summary>
/// Thực hiện các thao tác dữ liệu trên bảng Authors.
/// </summary>
public class AuthorRepository
{
    private readonly string _connectionString;

    /// <summary>
    /// Khởi tạo AuthorRepository với chuỗi kết nối cơ sở dữ liệu.
    /// </summary>
    /// <param name="connectionString">Chuỗi kết nối SQL Server.</param>
    public AuthorRepository(string connectionString)
    {
        _connectionString = connectionString;
    }

    /// <summary>
    /// Lấy danh sách tất cả tác giả.
    /// </summary>
    /// <returns>Danh sách tác giả.</returns>
    public async Task<List<Author>> ListAsync()
    {
        const string sql = @"
            SELECT AuthorId, AuthorName, Biography, BirthDate, DeathDate, IsActive
            FROM Authors
            ORDER BY AuthorName;";

        using IDbConnection connection = new SqlConnection(_connectionString);
        return (await connection.QueryAsync<Author>(sql)).ToList();
    }

    /// <summary>
    /// Lấy thông tin tác giả theo mã.
    /// </summary>
    /// <param name="authorId">Mã tác giả.</param>
    /// <returns>Tác giả nếu tìm thấy; ngược lại trả về null.</returns>
    public async Task<Author?> GetAsync(int authorId)
    {
        const string sql = @"
            SELECT AuthorId, AuthorName, Biography, BirthDate, DeathDate, IsActive
            FROM Authors
            WHERE AuthorId = @AuthorId;";

        using IDbConnection connection = new SqlConnection(_connectionString);
        return await connection.QueryFirstOrDefaultAsync<Author>(
            sql, new { AuthorId = authorId });
    }

    /// <summary>
    /// Thêm một tác giả mới.
    /// </summary>
    /// <param name="author">Thông tin tác giả cần thêm.</param>
    /// <returns>Mã tác giả vừa được tạo.</returns>
    public async Task<int> AddAsync(Author author)
    {
        const string sql = @"
            INSERT INTO Authors (AuthorName, Biography, BirthDate, DeathDate, IsActive)
            VALUES (@AuthorName, @Biography, @BirthDate, @DeathDate, @IsActive);

            SELECT CAST(SCOPE_IDENTITY() AS INT);";

        using IDbConnection connection = new SqlConnection(_connectionString);
        return await connection.ExecuteScalarAsync<int>(sql, author);
    }

    /// <summary>
    /// Cập nhật thông tin tác giả.
    /// </summary>
    /// <param name="author">Thông tin tác giả cần cập nhật.</param>
    /// <returns>True nếu cập nhật được bản ghi, ngược lại là False.</returns>
    public async Task<bool> UpdateAsync(Author author)
    {
        const string sql = @"
            UPDATE Authors
            SET AuthorName = @AuthorName,
                Biography = @Biography,
                BirthDate = @BirthDate,
                DeathDate = @DeathDate,
                IsActive = @IsActive
            WHERE AuthorId = @AuthorId;";

        using IDbConnection connection = new SqlConnection(_connectionString);
        int rowsAffected = await connection.ExecuteAsync(sql, author);
        return rowsAffected > 0;
    }

    /// <summary>
    /// Xóa tác giả theo mã.
    /// </summary>
    /// <param name="authorId">Mã tác giả cần xóa.</param>
    /// <returns>True nếu xóa được bản ghi, ngược lại là False.</returns>
    public async Task<bool> DeleteAsync(int authorId)
    {
        const string sql = @"DELETE FROM Authors WHERE AuthorId = @AuthorId;";

        using IDbConnection connection = new SqlConnection(_connectionString);
        int rowsAffected = await connection.ExecuteAsync(
            sql, new { AuthorId = authorId });
        return rowsAffected > 0;
    }

    /// <summary>
    /// Kiểm tra tác giả có đang được sách tham chiếu hay không.
    /// </summary>
    /// <param name="authorId">Mã tác giả cần kiểm tra.</param>
    /// <returns>True nếu có sách tham chiếu, ngược lại là False.</returns>
    public async Task<bool> InUsedAsync(int authorId)
    {
        const string sql = @"
            SELECT CASE WHEN EXISTS (
                SELECT 1 FROM BookAuthors WHERE AuthorId = @AuthorId
            ) THEN 1 ELSE 0 END;";

        using IDbConnection connection = new SqlConnection(_connectionString);
        return await connection.ExecuteScalarAsync<bool>(
            sql, new { AuthorId = authorId });
    }
}
