﻿// ** React Imports
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
import LifeInsuranceForm from './LifeInsuranceForm';
import HealthInsuranceForm from './HealthInsuranceForm';
import VehicleInsuranceForm from './VehicleInsuranceForm';

const CalculateForm = () => {

    const [allType, setAllType] = useState([]);
    const [allWorkplace, setAllWorkplace] = useState([]);
    const [allDeathRate, setAllDeathRate] = useState([]);
    const [allVehicleProperty, setAllVehicleProperty] = useState([]);
    const [allVehicleType, setAllVehicleType] = useState([]);
    const [value, setValue] = useState("1");

    useEffect(() => {
        const fetchData = async () => {
            try {
                const responseAllInsuranceType = await fetch('https://localhost:7202/api/ClientSupport/GetAllInsuranceType');
                const responseDeathRate = await fetch('https://localhost:7202/api/LifeInsurance/AllDeathRate');
                const responseWorkplace = await fetch('https://localhost:7202/api/LifeInsurance/AllWorkplace');
                const responseVehicleProperty = await fetch('https://localhost:7202/api/VehicleInsurance/AllVehicleProperty');
                const responseVehicleType = await fetch('https://localhost:7202/api/VehicleInsurance/AllVehicleType');

                if (
                    !responseAllInsuranceType.ok
                    || !responseDeathRate.ok
                    || !responseWorkplace.ok
                    || !responseVehicleProperty.ok
                    || !responseVehicleType.ok
                ) {
                    throw new Error('Failed to fetch insurance types');
                }

                const dataAllInsuranceType = await responseAllInsuranceType.json();
                const dataDeathRate = await responseDeathRate.json();
                const dataWorkplace = await responseWorkplace.json();
                const dataVehicleProperty = await responseVehicleProperty.json();
                const dataVehicleType = await responseVehicleType.json();

                console.log('dataAllInsuranceType:', dataAllInsuranceType);
                console.log('dataDeathRate:', dataDeathRate);
                console.log('dataWorkplace:', dataWorkplace);
                console.log('dataVehicleProperty:', dataVehicleProperty);
                console.log('dataVehicleType:', dataVehicleType);

                setAllType(dataAllInsuranceType); 
                setAllWorkplace(dataWorkplace);
                setAllDeathRate(dataDeathRate);
                setAllVehicleProperty(dataVehicleProperty);
                setAllVehicleType(dataVehicleType);

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
        <Card>
            <TabContext value={value}>
                <TabList onChange={handleChange} aria-label='Ví dụ điều hướng thẻ'>
                    {allType.map((type) => (
                        <Tab key={type && type.id} value={String(type && type.id)} label={type.name} />
                    ))}
                </TabList>
                
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


                    </CardContent>

                )}
                
            </TabContext>
        </Card>
    );
}




export default CalculateForm;
