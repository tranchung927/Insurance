
// ** React Imports
import { useState } from 'react'

// ** MUI Imports
import Card from '@mui/material/Card';
import Autocomplete from '@mui/material/Autocomplete';
import Button from '@mui/material/Button';
import TextField from '@mui/material/TextField';
import Typography from '@mui/material/Typography';
import {
    Grid,
} from '@mui/material';
import CardMedia from '@mui/material/CardMedia';
import img_house_1 from './house_1.jpg';
import { useTheme } from '@mui/material/styles';
import useMediaQuery from '@mui/material/useMediaQuery';

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

    const handleHouseValueChange = (event) => {
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
        const result = houseValue * riskCoefficient.value * coefficientValue*0.001;
        console.log('result:', result);
        // Cập nhật giá trị state
        setValue(result);
    }


    // Định dạng giá trị thành tiền tệ Việt Nam
    const formattedValue = value.toLocaleString('vi-VN', {
        style: 'currency',
        currency: 'VND',
    });

    // bé hơn sm
    const theme = useTheme();
    const downSm = useMediaQuery(theme.breakpoints.down('sm'));
    const upSm = useMediaQuery(theme.breakpoints.up('sm'));
   
    return (
        <Grid container spacing={2}  >
            <Grid item xs={12} sm={7}  >
                <Card >
                    <CardMedia
                        component="img"
                        sx={{ height: 'auto', width: '100%' }}
                        image={img_house_1}
                        alt="Ảnh"
                        xs={{ objectFit: 'contain' }}
                    />
                </Card>
            </Grid>
            
            <Grid item xs={ 12} sm={5} container >
                <Grid item xs={12} >
                    {/* Trường dữ liệu giá trị Nhà */}
                    <TextField
                        id="outlined-basic"
                        label="Insurance value"
                        variant="outlined"
                        value={houseValue}
                        sx={{ width: '100%' }}
                        onChange={handleHouseValueChange}
                    />
                </Grid>
                <Grid item xs={12} >
                    {/* Loại nhà */}
                    <Autocomplete
                        disablePortal
                        id="workplace-autocomplete"
                        getOptionLabel={(option) => option.name}
                        options={allHomeType}
                        sx={{ width: '100%' }}
                        value={homeType}
                        onChange={homeTypeChange}
                        renderInput={(params) => <TextField {...params} label="Home type" />}
                    />
                </Grid>
                <Grid item xs={12} >
                    {/* kích thước nhà */}
                    <Autocomplete
                        disablePortal
                        id="workplace-autocomplete"
                        getOptionLabel={(option) => option.name}
                        options={allSizeType}
                        sx={{ width: '100%' }}
                        value={sizeType}
                        onChange={sizeTypeChange}
                        renderInput={(params) => <TextField {...params} label="Size type" />}
                    />
                </Grid>
                <Grid item xs={12} >
                    {/* mức độ rủi ro */}
                    <Autocomplete
                        disablePortal
                        id="workplace-autocomplete"
                        getOptionLabel={(option) => option.name}
                        options={allRiskCoefficient}
                        sx={{ width: '100%' }}
                        value={riskCoefficient}
                        onChange={riskCoefficientChange}
                        renderInput={(params) => <TextField {...params} label="Risk coefficient" />}
                    />
                </Grid>
                <Grid item container xs={12} spacing={2}>
                    <Grid item xs={6} >
                        <Button onClick={() => CalculateHomeInsurance(homeType, sizeType, riskCoefficient, houseValue)} variant="outlined">Calculate</Button>
                    </Grid>
                    <Grid item xs={6} >
                        <Typography gutterBottom variant="h6" component="div">
                            {formattedValue}/Month
                        </Typography>
                    </Grid>
                    

                </Grid>
            </Grid>
            <Grid item xs={12} spacing={2}>
            <Grid item xs={12} sm={6}>
            <Typography gutterBottom variant="h6" component="div" style={{ fontSize: '16px' }}>
                🏠 Protect Your Home with Home Insurance!
            </Typography>
            </Grid>
                <Grid item xs={12} sm={6}>
                    <Typography gutterBottom variant="h6" component="div" style={{ fontSize: '16px' }}>
                        🛡️ Protect against natural disasters, fire, and other risks.
                    </Typography>
                </Grid>
                <Grid item xs={12} sm={6}>
                    <Typography gutterBottom variant="h6" component="div" style={{ fontSize: '16px' }}>
                        💸 Compensation for property damage and repair costs.
                    </Typography>
                </Grid>
                <Grid item xs={12} sm={6}>
                    <Typography gutterBottom variant="h6" component="div" style={{ fontSize: '16px' }}>
                        🏡 Insurance for interior and exterior property.
                    </Typography>
                </Grid>
                <Grid item xs={12} sm={6}>
                    <Typography gutterBottom variant="h6" component="div" style={{ fontSize: '16px' }}>
                        🗝️ Legal protection and civil liability coverage.
                    </Typography>
                </Grid>
            </Grid>

        </Grid>
    );
}

export default HomeInsuranceForm;
