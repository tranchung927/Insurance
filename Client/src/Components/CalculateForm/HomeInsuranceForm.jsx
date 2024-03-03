
// ** React Imports
import { useState } from 'react'

// ** MUI Imports

import Autocomplete from '@mui/material/Autocomplete';
import Button from '@mui/material/Button';
import TextField from '@mui/material/TextField';
import Typography from '@mui/material/Typography';



const HomeInsuranceForm = ({ allHomeCoefficient, allHomeType, allSizeType, allRiskCoefficient }) => {

    // State lưu trữ giá trị các trường dữ liệu
    const [homeType, setHomeType] = useState(allHomeType[1]);

    const [houseValue, setHouseValue] = useState("");


    const [sizeType, setSizeType] = useState(allSizeType[1]);
    const [riskCoefficient, setRiskCoefficient] = useState(allRiskCoefficient[1]);

    const [value, setValue] = useState(0);


    function searchObject(data, homeTypeId, sizeTypeId, status) {
        return data.find(item => (
            item.homeTypeId === homeTypeId &&
            item.sizeTypeId === sizeTypeId &&
            item.status === status
        ));
    }

    const homeTypeChange = (event, newValue) => {
        setHomeType(newValue);
    };

    const sizeTypeChange = (event, newValue) => {
        setSizeType(newValue);
    };

    const riskCoefficientChange = (event, newValue) => {
        setRiskCoefficient(newValue);
    };

    const HouseValueChange = (event) => {
        const newValue = event.target.value;
        // Kiểm tra nếu giá trị mới không phải là một số thì không cập nhật state
        if (!isNaN(newValue)) {
            setHouseValue(newValue);
        }
    };

  


    function CalculateHomeInsurance(homeType, sizeType, riskCoefficient, houseValue) {
        console.log('homeType:', homeType);
        console.log('homeType.id:', homeType.id);
        console.log('sizeType.id:', sizeType.id);
        console.log('allHomeCoefficient:', allHomeCoefficient);

        // Tìm hệ số dựa trên loại nhà, kích thước và status
        const coefficient = searchObject(allHomeCoefficient, homeType.id, sizeType.id, 1);

        // Kiểm tra nếu không tìm thấy hệ số
        if (!coefficient) {
            console.error("Could not find coefficient for given parameters");
            return;
        }

        // Trích xuất giá trị hệ số từ đối tượng coefficient
        const coefficientValue = coefficient.coefficient;

        // Thực hiện phép nhân giữa giá trị nhà, hệ số rủi ro và hệ số của loại nhà và kích thước
        const result = houseValue * riskCoefficient.value * coefficientValue*0.01;

        // Cập nhật giá trị state
        setValue(result);
    }


    // Định dạng giá trị thành tiền tệ Việt Nam
    const formattedValue = value.toLocaleString('vi-VN', {
        style: 'currency',
        currency: 'VND',
    });

    return (
        <>
            {/* Trường dữ liệu giá trị nhà */}
            <TextField
                id="outlined-basic"
                label="House value"
                variant="outlined"
                value={houseValue}
                onChange={HouseValueChange}
            />

            
            {/* Loại nhà */}
            <Autocomplete
                disablePortal
                id="workplace-autocomplete"
                getOptionLabel={(option) => option.name}
                options={allHomeType}
                sx={{ width: 300 }}
                value={homeType}
                onChange={homeTypeChange}
                renderInput={(params) => <TextField {...params} label="Home type" />}
            />

            {/* kích thước nhà */}
            <Autocomplete
                disablePortal
                id="workplace-autocomplete"
                getOptionLabel={(option) => option.name}
                options={allSizeType}
                sx={{ width: 300 }}
                value={sizeType}
                onChange={sizeTypeChange}
                renderInput={(params) => <TextField {...params} label="Size type" />}
            />

            {/* mức độ rủi ro */}
            <Autocomplete
                disablePortal
                id="workplace-autocomplete"
                getOptionLabel={(option) => option.name}
                options={allRiskCoefficient}
                sx={{ width: 300 }}
                value={riskCoefficient}
                onChange={riskCoefficientChange}
                renderInput={(params) => <TextField {...params} label="Risk coefficient" />}
            />

           
            <Typography gutterBottom variant="h6" component="div">
                {formattedValue}
            </Typography>

            <Button onClick={() => CalculateHomeInsurance(homeType, sizeType, riskCoefficient, houseValue)} variant="outlined">Calculate</Button>
        </>
    );
}

export default HomeInsuranceForm;
