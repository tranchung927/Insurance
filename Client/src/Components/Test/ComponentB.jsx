// Import React và hook useState, useEffect từ thư viện 'react'
import React, { useState, useEffect } from 'react';

// Định nghĩa functional component có tên là ComponentB và nhận props { value, onChange }
const ComponentB = ({ value, onChange }) => {
    // Khởi tạo state 'localValue' với giá trị ban đầu là 'value' và hàm 'setLocalValue' để cập nhật state
    const [localValue, setLocalValue] = useState(value);

     /*Sử dụng useEffect để theo dõi sự thay đổi của 'value' và cập nhật 'localValue' khi 'value' thay đổi*/
    useEffect(() => {
        setLocalValue(value);
    }, [value]);

    // Hàm callback được gọi khi người dùng click vào nút 'Change Value to 'y'' để cập nhật 'value' thông qua prop 'onChange' truyền từ ComponentA
    const handleChange = () => {
        const newValue = 'y';
        onChange(newValue);
    };

    // Trả về JSX code của ComponentB
    return (
        <div>
            <p>Value in B: {localValue}</p>
            <button onClick={handleChange}>Change Value to y</button>
        </div>
    );
};

// Export ComponentB để có thể sử dụng ở các file khác trong ứng dụng React
export default ComponentB;
