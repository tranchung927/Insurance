import { useState } from 'react'
import { useRouter } from 'next/router'
import Box from '@mui/material/Box'
import { styled, useTheme } from '@mui/material/styles'
import Typography from '@mui/material/Typography'
import MenuDown from 'mdi-material-ui/MenuDown'
import URLFormat from 'url';
import Link from 'next/link'
import ListItemButton from '@mui/material/ListItemButton'
import Grow from '@mui/material/Grow';
import Paper from '@mui/material/Paper';

const NavItemHover = props => {
  // ** Props
  const { page } = props

  // ** States
  const [anchorEl, setAnchorEl] = useState(null)
  // ** Hooks
  const router = useRouter()
  const theme = useTheme()

  const handleDropdownOpen = event => {
    setAnchorEl(event.currentTarget)
  }

  const handleDropdownClose = url => {
    if (url && URLFormat.format(url)) {
      router.push(url)
    }
    setAnchorEl(null)
  }

  return (
    <>
      <Link passHref href={page.path === undefined ? '/' : `${page.path}`}>
        <ListItemButton
          onMouseEnter={handleDropdownOpen}
          onMouseLeave={handleDropdownClose}
          component={'a'}
          {...(page.openInNewTab ? { target: '_blank' } : null)}
          onClick={e => {
            if (page.path === undefined) {
              e.preventDefault()
              e.stopPropagation()
            }
          }}
          sx={{
            ...({
              cursor: 'pointer',
              '&:hover': {
                backgroundColor: 'transparent',
              },
              padding: 0,
            })
          }}
        >
          <Box sx={{ position: 'relative', overflow: 'hidden', py: 2 }}>
            <Typography sx={{
              fontWeight: 600,
              color: (anchorEl ? theme.palette.primary.main : theme.palette.text.primary)
            }}>{page?.title}</Typography>
            <Box sx={{
              position: 'absolute',
              bottom: 0,
              left: 0,
              width: '100%',
              height: 4,
              background: theme.palette.primary.main,
              transform: (anchorEl ? 'scaleX(1)' : 'scaleX(0)'),
              transformOrigin: (anchorEl ? 'bottom left' : 'bottom right'),
              transition: 'transform 0.2s ease'
            }} />
          </Box>
          {page?.items ? <MenuDown
            style={{
              color: anchorEl ? theme.palette.primary.main : theme.palette.text.primary,
              transition: 'transform 0.2s ease',
              transform: anchorEl ? 'rotate(180deg)' : 'rotate(0deg)'
            }} /> : null}

        </ListItemButton>
      </Link>
      {page.items ? <Grow
        in={anchorEl}
        sx={{
          position: 'absolute',
          right: 0,
          left: 0,
          top: 56,
          width: '100%'
        }} >
        <Paper elevation={3} style={{ padding: 20, boxShadow: '0 4px 8px rgba(0, 0, 0, 0.1)' }}>
          {page?.items?.map((item, index) => {
            
            return (<Link key={index} passHref href={item.path === undefined ? '/' : `${item.path}`}>
              <ListItemButton
                component={'a'}
                {...(item.openInNewTab ? { target: '_blank' } : null)}
                onClick={e => {
                  if (item.path === undefined) {
                    e.preventDefault()
                    e.stopPropagation()
                  }
                }}
                sx={{
                  ...({
                    cursor: 'pointer',
                    '&:hover': {
                      backgroundColor: 'transparent',
                    },
                    padding: 0,
                  })
                }}
              >
                <Typography sx={{
                  fontWeight: 500,
                  color: theme.palette.text.primary
                }}>{item?.title}</Typography>
              </ListItemButton>
            </Link>
            )
          })}
        </Paper>
      </Grow> : null}
    </>
  )
}

export default NavItemHover
