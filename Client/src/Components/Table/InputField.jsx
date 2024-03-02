import React, { useState, useEffect } from 'react';
import Card from '@mui/material/Card';
import CardContent from '@mui/material/CardContent';
import Grid from '@mui/material/Grid';
import TextField from '@mui/material/TextField';
import InputAdornment from '@mui/material/InputAdornment';
import FormControl from '@mui/material/FormControl';
import Select from '@mui/material/Select';
import MenuItem from '@mui/material/MenuItem';
import Typography from '@mui/material/Typography';


// Icons Imports
import MessageOutline from 'mdi-material-ui/MessageOutline';
import InputLabel from '@mui/material/InputLabel';

const InputField = ({ comment, status, callback }) => {

    console.log('1.status :', status);
    const [commentData, setCommentData] = useState({});
    const [statusData, setStatusData] = useState(status);

    useEffect(() => {
        setCommentData(comment);
    }, [comment]);

    useEffect(() => {
        setStatusData(status);
    }, [status]);



    const handleChange = (event) => {
        setStatusData(event.target.value)
        callback(prevState => ({
            ...prevState,
            status: statusData
        }));
        console.log('statusData :'+statusData);
    };




    const handleChangeComment = (event) => {
        setCommentData(event.target.value);
        callback(prevState => ({
            ...prevState,
            comment: commentData
        }));
        //console.log(comments);
    };







    //console.log(comment)
    //console.log(type)
    return (
        <Grid container justifyContent="center">
            <Grid item xs={12} >
                <Card >
                    <CardContent>
                        <form onSubmit={e => e.preventDefault()}>
                            <Grid container spacing={2}>
                                <Grid item xs={12}>
                                    <TextField
                                        fullWidth
                                        multiline
                                        minRows={3}
                                        label='Comments'
                                        placeholder='Note...'
                                        value={commentData || 'Note...'} // Đặt giá trị dữ liệu vào TextField
                                        onChange={handleChangeComment} // Xử lý sự kiện khi dữ liệu thay đổi
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
                                            value={statusData}
                                            label="Change status"
                                            onChange={handleChange}
                                        >
                                            <MenuItem  value={1}>Processed</MenuItem>
                                            <MenuItem  value={2}>In progress</MenuItem>
                                            <MenuItem  value={3}>Not processed yet</MenuItem>
                                        </Select>
                                    </FormControl>
                                </Grid>
                            </Grid>
                        </form>
                    </CardContent>
                </Card>
            </Grid>
        </Grid>
    );
}

export default InputField;
