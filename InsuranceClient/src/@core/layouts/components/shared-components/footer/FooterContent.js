// ** MUI Imports
import Box from '@mui/material/Box'
import Typography from '@mui/material/Typography'
import useMediaQuery from '@mui/material/useMediaQuery'
import Link from "@mui/material/Link";
import Grid from "@mui/material/Grid";
import Stack from "@mui/material/Stack";
import { styled } from '@mui/material/styles'

import MapMarker from 'mdi-material-ui/MapMarker'
import Phone from 'mdi-material-ui/Phone'
import Fax from 'mdi-material-ui/Fax'
import Email from 'mdi-material-ui/Email'
const LogoStyled = styled('img')(({ theme }) => ({
  width: 64,
  height: 56
}))
const IconStyled = styled('img')(({ theme }) => ({
  width: 24,
  height: 24
}))


const FooterContent = () => {
  // ** Var
  const hidden = useMediaQuery(theme => theme.breakpoints.down('md'))

  return (
    <footer className="footer-page">
    <Box sx={{ display: 'flex', flexWrap: 'wrap', alignItems: 'center', justifyContent: 'space-between' }}>
      <Grid container spacing={3}>
        <Grid item xs={12} sm={4}>
          <Box sx={{ marginBottom: "12px" }}>
            <Box>
              <LogoStyled src='/images/pages/tree.png' alt='Profile Pic' />
            </Box>
            <Stack spacing={1}>
              <Stack direction="row" spacing={2}>
                <MapMarker />
                <Typography>285 Đội Cấn, Ba Đình, Hà Nội</Typography>
              </Stack>
              <Stack direction="row" spacing={2}>
                <Phone />
                <Typography>Head Office: <a> 028 7303 1879</a> </Typography>
              </Stack>
              <Stack direction="row" spacing={2}>
                <Phone />
                <Typography>Hotline: <a>1900 636 993</a> </Typography>
              </Stack>
              <Stack direction="row" spacing={2}>
                <Fax />
                <Typography><a>028 - 6255 6399</a> </Typography>
              </Stack>
              <Stack direction="row" spacing={2}>
                <Email />
                <Typography><a>hotline@Insurance.com.vn</a> </Typography>
              </Stack>
            </Stack>
          </Box>
          <Box className="social">
            <Stack
              direction={{ xs: "column", sm: "row" }}
              spacing={{ xs: 1, sm: 2, md: 4 }}
            >
              <Stack>
                <Link
                  target="_blank"
                  href=""
                >
                  <IconStyled src='/images/logos/facebook.png' />
                </Link>
              </Stack>
              <Stack>
                <Link
                  target="_blank"
                  href=""
                >
                  <IconStyled src='/images/logos/zalo.png' />
                </Link>
              </Stack>
              <Stack>
                <Link
                  target="_blank"
                  href=""
                >
                  <IconStyled src='/images/logos/google.png' />
                </Link>
              </Stack>
            </Stack>
          </Box>
        </Grid>

        <Grid item xs={12} sm={4}>
          <Box className="info-footer" sx={{ marginBottom: "12px" }}>
            <Box sx={{ marginBottom: "24px" }}>
              <Typography variant="h5">Introduce</Typography>
            </Box>
            <Stack className="list-item-info" spacing={1}>
              <Typography>
                <a>General Introduction</a>
              </Typography>
              <Typography>
                <a>Development History</a>
              </Typography>
              <Typography>
                <a>Vision</a>
              </Typography>
              <Typography>
                <a>Leadership Team</a>
              </Typography>
              <Typography>
                <a>Awards</a>
              </Typography>
            </Stack>
          </Box>
        </Grid>
        <Grid item xs={12} sm={4}>
          <Box className="info-footer" sx={{ marginBottom: "12px" }}>
            <Box sx={{ marginBottom: "24px" }}>
              <Typography variant="h5">Product</Typography>
            </Box>
            <Stack className="list-item-info" spacing={1}>
              <a>Life Insurance</a>
              <Typography>
                <a> Medical Insurance</a>
              </Typography>
              <Typography>
                <a>Life Insurance</a>
              </Typography>
              <Typography>
                <a>Home Insurance</a>
              </Typography>
            </Stack>
          </Box>
        </Grid>
      </Grid>
      <Grid
        container
        spacing={3}
        textAlign={"center"}
        sx={{ marginTop: "36px" }}
      >
        <Grid item xs={12}>
          <Box className="copyright">
            © 2023 Insurance Vietnam. All rights reserved.
          </Box>
        </Grid>
      </Grid>
    </Box>
    </footer>
  )
}

export default FooterContent
