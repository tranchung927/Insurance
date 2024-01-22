import HomePage from "../Page/HomePage";

import LifeInsurance from "../Sections/Insurance-product/Life-insurance";
import { BrowserRouter as Router, Route, Routes } from "react-router-dom";

function InsuranceRouter() {
  
  return (
    <Router>
      
      <div>
        <Routes>
          <Route path="/product/LiveInsurance" element={<LifeInsurance />} />
          {/* <Route path="/product/LiveInsurance" element={<LifeInsurance />} />
          <Route path="/product/LiveInsurance" element={<LifeInsurance />} />
          <Route path="/product/LiveInsurance" element={<LifeInsurance />} /> */}
          <Route path="/" element={<HomePage />} />
        </Routes>
      </div>
    </Router>
  );
}

export default InsuranceRouter;
