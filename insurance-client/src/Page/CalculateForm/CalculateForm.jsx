// ** React Imports
import { useState, useEffect, useContext } from 'react';

// ** MUI Imports
import TabPanel from '@mui/lab/TabPanel';
import MuiTab from '@mui/material/Tab';
import TabContext from '@mui/lab/TabContext';
import TabList from '@mui/lab/TabList';
import Box from '@mui/material/Box';
import LifeInsuranceForm from './LifeInsuranceForm';
import HealthInsuranceForm from './HealthInsuranceForm';
import VehicleInsuranceForm from './VehicleInsuranceForm';
import HomeInsuranceForm from './HomeInsuranceForm';
import Header from "@HeaderLayout";
import Footer from "@FooterLayout";
import axios from '@axios';
import { styled } from '@mui/material/styles';
import { DataContext } from '@DataContext';

const Tab = styled(MuiTab)(({ theme }) => ({
    [theme.breakpoints.down('md')]: {
        minWidth: 100
    },
    [theme.breakpoints.down('sm')]: {
        minWidth: 67
    }
}))

const TabName = styled('span')(({ theme }) => ({
    lineHeight: 1.71,
    fontSize: '0.875rem',
    marginLeft: theme.spacing(2.4),
    [theme.breakpoints.down('md')]: {
        display: 'none'
    }
}))

const CalculateForm = () => {
    const { products } = useContext(DataContext);
    const [workplaces, setWorkplaces] = useState([]);
    const [deathRates, setDeathRates] = useState([]);
    // vehicle
    const [vehicleProperties, setVehicleProperties] = useState([]);
    const [vehicleTypes, setVehicleTypes] = useState([]);
    // home
    const [homeCoefficients, setHomeCoefficients] = useState([]);
    const [homeTypes, setHomeTypes] = useState([]);
    const [homeSizeTypes, setHomeSizeTypes] = useState([]);
    const [riskCoefficients, setRiskCoefficients] = useState([]);

    const [tabValue, setTabValue] = useState("life-insurance");

    useEffect(() => {
        axios
            .get("DeathRate")
            .then((response) => {
                setDeathRates(response.data.data)
            })
            .catch((error) => {
                console.error(error);
            });

        axios
            .get("Workplace")
            .then((response) => {
                setWorkplaces(response.data.data)
            })
            .catch((error) => {
                console.error(error);
            });

        axios
            .get("VehicleProperty")
            .then((response) => {
                setVehicleProperties(response.data.data)
            })
            .catch((error) => {
                console.error(error);
            });

        axios
            .get("VehicleType")
            .then((response) => {
                setVehicleTypes(response.data.data)
            })
            .catch((error) => {
                console.error(error);
            });

        axios
            .get("HouseType")
            .then((response) => {
                setHomeTypes(response.data.data)
            })
            .catch((error) => {
                console.error(error);
            });

        axios
            .get("HouseSize")
            .then((response) => {
                setHomeSizeTypes(response.data.data)
            })
            .catch((error) => {
                console.error(error);
            });

        axios
            .get("HouseCoefficien")
            .then((response) => {
                setHomeCoefficients(response.data.data)
            })
            .catch((error) => {
                console.error(error);
            });
    }, []);

    const handleChangeTab = (event, newValue) => {
        if (newValue !== tabValue) {
            setTabValue(newValue);
        }
    }

    return (
        <>
            <Header />
            <Box>
                <TabContext value={tabValue}>
                <TabList
                    onChange={handleChangeTab}
                    aria-label='calculate tabs'
                >
                    {products.map((product) => (
                        <Tab
                            value={product.code}
                            label={
                                <Box sx={{ display: 'flex', alignItems: 'center' }}>
                                    <TabName>{product.name}</TabName>
                                </Box>
                            }
                        />
                    ))}
                </TabList>
                <TabPanel sx={{ p: 0 }} value='life-insurance'>
                    <LifeInsuranceForm allWorkplace={workplaces} allDeathRate={deathRates} />
                </TabPanel>
                <TabPanel value='health-insurance' sx={{ p: 0 }}>
                    <HealthInsuranceForm allWorkplace={workplaces} allDeathRate={deathRates} />
                </TabPanel>

                <TabPanel value='car-insurance' sx={{ p: 0 }}>
                    <VehicleInsuranceForm allVehicleProperty={vehicleProperties} allVehicleType={vehicleTypes} />
                </TabPanel>
                <TabPanel value='home-insurance' sx={{ p: 0 }}>
                    <HomeInsuranceForm
                        allHomeCoefficient={homeCoefficients}
                        allHomeType={homeTypes}
                        allSizeType={homeSizeTypes}
                        allRiskCoefficient={riskCoefficients}
                    />
                </TabPanel>

            </TabContext>
            </Box>
            <Footer />
        </>
    );
}


export default CalculateForm;
