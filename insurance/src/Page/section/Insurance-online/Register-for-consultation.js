import Header from "../../../Component/header";
import Footer from "../../../Component/footer";
import {
  Stack,
  Typography,
  Box,
  TextField,
  Autocomplete,
  Button,Snackbar,Alert
} from "@mui/material";
import Grid from "@mui/material/Grid";
import { DataContext } from "../../../Context/data-context";
import { useContext } from "react";
import Radio from "@mui/material/Radio";
import RadioGroup from "@mui/material/RadioGroup";
import FormControlLabel from "@mui/material/FormControlLabel";
import FormControl from "@mui/material/FormControl";
import FormLabel from "@mui/material/FormLabel";
import { useFormik } from "formik";
import * as Yup from "yup";
import { useState, useEffect } from "react";
import { DateTimePicker } from "@mui/x-date-pickers/DateTimePicker";

import dayjs from "dayjs";
import { DemoContainer } from "@mui/x-date-pickers/internals/demo";
import { LocalizationProvider } from "@mui/x-date-pickers/LocalizationProvider";
import { AdapterDayjs } from "@mui/x-date-pickers/AdapterDayjs";
import { DatePicker } from "@mui/x-date-pickers/DatePicker";
import utc from "dayjs/plugin/utc";
import timezone from "dayjs/plugin/timezone";
import axios from "axios";

dayjs.extend(utc);
dayjs.extend(timezone);

