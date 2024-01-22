import React from "react";
import { Carousel } from "react-bootstrap";
import "bootstrap/dist/css/bootstrap.min.css";
import {
  Grid,
 
  Stack,
} from "@mui/material";
import PropTypes from "prop-types";
import Box from "@mui/material/Box";
import Tab from "@mui/material/Tab";
import "../App.css";

import Typography from "@mui/material/Typography";

import Container from "@mui/material/Container";

import { Outlet, Link } from "react-router-dom";



function Footer() {
    return ( <>
      <footer className="footer-page">
        <Container>
          <Grid container spacing={3}>
            <Grid item xs={12} sm={4}>
              <Box className="info-footer" sx={{ marginBottom: "12px" }}>
                <Box sx={{ marginBottom: "24px" }}>
                  <a>Logo</a>
                </Box>
                <Stack className="list-item-info" spacing={1}>
                  <Typography>
                    <span>
                      <i className="icon-location"></i>
                    </span>
                    Tòa nhà The World Center, 46-48-50 Phạm Hồng Thái, Quận 1,
                    TP. HCM
                  </Typography>
                  <Typography>
                    <span>
                      <i className="icon-call"></i>
                    </span>
                    Trụ sở chính: <a> 028 7303 1879</a>
                  </Typography>
                  <Typography>
                    <span>
                      <i className="icon-call"></i>
                    </span>
                    Hotline: <a>1900 636 993</a>
                  </Typography>
                  <Typography>
                    <span>
                      <i className="icon-directStack"></i>
                    </span>
                    <a>028 - 6255 6399</a>
                  </Typography>
                  <Typography>
                    <span>
                      <i className="icon-sms"></i>
                    </span>
                    <a>hotline@Insurance.com.vn</a>
                  </Typography>
                </Stack>
              </Box>
              <Box className="social">
                <Stack
                  direction={{ xs: "column", sm: "row" }}
                  spacing={{ xs: 1, sm: 2, md: 4 }}
                >
                  <Stack>
                    <Link
                      target="_blank"
                      href="https://www.facebook.com/CathayLifeHeadOffice.VN"
                    >
                      <img
                        src={require("../Img/facebook.png")}
                        title="Face"
                        alt="face"
                        width={"20px"}
                      />
                    </Link>
                  </Stack>
                  <Stack>
                    <Link
                      target="_blank"
                      href="https://oa.zalo.me/2776425001153661568?src=media"
                    >
                      <img
                        src={require("../Img/7044033_zalo_icon.png")}
                        title="Zalo"
                        alt="zalo"
                        width={"20px"}
                      />
                    </Link>
                  </Stack>
                  <Stack>
                    <Link
                      target="_blank"
                      href="https://www.linkedin.com/company/cathay-life-vietnam"
                    >
                      <img
                        src={require("../Img/tiktok.png")}
                        title="LinkedIn"
                        alt="linkedIn"
                        width={"20px"}
                      />
                    </Link>
                  </Stack>
                </Stack>
              </Box>
            </Grid>
            {/* ... Các cột khác */}
            <Grid item xs={12} sm={4}>
              <Box className="info-footer" sx={{ marginBottom: "12px" }}>
                <Box sx={{ marginBottom: "24px" }}>
                  <Typography variant="h5">Introduce</Typography>
                </Box>
                <Stack className="list-item-info" spacing={1}>
                  <Typography>
                    <a>General Introduction</a>
                  </Typography>
                  <Typography>
                    <a>Development History</a>
                  </Typography>
                  <Typography>
                    <a>Vision</a>
                  </Typography>
                  <Typography>
                    <a>Leadership Team</a>
                  </Typography>
                  <Typography>
                    <a>Awards</a>
                  </Typography>
                </Stack>
              </Box>
            </Grid>
            <Grid item xs={12} sm={4}>
              <Box className="info-footer" sx={{ marginBottom: "12px" }}>
                <Box sx={{ marginBottom: "24px" }}>
                  <Typography variant="h5">Product</Typography>
                </Box>
                <Stack className="list-item-info" spacing={1}>
                  <a>Life Insurance</a>
                  <Typography>
                    <a> Medical Insurance</a>
                  </Typography>
                  <Typography>
                    <a>Life Insurance</a>
                  </Typography>
                  <Typography>
                    <a>Home Insurance</a>
                  </Typography>
                </Stack>
              </Box>
            </Grid>
          </Grid>
          <Grid
            container
            spacing={3}
            textAlign={"center"}
            sx={{ marginTop: "36px" }}
          >
            <Grid item xs={12}>
              <Box className="copyright">
                © 2023 Insurance Vietnam. All rights reserved.
              </Box>
            </Grid>
          </Grid>
        </Container>
      </footer>
      <Outlet />
    </> );
}

export default Footer;