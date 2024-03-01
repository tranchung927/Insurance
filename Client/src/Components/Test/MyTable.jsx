import React, { useState } from 'react';
import { Button, Table, TableBody, TableCell, TableContainer, TableHead, TableRow, Paper } from '@mui/material';
import MyFormDialog from './MyFormDialog'; // Import component MyFormDialog

function MyTable() {
    const [open, setOpen] = useState(false); // Sử dụng useState để quản lý trạng thái mở/đóng của Dialog
    const [selectedRowData, setSelectedRowData] = useState(null); // Sử dụng useState để lưu trữ dữ liệu của hàng được chọn

    // Hàm mở Dialog và thiết lập dữ liệu của hàng được chọn
    const handleOpen = (rowData) => {
        setSelectedRowData(rowData);
        setOpen(true);
    };

    const handleClose = () => {
        setOpen(false); // Đóng Dialog khi được gọi
    };

    // Giả sử dữ liệu của bảng được đặt trong một mảng có tên là rows
    const rows = [
        { id: 1, name: 'John', age: 30 },
        { id: 2, name: 'Jane', age: 25 },
        // Các dòng tiếp theo...
    ];

    return (
        <div>
            <TableContainer component={Paper}> {/* Container cho bảng với component là Paper */}
                <Table>
                    <TableHead>
                        <TableRow>
                            <TableCell>Name</TableCell>
                            <TableCell>Age</TableCell>
                            <TableCell>Action</TableCell> {/* Thêm cột Action */}
                        </TableRow>
                    </TableHead>
                    <TableBody>
                        {/* Mapping qua mỗi hàng trong mảng rows */}
                        {rows.map((row) => (
                            <TableRow key={row.id}>
                                <TableCell>{row.name}</TableCell>
                                <TableCell>{row.age}</TableCell>
                                <TableCell>
                                    {/* Nút mở Dialog và truyền dữ liệu của hàng được chọn */}
                                    <Button variant="outlined" onClick={() => handleOpen(row)}>Open Form</Button>
                                </TableCell> {/* Nút mở Dialog */}
                            </TableRow>
                        ))}
                    </TableBody>
                </Table>
            </TableContainer>
            {/* Truyền trạng thái mở/đóng và dữ liệu của hàng được chọn vào Dialog */}
            <MyFormDialog open={open} onClose={handleClose} selectedRowData={selectedRowData} />
        </div>
    );
}

export default MyTable; // Export component MyTable
