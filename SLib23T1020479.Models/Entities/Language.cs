namespace SLib23T1020479.Models.Entities;

/// <summary>
/// Ngôn ngữ của sách.
/// </summary>
public class Language
{
    /// <summary>
    /// Mã định danh ngôn ngữ.
    /// </summary>
    public int LanguageId { get; set; }

    /// <summary>
    /// Mã ngôn ngữ.
    /// </summary>
    public string LanguageCode { get; set; } = string.Empty;

    /// <summary>
    /// Tên ngôn ngữ.
    /// </summary>
    public string LanguageName { get; set; } = string.Empty;

    /// <summary>
    /// Trạng thái hoạt động của ngôn ngữ.
    /// </summary>
    public bool IsActive { get; set; } = true;
}
