using Dapper;
using Microsoft.Data.SqlClient;
using SLib23T1020479.Models.Entities;
using System.Data;

namespace SLib23T1020479.DataLayer;

/// <summary>
/// Thực hiện các thao tác dữ liệu trên bảng Publishers.
/// </summary>
public class PublisherRepository
{
    private readonly string _connectionString;

    /// <summary>
    /// Khởi tạo PublisherRepository với chuỗi kết nối cơ sở dữ liệu.
    /// </summary>
    /// <param name="connectionString">Chuỗi kết nối SQL Server.</param>
    public PublisherRepository(string connectionString)
    {
        _connectionString = connectionString;
    }

    /// <summary>
    /// Lấy danh sách tất cả nhà xuất bản.
    /// </summary>
    /// <returns>Danh sách nhà xuất bản.</returns>
    public async Task<List<Publisher>> ListAsync()
    {
        const string sql = @"
                SELECT PublisherId, PublisherName, Address, Phone,
                       Email, Website, IsActive, CreatedAt
                FROM Publishers
                ORDER BY PublisherName;";

        using IDbConnection connection =
            new SqlConnection(_connectionString);

        return (await connection.QueryAsync<Publisher>(sql)).ToList();
    }

    /// <summary>
    /// Lấy thông tin nhà xuất bản theo mã.
    /// </summary>
    /// <param name="publisherId">Mã nhà xuất bản.</param>
    /// <returns>Nhà xuất bản nếu tìm thấy; ngược lại trả về null.</returns>
    public async Task<Publisher?> GetAsync(int publisherId)
    {
        const string sql = @"
                SELECT PublisherId, PublisherName, Address, Phone,
                       Email, Website, IsActive, CreatedAt
                FROM Publishers
                WHERE PublisherId = @PublisherId;";

        using IDbConnection connection =
            new SqlConnection(_connectionString);

        return await connection.QueryFirstOrDefaultAsync<Publisher>(
            sql, new { PublisherId = publisherId });
    }

    /// <summary>
    /// Thêm một nhà xuất bản mới.
    /// </summary>
    /// <param name="publisher">Thông tin nhà xuất bản cần thêm.</param>
    /// <returns>Mã nhà xuất bản vừa được tạo.</returns>
    public async Task<int> AddAsync(Publisher publisher)
    {
        const string sql = @"
                INSERT INTO Publishers
                    (PublisherName, Address, Phone, Email, Website, IsActive)
                VALUES
                    (@PublisherName, @Address, @Phone, @Email, @Website, @IsActive);

                SELECT CAST(SCOPE_IDENTITY() AS INT);";

        using IDbConnection connection =
            new SqlConnection(_connectionString);

        return await connection.ExecuteScalarAsync<int>(sql, publisher);
    }

    /// <summary>
    /// Cập nhật thông tin nhà xuất bản.
    /// </summary>
    /// <param name="publisher">Thông tin nhà xuất bản cần cập nhật.</param>
    /// <returns>True nếu cập nhật được bản ghi, ngược lại là False.</returns>
    public async Task<bool> UpdateAsync(Publisher publisher)
    {
        const string sql = @"
                UPDATE Publishers
                SET PublisherName = @PublisherName,
                    Address = @Address,
                    Phone = @Phone,
                    Email = @Email,
                    Website = @Website,
                    IsActive = @IsActive
                WHERE PublisherId = @PublisherId;";

        using IDbConnection connection =
            new SqlConnection(_connectionString);

        int rowsAffected = await connection.ExecuteAsync(sql, publisher);

        return rowsAffected > 0;
    }

    /// <summary>
    /// Xóa nhà xuất bản theo mã.
    /// </summary>
    /// <param name="publisherId">Mã nhà xuất bản cần xóa.</param>
    /// <returns>True nếu xóa được bản ghi, ngược lại là False.</returns>
    public async Task<bool> DeleteAsync(int publisherId)
    {
        const string sql = @"
                DELETE FROM Publishers
                WHERE PublisherId = @PublisherId;";

        using IDbConnection connection =
            new SqlConnection(_connectionString);

        int rowsAffected = await connection.ExecuteAsync(
            sql, new { PublisherId = publisherId });

        return rowsAffected > 0;
    }

    /// <summary>
    /// Kiểm tra nhà xuất bản có đang được sách tham chiếu hay không.
    /// </summary>
    /// <param name="publisherId">Mã nhà xuất bản cần kiểm tra.</param>
    /// <returns>True nếu có sách tham chiếu, ngược lại là False.</returns>
    public async Task<bool> InUsedAsync(int publisherId)
    {
        const string sql = @"
                SELECT CASE
                    WHEN EXISTS (
                        SELECT 1
                        FROM Books
                        WHERE PublisherId = @PublisherId
                    )
                    THEN 1
                    ELSE 0
                END;";

        using IDbConnection connection =
            new SqlConnection(_connectionString);

        return await connection.ExecuteScalarAsync<bool>(
            sql, new { PublisherId = publisherId });
    }
}
