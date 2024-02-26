import React from "react";

import "bootstrap/dist/css/bootstrap.min.css";
import { Button, AppBar, IconButton, Drawer, Stack } from "@mui/material";
import PropTypes from "prop-types";
import Box from "@mui/material/Box";
import Tab from "@mui/material/Tab";
import "../App.css";
import Menu from "@mui/material/Menu";
import MenuItem from "@mui/material/MenuItem";
import TabContext from "@mui/lab/TabContext";
import TabList from "@mui/lab/TabList";

import Typography from "@mui/material/Typography";

import MenuIcon from "@mui/icons-material/Menu";
import List from "@mui/material/List";
import ListItem from "@mui/material/ListItem";
import ListItemButton from "@mui/material/ListItemButton";
import ListItemText from "@mui/material/ListItemText";
import Toolbar from "@mui/material/Toolbar";
import Divider from "@mui/material/Divider";

import ExpandLess from "@mui/icons-material/ExpandLess";
import ExpandMore from "@mui/icons-material/ExpandMore";

import Collapse from "@mui/material/Collapse";

import { Link } from "react-router-dom";
import { useContext, useEffect } from "react";
import { DataContext } from "../Context/data-context";

import Contact from "../Page/Contact";
import { useNavigate } from "react-router-dom";

const drawerWidth = 240;
function Header(props) {
  const { window } = props;
  
  const [anchorEl, setAnchorEl] = React.useState(null);
  const [anchorElService, setAnchorElService] = React.useState(null);
  const [openChilProduct, setOpenChilProduct] = React.useState(false);
  const [openChilService, setOpenChilService] = React.useState(false);
  const { insuranceTypes, navItems,valueNav,setValueNav } =
    useContext(DataContext);

  const handleChange = (event, newValue) => {
    if (newValue !== valueNav) {
      setValueNav(newValue);
    }
  };

  console.log(valueNav);
  
  const handleClickProduct = (event) => {
    setAnchorEl(event.currentTarget);
  };
  const handleClickService = (event) => {
    setAnchorElService(event.currentTarget);
  };
  const handleClose = () => {
    setAnchorEl(null);
  };
  const handleCloseService = () => {
    setAnchorElService(null);
  };
  const navigate = useNavigate();
  const handleContact = () => {
    navigate("/Contact");
   
  };


  const [mobileOpen, setMobileOpen] = React.useState(false);

  const handleDrawerToggle = () => {
    setMobileOpen(true);
  };
  const offDrawerToggle = (e) => {
    e.stopPropagation();
    setMobileOpen(!mobileOpen);
  };

  const drawer = (
    <Box onClick={handleDrawerToggle} sx={{ textAlign: "center" }}>
      <div onClick={offDrawerToggle}>
        <Typography variant="h6" sx={{ my: 2 }}>
          MUI
        </Typography>
      </div>
      <Divider />
      <List>
        <ListItem disablePadding>
          <ListItemButton sx={{ textAlign: "center" }}>
            <ListItemText primary={navItems[0].label} />
          </ListItemButton>
        </ListItem>

        <ListItem disablePadding>
          <ListItemButton
            sx={{ textAlign: "center" }}
            onClick={() => {
              setOpenChilProduct(!openChilProduct);
            }}
          >
            <ListItemText primary={navItems[1].label} />
            {openChilProduct ? <ExpandLess /> : <ExpandMore />}
          </ListItemButton>
        </ListItem>
        <Collapse in={openChilProduct} timeout="auto" unmountOnExit>
          <List component="div" disablePadding>
            {insuranceTypes.map((chil, index) => (
              <Link
                to={`http://localhost:3000/product/${chil.typeName
                  .split(" ")
                  .join("")}`}
                key={index}
                style={{ textDecoration: "none", color: "inherit" }}
              >
                <ListItemButton sx={{ pl: 4, textAlign: "center" }}>
                  <ListItemText primary={chil.typeName} />
                </ListItemButton>
              </Link>
            ))}
          </List>
        </Collapse>

        <ListItem disablePadding>
          <ListItemButton
            sx={{ textAlign: "center" }}
            onClick={() => {
              setOpenChilService(!openChilService);
            }}
          >
            <ListItemText primary={navItems[2].label} />
            {openChilService ? <ExpandLess /> : <ExpandMore />}
          </ListItemButton>
        </ListItem>

        <Collapse in={openChilService} timeout="auto" unmountOnExit>
          <List component="div" disablePadding>
            {navItems[2].children.map((chil, index) => (
              <Link
                to={`/${chil}`}
                key={index}
                style={{ textDecoration: "none", color: "inherit" }}
              >
                <ListItemButton sx={{ pl: 4, textAlign: "center" }}>
                  <ListItemText primary={chil} />
                </ListItemButton>
              </Link>
            ))}
          </List>
        </Collapse>

        <ListItem disablePadding>
          <ListItemButton sx={{ textAlign: "center" }}>
            <ListItemText primary={navItems[3].label} />
          </ListItemButton>
        </ListItem>
        <ListItem sx={{justifyContent:'center'}}  disablePadding>
        <Link
          to={`http://localhost:3000/Contact`}
          style={{ textDecoration: "none", color: "inherit" }}
        >      
            <ListItemButton sx={{ textAlign: "center" ,justifyContent:"center"}} onClick={offDrawerToggle}>
              <ListItemText primary={navItems[4].label} />
            </ListItemButton>
        </Link>
          </ListItem>
      </List>
    </Box>
  );

  const container =
    window !== undefined ? () => window().document.body : undefined;
  return (
    <>
      <AppBar component="nav" sx={{ backgroundColor: "white" }}>
        <Toolbar
          sx={{
            margin: {
              xs: "0 10px",
              sm: "0 420px",
            },
            justifyContent: "space-between",
          }}
        >
          <IconButton
            color="inherit"
            aria-label="open drawer"
            edge="start"
            onClick={handleDrawerToggle}
            sx={{ mr: 2, display: { sm: "none" }, backgroundColor: "#ccc" }}
          >
            <MenuIcon />
          </IconButton>
          <div style={{ display: "flex", alignItems: "center" }}>
            <Typography
              variant="h6"
              component="div"
              sx={{ display: { xs: "none", sm: "block" }, color: "#000" }}
            >
              <Link
                to="/"
                style={{ textDecoration: "none", color: "#000" }}
                onClick={() => {
                  setValueNav("1");
                }}
              >
                Logo
              </Link>
            </Typography>
            <Box
              sx={{ display: { xs: "none", sm: "flex" }, alignItems: "center" }}
            >
              <TabContext value={valueNav}>
                <Box sx={{ borderBottom: 1, borderColor: "divider" }}>
                  <TabList
                    onChange={handleChange}
                    aria-label="lab API tabs example"
                    TabIndicatorProps={{
                      style: {
                        backgroundColor: "green",
                        color: "green",
                      },
                    }}
                    sx={{
                      "& .Mui-selected": {
                        color: "green !important",
                      },
                    }}
                  >
                    <Tab
                      label={navItems[0].label}
                      value="1"
                      className="tap-btn"
                    />

                    <Tab
                      label={
                        <Box sx={{ display: "flex", alignItems: "center" }}>
                          {navItems[1].label}

                          <ExpandMore />
                        </Box>
                      }
                      value="2"
                      className="tap-btn"
                      onClick={handleClickProduct}
                    />
                    <Tab
                      label={
                        <Box sx={{ display: "flex", alignItems: "center" }}>
                          {navItems[2].label}

                          <ExpandMore />
                        </Box>
                      }
                      value="3"
                      className="tap-btn"
                      onClick={handleClickService}
                    />
                    <Tab
                      label={navItems[3].label}
                      value="4"
                      className="tap-btn"
                    />
                    <Tab
                      label={navItems[4].label}
                      value="5"
                      className="tap-btn"
                      // href="/Contact"
                      onClick={handleContact}
                    />
                  </TabList>
                </Box>
              </TabContext>
              <Menu
                id="basic-menu"
                anchorEl={anchorEl}
                open={Boolean(anchorEl)}
                onClose={handleClose}
                MenuListProps={{
                  "aria-labelledby": "basic-button",
                }}
              >
                {insuranceTypes.map((item, index) => {
                  const productLink = `/${
                    "product/" + item.typeName.replace(/\s/g, "")
                  }`;

                  return (
                    <MenuItem key={index} onClick={handleClose}>
                      <Link
                        to={productLink}
                        style={{ textDecoration: "none", color: "#000" }}
                      >
                        {item.typeName}
                      </Link>
                    </MenuItem>
                  );
                })}
              </Menu>
              <Menu
                id="basic-menu-service"
                anchorEl={anchorElService}
                open={Boolean(anchorElService)}
                onClose={handleCloseService}
                MenuListProps={{
                  "aria-labelledby": "basic-button",
                }}
              >
                {navItems[2].children.map((item, index) => (
                  <MenuItem key={index} onClick={handleClose}>
                    <Link
                      to={`/${item}`}
                      style={{ textDecoration: "none", color: "#000" }}
                    >
                      {item}
                    </Link>
                  </MenuItem>
                ))}
              </Menu>
            </Box>
          </div>
          <Button variant="contained" className="btn-hea-info-green">
            Register now
          </Button>
        </Toolbar>
      </AppBar>
      <nav>
        <Drawer
          container={container}
          variant="temporary"
          open={mobileOpen}
          ModalProps={{
            keepMounted: true,
          }}
          sx={{
            display: { xs: "block", sm: "none" },
            "& .MuiDrawer-paper": {
              boxSizing: "border-box",
              width: drawerWidth,
            },
          }}
        >
          <div onClick={(e) => e.stopPropagation()}>{drawer}</div>
        </Drawer>
      </nav>
    </>
  );
}

export default Header;
