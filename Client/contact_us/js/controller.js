// đối tượng đăng ký
function Ticket(name, phone, email, problem, insuranceTypeId) {
    // Kiểm tra nếu một trong các trường không được cung cấp
    if (!name || !phone || !email || !problem || !insuranceTypeId) {
        throw new Error('All fields are required');
    }

    // Kiểm tra định dạng số điện thoại
    if (!isValidPhoneNumber(phone)) {
        throw new Error('Invalid phone number format');
    }

    // Kiểm tra định dạng email
    if (!isValidEmail(email)) {
        throw new Error('Invalid email address format');
    }

    this.name = name;
    this.phone = phone;
    this.email = email;
    this.problem = problem;
    this.insuranceTypeId = insuranceTypeId;
}

// lấy loại bảo hiểm
async function fetchDataFromAPI() {
    try {
        const type = await fetch('https://localhost:7202/api/ClientSupport/GetAllInsuranceType');

        if (!type.ok ) {
        throw new Error('Network response was not ok');
        }
        const data = await type.json();

        console.log(data);

        const selectElement = document.getElementById('type');


        if (data != null && selectElement) {
            for (let i = 0; i < data.length; i++) {
                const option = document.createElement('option'); // Đổi từ option1 thành option
                option.value = data[i].id;
                option.text = data[i].name;
                selectElement.appendChild(option);
            }
        }

    } catch (error) {
        console.error('Error fetching data:', error);
        return null;
    }
}

async function processData() {
    const data = await fetchDataFromAPI();
}



  
const button = document.getElementById("btn_sent");
  
button.addEventListener("click", async (event) => {
    event.preventDefault(); // Ngăn chặn việc gửi biểu mẫu mặc định
  
    // lấy giá trị từ input
    const name = document.getElementById("name").value;
    const phone = document.getElementById("phone").value;
    const email = document.getElementById("email").value;
    const problem = document.getElementById("problem").value;
    const insuranceTypeId = document.getElementById("type").value;

    const type = document.getElementById('type').value;

  
    const url = "https://localhost:7202/api/ClientSupport/AddNewTicket";
    const ticket = new Ticket(name, phone, email, problem, type);
  
    const data = {
      id: 0,
      name: ticket.name,
      phone: ticket.phone,
      email: ticket.email,
      problem: ticket.problem,
      comment: null,
      status: 1,
      usersId: null,
      insuranceTypeId: insuranceTypeId
    };
  
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
  
      // Xử lý kết quả thành công ở đây
      console.log("Request successful!");
    } catch (error) {
      // Xử lý lỗi ở đây
      console.error("Error:", error.message);
    }
});
  
window.addEventListener("load", function() {
    const element = document.querySelector(".cont_centrar");
    if (element) {
      element.classList.add("cent_active");
    } else {
      console.error("Element with class 'cont_centrar' not found in the DOM");
    }
});
  
  