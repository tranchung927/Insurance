// ** React Imports
import { useState } from 'react'

// ** MUI Imports
import Card from '@mui/material/Card'
import TabList from '@mui/lab/TabList'
import TabPanel from '@mui/lab/TabPanel'
import TabContext from '@mui/lab/TabContext'
import { styled } from '@mui/material/styles'
import MuiTab from '@mui/material/Tab'

// **  Tabs Imports
import TabInfo from './TabInfo'
import TabRider from './TabRider'
import TabHistory from './TabHistoryPayment'
import TabBeneficiary from './TabBeneficiary'
import TabServiceAgent from './TabServiceAgent'

const Tab = styled(MuiTab)(({ theme }) => ({
    [theme.breakpoints.down('md')]: {
      minWidth: 100
    },
    [theme.breakpoints.down('sm')]: {
      minWidth: 67
    }
  }))
  
  const MyPolicy = () => {
    // ** State
    const [value, setValue] = useState('info')
  
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
              label='Policies Information'
            />
            <Tab
              value='rider'
              label='Rider'
            />
            <Tab
              value='history-payment'
              label='History Payment'
            />

            <Tab
              value='beneficiary'
              label='Beneficiary'
            />
            
            <Tab
              value='service-agent'
              label='Service Agent'
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
  