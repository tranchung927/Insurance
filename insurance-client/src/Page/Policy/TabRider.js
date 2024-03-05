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
  { id: 'rider', label: 'Rider', minWidth: 170, align: 'center' },
  { id: 'insured', label: 'Insured', minWidth: 100, align: 'center' },
  {
    id: 'effective_date',
    label: 'Effective\u00a0date',
    minWidth: 170,
    align: 'center',
    format: value => format(value, 'yyyy-MM-dd')
  },
  {
    id: 'policy_status',
    label: 'Policy\u00a0Status',
    minWidth: 170,
    align: 'center'
  },
  {
    id: 'sum_assured',
    label: 'Sum\u00a0Assured',
    minWidth: 170,
    align: 'right',
    format: value => value.toLocaleString('en-US')
  },
  {
    id: 'premium',
    label: 'Premium',
    minWidth: 170,
    align: 'right',
    format: value => value.toLocaleString('en-US')
  },
]
function createData(rider, insured, effective_date, policy_status, sum_assured, premium) {
  return { rider, insured, effective_date, policy_status, sum_assured, premium }
}

const rows = [
  createData('Bảo hiểm bổ trợ Hỗ trợ nằm viện 2022', 'TRẦN VĂN CHUNG', '2023-12-26', 'Policy is In-force', 400000, 97000),
  createData('Bảo hiểm bổ trợ Tử vong và Thương tật mở rộng do tai nạn 2022', 'TRẦN VĂN CHUNG', '2023-12-26', 'Policy is In-force', 200000000, 40000),
  createData('Bảo hiểm bổ trợ Bệnh hiểm nghèo 2022', 'TRẦN VĂN CHUNG', '2023-12-26', 'Policy is In-force', 200000000, 53000),
  createData('Bảo hiểm bổ trợ Tử vong hoặc Thương tật toàn bộ và vĩnh viễn 2022', 'TRẦN VĂN CHUNG', '2023-12-26', 'Policy is In-force', 150000000, 45000),
]

const TabRider = () => {
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
      <Typography variant='h6' align="left" fontWeight="bold" color="primary" style={{ margin: '20px'}}>Rider List</Typography>
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

export default TabRider
