import { useState } from 'react'
import { Button, AppBar, IconButton, Drawer } from "@mui/material";
import Box from "@mui/material/Box";
import Tab from "@mui/material/Tab";
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

const drawerWidth = 240;

const products = [
    {
        name: "Live Insurance",
        id: "live-insurance",
        description:
            "Protects you and your vehicle in case of accidents or losses.",
        coverage: "Liability insurance, loss and damage insurance.",
        image_url: '/images/cards/glass-house.png',
    },
    {
        name: "Home Insurance",
        id: "home-insurance",
        description: "Protects your home from risks and damages.",
        coverage: "Fire insurance, loss and other damages coverage.",
        image_url: '/images/cards/glass-house.png',
    },
    {
        name: "Health Insurance",
        id: "health-insurance",
        description: "Safeguards your health and covers medical expenses.",
        coverage:
            "Healthcare coverage, surgery insurance, and other medical services.",
        image_url: '/images/cards/glass-house.png',
    },
    {
        name: "Social Insurance",
        id: "social-insurance",
        description: "Protects workers and families in challenging situations.",
        coverage:
            "Unemployment insurance, maternity insurance, and other social benefits.",
        image_url: '/images/cards/glass-house.png',
    },
];

const pages = [
    { title: "Introduce" },
    {
        title: "Product",
    },
    { title: "Service", children: ["Suport ", "Other"] },
    { title: "News" },
    { title: "Contact" },
];

const LayoutAppBar = props => {
    // ** Props
    const { window } = props;
    const [pageValue, setPageValue] = useState('1')
    const handlePageChange = (event, newValue) => {
        if (newValue !== pageValue) {
            setPageValue(newValue)
        }
    }

    const [anchorEl, setAnchorEl] = useState(null);
    const [anchorElService, setAnchorElService] = useState(null);
    const [openChilProduct, setOpenChilProduct] = useState(false);
    const [openChilService, setOpenChilService] = useState(false);

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
    // const navigate = useNavigate();
    const handleContact = () => {
        // navigate("/Contact");

    };
    const [mobileOpen, setMobileOpen] = useState(false);
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
                        <ListItemText primary={pages[0].pages} />
                    </ListItemButton>
                </ListItem>

                <ListItem disablePadding>
                    <ListItemButton
                        sx={{ textAlign: "center" }}
                        onClick={() => {
                            setOpenChilProduct(!openChilProduct);
                        }}
                    >
                        <ListItemText primary={pages[1].pages} />
                        {openChilProduct ? <ExpandLess /> : <ExpandMore />}
                    </ListItemButton>
                </ListItem>
                <Collapse in={openChilProduct} timeout="auto" unmountOnExit>
                    <List component="div" disablePadding>
                        {products.map((product, index) => (
                            <Link
                                to={`http://localhost:3000/product/${product.id}`}
                                key={index}
                                style={{ textDecoration: "none", color: "inherit" }}
                            >
                                <ListItemButton sx={{ pl: 4, textAlign: "center" }}>
                                    <ListItemText primary={product.name} />
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
                        <ListItemText primary={pages[2].pages} />
                        {openChilService ? <ExpandLess /> : <ExpandMore />}
                    </ListItemButton>
                </ListItem>

                <Collapse in={openChilService} timeout="auto" unmountOnExit>
                    <List component="div" disablePadding>
                        {pages[2].children.map((service, index) => (
                            <Link
                                to={`/${service}`}
                                key={index}
                                style={{ textDecoration: "none", color: "inherit" }}
                            >
                                <ListItemButton sx={{ pl: 4, textAlign: "center" }}>
                                    <ListItemText primary={service} />
                                </ListItemButton>
                            </Link>
                        ))}
                    </List>
                </Collapse>

                <ListItem disablePadding>
                    <ListItemButton sx={{ textAlign: "center" }}>
                        <ListItemText primary={pages[3].title} />
                    </ListItemButton>
                </ListItem>
                <ListItem sx={{ justifyContent: 'center' }} disablePadding>
                    <Link
                        to={`http://localhost:3000/Contact`}
                        style={{ textDecoration: "none", color: "inherit" }}
                    >
                        <ListItemButton sx={{ textAlign: "center", justifyContent: "center" }} onClick={offDrawerToggle}>
                            <ListItemText primary={pages[4].title} />
                        </ListItemButton>
                    </Link>
                </ListItem>
            </List>
        </Box>
    );
    const container = window !== undefined ? () => window().document.body : undefined;
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
                                    setValue("1");
                                }}
                            >
                                Logo
                            </Link>
                        </Typography>
                        <Box
                            sx={{ display: { xs: "none", sm: "flex" }, alignItems: "center" }}
                        >
                            <TabContext value={pageValue}>
                                <Box sx={{ borderBottom: 1, borderColor: "divider" }}>
                                    <TabList
                                        onChange={handlePageChange}
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
                                            label={pages[0].title}
                                            value="1"
                                            className="tap-btn"
                                        />

                                        <Tab
                                            label={
                                                <Box sx={{ display: "flex", alignItems: "center" }}>
                                                    {pages[1].title}

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
                                                    {pages[2].title}

                                                    <ExpandMore />
                                                </Box>
                                            }
                                            value="3"
                                            className="tap-btn"
                                            onClick={handleClickService}
                                        />
                                        <Tab
                                            label={pages[3].title}
                                            value="4"
                                            className="tap-btn"
                                        />
                                        <Tab
                                            label={pages[4].title}
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
                                {products.map((product, index) => {
                                    const productLink = `/${"product/" + product.id}`;

                                    return (
                                        <MenuItem key={index} onClick={handleClose}>
                                            <Link
                                                to={productLink}
                                                style={{ textDecoration: "none", color: "#000" }}
                                            >
                                                {product.name}
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
                                {pages[2].children.map((item, index) => (
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
                    container= {container}
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

export default LayoutAppBar;