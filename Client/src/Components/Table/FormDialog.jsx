import React, { useState } from 'react';
import { Button, Dialog, DialogTitle, DialogContent, DialogActions, Card, Grid, CardContent, Box, Typography } from '@mui/material';
import AlternateEmailIcon from '@mui/icons-material/AlternateEmail';
import CallIcon from '@mui/icons-material/Call';
import SettingsIcon from '@mui/icons-material/Settings';
import InputField from './InputField';

import { LockOpenOutline, AccountOutline, StarOutline, TrendingUp } from 'mdi-material-ui'; // Import các biểu tượng



function FormDialog({ open, onClose, selectedRowData }) {
    
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
        //<div>   
        //    <h1>{console.log(open)}</h1>
        //    <h1>{console.log(onClose)}</h1>
        //    <h1>{console.log(selectedRowData)}</h1>
        //</div>
        

        <Dialog open={open} onClose={onClose}> {/* Dialog mở/đóng dựa vào trạng thái open */}
            <DialogTitle>Form Dialog</DialogTitle>
            <DialogContent>
                <Card sx={{ maxWidth: 600 }}>
                    <Grid container spacing={6}>
                        <Grid item xs={12} sm={12}>
                            <CardContent sx={{ padding: theme => `${theme.spacing(3.25, 5.75, 6.25)} !important` }}>
                                <Grid container spacing={4}>
                                    <Grid item xs={12} sm={5}>
                                        <Box sx={{ mb: 6.75, display: 'flex', alignItems: 'center' }}>
                                            <CallIcon sx={{ color: 'primary.main', marginRight: 2.75 }} fontSize='small' />
                                            <Typography variant='body2'>Phone: {selectedRowData && selectedRowData ? selectedRowData.phone : ''}</Typography>
                                        </Box>
                                        <Box sx={{ display: 'flex', alignItems: 'center' }}>
                                            <AccountOutline sx={{ color: 'primary.main', marginRight: 2.75 }} fontSize='small' />
                                            <Typography variant='body2'>Name: {selectedRowData && selectedRowData ? selectedRowData.name : ''}</Typography>
                                        </Box>
                                    </Grid>
                                    <Grid item xs={12} sm={7}>
                                        <Box sx={{ mb: 6.75, display: 'flex', alignItems: 'center' }}>
                                            <AlternateEmailIcon sx={{ color: 'primary.main', marginRight: 2.75 }} fontSize='small' />
                                            <Typography variant='body2'>Email: {selectedRowData && selectedRowData ? selectedRowData.email : ''}</Typography>
                                        </Box>
                                        <Box sx={{ display: 'flex', alignItems: 'center' }}>
                                            <AlternateEmailIcon sx={{ color: 'primary.main', marginRight: 2.75 }} fontSize='small' />
                                            <Typography variant='body2'>Type:{selectedRowData && selectedRowData ? selectedRowData.type : ''}</Typography>
                                        </Box>
                                    </Grid>
                                    <Grid item xs={12} sm={12}>
                                        <Typography variant='h6' sx={{ marginBottom: 2.75 }}>
                                            Support
                                        </Typography>
                                        <Typography variant='h6' >
                                            {selectedRowData && selectedRowData ? selectedRowData.problem : ''}
                                        </Typography>
                                    </Grid>


                                </Grid>
                            </CardContent>
                        </Grid>
                    </Grid>
                    <InputField comment={selectedRowData && selectedRowData ? selectedRowData.comment : ''} type={selectedRowData && selectedRowData ? selectedRowData.type : ''} problem={selectedRowData && selectedRowData? selectedRowData.problem: ''} />
                </Card>
            </DialogContent>
            <DialogActions>
                <Button onClick={onClose}>Cancel</Button> {/* Nút hủy */}
                <Button onClick={handleSubmit}>Submit</Button> {/* Nút gửi */}
            </DialogActions>
        </Dialog>
    
    )



}

export default FormDialog;