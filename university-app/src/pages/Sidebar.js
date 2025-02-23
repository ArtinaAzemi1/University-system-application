/*import { useState } from "react";
import { Sidebar, Menu, MenuItem } from "react-pro-sidebar";
import { Box, IconButton, Typography, useTheme } from "@mui/material";
import { Link } from "react-router-dom";
//import 'react-pro-sidebar/dist/index.css';
import HomeOutlinedIcon from "@mui/icons-material/HomeOutlined";
import PeopleOutlinedIcon from "@mui/icons-material/PeopleOutlined";
import CalendarTodayOutlinedIcon from "@mui/icons-material/CalendarTodayOutlined";
import ReceiptOutlinedIcon from "@mui/icons-material/ReceiptOutlined";
import PersonOutlinedIcon from "@mui/icons-material/PersonOutlined";
import MenuOutlinedIcon from "@mui/icons-material/MenuOutlined";
//import profileImage from '../../picture/profile2.png';

const Item = ({ title, to, icon, selected, setSelected }) => {
  return (
    <MenuItem
      active={selected === title}
      style={{
        color: "#ffffff",
      }}
      onClick={() => setSelected(title)}
      icon={icon}
    >
      <Typography>{title}</Typography>
      <Link to={to} />
    </MenuItem>
  );
};

const SidebarContent = () => {
  const [isCollapsed, setIsCollapsed] = useState(false);
  const [selected, setSelected] = useState("Dashboard");

  return (
    <Box
      sx={{
        "& .pro-sidebar-inner": {
          background: `${"#primary"} !important`,
        },
        "& .pro-icon-wrapper": {
          backgroundColor: "transparent !important",
        },
        "& .pro-inner-item": {
          padding: "5px 35px 5px 20px !important",
        },
        "& .pro-inner-item:hover": {
          color: "#868dfb !important",
        },
        "& .pro-menu-item.active": {
          color: "#6870fa !important",
        },
      }}
    >
      <Sidebar collapsed={isCollapsed}>
        <Menu iconShape="square">
          <MenuItem
            onClick={() => setIsCollapsed(!isCollapsed)}
            icon={isCollapsed ? <MenuOutlinedIcon /> : undefined}
            style={{
              margin: "10px 0 20px 0",
              color: "#ffffff",
            }}
          >
            {!isCollapsed && (
              <Box
                display="flex"
                justifyContent="space-between"
                alignItems="center"
                ml="15px"
              >
                <Typography variant="h3" color="#ffffff">
                  ADMIN
                </Typography>
                <IconButton onClick={() => setIsCollapsed(!isCollapsed)}>
                  <MenuOutlinedIcon />
                </IconButton>
              </Box>
            )}
          </MenuItem>

          {!isCollapsed && (
            <Box mb="25px">
              <Box display="flex" justifyContent="center" alignItems="center">
                <img
                  alt="profile-user"
                  width="100px"
                  height="100px"

                  style={{ cursor: "pointer", borderRadius: "50%" }}
                />
              </Box>
              <Box textAlign="center">
                <Typography
                  variant="h2"
                  color={"#ffffff"}
                  fontWeight="bold"
                  sx={{ m: "10px 0 0 0" }}
                >
                  Artinë Azemi
                </Typography>
                <Typography variant="h5" color={"#ffffff"}>
                  Collaborative Learning
                </Typography>
              </Box>
            </Box>
          )}

          <Box paddingLeft={isCollapsed ? undefined : "10%"}>
            <Item
              title="Dashboard"
              to="/"
              icon={<HomeOutlinedIcon />}
              selected={selected}
              setSelected={setSelected}
            />
            <Item
              title="Courses"
              name='courses'
              to="/courses"  
              icon={<PeopleOutlinedIcon />}
              selected={selected}
              setSelected={setSelected}
            />
            <Item
              title="Students"
              to="/students"
              icon={<PeopleOutlinedIcon />}
              selected={selected}
              setSelected={setSelected}
            />
          </Box>
        </Menu>
      </Sidebar>
    </Box>
  );
};

export default SidebarContent;*/

import React from "react";
import { useState } from "react";
import { Button, Nav } from "react-bootstrap";
import { Link } from "react-router-dom";
import { FaHome, FaUsers, FaGraduationCap, FaBars } from "react-icons/fa";
import "../styles/Dashboard.css";
import Courses from "../components/Courses";

const SidebarContent = () => {
  const [open, setOpen] = useState(true);

  return (
    <div className="d-flex">
      <Button
        variant="primary"
        className="toggle-btn"
        onClick={() => setOpen(!open)}
      >
        <FaBars />
      </Button>


      <div className={`sidebar ${open ? "open" : "closed"}`}>
      <a
          href=""
          className="simple-text logo-normal"
        >
          Admin
        </a>
        <Nav className="flex-column">
          <Nav.Link as={Link} to="/dashboard" className="nav-item">
            <FaHome className="icon" /> {open && "Dashboard"}
          </Nav.Link>
          <Nav.Link as={Link} to="/courses" className="nav-item">
            <FaUsers className="icon" /> {open && "Course"}
          </Nav.Link>
          <Nav.Link as={Link} to="/students" className="nav-item">
            <FaGraduationCap className="icon" /> {open && "Students"}
          </Nav.Link>
        </Nav>
      </div>
      </div>
  );
};

export default SidebarContent;



/*import React from "react";
import { Link } from "react-router-dom";
import "../styles/Dashboard.css";
import Course from "../components/Course";

const Sidebar = () => {
  return (
    <div className="sidebar">
      <h2>University Panel</h2>
      <ul>
        <li><Link to="/dashboard">Dashboard</Link></li>
        <li><Link to="/students">Students</Link></li>
        <li><Link to="/professors">Professors</Link></li>
        <li><Link to="/courses">Courses</Link></li>
        <li><button className="logout">Logout</button></li>
      </ul>
    </div>
  );
};

export default Sidebar;*/