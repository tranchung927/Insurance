import Header from "../../../Component/header";
import Footer from "../../../Component/footer";
import BusinessLocation from "../../../Component/Business-location";
import { useContext, useState, useEffect, use } from "react";
import "./insurance-product.css";
import {
  Stack,
  Typography,
  Button,
  Box,
  CardActionArea,
  Grid,
  TextField,
  Autocomplete,
  Link,
  Snackbar,
  Alert,
} from "@mui/material";

import { DataContext } from "../../../Context/data-context";
import Card from "@mui/material/Card";
import CardActions from "@mui/material/CardActions";
import CardContent from "@mui/material/CardContent";
import CardMedia from "@mui/material/CardMedia";
import "../../../App.css";
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
import moment from "moment";
import SupportRegistration from "../../../Component/SupportRegistrationForm";
import { useNavigate } from "react-router-dom";

const City = ["Tp.Hcm", "Hà Nội"];

function LifeInsurance() {
  const [insuranceType, setInsuranceType] = useState({});
  const [finterData, setFinterData] = useState([]);
  const [otherProduct, setOtherProduct] = useState([]);
  const [openDialog, setOpenDialog] = useState(false);
  const [dataProvince, setDataProvince] = useState([]);
  const [alertCheck, setAlertCheck] = useState(false);
    const navigate = useNavigate();
    
  const { provinces, getAllProvince,insuranceTypes, productNews } = useContext(DataContext);
  const date = moment().utcOffset("+07:00").format("YYYY-MM-DDThh:mm:ss");


  const handleClickBuyNow = () => {
    navigate("/insurance-online/Buy-Insurance", { state: { insuranceType } });
  };

  const handleCloseAlert = (event, reason) => {
    if (reason === "clickaway") {
      return;
    }

    setAlertCheck(false);
  };

  useEffect(() => {
    if (getAllProvince.results != undefined) {
      const provinceIds = getAllProvince.results;
      setDataProvince(provinceIds);
    }
  }, [getAllProvince]);

  const handleClickOpenDialog = () => {
    setOpenDialog(true);
  };

  const handleClose = () => {
    setOpenDialog(false);
  };

  useEffect(() => {
    const filteredInsuranceTypes = insuranceTypes.filter(
      (item) => item.typeId === 4
    );
    if (filteredInsuranceTypes.length > 0) {
      setInsuranceType(filteredInsuranceTypes[0]);
    }
  }, [insuranceTypes]);

  useEffect(() => {
    // Ensure insuranceType is not an empty object
    if (insuranceType && Object.keys(insuranceType).length > 0) {
      const data = productNews.filter((x) => x.typeId === insuranceType.typeId);
      setFinterData(data);
    }
  }, [insuranceType, productNews]);

  // Access the TypeId of the first object in the array
  useEffect(() => {
    if (insuranceTypes && Object.keys(insuranceType).length > 0) {
      const data = insuranceTypes.filter(
        (x) => x.typeId !== insuranceType.typeId
      );
      setOtherProduct(data);
    }
  }, [insuranceTypes, insuranceType]);

  return (
    <>
      <div className="bg-page-2">
        <Header />
        {/* banner */}

        <Stack sx={{ marginTop: "70px" }} className="banner-product">
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
              {insuranceType.typeName}
            </Typography>
          </Stack>
        </Stack>

        {/* ádsa */}

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
                {insuranceType.typeName}
              </Typography>
              <Typography
                variant="body2"
                sx={{ marginBottom: "24px", fontSize: "16px" }}
              >
                {insuranceType.description}
              </Typography>
              <Stack
                direction={{ xs: "column", sm: "row" }}
                spacing={{ xs: 1, sm: 2, md: 4 }}
              >
                {/* <Button
                  size="small"
                  className="btn-hea-info-green"
                  variant="contained"
                  onClick={handleClickOpenDialog}
                >
                  Further Advice
                </Button> */}

                <Button
                  size="small"
                  className="btn-hea-info-white"
                  variant="contained"
                  onClick={handleClickBuyNow}
                >
                  Buy now
                </Button>
              </Stack>
            </div>
          </Stack>
          <Stack sx={{ flex: 1 }}>
            <img
              src={`https://localhost:7064/InsuranceType/${insuranceType.typeId}`}
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
        </Stack>

        {/* Dk tham gia */}
        <div>
          <Stack
            direction={{ xs: "column", sm: "row" }}
            sx={{
              margin: {
                xs: "6px 10px",
                sm: "0px 420px",
              },
              height: "100%",
              borderRadius: "15px", // Thêm border-radius ở đây
              overflow: "hidden",
              display: "flex",
            }}
          >
            <Stack sx={{ flex: 1 }}>
              <img
                src={require("../../../Img/dieukienthamgia.jpg")}
                alt="Insurance House"
                style={{
                  width: "100%",
                  height: "100%",
                  objectFit: "cover",
                  maxHeight: "448px",
                }}
              />
            </Stack>
            <Stack sx={{ flex: 1 }}>
              <div className="dkThamgiaDes">
                <Typography
                  sx={{
                    fontSize: {
                      xs: "24px", // Define font size for extra-small screens
                      sm: "33px", // Define font size for small screens and larger
                    },
                    textAlign: "center",
                    fontWeight: "700",
                  }}
                >
                  Conditions of participation
                </Typography>

                <Box>
                  <div style={{ marginBottom: "36px" }}></div>
                  <div style={{ display: "flex", gap: "12px" }}>
                    <p></p>
                  </div>
                  <div style={{ display: "flex", gap: "12px" }}>
                    <p>Participating age: From 0 to 65 years old</p>
                  </div>
                  <div style={{ display: "flex", gap: "12px" }}>
                    <p>Maximum renewal age: 70 years old</p>
                  </div>
                  <div style={{ display: "flex", gap: "12px" }}></div>
                  <div style={{ marginTop: "12px", marginLeft: "40px" }}></div>
                </Box>
              </div>
            </Stack>
          </Stack>
        </div>
        {/* child */}
        <Box sx={{ backgroundColor: "#fafafa" }}>
          <Stack
            spacing={{ xs: 1, sm: 2, md: 4 }}
            sx={{
              margin: {
                xs: "6px 10px",
                sm: "60px 420px",
              },
              padding: "24px 0",
            }}
          >
            <Stack
              direction={{ xs: "column", sm: "row" }}
              justifyContent={"center"}
            >
              <Stack>
                <Typography
                  sx={{
                    fontSize: {
                      xs: "24px", // Define font size for extra-small screens
                      sm: "33px", // Define font size for small screens and larger
                    },
                    textAlign: "center",
                    fontWeight: "700",
                  }}
                >
                  Why should you choose?
                </Typography>

                <Typography
                  sx={{
                    fontSize: {
                      xs: "24px", // Define font size for extra-small screens
                      sm: "33px", // Define font size for small screens and larger
                    },
                    textAlign: "center",
                    fontWeight: "700",
                    color: "#02904a",
                  }}
                >
                  {insuranceType.typeName}
                </Typography>
              </Stack>
            </Stack>
            <Grid container spacing={2} sx={{ margin: "0px -18px !important" }}>
              {finterData.map((item, index) => (
                <Grid item key={index} xs={12} sm={6} md={4}>
                  <Card sx={{ height: 350 }}>
                    <CardActionArea>
                      <CardMedia
                        component="img"
                        height="140"
                        image={`https://localhost:7064/NewsInsuranceType/${item.id}`}
                        alt="green iguana"
                      />
                      <Stack
                        direction={{ xs: "column", sm: "row" }}
                        spacing={2}
                        sx={{ padding: "16px 0px 0px 16px" }}
                      >
                        <Typography variant="body" color={"green"}>
                          {item.newsType}
                        </Typography>
                      </Stack>
                      <CardContent sx={{ paddingTop: "0px" }}>
                        <Typography gutterBottom variant="h5" component="div">
                          {item.title}
                        </Typography>
                        <Typography variant="body2" color="text.secondary">
                          {item.description}
                        </Typography>
                      </CardContent>
                    </CardActionArea>
                  </Card>
                </Grid>
              ))}
            </Grid>
          </Stack>
        </Box>
        {/* Tư vấn */}
        <SupportRegistration />
        {/* Other products */}
        <Box sx={{ backgroundColor: "#fafafa" }}>
          <Stack
            spacing={{ xs: 1, sm: 2, md: 4 }}
            sx={{
              margin: {
                xs: "6px 10px",
                sm: "60px 420px",
              },
              padding: "24px 0",
            }}
          >
            <Stack
              direction={{ xs: "column", sm: "row" }}
              justifyContent={"center"}
            >
              <Stack>
                <Typography
                  sx={{
                    fontSize: {
                      xs: "24px", // Define font size for extra-small screens
                      sm: "33px", // Define font size for small screens and larger
                    },
                    marginBottom: "40px",
                    fontWeight: "700",
                  }}
                >
                  Other product
                </Typography>
              </Stack>
            </Stack>
            <Grid container spacing={2} sx={{ margin: "0px -18px !important" }}>
              {otherProduct.map((item, index) => (
                <Grid item key={index} xs={12} sm={6} md={4}>
                  <a
                    href={`http://localhost:3000/product/${item.typeName
                      .split(" ")
                      .join("")}`}
                    style={{ textDecoration: "none" }}
                  >
                    <Card sx={{ height: 550 }}>
                      <CardActionArea>
                        <CardMedia
                          component="img"
                          image={`https://localhost:7064/InsuranceType/${item.typeId}`}
                          alt="green iguana"
                          height="240"
                        />
                        <Stack
                          direction={{ xs: "column", sm: "row" }}
                          spacing={2}
                          sx={{ padding: "16px 0px 0px 16px" }}
                        >
                          <Typography variant="h5">{item.typeName}</Typography>
                        </Stack>
                        <CardContent sx={{ paddingTop: "0px" }}>
                          <Typography gutterBottom variant="h5" component="div">
                            {item.title}
                          </Typography>
                          <Typography
                            variant="body2"
                            color="text.secondary"
                            minHeight={"240px"}
                          >
                            {item.description}
                          </Typography>
                        </CardContent>
                      </CardActionArea>
                    </Card>
                  </a>
                </Grid>
              ))}
            </Grid>
          </Stack>
        </Box>
        <BusinessLocation />
        <Footer />

        {/* snackbar */}
        <Snackbar
          open={alertCheck}
          autoHideDuration={6000}
          onClose={handleCloseAlert}
        >
          <Alert
            onClose={handleCloseAlert}
            severity="success"
            variant="filled"
            sx={{ width: "100%" }}
          >
            Add information success
          </Alert>
        </Snackbar>
      </div>
    </>
  );
}

export default LifeInsurance;
