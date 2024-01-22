import Header from "../../Component/header";
import Footer from "../../Component/footer";
import BusinessLocation from "../../Component/Business-location";

import './insurance-product.css'
import { Stack } from "@mui/material";
function LifeInsurance() {
    return ( <>
    <Header />
        {/* banner */}
       
    <Stack sx={{marginTop:'70px'}} className="banner-product"></Stack>
        <BusinessLocation/>
    <Footer/>
    </> );
}

export default LifeInsurance;