function RegisterForConsultation() {
  const { insuranceTypes, getAllProvince } = useContext(DataContext);
  const [dataProvince, setDataProvince] = useState([]);
  const[alertCheckSuccess,setAlertCheckSuccess] = useState(false);
  const[alertCheckError,setAlertCheckError] = useState(false);

  const handleCloseAlert = (event, reason) => {
    if (reason === 'clickaway') {
      return;
    }
    setAlertCheckSuccess(false);
    setAlertCheckError(false)
  };

  useEffect(() => {
    if (getAllProvince.results != undefined) {
      const provinceIds = getAllProvince.results;
      setDataProvince(provinceIds);
    }
  }, [getAllProvince]);

  const formik = useFormik({
    initialValues: {
      fullName: "",
      birthDay: null,
      livingArea: "",
      selectedInsuranceType: null,
      gender: null,
      selectedCity: null,
      contactDate: null,
      referralCode: "",
      email: "",
      phone: "",
    },
    validationSchema: Yup.object({
      fullName: Yup.string().required("Field is required"),
      phone: Yup.string()
        .matches(/^\d+$/, "Invalid phone number")
        .required("Phone Number is required"),
      email: Yup.string().nullable().email("Invalid email format"),
    }),
    onSubmit: async (values, { resetForm }) => {
      try {
        const formattedValues = {
          ...values,
          birthDay: values.birthDay
            ? dayjs(values.birthDay).tz("Asia/Ho_Chi_Minh").format("YYYY-MM-DD") // adjust the format if needed
            : null,
          contactDate: values.contactDate
            ? dayjs(values.contactDate)
                .tz("Asia/Ho_Chi_Minh")
                .format("YYYY-MM-DD HH:mm:ss") // adjust the format if needed
            : null,
        };

        alert(JSON.stringify(formattedValues, null, 2));

        const formData = new FormData();
        formData.append("fullName", formattedValues.fullName);
        formData.append("gender", formattedValues.gender);
        formData.append("birthDay", formattedValues.birthDay);
        formData.append("referralCode", formattedValues.referralCode);
        formData.append("currentResidenceDetails", formattedValues.livingArea);
        formData.append("province", formattedValues.selectedCity.province_name);
        formData.append("phone", formattedValues.phone);
        formData.append("email", formattedValues.email);
        formData.append(
          "insuranceTypeId",
          formattedValues.selectedInsuranceType.typeId
        );
        formData.append(
          "dateAndTimeOfConsultation",
          formattedValues.contactDate
        );

        const response = await axios.post(
          "https://localhost:7064/RegisterForConsultation/insert",
          formData,
          {
            headers: {
              "Content-Type": "multipart/form-data",
            },
          }
        );
          setAlertCheckSuccess(true);
        // Reset the form after successful submission
        resetForm();
      } catch (error) {
        setAlertCheckError(true)
        console.error("insert error", error);
      }
    },
  });
  return (
    <>
      <Header />
      {/* banner */}
      <Stack sx={{ marginTop: "70px" }} className="banner-tuvan">
        <Stack
          sx={{
            margin: {
              xs: "6px 10px",
              sm: "0px 420px",
            },
            height: "100%",
          }}
        >
          <Typography
            sx={{
              fontSize: {
                xs: "24px", // Define font size for extra-small screens
                sm: "40px", // Define font size for small screens and larger
              },
              display: "flex",
              alignItems: "center",
              height: "100%",
              textAlign: { xs: "center", sm: "start" },
              fontWeight: "700",
              color: "#fff",
            }}
          >
            REGISTER FOR CONSULTATION
          </Typography>
        </Stack>
      </Stack>

      {/* con */}
      <Stack
        spacing={{ xs: 1, sm: 2, md: 4 }}
        sx={{
          margin: {
            xs: "20px 10px",
            sm: "60px 420px",
          },
          height: "100%",

          display: "flex", // Sử dụng flex để chia cấp chiều rộng và chiều cao
        }}
      >
        <Stack sx={{ flex: 1 }}>
          <div style={{ flex: 1 }}>
            <Typography
              sx={{
                fontSize: {
                  xs: "24px", // Define font size for extra-small screens
                  sm: "30px", // Define font size for small screens and larger
                },
                textAlign: "center",
                fontWeight: "700",

                color: "#518853",
              }}
            >
              Sign up now
            </Typography>
          </div>
        </Stack>
        <Stack
          direction={{ xs: "column", sm: "row" }}
          spacing={{ xs: 1, sm: 2, md: 4 }}
          sx={{
            margin: {
              xs: "20px 10px",
              sm: "40px 420px",
            },
            height: "100%",

            display: "flex", // Sử dụng flex để chia cấp chiều rộng và chiều cao
          }}
        >
          <Stack
            direction={{ xs: "column", sm: "row" }}
            sx={{ display: "flex" }}
            spacing={3}
          >
            <Stack sx={{ flex: 2 }}>
              <img
                src={require("../../../Img/baner.jpeg")}
                alt="Insurance House"
                style={{
                  width: "100%",
                  height: "100%",
                  objectFit: "cover",
                  maxHeight: "448px",
                  borderRadius: "15px",
                }}
              />
            </Stack>
            <Stack sx={{ flex: 1, display: "flex", flexDirection: "column" }}>
              <Typography variant="h5" fontWeight={"600"}>
                Insurance Viet Nam
              </Typography>
              <Typography variant="body2" fontSize={"18px"}>
                Take care of yourself and your family with peace of mind with
                comprehensive financial protection plans against the risks of
                accidents, serious diseases...
              </Typography>
            </Stack>
          </Stack>
        </Stack>

        <Stack
          direction={{ xs: "column", sm: "row" }}
          spacing={{ xs: 1, sm: 2, md: 4 }}
        >
          <Stack
            direction={{ xs: "column", sm: "row" }}
            spacing={{ xs: 1, sm: 2, md: 3 }}
            alignItems={"center"}
            borderRadius={"12px"}
            width={"50%"}
            sx={{ backgroundColor: "#e7f3ed", overflow: "hidden" }}
          >
            <Typography
              variant="h4"
              fontWeight={"600"}
              sx={{ color: "#fff", backgroundColor: "#00994e" }}
              padding={"6px 12px"}
            >
              01
            </Typography>
            <Typography variant="body2" fontWeight={"600"} fontSize={"16px"}>
              Fill in your information
            </Typography>
          </Stack>
          <Stack
            direction={{ xs: "column", sm: "row" }}
            spacing={{ xs: 1, sm: 2, md: 3 }}
            alignItems={"center"}
            borderRadius={"12px"}
            width={"50%"}
            sx={{ backgroundColor: "#e7f3ed", overflow: "hidden" }}
          >
            <Typography
              variant="h4"
              fontWeight={"600"}
              sx={{ color: "#fff", backgroundColor: "#00994e" }}
              padding={"6px 12px"}
            >
              02
            </Typography>
            <Typography variant="body2" fontWeight={"600"} fontSize={"16px"}>
              Our staff will call you back to confirm your appointment
            </Typography>
          </Stack>
        </Stack>

        {/* form */}
        <Box sx={{ flexGrow: 1, boxShadow: "0px 0px 10px rgba(0, 0, 0, 0.1)" }}>
          <Typography
            variant="h5"
            sx={{ margin: "24px 0px", textAlign: "center", fontWeight: "600" }}
          >
            Enter personal information for consultation
          </Typography>
          <form onSubmit={formik.handleSubmit}>
            <Grid
              container
              spacing={{ xs: 2, md: 3 }}
              columns={{ xs: 4, sm: 8, md: 12 }}
              padding={"24px"}
            >
              <Grid item xs={12} sm={4} md={4}>
                <TextField
                  id="filled-hidden-label-small"
                  label="Your name"
                  variant="outlined"
                  sx={{ minWidth: "320px" }}
                  {...formik.getFieldProps("fullName")}
                  error={
                    formik.touched.fullName && Boolean(formik.errors.fullName)
                  }
                  helperText={formik.touched.fullName && formik.errors.fullName}
                />
              </Grid>
              <Grid item xs={12} sm={4} md={4}>
                <TextField
                  id="filled-hidden-label-small"
                  label="Living area"
                  variant="outlined"
                  sx={{ minWidth: "320px" }}
                  {...formik.getFieldProps("livingArea")}
                />
              </Grid>
              <Grid item xs={12} sm={4} md={4}>
                <Autocomplete
                  disablePortal
                  id="combo-box-demo"
                  options={insuranceTypes}
                  sx={{ width: 320 }}
                  getOptionLabel={(item) => item.typeName}
                  renderInput={(params) => (
                    <TextField {...params} label="Type of insurance" />
                  )}
                  value={formik.values.selectedInsuranceType}
                  onChange={(event, value) => {
                    formik.setFieldValue("selectedInsuranceType", value);
                  }}
                />
              </Grid>
              <Grid item xs={12} sm={4} md={4}>
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
              </Grid>
              <Grid item xs={12} sm={4} md={4}>
                <Autocomplete
                  disablePortal
                  options={dataProvince}
                  getOptionLabel={(options) => options.province_name}
                  renderInput={(params) => (
                    <TextField {...params} label="Select city and province" />
                  )}
                  value={formik.values.selectedCity}
                  onChange={(event, value) => {
                    formik.setFieldValue("selectedCity", value);
                  }}
                />
              </Grid>
              <Grid item xs={12} sm={4} md={4}>
                <LocalizationProvider dateAdapter={AdapterDayjs}>
                  <DateTimePicker
                    sx={{ width: "320px" }}
                    label="Hours can be contacted"
                    value={
                      formik.values.contactDate
                        ? dayjs(formik.values.contactDate).tz("Asia/Bangkok")
                        : null
                    }
                    onChange={(newValue) => {
                      formik.setFieldValue(
                        "contactDate",
                        newValue
                          ? dayjs(newValue).tz("Asia/Bangkok").toDate()
                          : null
                      );
                    }}
                    format="DD/MM/YYYY HH:mm"
                    renderInput={(startProps) => (
                      <>
                        <TextField
                          {...startProps}
                          fullWidth
                          variant="outlined"
                          margin="normal"
                          helperText={
                            formik.touched.contactDate &&
                            formik.errors.contactDate
                          }
                          error={
                            formik.touched.contactDate &&
                            Boolean(formik.errors.contactDate)
                          }
                        />
                      </>
                    )}
                  />
                </LocalizationProvider>
              </Grid>
              <Grid item xs={12} sm={4} md={4}>
                <LocalizationProvider dateAdapter={AdapterDayjs}>
                  <DemoContainer components={["DatePicker", "DatePicker"]}>
                    <DatePicker
                      label="Birth day"
                      value={formik.values.birthDay}
                      onChange={(value) => {
                        formik.setFieldValue("birthDay", value);
                      }}
                      format={"DD/MM/YYYY"}
                      sx={{ width: "320px", marginTop: "-8px" }}
                    />
                  </DemoContainer>
                </LocalizationProvider>
              </Grid>
              <Grid item xs={12} sm={4} md={4}>
                <TextField
                  id="filled-hidden-label-small"
                  label="Phone"
                  variant="outlined"
                  sx={{ minWidth: "320px" }}
                  {...formik.getFieldProps("phone")}
                  error={formik.touched.phone && Boolean(formik.errors.phone)}
                  helperText={formik.touched.phone && formik.errors.phone}
                />
              </Grid>
              <Grid item xs={12} sm={4} md={4}>
                <TextField
                  id="filled-hidden-label-small"
                  label="Referral code"
                  variant="outlined"
                  sx={{ minWidth: "320px" }}
                  {...formik.getFieldProps("referralCode")}
                />
              </Grid>
              <Grid item xs={12} sm={4} md={4}>
                <TextField
                  id="filled-hidden-label-small"
                  label="Email"
                  variant="outlined"
                  sx={{ minWidth: "320px" }}
                  {...formik.getFieldProps("email")}
                  error={formik.touched.email && Boolean(formik.errors.email)}
                  helperText={
                    (formik.touched.email && formik.errors.email) ||
                    (!formik.errors.email && "Enter a valid email")
                  }
                />
              </Grid>
            </Grid>
            <Stack sx={{ alignItems: "end" }}>
              <Button
                size="small"
                className="btn-hea-info-green"
                variant="contained"
                sx={{
                  maxWidth: "160px",
                  padding: "8px 16px !important;",
                  margin: "0px 28px 16px",
                }}
                type="submit"
              >
                Send
              </Button>
            </Stack>
          </form>
        </Box>
      </Stack>

        {/* snackbar */}
        <Snackbar open={alertCheckSuccess} autoHideDuration={6000} onClose={handleCloseAlert}>
        <Alert
          onClose={handleCloseAlert}
          severity="success"
          variant="filled"
          sx={{ width: '100%' }}
        >
          Add information success
        </Alert>
      </Snackbar>
        {/* snackbar */}
        <Snackbar open={alertCheckError} autoHideDuration={6000} onClose={handleCloseAlert}>
        <Alert
          onClose={handleCloseAlert}
          severity="error"
          variant="filled"
          sx={{ width: '100%' }}
        >
          Add information wrong
        </Alert>
      </Snackbar>


      <Footer />
    </>
  );
}

export default RegisterForConsultation;
