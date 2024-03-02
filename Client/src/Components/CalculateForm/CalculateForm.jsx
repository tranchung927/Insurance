// ** React Imports
import { useState, useEffect } from 'react'

// ** MUI Imports
import Tab from '@mui/material/Tab'
import Card from '@mui/material/Card'
import TabList from '@mui/lab/TabList';
import TabPanel from '@mui/lab/TabPanel'
import Button from '@mui/material/Button'
import TabContext from '@mui/lab/TabContext'
import Typography from '@mui/material/Typography'
import CardContent from '@mui/material/CardContent'

const CalculateForm = () => {

    const [dataForm, setDataForm] = useState([]);

    useEffect(() => {
        const fetchData = async () => {
            try {
                const response = await fetch('https://localhost:7202/api/ClientSupport/GetAllInsuranceType');
                if (!response.ok) {
                    throw new Error('Failed to fetch insurance types');
                }
                const data = await response.json();
                setDataForm(data); // Cập nhật danh sách loại bảo hiểm từ API
            } catch (error) {
                console.error('Error fetching insurance types:', error);
            }
        };
        fetchData();
    }, []);

    //useEffect(() => {
    //    setFormData(selectedRowData);
    //}, [selectedRowData]);

    // ** State
    const [value, setValue] = useState('1')

    const handleChange = (event, newValue) => {
        setValue(newValue)
    }

    const renderTabPanels = () => {
        return dataForm.map((body) => (
            <TabPanel key={body.id} value={"ádasd"} sx={{ p: 0 }}>
                <Typography variant='h6' sx={{ marginBottom: 2 }}>
                    Tiêu đề Một
                </Typography>
                <Typography variant='body2' sx={{ marginBottom: 4 }}>
                    Pudding tiramisu caramels. Gingerbread gummies danish chocolate bar toffee marzipan. Wafer wafer cake
                    powder danish oat cake.
                </Typography>
                <Button variant='contained'>Nút Một</Button>
            </TabPanel>
        ));
    };

    return (
        <Card>
            <TabContext value={value}>
                <TabList onChange={handleChange} aria-label='Ví dụ điều hướng thẻ'>
                    {
                        dataForm.map((type) => (
                            <Tab key={type.id} value={type.id} label={type.name} />
                        ))
                    }
                </TabList>
                <CardContent>
                    {renderTabPanels()}
                </CardContent>
            </TabContext>
        </Card>
    );
}

export default CalculateForm;
