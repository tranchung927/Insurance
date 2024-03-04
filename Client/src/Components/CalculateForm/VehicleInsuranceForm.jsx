
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
import CardMedia from '@mui/material/CardMedia';
import useMediaQuery from '@mui/material/useMediaQuery';
import { useTheme } from '@mui/material/styles';
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

    // bé hơn sm
    const theme = useTheme();
    const downMd = useMediaQuery(theme.breakpoints.down('md'));
    const upMd = useMediaQuery(theme.breakpoints.up('md'));

    return (
        <>
            <Grid container spacing={2}  >
                <Grid item xs={12} sm={7}  >
                    <Card >
                        <CardMedia
                            component="img"
                            sx={{ height: 'auto', width: '100%' }}
                            image={'https://cafefcdn.com/203337114487263232/2023/4/12/1673050317226chery-has-not-yet-had-such-crossovers-renders-of-chery-1681257971589-1681257972030724898610.jpg'}
                            alt="Ảnh"
                            xs={{ objectFit: 'contain' }}
                        />
                    </Card>
                </Grid>
                <Grid item xs={12} sm={5}>
                    <Typography gutterBottom variant="h6" component="div" style={{ fontSize: '16px' }}>
                        Hãy đảm bảo rằng bạn và gia đình luôn được bảo vệ mọi lúc, mọi nơi.
                        Đừng để cuộc sống bị gián đoạn bởi những rủi ro y tế không mong muốn.
                        Hãy liên hệ với chúng tôi ngay hôm nay để biết thêm thông tin về các gói
                        bảo hiểm y tế tốt nhất phù hợp với nhu cầu của bạn!
                    </Typography>
                    {upMd && (
                        <Grid item container xs={12}  spacing={2} >
                            <Grid item xs={12} >
                                {/* Loại xe */}
                                <Autocomplete
                                    disablePortal
                                    id="workplace-autocomplete"
                                    getOptionLabel={(option) => option.name}
                                    options={allVehicleType}
                                    sx={{ width: '100%' }}
                                    value={type}
                                    onChange={handTypeChange}
                                    renderInput={(params) => <TextField {...params} label="Vehicle type" />}
                                />
                            </Grid>
                            <Grid item xs={12} >
                                {/* Tính chất xe */}
                                <Autocomplete
                                    disablePortal
                                    id="workplace-autocomplete"
                                    getOptionLabel={(option) => option.property}
                                    options={!tempProperty ? allVehicleProperty : tempProperty}
                                    sx={{ width: '100%' }}
                                    value={property}
                                    onChange={handPropertyChange}
                                    renderInput={(params) => <TextField {...params} label="Vehicle property" />}
                                />
                            </Grid>
                            {/*nút và giá*/}
                            <Grid item container xs={12}  >
                                <Grid item xs={6} >
                                    <Button onClick={() => CalculateVehicleInsurance(property)} variant="outlined">Calculate</Button>
                                </Grid>
                                <Grid item xs={6} >
                                    <Typography gutterBottom variant="h6" component="div">
                                        {formattedValue}
                                    </Typography>
                                </Grid>
                            </Grid>
                        </Grid>
                    )}
                </Grid>
                {downMd && (
                    <Grid item container spacing={2} xs={12} >
                        <Grid item xs={12} sm={6}>
                            {/* Loại xe */}
                            <Autocomplete
                                disablePortal
                                id="workplace-autocomplete"
                                getOptionLabel={(option) => option.name}
                                options={allVehicleType}
                                sx={{ width: '100%' }}
                                value={type}
                                onChange={handTypeChange}
                                renderInput={(params) => <TextField {...params} label="Vehicle type" />}
                            />
                        </Grid>
                        <Grid item xs={12} sm={6}>
                            {/* Tính chất xe */}
                            <Autocomplete
                                disablePortal
                                id="workplace-autocomplete"
                                getOptionLabel={(option) => option.property}
                                options={!tempProperty ? allVehicleProperty : tempProperty}
                                sx={{ width: '100%' }}
                                value={property}
                                onChange={handPropertyChange}
                                renderInput={(params) => <TextField {...params} label="Vehicle property" />}
                            />
                        </Grid>

                        <Grid item container xs={12} sm={6} >
                            <Grid item xs={6} >
                                <Button onClick={() => CalculateVehicleInsurance(property)} variant="outlined">Calculate</Button>
                            </Grid>
                            <Grid item xs={6} >
                                <Typography gutterBottom variant="h6" component="div">
                                    {formattedValue}
                                </Typography>
                            </Grid>
                        </Grid>


                    </Grid>
                        
                    )}
                

                

                

            </Grid>


           
            

            
            

        </>
    );
}

export default VehicleInsuranceForm;
