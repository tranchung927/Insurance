// ** React Imports
import { useState } from 'react'

// ** MUI Imports
import Card from '@mui/material/Card'
import TabList from '@mui/lab/TabList'
import TabPanel from '@mui/lab/TabPanel'
import TabContext from '@mui/lab/TabContext'
import { styled } from '@mui/material/styles'
import MuiTab from '@mui/material/Tab'
import Box from '@mui/material/Box'
// **  Tabs Imports
import TabInfo from './TabInfo'
import TabRider from './TabRider'
import TabHistory from './TabHistoryPayment'
import TabBeneficiary from './TabBeneficiary'
import TabServiceAgent from './TabServiceAgent'
import Header from "@HeaderLayout";
import Footer from "@FooterLayout";

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

    const BlankLayoutWrapper = styled(Box)(({ theme }) => ({
      height: '100vh',
    
      // For V1 Blank layout pages
      '& .content-center': {
        display: 'flex',
        minHeight: '100vh',
        alignItems: 'center',
        justifyContent: 'center',
        padding: theme.spacing(5)
      },
    
      // For V2 Blank layout pages
      '& .content-right': {
        display: 'flex',
        minHeight: '100vh',
        overflowX: 'hidden',
        position: 'relative'
      }
    }))
    
    const BlankLayout = ({ children }) => {
      return (
        <BlankLayoutWrapper className='layout-wrapper'>
          <Box className='app-content' sx={{ minHeight: '100vh', overflowX: 'hidden', position: 'relative' }}>
            {children}
          </Box>
        </BlankLayoutWrapper>
      )
    }

    return (
      <BlankLayout>

    
    {/* <Header/> */}
      <Card>
        <TabContext value={value}>

          <TabList
            onChange={handleChange}
            aria-label='my-policy tabs'
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
      <Footer/>
      </BlankLayout>
    )
  }
  
  export default MyPolicy
  