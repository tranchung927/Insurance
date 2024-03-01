import React, { useState } from 'react';
import { Button, Dialog, DialogTitle, DialogContent, DialogActions, TextField } from '@mui/material';

function MyFormDialog({ open, onClose, selectedRowData }) {
    const [formData, setFormData] = useState({}); // Sử dụng useState để lưu trữ dữ liệu của Form

    // Hàm xử lý thay đổi dữ liệu của Form khi người dùng nhập liệu
    const handleChange = (event) => {
        setFormData({ ...formData, [event.target.name]: event.target.value });
    };

    // Hàm xử lý khi người dùng nhấn nút Submit
    const handleSubmit = () => {
        // Xử lý dữ liệu từ Form
        console.log('Dữ liệu từ Form:', formData);
        onClose(); // Đóng Dialog
    };

    return (
        <Dialog open={open} onClose={onClose}> {/* Dialog mở/đóng dựa vào trạng thái open */}
            <DialogTitle>Form Dialog</DialogTitle>
            <DialogContent>
                <TextField
                    autoFocus
                    margin="dense"
                    name="name"
                    label="Name"
                    type="text"
                    fullWidth
                    value={selectedRowData ? selectedRowData.name : ''} // Giá trị mặc định của trường Name
                    onChange={handleChange} // Sự kiện thay đổi giá trị của trường Name
                />
                <TextField
                    margin="dense"
                    name="age"
                    label="Age"
                    type="text"
                    fullWidth
                    value={selectedRowData ? selectedRowData.age : ''} // Giá trị mặc định của trường Age
                    onChange={handleChange} // Sự kiện thay đổi giá trị của trường Age
                />
                {/* Thêm các trường dữ liệu khác nếu cần */}
            </DialogContent>
            <DialogActions>
                <Button onClick={onClose}>Cancel</Button> {/* Nút hủy */}
                <Button onClick={handleSubmit}>Submit</Button> {/* Nút gửi */}
            </DialogActions>
        </Dialog>
    );
}

export default MyFormDialog; // Export component MyFormDialog
