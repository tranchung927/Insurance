// ** Next Import
import Link from 'next/link'

// ** MUI Components
import Button from '@mui/material/Button'
import { styled } from '@mui/material/styles'
import Typography from '@mui/material/Typography'
import Box from '@mui/material/Box'

// ** Layout Import
import UserLayout from 'src/layouts/UserLayout'

const HomePage = () => {
    return (
        <Box className='content-center'>

        </Box>
    )
}
HomePage.getLayout = page => <UserLayout>{page}</UserLayout>

export default HomePage
