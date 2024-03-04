import React from 'react'
import ReactDOM from 'react-dom/client'
import TableStickyHeader from './Components/Table/TableStickyHeader'
import CalculateForm from './Components/CalculateForm/CalculateForm'
import Tickets from './Components/Tickets/Tickets'

ReactDOM.createRoot(document.getElementById('root')).render(
  <React.StrictMode>
     {/*   <TableStickyHeader />*/}
        <TableStickyHeader />
        <Tickets/>
        {/*<FormDialog />*/}
        {/*<ComponentA/>*/}
        {/*<DialogTest/>*/}
       {/* <CalculateForm/>*/}
  </React.StrictMode>
)