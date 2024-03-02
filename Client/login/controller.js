// Hàm tạo đối tượng đăng nhập
function SignInUser(userName, password) {
  // Xác thực độ dài và bảo mật của tên người dùng và mật khẩu
  if (userName.length < 8 || password.length < 8) {
    throw new Error('Tên người dùng và mật khẩu phải dài ít nhất 8 ký tự.');
  }
  
  const regexUserName = /[a-zA-Z0-9]/;
  const regexPassword = /^(?=.*[A-Z])(?=.*[a-z])(?=.*[0-9])(?=.*[!@#$%^&*()_+\-=\[\]{};':"\\|,.<>\/?]).{8,}$/;
  
  if (!regexUserName.test(userName) || !regexPassword.test(password)) {
    throw new Error('Tên người dùng và mật khẩu phải chứa các ký tự chữ và số.');
  }
  
  // Lưu trữ mật khẩu an toàn (băm và muối)
  this.userName = userName;
  this.password = password;
}

// đối tượng đăng ký
function SignUpUser(email, password, phone, userName,firstName, lastName) {
  this.userName = userName;
  this.email = email;
  this.password = password;
  this.phone = phone;
  this.firstName = firstName;
  this.lastName = lastName;
}


const button = document.getElementById("btn_sign");

button.addEventListener("click", async (event) => {
  event.preventDefault(); // Ngăn chặn việc gửi biểu mẫu mặc định

  // lấy giá trị từ input
  const email = document.getElementById("email").value;
  const userName = document.getElementById("userName").value;
  const password = document.getElementById("password").value;
  const phone = document.getElementById("phone").value;
  const firstName = document.getElementById("firstName").value;
  const lastName = document.getElementById("lastName").value;

  // kiểm tra đang đăng ký hay đăng nhập
  if (button.textContent == "SIGN IN") {
    const url = "https://localhost:7202/api/Login/SignIn";
    const user = new SignInUser(userName, password);
    const data = {
      userName: user.userName,
      password: user.password
    }

    console.log("SIGN IN");

    try {
      // gửi request
      const response = await fetch(url, {
        method: "POST",
        headers: {
          accept: "*/*",
          "Content-Type": "application/json",
        },
        body: JSON.stringify(data),
      });

      if (!response.ok) {
        throw new Error(`Request failed with status ${response.status}`);
      }

      const token = await response.text(); // Truy cập mã thông báo trực tiếp
      console.log("set token:", token);
      // Lưu token vào localStorage
        localStorage.setItem("token", token);
        const tokenxxx = localStorage.getItem('token');
        console.log("get token:", tokenxxx);
    } catch (error) {
      console.error("Lỗi tạo người dùng:", error.message);
    }
  } 
  else {
    console.log("SIGN UP");
    const user = new SignUpUser(email, password, phone, userName, firstName,lastName);
    const url = "https://localhost:7202/api/Login/SignUp";

    const data = {
      firstName: user.firstName,
      lastName: user.lastName,
      userName: user.userName,
      email: user.email,
      password: user.password,
      phoneNumber: user.phone,
      address: "",
      status: 1
    }

    try {
      const response = await fetch(url, {
        method: "POST",
        headers: {
          accept: "*/*",
          "Content-Type": "application/json",
        },
        body: JSON.stringify(data),
      });

      if (!response.ok) {
        throw new Error(`Request failed with status ${response.status}`);
      }
    } catch (error) {
      console.error("Lỗi tạo người dùng:", error.message);
      // Hiển thị thông báo lỗi cho người dùng
    }
  }

  // đẩy lên sever
});

window.onload = function () {
  document.querySelector(".cont_centrar").className =
    "cont_centrar cent_active";
};
