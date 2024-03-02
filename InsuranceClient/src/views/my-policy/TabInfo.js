// ** React Imports
import { useState } from 'react'

// ** MUI Imports
import Box from '@mui/material/Box'
import Grid from '@mui/material/Grid'
import Link from '@mui/material/Link'
import Alert from '@mui/material/Alert'
import Select from '@mui/material/Select'
import { styled } from '@mui/material/styles'
import MenuItem from '@mui/material/MenuItem'
import TextField from '@mui/material/TextField'
import Typography from '@mui/material/Typography'
import InputLabel from '@mui/material/InputLabel'
import AlertTitle from '@mui/material/AlertTitle'
import IconButton from '@mui/material/IconButton'
import CardContent from '@mui/material/CardContent'
import Button from '@mui/material/Button'
import Paper from '@mui/material/Paper'

// ** Icons Imports
import Close from 'mdi-material-ui/Close'

const ImgStyled = styled('img')(({ theme }) => ({
  width: 120,
  height: 120,
  marginRight: theme.spacing(6.25),
  borderRadius: theme.shape.borderRadius
}))

const ButtonStyled = styled(Button)(({ theme }) => ({
  [theme.breakpoints.down('sm')]: {
    width: '100%',
    textAlign: 'center'
  }
}))

const ResetButtonStyled = styled(Button)(({ theme }) => ({
  marginLeft: theme.spacing(4.5),
  [theme.breakpoints.down('sm')]: {
    width: '100%',
    marginLeft: 0,
    textAlign: 'center',
    marginTop: theme.spacing(4)
  }
}))

const SectionLabel = ({ section }) => {
  return (
    <Grid item xs={2} sm={4} md={3}>
      <Typography variant='h6' align="left" fontWeight="bold" color="primary" style={{ marginTop: '20px', marginBottom: '20px'}}>{section}</Typography>
    </Grid>
  );
};


const TitleLabel = ({ title }) => {
  return (
    <Grid item xs={2} sm={4} md={3}>
      <Typography variant='subtitle1' align="left" fontWeight="bold">{title}</Typography>
    </Grid>
  );
};

const ValueLabel = ({ value }) => {
  return (
    <Grid item xs={2} sm={4} md={3}>
      <Typography variant='subtitle1' align="left" fontWeight="regular" style={{ marginRight: '20px' }}>{value}</Typography>
    </Grid>
  );
};

const TabInfo = () => {
    return (
        <CardContent>
          <SectionLabel section='Basic info'/>
          <Grid container spacing={{ xs: 2, md: 2 }} columns={{ xs: 4, sm: 8, md: 12 }}>
            <TitleLabel title='Policy number:'/>
            <ValueLabel value='S11005141275'/>
            <TitleLabel title='Policy status:'/>
            <ValueLabel value='Policy is In-force'/>
            <TitleLabel title='Main Product:'/>
            <ValueLabel value='Thịnh An Ưu Việt - Kế Hoạch Bảo Hiểm Cơ Bản'/>
            <TitleLabel title='Effective date:'/>
            <ValueLabel value='2023-12-26'/>
            <TitleLabel title='Sum assured:'/>
            <ValueLabel value='400,000,000'/>
            <TitleLabel title='Maturity date:'/>
            <ValueLabel value='2094-12-25'/>
            <TitleLabel title='Premium:'/>
            <ValueLabel value='767,000'/>
            <TitleLabel title='Policy term:'/>
            <ValueLabel value='71'/>
            <TitleLabel title='Payment mode:'/>
            <ValueLabel value='Monthly payment'/>
            <TitleLabel title='Premium Payment period:'/>
            <ValueLabel value='71'/>
            <TitleLabel title='Recent paid:'/>
            <ValueLabel value='2023-12-27'/>
            <TitleLabel title='Paid premium counts:'/>
            <ValueLabel value='1'/>
            <TitleLabel title='Account value (Calculated date):'/>
            <ValueLabel value='0 (2024-03-01)'/>
            <TitleLabel title='Next Premium:'/>
            <ValueLabel value='2024-01-26'/>
          </Grid>
          <SectionLabel section='Policy owner name info'/>
          <Grid container spacing={{ xs: 2, md: 2 }} columns={{ xs: 4, sm: 8, md: 12 }}>
            <TitleLabel title='Policy owner name:'/>
            <ValueLabel value='TRẦN VĂN CHUNG'/>
            <TitleLabel title='Gender:'/>
            <ValueLabel value='Man'/>
            <TitleLabel title='Date of birth:'/>
            <ValueLabel value='1995-01-10'/>
            <TitleLabel title='ID number:'/>
            <ValueLabel value='036095013658'/>
            <TitleLabel title='Address:'/>
            <ValueLabel value='Đội 10 Nghĩa Hồng Nghĩa Hưng Nam Định Tỉnh Nam Định'/>
          </Grid>
          <SectionLabel section='Insured info'/>
          <Grid container spacing={{ xs: 2, md: 2 }} columns={{ xs: 4, sm: 8, md: 12 }}>
            <TitleLabel title='Insured name:'/>
            <ValueLabel value='TRẦN VĂN CHUNG'/>
            <TitleLabel title='Gender:'/>
            <ValueLabel value='Man'/>
            <TitleLabel title='Date of birth:'/>
            <ValueLabel value='1995-01-10'/>
            <TitleLabel title='ID number:'/>
            <ValueLabel value='036095013658'/>
          </Grid>
        </CardContent>
  )
}
export default TabInfo