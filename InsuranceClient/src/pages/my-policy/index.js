// ** React Imports
import { useState } from 'react'

// ** MUI Imports
import Box from '@mui/material/Box'
import Card from '@mui/material/Card'
import TabList from '@mui/lab/TabList'
import TabPanel from '@mui/lab/TabPanel'
import TabContext from '@mui/lab/TabContext'
import { styled } from '@mui/material/styles'
import MuiTab from '@mui/material/Tab'

// **  Tabs Imports
import TabInfo from 'src/views/policy/TabInfo'
import TabRider from 'src/views/policy/TabRider'
import TabHistory from 'src/views/policy/TabHistoryPayment'
import TabBeneficiary from 'src/views/policy/TabBeneficiary'
import TabServiceAgent from 'src/views/policy/TabServiceAgent'

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

  const MyPolicy = () => {
    // ** State
    const [value, setValue] = useState('my-policy')
  
    const handleChange = (event, newValue) => {
      setValue(newValue)
    }
  
    return (
      <Card>
        <TabContext value={value}>
          <TabList
            onChange={handleChange}
            aria-label='my-policy tabs'
            sx={{ borderBottom: theme => `1px solid ${theme.palette.divider}` }}
          >
            <Tab
              value='info'
              label={
                <Box sx={{ display: 'flex', alignItems: 'center' }}>
                  <TabName>Policies Information</TabName>
                </Box>
              }
            />
            <Tab
              value='rider'
              label={
                <Box sx={{ display: 'flex', alignItems: 'center' }}>
                  <TabName>Rider</TabName>
                </Box>
              }
            />
            <Tab
              value='history-payment'
              label={
                <Box sx={{ display: 'flex', alignItems: 'center' }}>
                  <TabName>History Payment</TabName>
                </Box>
              }
            />

            <Tab
              value='beneficiary'
              label={
                <Box sx={{ display: 'flex', alignItems: 'center' }}>
                  <TabName>Beneficiary</TabName>
                </Box>
              }
            />
            
            <Tab
              value='service-agent'
              label={
                <Box sx={{ display: 'flex', alignItems: 'center' }}>
                  <TabName>Service Agent</TabName>
                </Box>
              }
            />
          </TabList>
  
          <TabPanel sx={{ p: 0 }} value='info'>
            <TabInfo />
          </TabPanel>
          <TabPanel sx={{ p: 0 }} value='rider'>
            <TabRider />
          </TabPanel>
          <TabPanel sx={{ p: 0 }} value='history-payment'>
            <TabHistory />
          </TabPanel>
          <TabPanel sx={{ p: 0 }} value='beneficiary'>
            <TabBeneficiary />
          </TabPanel>
          <TabPanel sx={{ p: 0 }} value='service-agent'>
            <TabServiceAgent />
          </TabPanel>
        </TabContext>
      </Card>
    )
  }
  
  export default MyPolicy
  