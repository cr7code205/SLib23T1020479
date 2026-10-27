using Dapper;
using Microsoft.Data.SqlClient;
using SLib23T1020479.Models.Entities;
using System.Data;

namespace SLib23T1020479.DataLayer;

/// <summary>
/// Thực hiện các thao tác dữ liệu trên bảng MemberTypes.
/// </summary>
public class MemberTypeRepository
{
    private readonly string _connectionString;

    /// <summary>
    /// Khởi tạo MemberTypeRepository với chuỗi kết nối cơ sở dữ liệu.
    /// </summary>
    /// <param name="connectionString">Chuỗi kết nối SQL Server.</param>
    public MemberTypeRepository(string connectionString)
    {
        _connectionString = connectionString;
    }

    /// <summary>
    /// Lấy danh sách tất cả loại độc giả.
    /// </summary>
    /// <returns>Danh sách loại độc giả.</returns>
    public async Task<List<MemberType>> ListAsync()
    {
        const string sql = @"
            SELECT MemberTypeId, TypeName, MaxActiveLoans, LoanPeriodDays, MaxRenewals, IsActive
            FROM MemberTypes
            ORDER BY TypeName;";

        using IDbConnection connection = new SqlConnection(_connectionString);
        return (await connection.QueryAsync<MemberType>(sql)).ToList();
    }

    /// <summary>
    /// Lấy thông tin loại độc giả theo mã.
    /// </summary>
    /// <param name="memberTypeId">Mã loại độc giả.</param>
    /// <returns>Loại độc giả nếu tìm thấy; ngược lại trả về null.</returns>
    public async Task<MemberType?> GetAsync(int memberTypeId)
    {
        const string sql = @"
            SELECT MemberTypeId, TypeName, MaxActiveLoans, LoanPeriodDays, MaxRenewals, IsActive
            FROM MemberTypes
            WHERE MemberTypeId = @MemberTypeId;";

        using IDbConnection connection = new SqlConnection(_connectionString);
        return await connection.QueryFirstOrDefaultAsync<MemberType>(
            sql, new { MemberTypeId = memberTypeId });
    }

    /// <summary>
    /// Thêm một loại độc giả mới.
    /// </summary>
    /// <param name="memberType">Thông tin loại độc giả cần thêm.</param>
    /// <returns>Mã loại độc giả vừa được tạo.</returns>
    public async Task<int> AddAsync(MemberType memberType)
    {
        const string sql = @"
            INSERT INTO MemberTypes
                (TypeName, MaxActiveLoans, LoanPeriodDays, MaxRenewals, IsActive)
            VALUES
                (@TypeName, @MaxActiveLoans, @LoanPeriodDays, @MaxRenewals, @IsActive);

            SELECT CAST(SCOPE_IDENTITY() AS INT);";

        using IDbConnection connection = new SqlConnection(_connectionString);
        return await connection.ExecuteScalarAsync<int>(sql, memberType);
    }

    /// <summary>
    /// Cập nhật thông tin loại độc giả.
    /// </summary>
    /// <param name="memberType">Thông tin loại độc giả cần cập nhật.</param>
    /// <returns>True nếu cập nhật được bản ghi, ngược lại là False.</returns>
    public async Task<bool> UpdateAsync(MemberType memberType)
    {
        const string sql = @"
            UPDATE MemberTypes
            SET TypeName = @TypeName,
                MaxActiveLoans = @MaxActiveLoans,
                LoanPeriodDays = @LoanPeriodDays,
                MaxRenewals = @MaxRenewals,
                IsActive = @IsActive
            WHERE MemberTypeId = @MemberTypeId;";

        using IDbConnection connection = new SqlConnection(_connectionString);
        int rowsAffected = await connection.ExecuteAsync(sql, memberType);
        return rowsAffected > 0;
    }

    /// <summary>
    /// Xóa loại độc giả theo mã.
    /// </summary>
    /// <param name="memberTypeId">Mã loại độc giả cần xóa.</param>
    /// <returns>True nếu xóa được bản ghi, ngược lại là False.</returns>
    public async Task<bool> DeleteAsync(int memberTypeId)
    {
        const string sql = @"DELETE FROM MemberTypes WHERE MemberTypeId = @MemberTypeId;";

        using IDbConnection connection = new SqlConnection(_connectionString);
        int rowsAffected = await connection.ExecuteAsync(
            sql, new { MemberTypeId = memberTypeId });
        return rowsAffected > 0;
    }

    /// <summary>
    /// Kiểm tra loại độc giả có đang được độc giả sử dụng hay không.
    /// </summary>
    /// <param name="memberTypeId">Mã loại độc giả cần kiểm tra.</param>
    /// <returns>True nếu có độc giả tham chiếu, ngược lại là False.</returns>
    public async Task<bool> InUsedAsync(int memberTypeId)
    {
        const string sql = @"
            SELECT CASE WHEN EXISTS (
                SELECT 1 FROM Members WHERE MemberTypeId = @MemberTypeId
            ) THEN 1 ELSE 0 END;";

        using IDbConnection connection = new SqlConnection(_connectionString);
        return await connection.ExecuteScalarAsync<bool>(
            sql, new { MemberTypeId = memberTypeId });
    }
}
