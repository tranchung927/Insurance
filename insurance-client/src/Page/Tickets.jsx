import React, { useState, useEffect } from 'react';
import {
    Card,
    Grid,
    Button,
    TextField,
    CardHeader,
    CardContent,
    InputAdornment,
    FormControl,
    InputLabel,
    Select,
    MenuItem,
    Box,
    Snackbar,
    Alert as MuiAlert
} from '@mui/material';
import Phone from 'mdi-material-ui/Phone';
import EmailOutline from 'mdi-material-ui/EmailOutline';
import AccountOutline from 'mdi-material-ui/AccountOutline';
import MessageOutline from 'mdi-material-ui/MessageOutline';
import { DataContext } from "../Context/data-context";
import axios from '@axios';
import { useContext } from "react";
import Header from "@HeaderLayout";
import Footer from "@FooterLayout";

const Alert = React.forwardRef(function Alert(props, ref) {
    return <MuiAlert elevation={6} ref={ref} variant="filled" {...props} />;
});

const Tickets = () => {
    const { products } =
    useContext(DataContext);
    const [formData, setFormData] = useState({
        name: '',
        phone: '',
        email: '',
        problem: '',
        comment: null,
        status: 3,
        assign: null,
        product: ''
    });
    const [snackbarOpen, setSnackbarOpen] = useState(false);
    const [snackbarMessage, setSnackbarMessage] = useState('');
    const [snackbarSeverity, setSnackbarSeverity] = useState('success');

    const handleChange = (e) => {
        const { name, value } = e.target;
        setFormData({ ...formData, [name]: value });
    };

    const validateEmail = (email) => {
        const regex = /^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$/;
        return regex.test(email);
    };

    const validatePhone = (phone) => {
        const regex = /^\+?[0-9]{6,14}$/;
        return regex.test(phone);
    };

    const handleSubmit = async (e) => {
        e.preventDefault();

        // Kiểm tra các trường TextField không được để trống
        if (!formData.name || !formData.email || !formData.phone || !formData.problem || !formData.insuranceTypeId) {
            setSnackbarMessage('Please fill in all fields');
            setSnackbarSeverity('error');
            setSnackbarOpen(true);
            return;
        }

        // Tiếp tục kiểm tra xác thực email và số điện thoại
        if (!validateEmail(formData.email)) {
            setSnackbarMessage('Invalid email format');
            setSnackbarSeverity('error');
            setSnackbarOpen(true);
            return;
        }
        if (!validatePhone(formData.phone)) {
            setSnackbarMessage('Invalid phone number format');
            setSnackbarSeverity('error');
            setSnackbarOpen(true);
            return;
        }

        // Tiếp tục xử lý khi dữ liệu hợp lệ
        console.log('data gửi đi:', formData);
        try {
            const response = await axios.post('Ticket', formData);

            if (!response.ok) {
                throw new Error('Failed to submit ticket');
            }

            // Reset form data after successful submission
            setFormData({
                name: '',
                phone: '',
                email: '',
                problem: '',
                comment: null,
                status: 3,
                assign: null,
                product: ''
            });

            setSnackbarMessage('Ticket submitted successfully');
            setSnackbarSeverity('success');
            setSnackbarOpen(true);
        } catch (error) {
            console.error('Error submitting ticket:', error);
            setSnackbarMessage('Failed to submit ticket. Please try again later.');
            setSnackbarSeverity('error');
            setSnackbarOpen(true);
        }
    };

    const handleCloseSnackbar = (event, reason) => {
        if (reason === 'clickaway') {
            return;
        }
        setSnackbarOpen(false);
    };

    return (
        <>
        <Header/>
        <Box sx={{ display: 'flex', justifyContent: 'center', alignItems: 'center', height: '100vh' }}>
            <Card sx={{ maxWidth: 600 }}>
                <CardHeader title='Send us a message' titleTypographyProps={{ variant: 'h6' }} />
                <CardContent>
                    <form onSubmit={handleSubmit}>
                        <Grid container spacing={3}>
                            <Grid item xs={12}>
                                <TextField
                                    fullWidth
                                    label='Full Name'
                                    name='name'
                                    value={formData.name}
                                    onChange={handleChange}
                                    InputProps={{
                                        startAdornment: (
                                            <InputAdornment position='start'>
                                                <AccountOutline />
                                            </InputAdornment>
                                        )
                                    }}
                                />
                            </Grid>
                            <Grid item xs={12}>
                                <TextField
                                    fullWidth
                                    type='email'
                                    label='Email'
                                    name='email'
                                    value={formData.email}
                                    onChange={handleChange}
                                    InputProps={{
                                        startAdornment: (
                                            <InputAdornment position='start'>
                                                <EmailOutline />
                                            </InputAdornment>
                                        )
                                    }}
                                />
                            </Grid>
                            <Grid item xs={12}>
                                <TextField
                                    fullWidth
                                    type='tel'
                                    label='Phone No.'
                                    name='phone'
                                    value={formData.phone}
                                    onChange={handleChange}
                                    InputProps={{
                                        startAdornment: (
                                            <InputAdornment position='start'>
                                                <Phone />
                                            </InputAdornment>
                                        )
                                    }}
                                />
                            </Grid>
                            <Grid item xs={12}>
                                <TextField
                                    fullWidth
                                    multiline
                                    minRows={3}
                                    label='Message'
                                    name='problem'
                                    value={formData.problem}
                                    onChange={handleChange}
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
                                    <InputLabel id="status-select-label">Insurance type</InputLabel>
                                    <Select
                                        labelId="status-select-label"
                                        id="status-select"
                                        name='insuranceTypeId'
                                        label="Insurance type"
                                        value={formData.insuranceTypeId}
                                        onChange={handleChange}
                                    >
                                        {products.map((type) => (
                                            <MenuItem key={type.id} value={type.id}>{type.name}</MenuItem>
                                        ))}
                                    </Select>
                                </FormControl>
                            </Grid>
                            <Grid item xs={12}>
                                <Button type='submit' variant='contained' size='large'>
                                    Submit
                                </Button>
                                <Snackbar
                                    open={snackbarOpen}
                                    autoHideDuration={6000}
                                    onClose={handleCloseSnackbar}
                                    anchorOrigin={{ vertical: 'top', horizontal: 'right' }}
                                >
                                    <Alert onClose={handleCloseSnackbar} severity={snackbarSeverity}>
                                        {snackbarMessage}
                                    </Alert>
                                </Snackbar>
                            </Grid>
                        </Grid>
                    </form>

                </CardContent>
            </Card>
        </Box>
         <Footer/>
         </>
    );
};

export default Tickets;
