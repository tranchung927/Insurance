
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
import Typography from '@mui/material/Typography';

import {
    Card,
    CardContent,
    FormControl,
    Grid,
    InputLabel,
    MenuItem,
    Select
} from '@mui/material';


const VehicleInsuranceForm = ({ allVehicleProperty, allVehicleType }) => {
  
    // State lưu trữ giá trị các trường dữ liệu
    const [property, setProperty] = useState(allVehicleProperty[1]);
    const [type, setType] = useState(allVehicleType[1]);
    const [tempProperty, setTempProperty] = useState('');
    const [value, setValue] = useState(0);

    const handPropertyChange = (event, newValue) => {
        setProperty(newValue);
    };

    const handTypeChange = (event, newValue) => {
        setType(newValue);
        const newData = allVehicleProperty.filter(item => item.vehicleTypeId === newValue.id);
        
        setTempProperty(newData);
        setProperty(newData[0])
        console.log('tempProperty: ', tempProperty[0])
    };

    const generateRandomKey = () => {
        return Math.random().toString(36).substring(7);
    };


    function CalculateVehicleInsurance(property) {
        console.log("vehicleProperty:", property);
        console.log("value:", property.value);
        setValue(property.value)
    }

    // Định dạng giá trị thành tiền tệ Việt Nam
    const formattedValue = value.toLocaleString('vi-VN', {
        style: 'currency',
        currency: 'VND',
    });

    return (
        <>
            {/* Loại xe */}
            <Autocomplete
                disablePortal
                id="workplace-autocomplete"
                getOptionLabel={(option) => option.name}
                options={allVehicleType}
                sx={{ width: 300 }}
                value={type}
                onChange={handTypeChange}
                renderInput={(params) => <TextField {...params} label="Vehicle type" />}
            />

            {/* Tính chất xe */}
            <Autocomplete
                disablePortal
                id="workplace-autocomplete"
                getOptionLabel={(option) => option.property}
                options={!tempProperty ? allVehicleProperty : tempProperty}
                sx={{ width: 300 }}
                value={property}
                onChange={handPropertyChange}
                renderInput={(params) => <TextField {...params} label="Vehicle property" />}
            />
            <Typography gutterBottom variant="h6" component="div">
                {formattedValue}
            </Typography>

            <Button onClick={() => CalculateVehicleInsurance(property)} variant="outlined">Calculate</Button>
        </>
    );
}

export default VehicleInsuranceForm;
