// ** MUI Imports
import Box from '@mui/material/Box'
import Link from '@mui/material/Link'
import Grid from '@mui/material/Grid'
import Stack from '@mui/material/Stack'
import Typography from '@mui/material/Typography'
import useMediaQuery from '@mui/material/useMediaQuery'
import Logo from 'src/@core/components/logo'
import Divider from '@mui/material/Divider'

import { styled, useTheme } from '@mui/material/styles'

const FooterContent = () => {
  // ** Var
  const hidden = useMediaQuery(theme => theme.breakpoints.down('md'))
  const theme = useTheme()
  return (
    <Box>
      {hidden ? null : (
        <Grid container spacing={2}>
          <Grid item md={4}>
            <Box sx={{ width: '100%' }}>
              <Stack spacing={1}>
                <Logo />
                <Link href='/'><Typography variant='body2'>401</Typography></Link>
                <Link href='/'><Typography variant='body2'>401</Typography></Link>
              </Stack>
            </Box>
          </Grid>
          <Grid item md={2}>
            <Box sx={{ width: '100%' }}>
              <Typography variant='h6'>Introduce</Typography>
              <Stack spacing={1}>
                <Link target='_blank' href='/'><Typography variant='body2'>General introduction</Typography></Link>
                <Link href='/'><Typography variant='body2'>History of development</Typography></Link>
                <Link href='/'><Typography variant='body2'>Vision</Typography></Link>
                <Link href='/'><Typography variant='body2'>Leadership team</Typography></Link>
                <Link href='/'><Typography variant='body2'>Branches, transaction offices</Typography></Link>
              </Stack>
            </Box>
          </Grid>
          <Grid item md={2}>
            <Box sx={{ width: '100%' }}>
              <Typography variant='h6'>Products stand out</Typography>
              <Stack spacing={1}>
                <Link target='_blank' href='/'><Typography variant='body2'>Protection Products</Typography></Link>
                <Link href='/'><Typography variant='body2'>Save products</Typography></Link>
                <Link href='/'><Typography variant='body2'>Educational products</Typography></Link>
                <Link href='/'><Typography variant='body2'>Investment products</Typography></Link>
                <Link href='/'><Typography variant='body2'>Supplementary products</Typography></Link>
              </Stack>
            </Box>
          </Grid>
          <Grid item md={2}>
            <Box sx={{ width: '100%' }}>
              <Typography variant='h6'>Service</Typography>
              <Stack spacing={1}>
                <Link target='_blank' href='/'><Typography variant='body2'> Payment for BH fee</Typography></Link>
                <Link href='/'><Typography variant='body2'>Solving BH benefits</Typography></Link>
                <Link href='/'><Typography variant='body2'>Appraisal service</Typography></Link>
                <Link href='/'><Typography variant='body2'>Transactions related to the Council</Typography></Link>
                <Link href='/'><Typography variant='body2'>Customer care program</Typography></Link>
                <Link href='/'><Typography variant='body2'>Taiwan Medical Service Plan</Typography></Link>
              </Stack>
            </Box>
          </Grid>
          <Grid item md={2}>
            <Box sx={{ width: '100%' }}>
              <Typography variant='h6'>News</Typography>
              <Stack spacing={1}>
                <Link target='_blank' href='/'><Typography variant='body2'>Company news</Typography></Link>
                <Link href='/'><Typography variant='body2'>Recruitment (Consultant)</Typography></Link>
                <Link href='/'><Typography variant='body2'>Recruitment (Office blocks)</Typography></Link>
                <Link href='/'><Typography variant='body2'>Public information</Typography></Link>
              </Stack>
            </Box>
          </Grid>
        </Grid>
      )}
      <Divider />
      <Typography sx={{ textAlign: 'center' }}>
        {`© ${new Date().getFullYear()} Insurance Online. All rights reserved. `}
      </Typography>
    </Box>
  )
}

export default FooterContent
