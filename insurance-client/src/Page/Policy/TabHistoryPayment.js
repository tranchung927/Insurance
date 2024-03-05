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
  { id: 'create_date',
    label: 'Date\u00a0of\u00a0Payment',
    minWidth: 100,
    align: 'center',
    format: value => format(value, 'yyyy-MM-dd')
  },
  { id: 'due_date',
    label: 'Due date',
    minWidth: 100,
    align: 'center',
    format: value => format(value, 'yyyy-MM-dd')
  },
  {
    id: 'amount',
    label: 'Amount',
    minWidth: 170,
    align: 'right',
    format: value => value.toLocaleString('en-US')
  },
  {
    id: 'type',
    label: 'Type\u00a0of\u00a0Transaction',
    minWidth: 170,
    align: 'center'
  },
  {
    id: 'invoice_number',
    label: 'Invoice\u00a0number',
    minWidth: 170,
    align: 'right'
  },
]
function createData(create_date, due_date, amount, type, invoice_number) {
  return { create_date, due_date, amount, type, invoice_number }
}

const rows = [
  createData('2023-12-28', '2023-12-26', 1002000, 'First premium', 'K23DAA 01482740'),
]

const TabHistoryPayment = () => {
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
      <Typography variant='h6' align="left" fontWeight="bold" color="primary" style={{ margin: '20px'}}>Payment List</Typography>
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
                        {column.format && (typeof value === 'number' || (typeof value === 'object' && value instanceof Date)) ? column.format(value) : value}
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

export default TabHistoryPayment
