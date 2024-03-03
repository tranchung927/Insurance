// ** React Imports
import { useState, useEffect } from 'react'

// ** MUI Imports
import TabPanel from '@mui/lab/TabPanel';
import Tab from '@mui/material/Tab';
import TabList from '@mui/lab/TabList';
import TabContext from '@mui/lab/TabContext'
import Tabs from '@mui/material/Tabs';

import {
    Card,
    CardContent,

} from '@mui/material';
import LifeInsuranceForm from './LifeInsuranceForm';
import HealthInsuranceForm from './HealthInsuranceForm';
import VehicleInsuranceForm from './VehicleInsuranceForm';
import HomeInsuranceForm from './HomeInsuranceForm';

const CalculateForm = () => {

    const [allType, setAllType] = useState([]);
    const [allWorkplace, setAllWorkplace] = useState([]);
    const [allDeathRate, setAllDeathRate] = useState([]);
    // vehicle
    const [allVehicleProperty, setAllVehicleProperty] = useState([]);
    const [allVehicleType, setAllVehicleType] = useState([]);
    // home
    const [allHomeCoefficient, setAllHomeCoefficient] = useState([]);
    const [allHomeType, setAllHomeType] = useState([]);
    const [allSizeType, setAllSizeType] = useState([]);
    const [allRiskCoefficient, setAllRiskCoefficient] = useState([]);

    const [value, setValue] = useState("1");

    useEffect(() => {
        const fetchData = async () => {
            try {

                const responseAllInsuranceType = await fetch('https://localhost:7202/api/ClientSupport/GetAllInsuranceType');
                const responseDeathRate = await fetch('https://localhost:7202/api/LifeInsurance/AllDeathRate');
                const responseWorkplace = await fetch('https://localhost:7202/api/LifeInsurance/AllWorkplace');
                // vehicle
                const responseVehicleProperty = await fetch('https://localhost:7202/api/VehicleInsurance/AllVehicleProperty');
                const responseVehicleType = await fetch('https://localhost:7202/api/VehicleInsurance/AllVehicleType');
                // home
                const responseHomeCoefficient = await fetch('https://localhost:7202/api/HomeInsurance/AllHomeCoefficient');
                const responseHomeType = await fetch('https://localhost:7202/api/HomeInsurance/AllHomeType');
                const responseSizeType = await fetch('https://localhost:7202/api/HomeInsurance/AllSizeTypeModel');
                const responseRiskCoefficient = await fetch('https://localhost:7202/api/HomeInsurance/AllRiskCoefficientModel');

                if (
                    !responseAllInsuranceType.ok
                    || !responseDeathRate.ok
                    || !responseWorkplace.ok
                    // vehicle
                    || !responseVehicleProperty.ok
                    || !responseVehicleType.ok
                    // home
                    || !responseHomeCoefficient.ok
                    || !responseHomeType.ok
                    || !responseSizeType.ok
                    || !responseRiskCoefficient.ok
                ) {
                    throw new Error('Failed to fetch insurance types');
                }

                const dataAllInsuranceType = await responseAllInsuranceType.json();
                const dataDeathRate = await responseDeathRate.json();
                const dataWorkplace = await responseWorkplace.json();
                // vehicle
                const dataVehicleProperty = await responseVehicleProperty.json();
                const dataVehicleType = await responseVehicleType.json();
                // home
                const dataHomeCoefficient = await responseHomeCoefficient.json();
                const dataHomeType = await responseHomeType.json();
                const dataSizeType = await responseSizeType.json();
                const dataRiskCoefficient = await responseRiskCoefficient.json();



                //console.log('dataAllInsuranceType:', dataAllInsuranceType);
                //console.log('dataDeathRate:', dataDeathRate);
                //console.log('dataWorkplace:', dataWorkplace);
                //console.log('dataVehicleProperty:', dataVehicleProperty);
                //console.log('dataVehicleType:', dataVehicleType);

                setAllType(dataAllInsuranceType); 
                setAllWorkplace(dataWorkplace);
                setAllDeathRate(dataDeathRate);
                setAllVehicleProperty(dataVehicleProperty);
                setAllVehicleType(dataVehicleType);

                setAllHomeCoefficient(dataHomeCoefficient);
                setAllHomeType(dataHomeType);
                setAllSizeType(dataSizeType);
                setAllRiskCoefficient(dataRiskCoefficient);

            } catch (error) {
                console.error('Error fetching insurance types:', error);
            }
        };
        fetchData();
    }, []);

    const handleChange = (event, newValue) => {
        setValue(newValue);
    }

    return (
        <Card >
            <TabContext value={value}>
                <Tabs
                    value={value}
                    onChange={handleChange}
                    variant="scrollable"
                    scrollButtons
                    allowScrollButtonsMobile
                    aria-label="scrollable force tabs example"
                >
                    {allType.map((type) => (
                        <Tab key={type && type.id} value={String(type && type.id)} label={type.name} />
                    ))}
                </Tabs>
                
                
                {setAllType.length > 0 && (
                    <CardContent>
                        <TabPanel key={1} value={"1"} sx={{ p: 0 }}>
                            <LifeInsuranceForm allWorkplace={allWorkplace} allDeathRate={allDeathRate} />
                        </TabPanel>

                        <TabPanel key={3} value={"3"} sx={{ p: 0 }}>
                            <HealthInsuranceForm allWorkplace={allWorkplace} allDeathRate={allDeathRate} />
                        </TabPanel>

                        <TabPanel key={2} value={"2"} sx={{ p: 0 }}>
                            <VehicleInsuranceForm allVehicleProperty={allVehicleProperty} allVehicleType={allVehicleType} />
                        </TabPanel>

                        <TabPanel key={4} value={"4"} sx={{ p: 0 }}>
                            <HomeInsuranceForm
                                allHomeCoefficient={allHomeCoefficient}
                                allHomeType={allHomeType}
                                allSizeType={allSizeType}
                                allRiskCoefficient={allRiskCoefficient}
                            />
                        </TabPanel>


                    </CardContent>

                )}
                
            </TabContext>
        </Card>
    );
}


export default CalculateForm;
