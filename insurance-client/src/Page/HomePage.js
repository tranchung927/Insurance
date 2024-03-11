import React from "react";
import { Carousel } from "react-bootstrap";
import "bootstrap/dist/css/bootstrap.min.css";
import {
  Grid,
  Button,
  CardActionArea,
  CardActions,
  Stack,
} from "@mui/material";
import Box from "@mui/material/Box";
import "@Style";
import CheckCircleOutlineIcon from "@mui/icons-material/CheckCircleOutline";
import ArrowForwardIcon from "@mui/icons-material/ArrowForward";
import Card from "@mui/material/Card";
import CardContent from "@mui/material/CardContent";
import CardMedia from "@mui/material/CardMedia";
import Typography from "@mui/material/Typography";
import { useContext } from "react";
import { DataContext } from "../Context/data-context";
import Header from "@HeaderLayout";
import Footer from "@FooterLayout";
import ImagePath from "@image-path";
import BusinessLocation from "../Component/Business-location";

const HomePage = () => {
  const { peopleArray, products, news } =
    useContext(DataContext);

  return (
    <>
      <Header />
      {/* Banner */}
      <Carousel
        id="carouselExampleCaptions"
        interval={3000}
        style={{ marginTop: "57px" }}
      >
        <Carousel.Item>
          <img src={require("../Img/baner.jpeg")} className="d-block w-100 " />
          <Carousel.Caption>
            <h5>First slide label</h5>
            <p>Some representative placeholder content for the first slide.</p>
          </Carousel.Caption>
        </Carousel.Item>
        <Carousel.Item>
          <img
            src={require("../Img/baner.jpeg")}
            className="d-block w-100"
            alt="..."
          />
          <Carousel.Caption>
            <h5>Second slide label</h5>
            <p>Some representative placeholder content for the second slide.</p>
          </Carousel.Caption>
        </Carousel.Item>
        {/* Add additional Carousel.Items as needed */}
      </Carousel>

      {/* Add additional Carousel.Items as needed */}

      {/* About company */}
      <Stack
        direction={{ xs: "column", sm: "row" }}
        spacing={{ xs: 1, sm: 2, md: 4 }}
        sx={{
          margin: {
            xs: "6px 10px",
            sm: "40px 420px",
          },
        }}
        className="about-com "
      >
        <Stack>
          <div>
            <img
              src={require("../Img/about-img.jpeg")}
              style={{
                width: "100%", // Make the image responsive
                height: "auto", // Maintain aspect ratio
                display: "block",
              }}
              alt="About Us"
              className="d-block w-100 "
            />
          </div>
        </Stack>
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
            Insurance - Choose a protection solution just for you
          </Typography>
          <Typography
            sx={{
              fontSize: {
                xs: "18px", // Define font size for extra-small screens
                sm: "24px", // Define font size for small screens and larger
              },
              textAlign: "center",
              fontWeight: "600",
            }}
          >
            Always respect customers, aim for perfect service
          </Typography>
          <Box>
            <div style={{ marginBottom: "36px" }}></div>
            <div style={{ display: "flex", gap: "12px" }}>
              <CheckCircleOutlineIcon fontSize="large" color="success" />
              <p>
                We believe we will duplicate the success of the two-pronged dual
                impact strategy "Insurance" from Us Insurance Financial Group to
                become the strongest and most reliable financial institution in
                Vietnam.
              </p>
            </div>
            <div style={{ display: "flex", gap: "12px" }}>
              <CheckCircleOutlineIcon fontSize="large" color="success" />
              <p>
                Providing unique products to gradually create a unique identity
                for Insurance in the Vietnamese market.
              </p>
            </div>
            <div style={{ display: "flex", gap: "12px" }}>
              <CheckCircleOutlineIcon fontSize="large" color="success" />
              <p>Focus on building a team of excellent consultants</p>
            </div>
            <div style={{ display: "flex", gap: "12px" }}>
              <CheckCircleOutlineIcon fontSize="large" color="success" />
              <p className="loyalCustomer">
                Loyal customers:{" "}
                <strong
                  className="registeredMemberCount"
                  style={{ color: "#00cee5" }}
                >
                  {peopleArray.length}
                </strong>
              </p>
            </div>
            {/* <div style={{ marginTop: "12px", marginLeft: "40px" }}>
              <Button
                variant="contained"
                color="success"
                endIcon={<ArrowForwardIcon />}
                className="btn-padding"
              >
                Detail now
              </Button>
            </div> */}
          </Box>
        </Stack>
      </Stack>

      {/* All service */}
      <Stack
        spacing={{ xs: 1, sm: 2, md: 4 }}
        sx={{
          margin: {
            xs: "6px 10px",
            sm: "60px 420px",
          },
        }}
        className="offer-bg"
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
            What Are We Offering
          </Typography>
        </Stack>
        
        <Grid container spacing={2} sx={{ margin: "0px -18px !important" }}>
          {products.map((product, index) => (
            <Grid item key={index} xs={12} sm={6} md={3}>
              <a
                href={`http://localhost:3000/product/${product.code}`}
                style={{ textDecoration: "none" }}
              >
                <Card sx={{ height: "660px" }}>
                  <CardActionArea>
                    <CardMedia
                      component="img"
                      image={ImagePath.getImageURL(`${product.code}.jpeg`)}
                      alt="green iguana"
                      height="240px"
                    />
                    <Stack
                      direction={{ xs: "column", sm: "row" }}
                      spacing={2}
                      sx={{ padding: "16px 0px 0px 16px" }}
                    >
                      <Typography variant="h5">{product.name}</Typography>
                    </Stack>
                    <CardContent sx={{ paddingTop: "0px" }}>
                      <Typography
                        variant="body2"
                        color="#000000"
                        minHeight={"260px"}
                      >
                        "sakdhlaskdlskahdslkdlskadsladh"
                      </Typography>
                    </CardContent>
                    
                  </CardActionArea>
                  <CardActions >
                  <Button
                    variant="contained"
                    color="success"
                    endIcon={<ArrowForwardIcon />}
                    textAlign="center"
                  >
                    Detail now
                  </Button>
                  </CardActions>
                </Card>
              </a>
            </Grid>
          ))}
        </Grid>
      </Stack>
      {/* news */}
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
            justifyContent={"space-between"}
          >
            <Stack>
              <Typography
                sx={{
                  fontSize: {
                    xs: "24px", // Define font size for extra-small screens
                    sm: "33px", // Define font size for small screens and larger
                  },

                  fontWeight: "700",
                }}
              >
                Latest news
              </Typography>

              <Typography
                sx={{
                  fontSize: {
                    xs: "18px", // Define font size for extra-small screens
                    sm: "24px", // Define font size for small screens and larger
                  },
                  fontWeight: "500",
                }}
              >
                Always respect customers, aim for perfect service
              </Typography>
            </Stack>
            <Stack>
              <Button
                variant="contained"
                color="success"
                className="btn-padding"
                endIcon={<ArrowForwardIcon />}
              >
                See all
              </Button>
            </Stack>
          </Stack>
          <Grid container spacing={2} sx={{ margin: "0px -18px !important" }}>
            {news.map((item, index) => (
              <Grid item key={index} xs={12} sm={6} md={4}>
                <Card>
                  <CardActionArea>
                    <CardMedia
                      component="img"
                      height="140"
                      image={item.urlImg}
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
                      <li>{item.date}</li>
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
      {/* LIên hệ */}
      <BusinessLocation />
      {/* footer */}
      <Footer />
    </>
  );
};

export default HomePage;
