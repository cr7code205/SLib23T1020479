using SLib23T1020479.DataLayer;
using SLib23T1020479.Models.Entities;

namespace SLib23T1020479.BusinessLayer;

/// <summary>
/// Cung cấp các chức năng nghiệp vụ quản lý ngôn ngữ.
/// </summary>
public class LanguageService
{
    private readonly LanguageRepository _languageRepository;

    /// <summary>
    /// Khởi tạo LanguageService với LanguageRepository.
    /// </summary>
    public LanguageService(LanguageRepository languageRepository)
    {
        _languageRepository = languageRepository
            ?? throw new Exception("LanguageRepository không được null.");
    }

    /// <summary>
    /// Lấy danh sách ngôn ngữ.
    /// </summary>
    public async Task<List<Language>> ListAsync()
    {
        return await _languageRepository.ListAsync();
    }

    /// <summary>
    /// Lấy thông tin ngôn ngữ theo mã.
    /// </summary>
    public async Task<Language> GetAsync(int languageId)
    {
        if (languageId <= 0)
            throw new Exception("Mã ngôn ngữ phải lớn hơn 0.");

        var language = await _languageRepository.GetAsync(languageId);
        if (language == null)
            throw new Exception("Không tìm thấy ngôn ngữ.");

        return language;
    }

    /// <summary>
    /// Thêm ngôn ngữ mới và trả về mã ngôn ngữ vừa tạo.
    /// </summary>
    public async Task<int> AddAsync(Language language)
    {
        ValidateLanguage(language);
        return await _languageRepository.AddAsync(language);
    }

    /// <summary>
    /// Cập nhật thông tin ngôn ngữ.
    /// </summary>
    public async Task<bool> UpdateAsync(Language language)
    {
        ValidateLanguage(language);

        if (language.LanguageId <= 0)
            throw new Exception("Mã ngôn ngữ phải lớn hơn 0.");

        return await _languageRepository.UpdateAsync(language);        
    }

    /// <summary>
    /// Xóa ngôn ngữ nếu không được sách tham chiếu.
    /// </summary>
    public async Task<bool> DeleteAsync(int languageId)
    {
        if (languageId <= 0)
            throw new Exception("Mã ngôn ngữ phải lớn hơn 0.");

        if (await _languageRepository.InUsedAsync(languageId))
            throw new Exception("Không thể xóa ngôn ngữ vì đang được sách tham chiếu.");

        return await _languageRepository.DeleteAsync(languageId);        
    }

    /// <summary>
    /// Kiểm tra tính hợp lệ của dữ liệu ngôn ngữ
    /// </summary>
    private static void ValidateLanguage(Language language)
    {
        if (language == null)
            throw new Exception("Thông tin ngôn ngữ không được null.");

        if (string.IsNullOrWhiteSpace(language.LanguageCode))
            throw new Exception("Mã ngôn ngữ không được để trống.");

        if (string.IsNullOrWhiteSpace(language.LanguageName))
            throw new Exception("Tên ngôn ngữ không được để trống.");
    }
}
