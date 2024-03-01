// Hàm kiểm tra định dạng số điện thoại
function isValidPhoneNumber(phone) {
    // Sử dụng biểu thức chính quy để kiểm tra
    // ở đây là một ví dụ, bạn có thể điều chỉnh nó tùy theo yêu cầu cụ thể của bạn
    var phoneRegex = /^[0-9]{10}$/;
    return phoneRegex.test(phone);
}

// Hàm kiểm tra định dạng email
function isValidEmail(email) {
    // Sử dụng biểu thức chính quy để kiểm tra
    // ở đây là một ví dụ, bạn có thể điều chỉnh nó tùy theo yêu cầu cụ thể của bạn
    var emailRegex = /^[^\s@]+@[^\s@]+\.[^\s@]+$/;
    return emailRegex.test(email);
}