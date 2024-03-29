import { useContext, useState, useEffect } from "react";

import {
  Stack,
  Typography,
  Button,
  Box,
  CardActionArea,
  Grid,
  TextField,
  Autocomplete,
  Link,Snackbar,Alert
} from "@mui/material";

import Card from "@mui/material/Card";
import CardActions from "@mui/material/CardActions";
import CardContent from "@mui/material/CardContent";
import CardMedia from "@mui/material/CardMedia";

import axios from "axios";
import Radio from "@mui/material/Radio";
import RadioGroup from "@mui/material/RadioGroup";
import FormControlLabel from "@mui/material/FormControlLabel";
import FormControl from "@mui/material/FormControl";
import FormLabel from "@mui/material/FormLabel";
import { useFormik } from "formik";
import * as Yup from "yup";
import Dialog from "@mui/material/Dialog";
import DialogActions from "@mui/material/DialogActions";
import DialogContent from "@mui/material/DialogContent";
import DialogContentText from "@mui/material/DialogContentText";
import DialogTitle from "@mui/material/DialogTitle";
import { DataContext } from "../Context/data-context";
import moment from "moment";



const City = ["Tp.Hcm", "Hà Nội"];

function SupportRegistration() {
  const[dataProvince,setDataProvince] = useState([]);
  const {provinces,getAllProvince} = useContext(DataContext);
  const date = moment().utcOffset("+07:00").format("YYYY-MM-DDThh:mm:ss");
  const[alertCheck,setAlertCheck] = useState(false);

  const handleCloseAlert = (event, reason) => {
    if (reason === 'clickaway') {
      return;
    }
    setAlertCheck(false);
  };


  useEffect(()=>{
if(getAllProvince.results != undefined) {
    const provinceIds = getAllProvince.results;
    setDataProvince(provinceIds)
  }
  },[getAllProvince])
  const formik = useFormik({
    initialValues: {
      fullName: "",
      phoneNumber: "",
      Email: "",
      gender: null,
      selectedCity: null,
    },
    validationSchema: Yup.object({
      fullName: Yup.string().required("Field is required"),
      phoneNumber: Yup.string().required("Phone Number is required"),
      email: Yup.string().email("Invalid email format"),
    }),
    onSubmit: async (values) => {
      
      alert(JSON.stringify(values, null, 2));
      try {
        const formData = new FormData();
        formData.append('fullName', values.fullName);
        formData.append('phone', values.phoneNumber);
        formData.append('email', values.Email);
        formData.append('gender', values.gender);
        formData.append('province', values.selectedCity.province_name);
  
        // Remove 'Id' if it's not supposed to be manually set
        // formData.append('Id', 1);
  
        // Provide a valid date or remove if not needed
        formData.append('Id', 1);
      
        // Gửi request POST đến endpoint API với FormData
        const response = await axios.post(
          'https://localhost:7064/RegisterForConsultation/insert',
          formData,
          {
            headers: {
              'Content-Type': 'multipart/form-data',
            },
          }
        );
        setAlertCheck(true);
        console.log(response.data);
      } catch (error) {
        console.error("Error inserting data", error);
      }
      
    },
  });
  
    return ( <>
    <Stack
          direction={{ xs: "column", sm: "row" }}
          spacing={{ xs: 1, sm: 2, md: 4 }}
          sx={{
            margin: {
              xs: "60px 10px",
              sm: "80px 420px",
            },
            height: "100%",

            display: "flex", // Sử dụng flex để chia cấp chiều rộng và chiều cao
          }}
        >
          <Stack sx={{ flex: 1, display: "flex", flexDirection: "column" }}>
            <div style={{ flex: 1 }}>
              <Typography
                sx={{
                  fontSize: {
                    xs: "24px", // Define font size for extra-small screens
                    sm: "33px", // Define font size for small screens and larger
                  },
                  textAlign: "center",
                  fontWeight: "700",
                  marginBottom: "24px",
                }}
              >
                Want advice about products?
              </Typography>
              <Typography
                variant="body2"
                sx={{ marginBottom: "24px", fontSize: "16px" }}
              >
                Please leave your information below, an Insurance financial
                specialist will contact you as soon as possible
              </Typography>
              <Stack spacing={{ xs: 1, sm: 2, md: 4 }}>
                <form onSubmit={formik.handleSubmit}>
                  <Stack spacing={{ xs: 1, sm: 2, md: 4 }}>
                    <TextField
                      id="fullName"
                      label="customer's full name"
                      variant="outlined"
                      size="small"
                      {...formik.getFieldProps("fullName")}
                      error={
                        formik.touched.fullName &&
                        Boolean(formik.errors.fullName)
                      }
                      helperText={
                        formik.touched.fullName && formik.errors.fullName
                      }
                    />
                    <TextField
                      id="phoneNumber"
                      label="Phone number"
                      variant="outlined"
                      size="small"
                      {...formik.getFieldProps("phoneNumber")}
                      error={
                        formik.touched.phoneNumber &&
                        Boolean(formik.errors.phoneNumber)
                      }
                      helperText={
                        formik.touched.phoneNumber && formik.errors.phoneNumber
                      }
                    />
                    <TextField
                      id="Email"
                      label="Email"
                      variant="outlined"
                      size="small"
                      {...formik.getFieldProps("Email")}
                      error={
                        formik.touched.Email && Boolean(formik.errors.Email)
                      }
                      helperText={formik.touched.Email && formik.errors.Email}
                    />
                    {/* Other fields */}
                    <FormControl>
                      <FormLabel id="demo-row-radio-buttons-group-label">
                        Gender
                      </FormLabel>
                      <RadioGroup
                        row
                        aria-labelledby="demo-row-radio-buttons-group-label"
                        name="row-radio-buttons-group"
                        {...formik.getFieldProps("gender")}
                      >
                        <FormControlLabel
                          value="female"
                          control={<Radio />}
                          label="Female"
                        />
                        <FormControlLabel
                          value="male"
                          control={<Radio />}
                          label="Male"
                        />
                      </RadioGroup>
                    </FormControl>
                  
                    <Autocomplete
                      disablePortal
                      options={dataProvince}
                     getOptionLabel={(options)=>options.province_name}
                      renderInput={(params) => (
                        <TextField
                          {...params}
                          label="Select city and province"
                          size="small"
                        />
                      )}
                      value={formik.values.selectedCity}
                      onChange={(event, value) => {
                        formik.setFieldValue("selectedCity", value);
                      }}
                    />
                    <Button
                      variant="contained"
                      className="btn-hea-info-green"
                      type="submit"
                    >
                      Send information
                    </Button>
                  </Stack>
                </form>
              </Stack>
            </div>
          </Stack>
          <Stack sx={{ flex: 1 }}>
            <img
              src={require("../Img/muonduoctuvan.jpg")}
              alt="Insurance House"
              style={{
                width: "100%",
                height: "100%",
                objectFit: "cover",
                borderRadius: "15px",
              }}
            />
          </Stack>
        </Stack>
         {/* snackbar */}
         <Snackbar open={alertCheck} autoHideDuration={6000} onClose={handleCloseAlert}>
        <Alert
          onClose={handleCloseAlert}
          severity="success"
          variant="filled"
          sx={{ width: '100%' }}
        >
          Add information success
        </Alert>
      </Snackbar>
    </> );
}

export default SupportRegistration;