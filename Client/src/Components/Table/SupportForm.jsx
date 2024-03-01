import React from 'react';
import { styled } from '@mui/material/styles'; // Import styled từ @mui/material/styles
import Box from '@mui/material/Box';
import Card from '@mui/material/Card';
import Grid from '@mui/material/Grid';
import CardContent from '@mui/material/CardContent';
import AddIcCallIcon from '@mui/icons-material/AddIcCall';
import AlternateEmailIcon from '@mui/icons-material/AlternateEmail';
import AdminPanelSettingsIcon from '@mui/icons-material/AdminPanelSettings';

import Typography from '@mui/material/Typography';
import { LockOpenOutline, AccountOutline, StarOutline, TrendingUp } from 'mdi-material-ui'; // Import các biểu tượng
import InputField from './InputField'; // Giả sử là import cho InputFiel đã được định nghĩa ở nơi khác


const SupportForm = ({ selectedRowData } ) => {
    //console.log(selectedRowData);
    return (
        <Card sx={{ maxWidth: 600 }}   >
            <Grid container spacing={6}>
                <Grid item xs={12} sm={12}>
                    <CardContent sx={{ padding: theme => `${theme.spacing(3.25, 5.75, 6.25)} !important` }}>
                        <Grid container spacing={4}>
                            <Grid item xs={12} sm={5}>
                                <Box sx={{ mb: 6.75, display: 'flex', alignItems: 'center' }}>
                                    <AddIcCallIcon sx={{ color: 'primary.main', marginRight: 2.75 }} fontSize='small' />
                                    <Typography variant='body2'>Phone: {selectedRowData.phone}</Typography>
                                </Box>
                                <Box sx={{ display: 'flex', alignItems: 'center' }}>
                                    <AccountOutline sx={{ color: 'primary.main', marginRight: 2.75 }} fontSize='small' />
                                    <Typography variant='body2'>Name: {selectedRowData.name}</Typography>
                                </Box>
                            </Grid>
                            <Grid item xs={12} sm={7}>
                                <Box sx={{ mb: 6.75, display: 'flex', alignItems: 'center' }}>
                                    <AlternateEmailIcon sx={{ color: 'primary.main', marginRight: 2.75 }} fontSize='small' />
                                    <Typography variant='body2'>Email: {selectedRowData.email}</Typography>
                                </Box>
                                <Box sx={{ display: 'flex', alignItems: 'center' }}>
                                    <AdminPanelSettingsIcon sx={{ color: 'primary.main', marginRight: 2.75 }} fontSize='small' />
                                    <Typography variant='body2'>Type:{selectedRowData.type}</Typography>
                                </Box>
                            </Grid>
                            <Grid item xs={12} sm={12}>
                                <Typography variant='h6' sx={{ marginBottom: 2.75 }}>
                                    Support
                                </Typography>
                                <Typography variant='h6' >
                                    {selectedRowData.problem}
                                </Typography>
                            </Grid>

                            
                        </Grid>
                    </CardContent>
                </Grid>
            </Grid>
            <InputField comment={selectedRowData.comment} type={selectedRowData.type} problem={selectedRowData.problem} />
        </Card>
    )
};





export default SupportForm;
