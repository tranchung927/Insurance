
// ** React Imports
import { useState, useEffect } from 'react'

// ** MUI Imports
import TabPanel from '@mui/lab/TabPanel';
import Tabs from '@mui/material/Tabs';
import Tab from '@mui/material/Tab';
import TabList from '@mui/lab/TabList';
import TabContext from '@mui/lab/TabContext'
import Autocomplete from '@mui/material/Autocomplete';
import Button from '@mui/material/Button';
import TextField from '@mui/material/TextField';

import {
    Card,
    CardContent,
    FormControl,
    Grid,
    InputLabel,
    MenuItem,
    Select
} from '@mui/material';


const LifeInsuranceForm = ({ allWorkplace, allDeathRate }) => {
    const sexArr = [
        { label: 'Nam', sex: 1 },
        { label: 'Nữ', sex: 0 },
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

        const currentDate = new Date();
        const currentYear = currentDate.getFullYear();
        const age = currentYear - YearOfBirth;

        const fix = 0.6;

        const deathRate = allDeathRate.find(item => item.id === age);
        if (sex.sex === 1) {
            const maleDeathRate = parseFloat(deathRate.male);
            const maleValue = parseFloat(workplace.factor);
            const money1 = insuranceValue - ((1 - maleDeathRate * 100) + (maleValue) * fix) * 100;
            console.log('result :', money1);
            return money1;
        } else {
            const femaleDeathRate = parseFloat(deathRate.female);
            const femaleValue = parseFloat(workplace.factor);
            const money2 = insuranceValue - ((1 - femaleDeathRate * 100) + (femaleValue) * fix) * 100;
            console.log('result :', money2);
            return money2;
        }
    }


    return (
        <>
            {/* Trường dữ liệu giá trị bảo hiểm */}
            <TextField
                id="outlined-basic"
                label="Insurance value"
                variant="outlined"
                value={insuranceValue}
                onChange={handleInsuranceValueChange}
            />

            {/* Trường dữ liệu giới tính */}
            <Autocomplete
                disablePortal
                id="sex-autocomplete"
                getOptionLabel={(option) => option.label}
                options={sexArr}
                sx={{ width: 300 }}
                value={sex}
                onChange={handleSexChange}
                renderInput={(params) => <TextField {...params} label="Sex" />}
            />

            {/* Trường dữ liệu tuổi */}
            <TextField
                id="year-of-birth"
                label="Year of Birth"
                variant="outlined"
                value={yearOfBirth}
                onChange={handleYearOfBirthChange}
            />

            {/* Trường dữ liệu môi trường làm việc */}
            <Autocomplete
                disablePortal
                id="workplace-autocomplete"
                getOptionLabel={(option) => option.name}
                options={allWorkplace}
                sx={{ width: 300 }}
                value={workplace}
                onChange={handleWorkplaceChange}
                renderInput={(params) => <TextField {...params} label="Work place" />}
            />
            <Button onClick={() => CalculateLifeInsurance(sex, insuranceValue, parseInt(yearOfBirth), workplace, allDeathRate)} variant="outlined">Calculate</Button>

        </>
    );
}


export default LifeInsuranceForm;
