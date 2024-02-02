import HomePage from "../Page/HomePage";

import LifeInsurance from "../Sections/Insurance-product/Life-insurance";
import { BrowserRouter as Router, Route, Routes } from "react-router-dom";
import MedicalInsurance from "../Sections/Insurance-product/Medical-Insurance";
import MotorInsurance from "../Sections/Insurance-product/Motor-Insurance";
import HomeInsurance from "../Sections/Insurance-product/Home-Insurance";
import Contact from "../Page/Contact";

function InsuranceRouter() {
  
  return (
    <Router>
      
      <div>
        <Routes>
          <Route path="/product/LifeInsurance" element={<LifeInsurance />} />
          <Route path="/product/MedicalInsurance" element={<MedicalInsurance />} />
          <Route path="/product/MotorInsurance" element={<MotorInsurance />} />
          <Route path="/product/HomeInsurance" element={<HomeInsurance />} />
          <Route path="/" element={<HomePage />} />
          <Route path="/Contact" element={<Contact/>}/>
        </Routes>
      </div>
    </Router>
  );
}

export default InsuranceRouter;
