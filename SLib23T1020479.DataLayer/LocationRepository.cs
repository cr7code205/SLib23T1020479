using Dapper;
using Microsoft.Data.SqlClient;
using SLib23T1020479.Models.Entities;
using System.Data;

namespace SLib23T1020479.DataLayer;

/// <summary>
/// Thực hiện các thao tác dữ liệu trên bảng Locations.
/// </summary>
public class LocationRepository
{
    private readonly string _connectionString;

    /// <summary>
    /// Khởi tạo LocationRepository với chuỗi kết nối cơ sở dữ liệu.
    /// </summary>
    /// <param name="connectionString">Chuỗi kết nối SQL Server.</param>
    public LocationRepository(string connectionString)
    {
        _connectionString = connectionString;
    }

    /// <summary>
    /// Lấy danh sách tất cả vị trí lưu trữ.
    /// </summary>
    /// <returns>Danh sách vị trí lưu trữ.</returns>
    public async Task<List<Location>> ListAsync()
    {
        const string sql = @"
            SELECT LocationId, LocationCode, LocationName, Floor, Room, Shelf, Description, IsActive
            FROM Locations
            ORDER BY LocationCode;";

        using IDbConnection connection = new SqlConnection(_connectionString);
        return (await connection.QueryAsync<Location>(sql)).ToList();
    }

    /// <summary>
    /// Lấy thông tin vị trí lưu trữ theo mã.
    /// </summary>
    /// <param name="locationId">Mã vị trí lưu trữ.</param>
    /// <returns>Vị trí nếu tìm thấy; ngược lại trả về null.</returns>
    public async Task<Location?> GetAsync(int locationId)
    {
        const string sql = @"
            SELECT LocationId, LocationCode, LocationName, Floor, Room, Shelf, Description, IsActive
            FROM Locations
            WHERE LocationId = @LocationId;";

        using IDbConnection connection = new SqlConnection(_connectionString);
        return await connection.QueryFirstOrDefaultAsync<Location>(
            sql, new { LocationId = locationId });
    }

    /// <summary>
    /// Thêm một vị trí lưu trữ mới.
    /// </summary>
    /// <param name="location">Thông tin vị trí cần thêm.</param>
    /// <returns>Mã vị trí vừa được tạo.</returns>
    public async Task<int> AddAsync(Location location)
    {
        const string sql = @"
            INSERT INTO Locations
                (LocationCode, LocationName, Floor, Room, Shelf, Description, IsActive)
            VALUES
                (@LocationCode, @LocationName, @Floor, @Room, @Shelf, @Description, @IsActive);

            SELECT CAST(SCOPE_IDENTITY() AS INT);";

        using IDbConnection connection = new SqlConnection(_connectionString);
        return await connection.ExecuteScalarAsync<int>(sql, location);
    }

    /// <summary>
    /// Cập nhật thông tin vị trí lưu trữ.
    /// </summary>
    /// <param name="location">Thông tin vị trí cần cập nhật.</param>
    /// <returns>True nếu cập nhật được bản ghi, ngược lại là False.</returns>
    public async Task<bool> UpdateAsync(Location location)
    {
        const string sql = @"
            UPDATE Locations
            SET LocationCode = @LocationCode,
                LocationName = @LocationName,
                Floor = @Floor,
                Room = @Room,
                Shelf = @Shelf,
                Description = @Description,
                IsActive = @IsActive
            WHERE LocationId = @LocationId;";

        using IDbConnection connection = new SqlConnection(_connectionString);
        int rowsAffected = await connection.ExecuteAsync(sql, location);
        return rowsAffected > 0;
    }

    /// <summary>
    /// Xóa vị trí lưu trữ theo mã.
    /// </summary>
    /// <param name="locationId">Mã vị trí cần xóa.</param>
    /// <returns>True nếu xóa được bản ghi, ngược lại là False.</returns>
    public async Task<bool> DeleteAsync(int locationId)
    {
        const string sql = @"DELETE FROM Locations WHERE LocationId = @LocationId;";

        using IDbConnection connection = new SqlConnection(_connectionString);
        int rowsAffected = await connection.ExecuteAsync(
            sql, new { LocationId = locationId });
        return rowsAffected > 0;
    }

    /// <summary>
    /// Kiểm tra vị trí lưu trữ có đang được bản sao sách sử dụng hay không.
    /// </summary>
    /// <param name="locationId">Mã vị trí cần kiểm tra.</param>
    /// <returns>True nếu có bản sao sách tham chiếu, ngược lại là False.</returns>
    public async Task<bool> InUsedAsync(int locationId)
    {
        const string sql = @"
            SELECT CASE WHEN EXISTS (
                SELECT 1 FROM BookCopies WHERE LocationId = @LocationId
            ) THEN 1 ELSE 0 END;";

        using IDbConnection connection = new SqlConnection(_connectionString);
        return await connection.ExecuteScalarAsync<bool>(
            sql, new { LocationId = locationId });
    }
}
