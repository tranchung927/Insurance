// ** MUI Imports
import Box from '@mui/material/Box'
import useMediaQuery from '@mui/material/useMediaQuery'

// ** Layout Imports
import BlankLayout from 'src/@core/layouts/BlankLayout'

// ** Navigation Imports
import NavItems from 'src/navigation/user'

// ** Component Import
import UpgradeToProButton from './components/UpgradeToProButton'
import UserAppBarContent from './components/user/AppBarContent'

// ** Hook Import
import { useSettings } from 'src/@core/hooks/useSettings'

const UserLayout = ({ children }) => {
  // ** Hooks
  const { settings, saveSettings } = useSettings()
  const hidden = useMediaQuery(theme => theme.breakpoints.down('lg'))

  const UpgradeToProImg = () => {
    return (
      <Box sx={{ mx: 'auto' }}>
        <a
          target='_blank'
          rel='noreferrer'
          href='https://themeselection.com/products/materio-mui-react-nextjs-admin-template/'
        >
          <img width={230} alt='upgrade to premium' src={`/images/misc/upgrade-banner-${settings.mode}.png`} />
        </a>
      </Box>
    )
  }

  return (
    <BlankLayout>
      <UserAppBarContent
          hidden={hidden}
          settings={settings}
          saveSettings={saveSettings}
          pages={NavItems()}
        />
      {children}
      <UpgradeToProButton />
    </BlankLayout>
  )
}

export default UserLayout
