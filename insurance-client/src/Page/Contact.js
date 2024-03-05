import SupportRegistration from "../Component/SupportRegistrationForm";
import Header from "../Component/header";
import Footer from "../Component/footer";
import { Stack, Typography, Autocomplete, TextField ,Snackbar,Alert} from "@mui/material";
import { useState, useContext, useEffect } from "react";
import { DataContext } from "../Context/data-context";
import axios from "axios";
import List from "@mui/material/List";
import ListItem from "@mui/material/ListItem";
import ListItemText from "@mui/material/ListItemText";

function Contact() {
  const [headquarters, setHeadquarters] = useState({});
  const [chooseProvince, setChooseProvince] = useState({});
  const [businessLocationOfProvince, setBusinessLocation0fProvince] = useState(
    []
  );
 

  const { businesslocation, provinces } = useContext(DataContext);
 

  // Get business address by province

  // gett all province
  useEffect(() => {
    axios
      .get("https://localhost:7064/BusinessLocation/Id?Id=1")
      .then((response) => {
        setHeadquarters(response.data);
      })
      .catch((error) => {
        console.error("Lỗi khi gọi API:", error);
      });
  }, []);

  const handleProvinces = (event, newValue) => {
    setChooseProvince(newValue);
    setBusinessLocation0fProvince([]);

    if (newValue && newValue.id) {
      // Filter and set the new business locations
      const filteredByProvince = businesslocation.filter(
        (x) => x.provinceId === newValue.id
      );
      setBusinessLocation0fProvince(filteredByProvince);
    }
  };

 

  return (
    <>
      <Header />
      <Stack marginTop={"150px"}>
        <Stack textAlign={"center"}>
          <Typography variant="h4" fontWeight={"700"}>
            We are always ready to assist
          </Typography>
          <Typography variant="body2">
            Please contact us if you would like to learn more about insurance
            products or have any questions
          </Typography>
          <Typography variant="body2">
            Support issues and processes for resolving insurance benefits.
          </Typography>
        </Stack>
      </Stack>
      <SupportRegistration />

      <Stack
        direction={{ xs: "column", sm: "row" }}
        spacing={{ xs: 1, sm: 2, md: 4 }}
        sx={{
          margin: {
            xs: "6px 10px",
            sm: "120px 520px",
          },
          justifyContent: "center",
          alignItems: "center",
        }}
        className="location-header"
      >
        <Stack spacing={3}>
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
            Contact for support and further advice
          </Typography>

          <Stack spacing={1}>
            <Stack spacing={2}>
              <Typography variant="h6" fontWeight={"700"}>
                Name :
              </Typography>
              <Typography>{headquarters.locationName}</Typography>
            </Stack>

            <Stack spacing={2}>
              <Typography variant="h6" fontWeight={"700"}>
                Phone :
              </Typography>
              <Typography>{headquarters.phone}</Typography>
            </Stack>
            <Stack spacing={2}>
              <Typography variant="h6" fontWeight={"700"}>
                Address :
              </Typography>
              <Typography>{headquarters.locationAddress}</Typography>
            </Stack>
          </Stack>
        </Stack>
      </Stack>
      {/* Địa điểm kinh doanh */}
      <Stack
        direction={{ xs: "column", sm: "row" }}
        spacing={{ xs: 1, sm: 2, md: 4 }}
        sx={{
          margin: {
            xs: "6px 10px",
            sm: "120px 420px",
          },
          justifyContent: "center",
          alignItems: "center",
        }}
      >
        <Stack spacing={3} width={"80%"}>
          <Typography
            sx={{
              fontSize: {
                xs: "24px",
                sm: "36px",
              },
              textAlign: { xs: "center" },
              fontWeight: "700",
            }}
          >
            Business Location
          </Typography>

          <Stack>
            <Autocomplete
              id="filter-demo"
              options={provinces}
              getOptionLabel={(option) => option.name}
              onChange={handleProvinces}
              renderInput={(params) => (
                <TextField {...params} label="Business Location" fullWidth /> // Set fullWidth here
              )}
            />
          </Stack>
          <Stack>
            <List
              sx={{ width: "100%",bgcolor: "background.paper" }}
            >
              {businessLocationOfProvince.map((item,index) => (
                <ListItem key={index}>
                  <Stack>
                    <Typography variant="h6" fontWeight={'700'}>{item.locationName}</Typography>
                    <ListItemText primary={item.locationAddress} secondary={item.phone} />
                  </Stack>
                </ListItem>
              ))}
            </List>
          </Stack>
        </Stack>
      </Stack>

      <Footer />
    </>
  );
}

export default Contact;
