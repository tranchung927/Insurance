import HomePage from "../Page/HomePage";
import LifeInsurance from "../Page/section/Insurance-product/Life-insurance";
import { BrowserRouter as Router, Route, Routes } from "react-router-dom";
import MedicalInsurance from "../Page/section/Insurance-product/Medical-Insurance";
import MotorInsurance from "../Page/section/Insurance-product/Motor-Insurance";
import HomeInsurance from "../Page/section/Insurance-product/Home-Insurance";
import Contact from "../Page/Contact";
import BuyInsurance from "../Page/section/Insurance-online/Buy-Insurance"
import RegisterForConsultation from "../Page/section/Insurance-online/Register-for-consultation";

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
          <Route path="/insurance-online/Buy-Insurance" element={<BuyInsurance/>}/>
          <Route path="/insurance-online/Register-for-consultation" element={<RegisterForConsultation/>}/>
        </Routes>
      </div>
    </Router>
  );
}

export default InsuranceRouter;
