import { useLocation } from "react-router-dom";
import { useState, useContext, useEffect } from "react";
import {
  Typography,
  Stack,
  Button,
  Box,
  Grid,
  CardActionArea,
  Card,
  CardContent,
  CardMedia,
} from "@mui/material";
import Header from "../../../Component/header";
import { DataContext } from "../../../Context/data-context";
import ArrowForwardIcon from "@mui/icons-material/ArrowForward";
import ArrowForwardIosIcon from "@mui/icons-material/ArrowForwardIos";
import Dialog from "@mui/material/Dialog";
import DialogActions from "@mui/material/DialogActions";
import DialogContent from "@mui/material/DialogContent";
import DialogContentText from "@mui/material/DialogContentText";
import DialogTitle from "@mui/material/DialogTitle";
import CloseIcon from "@mui/icons-material/Close";

function BuyInsurance() {
  const [otherProduct, setOtherProduct] = useState([]);
  const location = useLocation();
  const { insuranceType } = location.state || {};
  const { insuranceTypes } = useContext(DataContext);
  const [open, setOpen] = useState(false);

  const handleClickOpen = () => {
    setOpen(true);
  };

  const handleClose = () => {
    setOpen(false);
  };

  console.log(insuranceType);
  useEffect(() => {
    if (insuranceTypes && Object.keys(insuranceType).length > 0) {
      const data = insuranceTypes.filter(
        (item) => item.typeId !== insuranceType.typeId
      );
      setOtherProduct(data);
    }
  }, [insuranceTypes, insuranceType]);

  return (
    <>
      <Header />
      <Stack sx={{ marginTop: "70px" }} className="banner-online">
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

      {/* container */}

      <Stack
        direction={{ xs: "column", sm: "row" }}
        spacing={{ xs: 1, sm: 2, md: 3 }}
        sx={{
          margin: {
            xs: "20px 10px",
            sm: "40px 420px",
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
                  sm: "30px", // Define font size for small screens and larger
                },
                textAlign: "center",
                fontWeight: "700",

                color: "#518853",
              }}
            >
              ONLINE INSURANCE WITH US
            </Typography>
          </div>
        </Stack>
      </Stack>

      {/*  */}
      <Stack>
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
          <Stack sx={{ flex: 2, display: "flex", flexDirection: "column" }}>
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
                  color: "#4D3219",
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
                  className="btn-hea-info-white"
                  variant="contained"
                >
                  Buy online
                </Button> */}
                <Button
                  onClick={handleClickOpen}
                  size="small"
                  className="btn-hea-info-white"
                  variant="contained"
                >
                  Buy online
                </Button>
                <Dialog
                  open={open}
                  onClose={handleClose}
                  aria-labelledby="alert-dialog-title"
                  aria-describedby="alert-dialog-description"
                >
                  <DialogTitle
                    id="alert-dialog-title"
                    sx={{
                      backgroundColor: "#58bd60",
                      display: "flex",
                      justifyContent: "space-between",
                      alignItems: "center",
                    }}
                  >
                    {"Members login"}
                    {/* <Button onClick={handleClose}>Disagree</Button> */}
                    <CloseIcon
                      onClick={handleClose}
                      sx={{ cursor: "pointer" }}
                    />
                  </DialogTitle>
                  <DialogContent sx={{paddingBottom:"0px",marginTop:"16px"}}>
                    <DialogContentText id="alert-dialog-description">
                      You must log in before making this transaction.
                    </DialogContentText>
                  </DialogContent>
                  <hr />
                  <DialogActions sx={{justifyContent:"center"}}>
                  <Button onClick={handleClose} sx={{backgroundColor:"#ffc206",color:"#000" ,'&:hover': {
                    backgroundColor: "#ffeabf", // Màu nhạt hơn khi hover
                },marginBottom:"16px"}}>Log in now</Button>
                  </DialogActions>
                </Dialog>
              </Stack>
            </div>
          </Stack>
        </Stack>
      </Stack>

      {/* sp khác */}

      <Box sx={{ backgroundColor: "#58bd60" }}>
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
                  href={`http://localhost:3000/product/${item.typeName}`}
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
                          minHeight={"200px"}
                        >
                          {item.description}
                        </Typography>
                        <Stack alignItems={"center"}>
                          <Button
                            size="small"
                            className="btn-hea-info-green"
                            variant="contained"
                            sx={{
                              maxWidth: "160px",
                              padding: "8px 16px !important;",
                            }}
                          >
                            Find out more
                          </Button>
                        </Stack>
                      </CardContent>
                    </CardActionArea>
                  </Card>
                </a>
              </Grid>
            ))}
          </Grid>
          <Stack alignItems={"center"}>
            <Button
              variant="contained"
              className="btn-hea-info-white"
              endIcon={<ArrowForwardIcon sx={{ fontSize: 60 }} />}
              href="/insurance-online/Register-for-consultation"
            >
              <Typography fontWeight={"600"}>
                You need further advice
              </Typography>
            </Button>
          </Stack>
        </Stack>
      </Box>

      {/*  */}
      <Stack>
        <Stack alignItems={"center"}>
          <Typography
            sx={{
              fontSize: {
                xs: "24px", // Define font size for extra-small screens
                sm: "28px", // Define font size for small screens and larger
              },
              marginBottom: "30px",
              fontWeight: "600",
              color: "#518853",
            }}
          >
            BUY INSURANCE IN JUST 4 SIMPLE STEPS
          </Typography>
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
            alignItems: "center",
          }}
        >
          <Stack>
            <Box
              sx={{
                width: "100%",
                textAlign: "center",
              }}
            >
              <img
                src={require("../../../Img/ol_pic1.png")}
                alt="Mô tả hình ảnh"
                width="40%" // chiều rộng ảnh
                height="30%" // chiều cao ảnh
              />
              <Stack marginTop={"20px"}>
                <Typography variant="h5">Select product</Typography>
                <Typography variant="body2">
                  depending on needs and financial situation
                </Typography>
              </Stack>
            </Box>
          </Stack>
          <Stack alignItems={"baseline"} direction={"row"}>
            <ArrowForwardIosIcon
              sx={{ color: "#5db747", fontSize: "40px", fontWeight: "600" }}
            />
            <Box
              sx={{
                width: "100%",
                textAlign: "center",
              }}
            >
              <img
                src={require("../../../Img/ol_pic2.png")}
                alt="Mô tả hình ảnh"
                width="40%" // chiều rộng ảnh
                height="30%" // chiều cao ảnh
              />
              <Stack marginTop={"20px"}>
                <Typography variant="h5">Log in</Typography>
                <Typography variant="body2">
                  (register if you don't have an account)
                </Typography>
              </Stack>
            </Box>
          </Stack>
          <Stack alignItems={"baseline"} direction={"row"}>
            <ArrowForwardIosIcon
              sx={{ color: "#5db747", fontSize: "40px", fontWeight: "600" }}
            />
            <Box
              sx={{
                width: "100%",
                textAlign: "center",
              }}
            >
              <img
                src={require("../../../Img/ol_pic3.png")}
                alt="Mô tả hình ảnh"
                width="40%" // chiều rộng ảnh
                height="30%" // chiều cao ảnh
              />
              <Stack marginTop={"20px"}>
                <Typography variant="h5">Fill in information</Typography>
                <Typography variant="body2">
                  Personal and beneficiary information
                </Typography>
              </Stack>
            </Box>
          </Stack>
          <Stack alignItems={"baseline"} direction={"row"}>
            <ArrowForwardIosIcon
              sx={{ color: "#5db747", fontSize: "40px", fontWeight: "600" }}
            />
            <Box
              sx={{
                width: "100%",
                textAlign: "center",
              }}
            >
              <img
                src={require("../../../Img/ol_pic4.png")}
                alt="Mô tả hình ảnh"
                width="40%" // chiều rộng ảnh
                height="30%" // chiều cao ảnh
              />
              <Stack marginTop={"20px"}>
                <Typography variant="h5">Payment</Typography>
                <Typography variant="body2">
                  and receive electronic contracts from Insurance
                </Typography>
              </Stack>
            </Box>
          </Stack>
        </Stack>
      </Stack>

      <Box sx={{ backgroundColor: "#58bd60" }}>
        <Stack
          spacing={{ xs: 1, sm: 2, md: 4 }}
          sx={{
            margin: {
              xs: "12px 10px",
              sm: "60px 420px 0px",
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
                variant="body2"
                color={"#fff"}
                fontWeight={"600"}
                fontSize={"18px"}
              >
                Copyright © 2024 Insurance. All right reserved.
              </Typography>
            </Stack>
          </Stack>
        </Stack>
      </Box>
    </>
  );
}

export default BuyInsurance;
