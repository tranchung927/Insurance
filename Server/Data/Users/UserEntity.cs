using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace Server.Data.Users
{
    // IdentityUser: Là lớp đại diện cho bảng AspNetUsers
    // kế thừa để tùy chỉnh thêm các thuộc tính mới cho người dùng (bảng AspNetUsers)
    // các bảng còn lại sẽ kế thừa các lớp còn lại tương ứng
    public class UserEntity : IdentityUser
    {
        // thuộc tính PhoneNumber và Password trong IdentityUser được quản
        // lý thông qua các phương thức và thuộc tính được cung cấp sẵn
        [MaxLength(50)] // Đặt độ dài tối đa của first name
        public string FirstName { get; set; }

        [MaxLength(50)] // Đặt độ dài tối đa của last name
        public string LastName { get; set; }

        [MaxLength(255)] // Đặt độ dài tối đa của địa chỉ
        public string Address { get; set; }

        public int Status { get; set; } // Kiểu dữ liệu của trạng thái có thể được điều chỉnh tùy thuộc vào yêu cầu cụ thể
    }
}
