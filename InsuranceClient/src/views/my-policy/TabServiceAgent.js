// ** React Imports
import { useState } from 'react'

// ** MUI Imports
import Paper from '@mui/material/Paper'
import Table from '@mui/material/Table'
import TableRow from '@mui/material/TableRow'
import TableHead from '@mui/material/TableHead'
import TableBody from '@mui/material/TableBody'
import TableCell from '@mui/material/TableCell'
import TableContainer from '@mui/material/TableContainer'
import TablePagination from '@mui/material/TablePagination'
import Typography from '@mui/material/Typography'
import { format } from 'date-fns';

const columns = [
  {
    id: 'name',
    label: 'Name\u00a0of\u00a0agent',
    minWidth: 170,
    align: 'center'
  },
  {
    id: 'phone_number',
    label: 'Phone\u00a0number',
    minWidth: 100,
    align: 'center'
  },
  { id: 'email',
    label: 'Email',
    minWidth: 170,
    align: 'center'
  },
  { id: 'address',
    label: 'Contact\u00a0Address',
    minWidth: 200,
    align: 'center'
  },
]
function createData(name, phone_number, email, address) {
  return { name, phone_number, email, address }
}

const rows = [
  createData('Nguyễn Thị Châm', '0965199866', 'nguyencham5895@gmail.com', 'Tầng 4, TNL Plaza Nam Định, Số 272 đường Trần Hưng Đạo, Phường Bà Triệu, Thành phố Nam Định, Tỉnh Nam Định'),
]

const TabServiceAgent = () => {
  // ** States
  const [page, setPage] = useState(0)
  const [rowsPerPage, setRowsPerPage] = useState(10)

  const handleChangePage = (event, newPage) => {
    setPage(newPage)
  }

  const handleChangeRowsPerPage = event => {
    setRowsPerPage(+event.target.value)
    setPage(0)
  }

  return (
    <Paper sx={{ width: '100%', overflow: 'hidden' }}>
      <Typography variant='h6' align="left" fontWeight="bold" color="primary" style={{ margin: '20px'}}>Beneficiary List</Typography>
      <TableContainer sx={{ maxHeight: 440 }}>
        <Table stickyHeader aria-label='rider table'>
          <TableHead>
            <TableRow>
              {columns.map(column => (
                <TableCell key={column.id} align={column.align} sx={{ minWidth: column.minWidth }}>
                  {column.label}
                </TableCell>
              ))}
            </TableRow>
          </TableHead>
          <TableBody>
            {rows.slice(page * rowsPerPage, page * rowsPerPage + rowsPerPage).map(row => {
              return (
                <TableRow hover role='checkbox' tabIndex={-1} key={row.code}>
                  {columns.map(column => {
                    const value = row[column.id]

                    return (
                      <TableCell key={column.id} align={column.align}>
                        {column.format && (typeof value === 'number' || (typeof myDate === 'object' && myDate instanceof Date)) ? column.format(value) : value}
                      </TableCell>
                    )
                  })}
                </TableRow>
              )
            })}
          </TableBody>
        </Table>
      </TableContainer>
      <TablePagination
        rowsPerPageOptions={[10, 25, 100]}
        component='div'
        count={rows.length}
        rowsPerPage={rowsPerPage}
        page={page}
        onPageChange={handleChangePage}
        onRowsPerPageChange={handleChangeRowsPerPage}
      />
    </Paper>
  )
}

export default TabServiceAgent