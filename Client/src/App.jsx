
// Import các Hooks từ React:
import { useEffect, useState } from 'react';
// Import CSS:
import './App.css';

// Khởi tạo component App:
function App() {
    // Khởi tạo state forecasts:
    // Sử dụng Hook useState để khởi tạo state forecasts. forecasts là một mảng dùng để lưu trữ dữ liệu về dự báo thời tiết
    const [forecasts, setForecasts] = useState();

    // Sử dụng Effect Hook useEffect để gọi hàm populateWeatherData sau khi component 
    // được render lần đầu tiên([] là dependencies array rỗng).
    useEffect(() => {
        populateWeatherData();
    }, []);

    // Biến contents chứa nội dung của component. Nếu forecasts chưa được định nghĩa, nó sẽ hiển thị 
    // một thông báo "Loading...", ngược lại nó sẽ hiển thị một bảng chứa dữ liệu dự báo thời tiết.
    const contents = forecasts === undefined
        ? <p><em>Loading... Please refresh once the ASP.NET backend has started. See <a href="https://aka.ms/jspsintegrationreact">https://aka.ms/jspsintegrationreact</a> for more details.</em></p>
        : <table className="table table-striped" aria-labelledby="tabelLabel">
            <h1>hahahahahahaha</h1>
            <thead>
                <tr>
                    <th>Date</th>
                    <th>Temp. (C)</th>
                    <th>Temp. (F)</th>
                    <th>Summary</th>
                </tr>
            </thead>
            <tbody>
                {forecasts.map(forecast =>
                    <tr key={forecast.date}>
                        <td>{forecast.date}</td>
                        <td>{forecast.temperatureC}</td>
                        <td>{forecast.temperatureF}</td>
                        <td>{forecast.summary}</td>
                    </tr>
                )}
            </tbody>
        </table>;

    return (
        <div>
            {contents}
        </div>
    );


    // Hàm populateWeatherData là một hàm async sử dụng fetch để gửi yêu cầu đến API 'weatherforecast' của backend.
    // Sau đó, nó lấy dữ liệu từ phản hồi và cập nhật state forecasts bằng hàm setForecasts.
    async function populateWeatherData() {
        const response = await fetch('weatherforecast');
        const data = await response.json();
        setForecasts(data);
    }
}

// Export component App để có thể sử dụng ở các thành phần khác trong ứng dụng của bạn.
export default App;