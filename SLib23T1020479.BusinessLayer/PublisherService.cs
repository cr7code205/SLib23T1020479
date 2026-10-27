using SLib23T1020479.DataLayer;
using SLib23T1020479.Models.Entities;
using System.Net.Mail;

namespace SLib23T1020479.BusinessLayer;

/// <summary>
/// Cung cấp các chức năng nghiệp vụ quản lý nhà xuất bản.
/// </summary>
public class PublisherService
{
    private readonly PublisherRepository _publisherRepository;

    /// <summary>
    /// Khởi tạo PublisherService với PublisherRepository.
    /// </summary>
    public PublisherService(PublisherRepository publisherRepository)
    {
        _publisherRepository = publisherRepository
            ?? throw new Exception("PublisherRepository không được null.");
    }

    /// <summary>
    /// Lấy danh sách nhà xuất bản.
    /// </summary>
    public async Task<List<Publisher>> ListAsync()
    {
        return await _publisherRepository.ListAsync();
    }

    /// <summary>
    /// Lấy thông tin nhà xuất bản theo mã.
    /// </summary>
    public async Task<Publisher> GetAsync(int publisherId)
    {
        if (publisherId <= 0)
            throw new Exception("Mã nhà xuất bản phải lớn hơn 0.");

        var publisher = await _publisherRepository.GetAsync(publisherId);

        if (publisher == null)
            throw new Exception("Không tìm thấy nhà xuất bản.");

        return publisher;
    }

    /// <summary>
    /// Thêm nhà xuất bản mới.
    /// </summary>
    public async Task<int> AddAsync(Publisher publisher)
    {
        ValidatePublisher(publisher);

        return await _publisherRepository.AddAsync(publisher);
    }

    /// <summary>
    /// Cập nhật thông tin nhà xuất bản.
    /// </summary>
    public async Task<bool> UpdateAsync(Publisher publisher)
    {
        ValidatePublisher(publisher);

        if (publisher.PublisherId <= 0)
            throw new Exception("Mã nhà xuất bản phải lớn hơn 0.");

        return await _publisherRepository.UpdateAsync(publisher);
    }

    /// <summary>
    /// Xóa nhà xuất bản theo mã.
    /// </summary>
    public async Task<bool> DeleteAsync(int publisherId)
    {
        // Không cho xóa nhà xuất bản đang được sách sử dụng.
        bool inUsed = await _publisherRepository.InUsedAsync(publisherId);

        if (inUsed)
            throw new Exception("Không thể xóa nhà xuất bản vì đang được sách tham chiếu.");

        return await _publisherRepository.DeleteAsync(publisherId);
    }

    /// <summary>
    /// Kiểm tra tính hợp lệ của dữ liệu nhà xuất bản.
    /// </summary>
    private static void ValidatePublisher(Publisher publisher)
    {
        if (publisher == null)
            throw new Exception("Thông tin nhà xuất bản không được null.");

        if (string.IsNullOrWhiteSpace(publisher.PublisherName))
            throw new Exception("Tên nhà xuất bản không được để trống.");

        // Email không bắt buộc, nhưng nếu nhập thì phải hợp lệ.
        if (!string.IsNullOrWhiteSpace(publisher.Email))
        {
            try
            {
                var email = new MailAddress(publisher.Email);

                if (email.Address != publisher.Email.Trim())
                    throw new Exception("Email không hợp lệ.");
            }
            catch (FormatException)
            {
                throw new Exception("Email không đúng định dạng.");
            }
        }

        // Website không bắt buộc, nhưng nếu nhập thì phải là URL hợp lệ.
        if (!string.IsNullOrWhiteSpace(publisher.Website))
        {
            bool validWebsite = Uri.TryCreate(
                publisher.Website,
                UriKind.Absolute,
                out Uri? uri)
                && (uri.Scheme == Uri.UriSchemeHttp
                    || uri.Scheme == Uri.UriSchemeHttps);

            if (!validWebsite)
                throw new Exception(
                    "Website không hợp lệ. Vui lòng nhập URL bắt đầu bằng http:// hoặc https://.");
        }
    }
}
