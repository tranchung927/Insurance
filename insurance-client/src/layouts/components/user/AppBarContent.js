import Box from '@mui/material/Box'
import Typography from '@mui/material/Typography';
import IconButton from '@mui/material/IconButton'
import Button from '@mui/material/Button'
import useMediaQuery from '@mui/material/useMediaQuery'
import themeConfig from 'src/configs/themeConfig'
import { styled, useTheme } from '@mui/material/styles'
import Menu from 'mdi-material-ui/Menu'
import Dropdown from 'src/@core/layouts/components/shared-components/dropdown'
import Logo from 'src/@core/components/logo';

const AppBarContent = props => {
  // ** Props
  const { hidden, settings, saveSettings, toggleNavVisibility, pages } = props

  // ** Hook
  const hiddenSm = useMediaQuery(theme => theme.breakpoints.down('sm'))
  const theme = useTheme()

  return (
    <Box sx={{ width: '100%', display: 'flex', alignItems: 'center', justifyContent: 'space-between' }}>
      <Box className='actions-left' sx={{ mr: 2, display: 'flex', alignItems: 'center' }}>
        {hidden ? (
          <IconButton
            color='inherit'
            onClick={toggleNavVisibility}
            sx={{ ml: -2.75, ...(hiddenSm ? {} : { mr: 3.5 }) }}
          >
            <Menu />
          </IconButton>
        ) : null}
        <Logo/>
        {!hidden ? (
          <Box sx={{ flexGrow: 1, display: 'flex', gap: 4, ml: 2 }}>
            {pages?.map((page, index) => (
              <Dropdown key={index} page={page} {...props}></Dropdown>
            ))}
          </Box>
        ) : null}
      </Box>
      <Box className='actions-right' sx={{ mr: 2, display: 'flex', alignItems: 'center' }}>
        <Button component='a' href='pages/login' variant='contained' sx={{ px: 5.5 }}>
          Register now
        </Button>
      </Box>
    </Box>
  )
}

export default AppBarContent
