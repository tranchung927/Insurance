// ** MUI Imports
import Box from '@mui/material/Box'
import useMediaQuery from '@mui/material/useMediaQuery'

// ** Layout Imports
// !Do not remove this Layout import
import BlankLayout from 'src/@core/layouts/BlankLayout'

// ** Hook Import
import { useSettings } from 'src/@core/hooks/useSettings'

const HomeLayout = ({ children }) => {
  const { settings, saveSettings } = useSettings()
  return (
    <BlankLayout>
      {children}
    </BlankLayout>
  )
}

export default HomeLayout
