using Dapper;
using Microsoft.Data.SqlClient;
using SLib23T1020479.Models.Entities;
using System.Data;

namespace SLib23T1020479.DataLayer;

/// <summary>
/// Thực hiện các thao tác dữ liệu trên bảng Languages.
/// </summary>
public class LanguageRepository
{
    private readonly string _connectionString;

    /// <summary>
    /// Khởi tạo LanguageRepository với chuỗi kết nối cơ sở dữ liệu.
    /// </summary>
    /// <param name="connectionString">Chuỗi kết nối SQL Server.</param>
    public LanguageRepository(string connectionString)
    {
        _connectionString = connectionString;
    }

    /// <summary>
    /// Lấy danh sách tất cả ngôn ngữ.
    /// </summary>
    /// <returns>Danh sách ngôn ngữ.</returns>
    public async Task<List<Language>> ListAsync()
    {
        const string sql = @"
            SELECT LanguageId, LanguageCode, LanguageName, IsActive
            FROM Languages
            ORDER BY LanguageName;";

        using IDbConnection connection = new SqlConnection(_connectionString);
        return (await connection.QueryAsync<Language>(sql)).ToList();
    }

    /// <summary>
    /// Lấy thông tin ngôn ngữ theo mã.
    /// </summary>
    /// <param name="languageId">Mã ngôn ngữ.</param>
    /// <returns>Ngôn ngữ nếu tìm thấy; ngược lại trả về null.</returns>
    public async Task<Language?> GetAsync(int languageId)
    {
        const string sql = @"
            SELECT LanguageId, LanguageCode, LanguageName, IsActive
            FROM Languages
            WHERE LanguageId = @LanguageId;";

        using IDbConnection connection = new SqlConnection(_connectionString);
        return await connection.QueryFirstOrDefaultAsync<Language>(
            sql, new { LanguageId = languageId });
    }

    /// <summary>
    /// Thêm một ngôn ngữ mới.
    /// </summary>
    /// <param name="language">Thông tin ngôn ngữ cần thêm.</param>
    /// <returns>Mã ngôn ngữ vừa được tạo.</returns>
    public async Task<int> AddAsync(Language language)
    {
        const string sql = @"
            INSERT INTO Languages (LanguageCode, LanguageName, IsActive)
            VALUES (@LanguageCode, @LanguageName, @IsActive);

            SELECT CAST(SCOPE_IDENTITY() AS INT);";

        using IDbConnection connection = new SqlConnection(_connectionString);
        return await connection.ExecuteScalarAsync<int>(sql, language);
    }

    /// <summary>
    /// Cập nhật thông tin ngôn ngữ.
    /// </summary>
    /// <param name="language">Thông tin ngôn ngữ cần cập nhật.</param>
    /// <returns>True nếu cập nhật được bản ghi, ngược lại là False.</returns>
    public async Task<bool> UpdateAsync(Language language)
    {
        const string sql = @"
            UPDATE Languages
            SET LanguageCode = @LanguageCode,
                LanguageName = @LanguageName,
                IsActive = @IsActive
            WHERE LanguageId = @LanguageId;";

        using IDbConnection connection = new SqlConnection(_connectionString);
        int rowsAffected = await connection.ExecuteAsync(sql, language);
        return rowsAffected > 0;
    }

    /// <summary>
    /// Xóa ngôn ngữ theo mã.
    /// </summary>
    /// <param name="languageId">Mã ngôn ngữ cần xóa.</param>
    /// <returns>True nếu xóa được bản ghi, ngược lại là False.</returns>
    public async Task<bool> DeleteAsync(int languageId)
    {
        const string sql = @"DELETE FROM Languages WHERE LanguageId = @LanguageId;";

        using IDbConnection connection = new SqlConnection(_connectionString);
        int rowsAffected = await connection.ExecuteAsync(
            sql, new { LanguageId = languageId });
        return rowsAffected > 0;
    }

    /// <summary>
    /// Kiểm tra ngôn ngữ có đang được sách tham chiếu hay không.
    /// </summary>
    /// <param name="languageId">Mã ngôn ngữ cần kiểm tra.</param>
    /// <returns>True nếu có sách tham chiếu, ngược lại là False.</returns>
    public async Task<bool> InUsedAsync(int languageId)
    {
        const string sql = @"
            SELECT CASE WHEN EXISTS (
                SELECT 1 FROM Books WHERE LanguageId = @LanguageId
            ) THEN 1 ELSE 0 END;";

        using IDbConnection connection = new SqlConnection(_connectionString);
        return await connection.ExecuteScalarAsync<bool>(
            sql, new { LanguageId = languageId });
    }
}
