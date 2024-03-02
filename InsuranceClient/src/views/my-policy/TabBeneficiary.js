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
    id: 'type',
    label: 'Beneficiary\u00a0type',
    minWidth: 170,
    align: 'center'
  },
  {
    id: 'name',
    label: 'Beneficiary\u00a0name',
    minWidth: 170,
    align: 'center'
  },
  { id: 'id_number',
    label: 'ID\u00a0number',
    minWidth: 100,
    align: 'right'
  },
  { id: 'rate',
    label: 'Beneficiary\u00a0rate',
    minWidth: 100,
    align: 'center',
    format: value => value.toFixed(0)
  },
]
function createData(type, name, id_number, rate) {
  return { type, name, id_number, rate }
}

const rows = [
  createData('Maturity', 'TRẦN VĂN CHUNG', '036095013658', 100),
  createData('Death	', 'Người thừa kế theo luật', '', 100),
]

const TabBeneficiary = () => {
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

export default TabBeneficiary
