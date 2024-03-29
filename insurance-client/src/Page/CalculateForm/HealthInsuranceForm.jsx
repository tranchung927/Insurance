﻿
// ** React Imports
import { useState } from 'react'
import { styled } from '@mui/system';
// ** MUI Imports

import {
    Grid,
} from '@mui/material';

import Autocomplete from '@mui/material/Autocomplete';
import Button from '@mui/material/Button';
import TextField from '@mui/material/TextField';
import Typography from '@mui/material/Typography';
import Card from '@mui/material/Card';
import Box from '@mui/material/Box';
import CardMedia from '@mui/material/CardMedia';
import Image from '@mui/material/CardMedia';
import { useTheme } from '@mui/material/styles';
import useMediaQuery from '@mui/material/useMediaQuery';


const HealthInsuranceForm = ({ allWorkplace, allDeathRate }) => {
    const [value, setValue] = useState(0);

    // Định dạng giá trị thành tiền tệ Việt Nam
    const formattedValue = (value/12).toLocaleString('vi-VN', {
        style: 'currency',
        currency: 'VND',
    });

    const sexArr = [
        { label: 'Male', sex: 1 },
        { label: 'Female', sex: 0 },
    ]
    // State lưu trữ giá trị các trường dữ liệu
    const [insuranceValue, setInsuranceValue] = useState('');
    const [sex, setSex] = useState(sexArr[0]); // Khởi tạo giá trị ban đầu là null
    const [yearOfBirth, setYearOfBirth] = useState('');
    const [workplace, setWorkplace] = useState(null); // Khởi tạo giá trị ban đầu là null

    // Hàm xử lý khi giá trị trường dữ liệu thay đổi
    const handleInsuranceValueChange = (event) => {
        setInsuranceValue(event.target.value);
    };

    // Hàm xử lý khi giá trị của Autocomplete thay đổi
    const handleSexChange = (event, newValue) => {
        setSex(newValue);
    };

    const handleYearOfBirthChange = (event) => {
        setYearOfBirth(event.target.value);
    };

    const handleWorkplaceChange = (event, newValue) => {
        setWorkplace(newValue);
    };


    function CalculateLifeInsurance(sex, insuranceValue, YearOfBirth, workplace, allDeathRate) {
        console.log("sex:", sex);
        console.log('insuranceValue:', insuranceValue);
        console.log('YearOfBirth:', YearOfBirth);
        console.log('workplace:', workplace);

        const fix = 0.1;

        const deathRate = allDeathRate.find(item => item.id === YearOfBirth);
        if (sex.sex === 1) {
            const maleDeathRate = parseFloat(deathRate.male);
            const workPlaceFactor = parseFloat(workplace.factor);

            

            const money1 = (insuranceValue - (1 - maleDeathRate) * fix * insuranceValue * workPlaceFactor);

            console.log('result :', money1);
            setValue(money1);
        } else {
            const femaleDeathRate = parseFloat(deathRate.female);
            const workPlaceFactor = parseFloat(workplace.factor);
            const money2 = (insuranceValue - (1 - femaleDeathRate) * fix * insuranceValue * workPlaceFactor);
            console.log('result :', money2);
            setValue(money2);
        }
    }

    const theme = useTheme();
    const xsToMd = useMediaQuery(useTheme().breakpoints.between('xs', 'md'));

    // bé hơn sm
    const downSm = useMediaQuery(theme.breakpoints.down('sm'));
    const upSm = useMediaQuery(theme.breakpoints.up('sm'));

    // lớn hơn
    const upMd = useMediaQuery(theme.breakpoints.up('md'));

    const imageURL = 'https://vuanem.com/blog/wp-content/uploads/2023/02/gia-dinh.jpg';
    return (

        <Grid container spacing={2}  >
            <Grid item xs={12} sm={6} spacing={2}>
                <Grid item xs={12} >
                    {xsToMd  && (
                        <Card >
                            <CardMedia
                                component="img"
                                sx={{ height: 'auto', width: '100%' }}
                                image={imageURL}
                                alt="Ảnh"
                                xs={{ objectFit: 'contain' }}
                            />
                        </Card>
                    )}
                </Grid>
                <Grid container spacing={2} >
                    <Grid item xs={12} >
                        {downSm || upMd && (
                            <Typography gutterBottom variant="h6" component="div" style={{ fontSize: '16px' }}>
                            Make sure you and your family are always protected, everywhere.
                            Don't let life be disrupted by unexpected health risks.
                            Contact us today for more information on the best health insurance packages tailored to your needs!
                            </Typography>
                        )}
                    </Grid>
                    <Grid item xs={12} >
                        {/* Trường dữ liệu giá trị bảo hiểm */}
                        <TextField
                            id="outlined-basic"
                            label="Insurance value"
                            variant="outlined"
                            value={insuranceValue}
                            sx={{ width: '100%' }}
                            onChange={handleInsuranceValueChange}
                        />
                    </Grid>
                    <Grid item xs={12} >
                        {/* Trường dữ liệu giới tính */}
                        <Autocomplete
                            disablePortal
                            id="sex-autocomplete"
                            getOptionLabel={(option) => option.label}
                            options={sexArr}
                            sx={{ width: '100%' }}
                            value={sex}
                            onChange={handleSexChange}
                            renderInput={(params) => <TextField {...params} label="Sex" />}
                        />
                    </Grid>
                    <Grid item xs={12} >
                        {/* Trường dữ liệu tuổi */}
                        <TextField
                            id="year-of-birth"
                            label="Age"
                            variant="outlined"
                            value={yearOfBirth}
                            onChange={handleYearOfBirthChange}
                            sx={{ width: '100%' }}
                        />
                    </Grid>

                    <Grid item xs={12} >
                        {/* Trường dữ liệu môi trường làm việc */}
                        <Autocomplete
                            disablePortal
                            id="workplace-autocomplete"
                            getOptionLabel={(option) => option.name}
                            options={allWorkplace}
                            sx={{ width: '100%' }}
                            value={workplace}
                            onChange={handleWorkplaceChange}
                            renderInput={(params) => <TextField {...params} label="Work place" />}
                        />
                    </Grid>


                    

                </Grid>
                
                <Grid item container xs={12} style={{ marginTop: '20px' }}>
                    <Grid item xs={6} >
                        <Button onClick={() => CalculateLifeInsurance(sex, insuranceValue, parseInt(yearOfBirth), workplace, allDeathRate)} variant="outlined">Calculate</Button>
                    </Grid>
                    <Grid item xs={5} style={{ display: 'flex', alignItems: 'flex-start' }}>
                        <Typography gutterBottom variant="h6">
                            {formattedValue} / Month
                        </Typography>
                    </Grid>
                    
                </Grid>

            </Grid>
            <Grid item xs={12} sm={6}  >

                {downSm || upMd && (
                    <Card >
                        <CardMedia
                            component="img"
                            sx={{ height: 'auto', width: '100%' }}
                            image={imageURL}
                            alt="Ảnh"
                            xs={{ objectFit: 'contain' }}
                        />
                    </Card>
                
                )}
                {xsToMd && (
                    <Grid style={{ maxHeight: 300 }}>
                        <Typography gutterBottom variant="h6" component="div" style={{ margin: '10px', fontSize: '16px' }}>
                        Make sure you and your family are always protected, everywhere.
                        </Typography>
                        <Typography gutterBottom variant="h6" component="div" style={{ margin: '10px', fontSize: '16px' }}>
                        Don't let life be disrupted by unexpected health risks.
                        </Typography>
                        <Typography gutterBottom variant="h6" component="div" style={{ margin: '10px', fontSize: '16px' }}>
                        Contact us today for more information on the best health insurance packages tailored to your needs!
                        </Typography>

                        <Typography gutterBottom variant="h6" component="div" style={{ margin: '10px', fontSize: '16px' }}>
                        Be at ease about health, be confident about the future. Health insurance cares for you and your family, anytime, anywhere.
                        </Typography>
                        <Typography gutterBottom variant="h6" component="div" style={{ margin: '10px', fontSize: '16px' }}>
                        Health insurance cares for you and your family, anytime, anywhere.
                        </Typography>
                    </Grid>
                    
                )}
                
            </Grid>
            
            
            
        </Grid>


        
           
    );
}


export default HealthInsuranceForm;
