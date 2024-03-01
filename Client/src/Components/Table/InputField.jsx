import React, { useState, useEffect } from 'react';
import Card from '@mui/material/Card';
import CardContent from '@mui/material/CardContent';
import Grid from '@mui/material/Grid';
import TextField from '@mui/material/TextField';
import Button from '@mui/material/Button';
import InputAdornment from '@mui/material/InputAdornment';
import FormControl from '@mui/material/FormControl';
import Select from '@mui/material/Select';
import MenuItem from '@mui/material/MenuItem';
import Typography from '@mui/material/Typography';


// Icons Imports
import MessageOutline from 'mdi-material-ui/MessageOutline';
import InputLabel from '@mui/material/InputLabel';

const InputField = ({ comment, type, problem }) => {

    // select
    const [selectedValue, setSelectedValue] = useState(1);

    const handleChange = (event) => {
        setSelectedValue(event.target.value);
    };

    // comment
    const [comments, setComments] = useState('');

  




    const handleChangeComment = (event) => {
        setComments(event.target.value);
        console.log(comments);
    };
    console.log(comment)
    console.log(type)
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
                                        value={comments} // Đặt giá trị dữ liệu vào TextField
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
                                            value={selectedValue}
                                            label="Change status"
                                            onChange={handleChange}
                                        >
                                            <MenuItem value={1}>Completed</MenuItem>
                                            <MenuItem value={2}>In Progress</MenuItem>
                                            <MenuItem value={3}>Not Supported</MenuItem>
                                        </Select>
                                    </FormControl>
                                </Grid>
                                
                                <Grid item xs={12}>
                                    <Button type='submit' variant='contained' size='large'>
                                        Submit
                                    </Button>
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
