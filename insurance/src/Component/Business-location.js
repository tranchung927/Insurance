import React from "react";
import Typography from "@mui/material/Typography";
import "bootstrap/dist/css/bootstrap.min.css";
import { Button, Stack } from "@mui/material";

import Divider from "@mui/material/Divider";

import LocalPhoneIcon from "@mui/icons-material/LocalPhone";
import PhoneAndroidIcon from "@mui/icons-material/PhoneAndroid";
import EmailIcon from "@mui/icons-material/Email";

function BusinessLocation() {
  return (
    <>
      <Stack
        direction={{ xs: "column", sm: "row" }}
        spacing={{ xs: 1, sm: 2, md: 4 }}
        sx={{
          margin: {
            xs: "6px 10px",
            sm: "120px 420px",
          },
          justifyContent: "space-between",
          alignItems: "center",
        }}
        className="location-header"
      >
        <Stack spacing={2}>
          <Typography
            sx={{
              fontSize: {
                xs: "24px", // Define font size for extra-small screens
                sm: "36px", // Define font size for small screens and larger
              },
              textAlign: { xs: "center" },
              fontWeight: "700",
            }}
          >
            Business location
          </Typography>

          <Typography variant="h6">Contact Info</Typography>
          <Stack
            direction="row"
            divider={<Divider orientation="vertical" flexItem />}
            spacing={2}
          >
            <Stack direction={"column"} spacing={2} alignItems={"center"}>
              <LocalPhoneIcon fontSize="large" />
              <a>1233456789</a>
            </Stack>
            <Stack direction={"column"} spacing={2} alignItems={"center"}>
              <PhoneAndroidIcon fontSize="large" />
              <a>1233456789</a>
            </Stack>
            <Stack direction={"column"} spacing={2} alignItems={"center"}>
              <EmailIcon fontSize="large" />
              <a>1233456789</a>
            </Stack>
          </Stack>
        </Stack>
        <Stack>
          <Button
            variant="outlined"
            className="btn-hea-info"
            sx={{
              margin: {
                xs: "12px",
                sm: "0",
              },
            }}
          >
            Find out more
          </Button>
        </Stack>
      </Stack>
    </>
  );
}

export default BusinessLocation;
