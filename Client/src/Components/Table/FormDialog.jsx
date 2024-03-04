import React, { useState, useEffect } from 'react';
import {
    Button,
    Dialog,
    Grid,
    Card,
    CardContent,
    TextField,
    MenuItem,
    InputAdornment,
    Select,
    InputLabel,
    FormControl,
    DialogTitle,
    DialogContent,
    DialogActions,
    Box,
    Typography
} from '@mui/material';
import AlternateEmailIcon from '@mui/icons-material/AlternateEmail';
import CallIcon from '@mui/icons-material/Call';
import AddModeratorOutlinedIcon from '@mui/icons-material/AddModeratorOutlined';
import MessageOutline from 'mdi-material-ui/MessageOutline'
import AccountBoxIcon from '@mui/icons-material/AccountBox';


function FormDialog({ open, onClose, selectedRowData }) {
    console.log('x.selectedRowData: ', selectedRowData);
    // khi selectedRowData có sự thay đổi (ở đây là từ null thành có giá trị)
    // sẽ đẩy giá trị mới vào formData
    useEffect(() => {
        setFormData(selectedRowData);
    }, [selectedRowData]);

    
    
    console.log('selectedRowData:', selectedRowData);
        
    const [formData, setFormData] = useState(selectedRowData);

    const handleChange = (event) => {
        const { name, value } = event.target;

        // Kiểm tra nếu name là 'status' (tức là sự kiện thay đổi của Select)
        if (name === 'status') {
            // Cập nhật giá trị của formData.status với giá trị mới
            setFormData({ ...formData, [name]: value });
        } else {
            // Nếu không phải là sự kiện thay đổi của Select, tiếp tục xử lý như bình thường
            setFormData({ ...formData, [name]: value });
        }
    };

    // sự kiện khi nhập vào ô textFeild
    const handleChangeTex = (event) => {
        // Lấy tên trường và giá trị từ sự kiện
        const { name, value } = event.target;

        // Cập nhật trạng thái của formData bằng cách sao chép trạng thái hiện tại và ghi đè trường được chỉ định với giá trị mới
        setFormData({ ...formData, [name]: value });
    };

    const handleSubmit = () => {
        // Truy xuất token từ localStorage
        const token = localStorage.getItem('token');
        console.log('Token: ', token);

        // Gửi dữ liệu đến API
        const apiUrl = '';
        console.log(formData);
        fetch(apiUrl, {
            method: 'POST',
            headers: {
                'Accept': 'text/plain',
                'Content-Type': 'application/json',
                'Authorization': `Bearer ${token}` // Thêm token vào tiêu đề Authorization
            },
            body: JSON.stringify(formData)
        })
            .then(response => {
                if (response.ok) {
                    console.log('Ticket added successfully.');
                    onClose(); // Đóng dialog sau khi gửi thành công
                } else {
                    console.error('Failed to add ticket.');
                }
            })
            .catch(error => {
                console.error('Error adding ticket:', error);
            });
    };


    return (
        <Dialog open={open} onClose={onClose} >
            <DialogTitle>Client information</DialogTitle>

            <DialogContent sx={{ display: 'flex', flexDirection: 'column', gap: '10px' }}>
                <Card >
                        
                    <CardContent >
                        <Box sx={{ display: 'flex', flexDirection: 'column', gap: '10px' }}>
                            <Box sx={{ display: 'flex', alignItems: 'center' }}>
                                <CallIcon sx={{ color: 'primary.main', marginRight: 2.75 }} fontSize='small' />
                                <Typography variant='body2'>Phone: {formData && formData.phone}</Typography>
                            </Box>
                            <Box sx={{ display: 'flex', alignItems: 'center' }}>
                                <AccountBoxIcon sx={{ color: 'primary.main', marginRight: 2.75 }} fontSize='small' />
                                <Typography variant='body2'>Name: {formData && formData.name}</Typography>
                            </Box>
                            <Box sx={{ display: 'flex', alignItems: 'center' }}>
                                <AlternateEmailIcon sx={{ color: 'primary.main', marginRight: 2.75 }} fontSize='small' />
                                <Typography variant='body2'>Email: {formData && formData.email}</Typography>
                            </Box>
                            <Box sx={{ display: 'flex', alignItems: 'center' }}>
                                <AddModeratorOutlinedIcon sx={{ color: 'primary.main', marginRight: 2.75 }} fontSize='small' />
                                <Typography variant='body2'>Type: {formData && formData.type}</Typography>
                            </Box>

                        </Box>
                            
                    </CardContent>
                </Card >
                <Typography variant='h6'>Messages</Typography>

                <Card >
                    
                    <CardContent>
                        <Typography variant='body1'>{formData && formData.problem}</Typography>
                    </CardContent>
                </Card >

                {/*input*/}
                <Typography variant='h6'>Respond</Typography>
                <Card >
                    <CardContent>
                        <form onSubmit={e => e.preventDefault()}>
                            <Grid container spacing={2}>
                                <Grid item xs={12}>
                                    <TextField
                                        fullWidth
                                        multiline
                                        minRows={3}
                                        label='Message'
                                        name="comment"
                                        value={formData ? formData.comment : ''}
                                        onChange={handleChangeTex}
                                        placeholder='Bio...'
                                        sx={{ '& .MuiOutlinedInput-root': { alignItems: 'baseline' } }}
                                        InputProps={{
                                            startAdornment: (
                                                <InputAdornment position='start'>
                                                    <MessageOutline />
                                                </InputAdornment>
                                            )
                                        }}
                                    />
                                </Grid>
                                <Grid item xs={12}>
                                    <FormControl fullWidth>
                                        <InputLabel id="demo-simple-select-label">Change status</InputLabel>
                                        <Select
                                            labelId="demo-simple-select-label"
                                            id="demo-simple-select"
                                            value={formData && formData.status}
                                            name="status" // Đặt name là 'status' để phân biệt với các trường khác
                                            label="Change status"
                                            onChange={handleChange}
                                        >
                                            <MenuItem value={1}>Processed</MenuItem>
                                            <MenuItem value={2}>In progress</MenuItem>
                                            <MenuItem value={3}>Not processed yet</MenuItem>
                                        </Select>
                                    </FormControl>
                                </Grid>
                            </Grid>
                        </form>
                    </CardContent>
                </Card>
            </DialogContent>
            <DialogActions>
                <Button onClick={onClose}>Cancel</Button>
                <Button onClick={handleSubmit}>Submit</Button>
            </DialogActions>
        </Dialog>
    );
    

  
    
}

export default FormDialog;