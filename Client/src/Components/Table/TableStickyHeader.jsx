// ** React Imports
import React, { useState } from 'react';

// ** MUI Imports
import Paper from '@mui/material/Paper'
import Table from '@mui/material/Table'
import TableRow from '@mui/material/TableRow'
import TableHead from '@mui/material/TableHead'
import TableBody from '@mui/material/TableBody'
import TableCell from '@mui/material/TableCell'
import TableContainer from '@mui/material/TableContainer'
import TablePagination from '@mui/material/TablePagination'
import Button from '@mui/material/Button';

import AccountCheckOutline from 'mdi-material-ui/AccountCheckOutline'
import AccountAlertOutline from 'mdi-material-ui/AccountAlertOutline'
import AccountClockOutline from 'mdi-material-ui/AccountClockOutline'
import AccessPointOff from 'mdi-material-ui/AccessPointOff'
import FormDialog from './FormDialog';

const icons = {
    AccountCheckOutline,
    AccountAlertOutline,
    AccountClockOutline,
    AccessPointOff
}



// Định nghĩa cấu trúc cột cho bảng

const columns = [
    // Cột Tên với độ rộng tối thiểu
    { id: 'id', label: 'id', minWidth: 30, align: 'center', }, 
    { id: 'name', label: 'Name', minWidth: 170, align: 'center', }, 
    {
        id: 'type',
        label: 'Type of insurance',
        minWidth: 170,
        align: 'center',
        // Định dạng dữ liệu dân số để hiển thị theo định dạng địa phương
        format: value => value.toLocaleString('en-US')
    }
    ,
    {
        id: 'email',
        label: 'Email',
        minWidth: 170,
        align: 'center',
        // Định dạng dữ liệu diện tích để hiển thị theo định dạng địa phương
        format: value => value.toLocaleString('en-US')
    },
    {
        id: 'phone',
        label: 'Phone',
        minWidth: 100,
        align: 'center',
        // Định dạng dữ liệu diện tích để hiển thị theo định dạng địa phương
        format: value => value.toLocaleString('en-US')
    },
    {
        id: 'action',
        label: 'Action',
        minWidth: 170,
        align: 'center',
        // Định dạng dữ liệu mật độ để hiển thị với hai chữ số thập phân
        format: value => value.toFixed(2)
    },
    {
        id: 'status',
        label: 'Status',
        minWidth: 50,
        align: 'center',
        // Định dạng dữ liệu mật độ để hiển thị với hai chữ số thập phân
        format: value => value.toFixed(2)
    }
]


// Hàm để chọn icon dựa trên giá trị của trường "status"
const getStatusIcon = (status) => {
    switch (status) {
        case 1:
            return <icons.AccountCheckOutline color="primary" />;
        case 2:
            return <icons.AccountClockOutline color="warning" /> ;
        case 3:
            return <icons.AccountAlertOutline color="error" />;
        default:
            return <icons.AccessPointOff/>;
            
    }
}


// Định nghĩa hàm để lấy dữ liệu từ API 
class ClientSupport {
    // Constructor - hàm khởi tạo
    constructor(id, name, insuranceType, email, phone, problem, status, comment) {
        this.id=id,
        this.type = insuranceType
        this.name = name;
        this.email = email;
        this.phone = phone;
        this.problem = problem;
        this.status = status;
        this.comment = comment
    }
}

function createClientSupport(dataTicket, dataInsuranceType) {
    let clientSupportList = [];
    dataTicket.forEach(itemA => {
        const insuranceType = dataInsuranceType.find(itemB => itemB.id === itemA.insuranceTypeId);
        if (insuranceType) {
            clientSupportList.push(
                new ClientSupport(
                    itemA.id,
                    itemA.name,
                    insuranceType.name,
                    itemA.email,
                    itemA.phone,
                    itemA.problem,
                    itemA.status,
                    itemA.comment
                )
            );
        }
    });
    return clientSupportList;
}

