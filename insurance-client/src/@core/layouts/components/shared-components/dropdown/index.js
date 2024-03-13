import { useState, useEffect, useRef } from 'react'
import Box from '@mui/material/Box'
import { useTheme } from '@mui/material/styles'
import Typography from '@mui/material/Typography'
import IconMenuDown from 'mdi-material-ui/MenuDown'
import Link from 'next/link'
import ListItemButton from '@mui/material/ListItemButton'
import Grow from '@mui/material/Grow';
import Paper from '@mui/material/Paper';

const Dropdown = props => {
  const { page } = props
  const [dropdown, setDropdown] = useState(false);
  const theme = useTheme()
  let ref = useRef();
  useEffect(() => {
    const handler = (event) => {
      if (dropdown && ref.current && !ref.current.contains(event.target)) {
        setDropdown(false);
      }
    };
    document.addEventListener("mousedown", handler);
    document.addEventListener("touchstart", handler);
    return () => {
      // Cleanup the event listener
      document.removeEventListener("mousedown", handler);
      document.removeEventListener("touchstart", handler);
    };
  }, [dropdown]);

  const onMouseEnter = () => {
    setDropdown(true);
  };

  const onMouseLeave = () => {
    setDropdown(false);
  };

  const toggleDropdown = () => {
    setDropdown((prev) => !prev);
  };

  const closeDropdown = () => {
    dropdown && setDropdown(false);
  };

  return (
    <Box ref={ref}
      onMouseEnter={onMouseEnter}
      onMouseLeave={onMouseLeave}
      onClick={closeDropdown}>
      <Link passHref href={page.path === undefined ? '/' : `${page.path}`}>
        <ListItemButton
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
              color: (dropdown ? theme.palette.primary.main : theme.palette.text.primary)
            }}>{page?.title}</Typography>
            <Box sx={{
              position: 'absolute',
              bottom: 0,
              left: 0,
              width: '100%',
              height: 4,
              background: theme.palette.primary.main,
              transform: (dropdown ? 'scaleX(1)' : 'scaleX(0)'),
              transformOrigin: (dropdown ? 'bottom left' : 'bottom right'),
              transition: 'transform 0.2s ease'
            }} />
          </Box>
          {page?.items ? <IconMenuDown
            style={{
              color: dropdown ? theme.palette.primary.main : theme.palette.text.primary,
              transition: 'transform 0.2s ease',
              transform: dropdown ? 'rotate(180deg)' : 'rotate(0deg)'
            }} /> : null}

        </ListItemButton>
      </Link>
      {page.items ? <Grow
        in={dropdown}
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
                    fontWeight: 400,
                    color: theme.palette.text.primary,
                    cursor: 'pointer',
                    '&:hover': {
                      backgroundColor: 'transparent',
                      color: theme.palette.primary.main
                    },
                    padding: 0,
                  })
                }}
              >
                {item?.title}
              </ListItemButton>
            </Link>
            )
          })}
        </Paper>
      </Grow> : null}
    </Box>
  );
};

export default Dropdown
