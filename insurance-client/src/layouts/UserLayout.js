// ** MUI Imports
import useMediaQuery from '@mui/material/useMediaQuery'

// ** Layout Imports
// !Do not remove this Layout import
import MainLayout from 'src/@core/layouts/MainLayout'

// ** Navigation Imports
import NavItems from 'src/navigation/user'

import UserAppBarContent from './components/user/AppBarContent'

// ** Hook Import
import { useSettings } from 'src/@core/hooks/useSettings'

const UserLayout = ({ children }) => {
  // ** Hooks
  const { settings, saveSettings } = useSettings()
  const hidden = useMediaQuery(theme => theme.breakpoints.down('lg'))

  return (
    <MainLayout
      hidden={true}
      settings={settings}
      saveSettings={saveSettings}
      navItems={NavItems()}
      mainAppBarContent={(
        props
      ) => (
        <UserAppBarContent
          hidden={hidden}
          settings={settings}
          saveSettings={saveSettings}
          toggleNavVisibility={props.toggleNavVisibility}
          pages={NavItems()}
        />
      )
      }
    >
      {children}
    </MainLayout>
  )
}

export default UserLayout
