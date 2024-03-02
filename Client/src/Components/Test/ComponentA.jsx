// Import React và hook useState, useEffect từ thư viện 'react'
import React, { useState, useEffect } from 'react';

// Import ComponentB từ file './ComponentB'
import ComponentB from './ComponentB';

// Định nghĩa functional component có tên là ComponentA
const ComponentA = () => {
    // Khởi tạo state 'value' với giá trị ban đầu là 'x' và hàm 'setValue' để cập nhật state
    const [value, setValue] = useState('x');

    // Sử dụng useEffect để theo dõi sự thay đổi của 'value' và in ra console khi có thay đổi
    useEffect(() => {
        console.log('Value changed in A:', value);
    }, [value]);

    // Hàm callback được truyền vào ComponentB để cập nhật giá trị của 'value' khi 'value' trong B thay đổi
    const handleBChange = (newValue) => {
        setValue(newValue);
    };

    // Hàm callback được gọi khi người dùng click vào nút 'Change Value in A' để cập nhật 'value' thành 'New Value in A'
    const handleChange = () => {
        const newValue = 'New Value in A';
        setValue(newValue);
    };

    // Trả về JSX code của ComponentA
    return (
        <div>
            <p>Value in A: {value}</p>
            <button onClick={handleChange}>Change Value in A</button>
            {/* Render ComponentB và truyền vào prop 'value' và 'onChange' */}
            <ComponentB value={value} onChange={handleBChange} />
        </div>
    );
};

// Export ComponentA để có thể sử dụng ở các file khác trong ứng dụng React
export default ComponentA;


// KẾT LUẬN

    // Hàm callback handleBChange đóng vai trò chính trong việc truyền giá trị từ ComponentB sang ComponentA.
    // useEffect giúp render lại ComponentA sau khi giá trị value được cập nhật, đảm bảo giao diện hiển thị chính xác.
    // nếu không có usereffect  thì giá trị vẫn dc truyền qua nhưng sẽ ko render lại