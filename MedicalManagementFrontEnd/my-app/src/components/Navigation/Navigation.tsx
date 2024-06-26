import React from "react";

import AppBar from "@mui/material/AppBar";
import Box from "@mui/material/Box";
import Toolbar from "@mui/material/Toolbar";
import IconButton from "@mui/material/IconButton";
import Typography from "@mui/material/Typography";
import Menu from "@mui/material/Menu";
import MenuIcon from "@mui/icons-material/Menu";
import Container from "@mui/material/Container";
import Avatar from "@mui/material/Avatar";
import Button from "@mui/material/Button";
import Tooltip from "@mui/material/Tooltip";
import MenuItem from "@mui/material/MenuItem";
import LocalHospitalIcon from "@mui/icons-material/LocalHospital";
import { useNavigate } from "react-router-dom";

const pages = ["Home", "Doctor Dashboard", "Patient Dashboard"];
const settings = ["Profile", "Account", "Logout"];

interface IProps {
  children: React.ReactNode;
}

const Navigation = ({ children }: IProps) => {
  const [anchorElNav, setAnchorElNav] = React.useState<null | HTMLElement>(
    null
  );
  const [anchorElUser, setAnchorElUser] = React.useState<null | HTMLElement>(
    null
  );

  const navigate = useNavigate();

  const handleOpenNavMenu = (event: React.MouseEvent<HTMLElement>) => {
    setAnchorElNav(event.currentTarget);
  };
  const handleOpenUserMenu = (event: React.MouseEvent<HTMLElement>) => {
    setAnchorElUser(event.currentTarget);
  };

  const handleCloseNavMenu = () => {
    setAnchorElNav(null);
  };

  const handleCloseUserMenu = () => {
    setAnchorElUser(null);
  };

  return (
    <>
      <AppBar position="static" style={{ padding: 0 }}>
        <Container maxWidth="xl">
          <Toolbar disableGutters>
            <LocalHospitalIcon
              sx={{ display: { xs: "none", md: "flex" }, mr: 2 }}
            />
            <Typography
              variant="h6"
              noWrap
              component="a"
              sx={{
                mr: 2,
                display: { xs: "none", md: "flex" },
                fontFamily: "monospace",
                fontWeight: 600,
                letterSpacing: ".3rem",
                color: "inherit",
                textDecoration: "none",
              }}
            >
              MedHub
            </Typography>

            <Box sx={{ flexGrow: 1, display: { xs: "flex", md: "none" } }}>
              <IconButton
                size="large"
                aria-label="account of current user"
                aria-controls="menu-appbar"
                aria-haspopup="true"
                onClick={handleOpenNavMenu}
                color="inherit"
              >
                <MenuIcon />
              </IconButton>
              <Menu
                id="menu-appbar"
                anchorEl={anchorElNav}
                anchorOrigin={{
                  vertical: "bottom",
                  horizontal: "left",
                }}
                keepMounted
                transformOrigin={{
                  vertical: "top",
                  horizontal: "left",
                }}
                open={Boolean(anchorElNav)}
                onClose={handleCloseNavMenu}
                sx={{
                  display: { xs: "block", md: "none" },
                }}
              >
                <MenuItem key={pages[0]} onClick={handleCloseNavMenu}>
                  <Typography textAlign="center">{pages[0]}</Typography>
                </MenuItem>
                <MenuItem key={pages[1]} onClick={handleCloseNavMenu}>
                  <Typography textAlign="center">{pages[1]}</Typography>
                </MenuItem>
                <MenuItem key={pages[2]} onClick={handleCloseNavMenu}>
                  <Typography textAlign="center">{pages[2]}</Typography>
                </MenuItem>
              </Menu>
            </Box>
            <Typography
              variant="h5"
              noWrap
              component="a"
              href="#app-bar-with-responsive-menu"
              sx={{
                mr: 2,
                display: { xs: "flex", md: "none" },
                flexGrow: 1,
                fontFamily: "monospace",
                fontWeight: 700,
                letterSpacing: ".3rem",
                color: "inherit",
                textDecoration: "none",
              }}
            />
            <Box sx={{ flexGrow: 1, display: { xs: "none", md: "flex" } }}>
              <Button
                key={pages[0]}
                onClick={() => {
                  handleCloseNavMenu();
                  navigate("/");
                }}
                sx={{ my: 2, color: "white", display: "block" }}
              >
                {pages[0]}
              </Button>
              <Button
                key={pages[1]}
                onClick={() => {
                  handleCloseNavMenu();
                  navigate("/doctor");
                }}
                sx={{ my: 2, color: "white", display: "block" }}
              >
                {pages[1]}
              </Button>
              <Button
                key={pages[2]}
                onClick={() => {
                  handleCloseNavMenu();
                  navigate("/patient");
                }}
                sx={{ my: 2, color: "white", display: "block" }}
              >
                {pages[2]}
              </Button>
            </Box>

            <Box sx={{ flexGrow: 0 }}>
              <Tooltip title="Open settings">
                <IconButton onClick={handleOpenUserMenu} sx={{ p: 0 }}>
                  <Avatar alt="Remy Sharp" src="/static/images/avatar/2.jpg" />
                </IconButton>
              </Tooltip>
              <Menu
                sx={{ mt: "45px" }}
                id="menu-appbar"
                anchorEl={anchorElUser}
                anchorOrigin={{
                  vertical: "top",
                  horizontal: "right",
                }}
                keepMounted
                transformOrigin={{
                  vertical: "top",
                  horizontal: "right",
                }}
                open={Boolean(anchorElUser)}
                onClose={handleCloseUserMenu}
              >
                {settings.map((setting) => (
                  <MenuItem key={setting} onClick={handleCloseUserMenu}>
                    <Typography textAlign="center">{setting}</Typography>
                  </MenuItem>
                ))}
              </Menu>
            </Box>
          </Toolbar>
        </Container>
      </AppBar>
      <Box>{children}</Box>
    </>
  );
  // <nav>
  //   <ul>
  //     <li><Link to="/">Home</Link></li>
  //     <li><Link to="/doctor">Doctor Dashboard</Link></li>
  //     <li><Link to="/patient">Patient Dashboard</Link></li>
  //     <li><Link to="/login">Login</Link></li>
  //   </ul>
  // </nav>
};

export default Navigation;
