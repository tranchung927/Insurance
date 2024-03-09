import HomePage from "../Page/HomePage";
import LifeInsurance from "../Page/section/Insurance-product/Life-insurance";
import { BrowserRouter as Router, Route, Routes } from "react-router-dom";
import MedicalInsurance from "../Page/section/Insurance-product/Medical-Insurance";
import MotorInsurance from "../Page/section/Insurance-product/Motor-Insurance";
import HomeInsurance from "../Page/section/Insurance-product/Home-Insurance";
import Contact from "../Page/Contact";
import BuyInsurance from "../Page/section/Insurance-online/Buy-Insurance"
import RegisterForConsultation from "../Page/section/Insurance-online/Register-for-consultation";
import News from "../Page/ListNews"
import Policy from "../Page/Policy"
import Payment from "../Page/Payment"
import CalculateForm from "../Page/CalculateForm/CalculateForm";
import Login from "../Page/Login";
import Tickets from "../Page/Tickets";
function InsuranceRouter() {
  
  return (
    <Router>
      
      <div>
        <Routes>
          <Route path="/product/life-insurance" element={<LifeInsurance />} />
          <Route path="/product/health-insurance" element={<MedicalInsurance />} />
          <Route path="/product/car-insurance" element={<MotorInsurance />} />
          <Route path="/product/home-insurance" element={<HomeInsurance />} />
          <Route path="/" element={<HomePage/>} />
          <Route path="/Contact" element={<Contact/>}/>
          <Route path="/insurance-online/Buy-Insurance" element={<BuyInsurance/>}/>
          <Route path="/insurance-online/Register-for-consultation" element={<RegisterForConsultation/>}/>
          <Route path="/Calculate" element={<CalculateForm />} />
          <Route path="/News" element={<News/>} />
          <Route path="/Policy" element={<Policy />} />
          <Route path="/Payment" element={<Payment />} />
          <Route path="/Login" element={<Login />} />
          <Route path="/Suport" element={<Tickets />} />
          
        </Routes>
      </div>
    </Router>
  );
}

export default InsuranceRouter;
