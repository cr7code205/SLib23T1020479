using SLib23T1020479.DataLayer;
using SLib23T1020479.Models.Entities;

namespace SLib23T1020479.BusinessLayer;

/// <summary>
/// Cung cấp các chức năng nghiệp vụ quản lý tác giả.
/// </summary>
public class AuthorService
{
    private readonly AuthorRepository _authorRepository;

    /// <summary>
    /// Khởi tạo AuthorService với AuthorRepository.
    /// </summary>
    public AuthorService(AuthorRepository authorRepository)
    {
        _authorRepository = authorRepository
            ?? throw new Exception("AuthorRepository không được null.");
    }

    /// <summary>
    /// Lấy danh sách tác giả.
    /// </summary>
    public async Task<List<Author>> ListAsync()
    {
        return await _authorRepository.ListAsync();
    }

    /// <summary>
    /// Lấy thông tin tác giả theo mã.
    /// </summary>
    public async Task<Author> GetAsync(int authorId)
    {
        if (authorId <= 0)
            throw new Exception("Mã tác giả phải lớn hơn 0.");

        var author = await _authorRepository.GetAsync(authorId);

        if (author == null)
            throw new Exception("Không tìm thấy tác giả.");

        return author;
    }

    /// <summary>
    /// Thêm tác giả mới và trả về mã tác giả vừa tạo.
    /// </summary>
    public async Task<int> AddAsync(Author author)
    {
        ValidateAuthor(author);
        return await _authorRepository.AddAsync(author);
    }

    /// <summary>
    /// Cập nhật thông tin tác giả.
    /// </summary>
    public async Task<bool> UpdateAsync(Author author)
    {
        ValidateAuthor(author);

        if (author.AuthorId <= 0)
            throw new Exception("Mã tác giả phải lớn hơn 0.");       

        return await _authorRepository.UpdateAsync(author);       
    }

    /// <summary>
    /// Xóa tác giả theo mã nếu không được sách tham chiếu.
    /// </summary>
    public async Task<bool> DeleteAsync(int authorId)
    {
        if (authorId <= 0)
            throw new Exception("Mã tác giả phải lớn hơn 0.");              

        if (await _authorRepository.InUsedAsync(authorId))
            throw new Exception("Không thể xóa tác giả vì đang được sách tham chiếu.");

        return await _authorRepository.DeleteAsync(authorId);        
    }

    /// <summary>
    /// Kiểm tra tính hợp lệ của dữ liệu tác giả
    /// </summary>   
    private static void ValidateAuthor(Author author)
    {
        if (author == null)
            throw new Exception("Thông tin tác giả không được null.");

        if (string.IsNullOrWhiteSpace(author.AuthorName))
            throw new Exception("Tên tác giả không được để trống.");

        if (author.BirthDate.HasValue && author.DeathDate.HasValue
            && author.DeathDate.Value.Date < author.BirthDate.Value.Date)
            throw new Exception("Ngày mất không được trước ngày sinh.");
    }
}