async function getDataFromAPI() {
    const responseTicket = await fetch('https://localhost:7202/api/ClientSupport/GetAllTicket');
    const responseInsuranceType = await fetch('https://localhost:7202/api/ClientSupport/GetAllInsuranceType');

    if (!responseTicket.ok || !responseInsuranceType.ok) {
        throw new Error('Network response was not ok');
    }
    const dataTicket = await responseTicket.json();
    const dataInsuranceType = await responseInsuranceType.json();

    const list = createClientSupport(dataTicket, dataInsuranceType);
    return list;
}

const rows = await getDataFromAPI();


// Component chức năng cho một bảng có tiêu đề 
const TableStickyHeader = () => {
    // ** Trạng thái

    // Biến trạng thái cho trang hiện tại, khởi tạo là 0
    const [page, setPage] = useState(0)
    // Biến trạng thái cho số dòng trên mỗi trang, khởi tạo là 25
    const [rowsPerPage, setRowsPerPage] = useState(25)

    // dialog

    const [openDialog, setOpenDialog] = useState(false); // Sử dụng useState để quản lý trạng thái mở/đóng của Dialog
    const [selectedRowData, setSelectedRowData] = useState(null); // Sử dụng useState để lưu trữ dữ liệu của hàng được chọn

    // Hàm mở Dialog và thiết lập dữ liệu của hàng được chọn
    const handleOpenDialog = (rowData) => {
        setSelectedRowData(rowData);
        setOpenDialog(true);
    };

    const handleCloseDialog = () => {
        setOpenDialog(false); // Đóng Dialog khi được gọi
    };

    // Hàm xử lý thay đổi trang
    const handleChangePage = (event, newPage) => {
        // Cập nhật trang hiện tại
        setPage(newPage)

    }

    // Hàm xử lý thay đổi số dòng trên mỗi trang
    const handleChangeRowsPerPage = event => {
        // Cập nhật số dòng trên mỗi trang
        setRowsPerPage(+event.target.value)
        // Đặt lại trang về trang đầu tiên
        setPage(0)
    }

    return (
        <Paper sx={{ width: '100%', overflow: 'hidden' }}>
            <TableContainer sx={{ maxHeight: 440 }}>
                <Table stickyHeader aria-label='sticky table'>
                    <TableHead>
                        <TableRow>
                            {columns.map(column => (
                                <TableCell key={column.id} align={column.align} sx={{ minWidth: column.minWidth }}>
                                    {column.label}
                                </TableCell>
                            ))}
                        </TableRow>
                    </TableHead>
                    <TableBody>
                        {rows.slice(page * rowsPerPage, page * rowsPerPage + rowsPerPage).map(row => {
                            return (
                                <TableRow hover role='checkbox' tabIndex={-1} key={row.id}>
                                    {columns.map(column => {
                                        const value = row[column.id];
                                        return (
                                            <TableCell key={column.id} align={column.align}>
                                                {/*Nếu column.id là 'status', nó sẽ gọi hàm getStatusIcon(value)*/}
                                                {/*Nếu column.id là 'action', nó sẽ render một nút "Action" và gán một hàm xử lý sự kiện handleButtonClick(row)*/}
                                                {column.id === 'status' ? getStatusIcon(value) : (column.id === 'action' ? (
                                                    <Button onClick={() => handleOpenDialog(row)} size="small" variant="outlined">Support</Button>
                                                ) : (
                                                    column.format && typeof value === 'number' ? column.format(value) : value
                                                ))}
                                            </TableCell>
                                        );
                                    })}
                                </TableRow>
                            );
                        })}
                    </TableBody>

                </Table>
                
                
            </TableContainer>
            <TablePagination
                rowsPerPageOptions={[10, 25, 100]}
                component='div'
                count={rows.length}
                rowsPerPage={rowsPerPage}
                page={page}
                onPageChange={handleChangePage}
                onRowsPerPageChange={handleChangeRowsPerPage}
            />
            
            {/* Truyền trạng thái mở/đóng và dữ liệu của hàng được chọn vào Dialog */}
            {/*{console.log('openDialog: ',openDialog) }*/}
            <FormDialog open={openDialog} onClose={handleCloseDialog} selectedRowData={selectedRowData} callback={setSelectedRowData} />

        </Paper>

    )
}

export default TableStickyHeader
