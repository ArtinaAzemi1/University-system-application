/*import React, { useState } from "react";
import { ProSidebar, Menu, MenuItem, SidebarHeader, SidebarContent } from "react-pro-sidebar";
import "react-pro-sidebar/dist/css/styles.css";
import { Link } from "react-router-dom";
import { FaTachometerAlt, FaBook, FaSignOutAlt, FaBars } from "react-icons/fa";

const Sidebar = () => {
  const [collapsed, setCollapsed] = useState(false);

  return (
    <ProSidebar collapsed={collapsed}>
      <SidebarHeader>
        <div className="sidebar-header">
          <button className="toggle-btn" onClick={() => setCollapsed(!collapsed)}>
            <FaBars />
          </button>
          {!collapsed && <h3>My App</h3>}
        </div>
      </SidebarHeader>

      <SidebarContent>
        <Menu iconShape="square">
          <MenuItem icon={<FaTachometerAlt />}>
            Dashboard <Link to="/dashboard" />
          </MenuItem>
          <MenuItem icon={<FaBook />}>
            Courses <Link to="/courses" />
          </MenuItem>
        </Menu>
      </SidebarContent>

      <Menu iconShape="square">
        <MenuItem icon={<FaSignOutAlt />}>Logout</MenuItem>
      </Menu>
    </ProSidebar>
  );
};

export default Sidebar;*/

import { useState } from "react";
import { ProSidebarProvider, Sidebar, Menu, MenuItem, SubMenu } from "react-pro-sidebar";
import { Box, IconButton, Typography, useTheme } from "@mui/material";
import { Link } from "react-router-dom";
import "react-pro-sidebar/dist/pro-sidebar.css";
import { tokens } from "../../theme";
import { FaHome, FaUser, FaUsers, FaClipboardList, FaCalendarAlt, FaQuestionCircle, FaChartBar, FaChartPie, FaChartLine, FaGlobe, FaBars } from "react-icons/fa";
import profileImage from '../../picture/profile2.png';

const Item = ({ title, to, icon, selected, setSelected }) => {
  const theme = useTheme();
  const colors = tokens(theme.palette.mode);
  
  return (
    <MenuItem
      active={selected === title}
      style={{ color: colors.grey[100] }}
      onClick={() => setSelected(title)}
      icon={icon}
      component={<Link to={to} />}
    >
      {title}
    </MenuItem>
  );
};

const SidebarPro = () => {
  const theme = useTheme();
  const colors = tokens(theme.palette.mode);
  const [isCollapsed, setIsCollapsed] = useState(false);
  const [selected, setSelected] = useState("Dashboard");

  return (
    <ProSidebarProvider>
      <Box
        sx={{
          "& .ps-sidebar-root": { background: `${colors.primary[400]} !important` },
          "& .ps-menu-button:hover": { color: "#868dfb !important" },
          "& .ps-menu-button.ps-active": { color: "#6870fa !important" },
        }}
      >
        <Sidebar collapsed={isCollapsed}>
          <Menu>
            {/* LOGO AND MENU ICON */}
            <MenuItem
              onClick={() => setIsCollapsed(!isCollapsed)}
              icon={isCollapsed ? <FaBars /> : undefined}
              style={{ margin: "10px 0 20px 0", color: colors.grey[100] }}
            >
              {!isCollapsed && (
                <Box display="flex" justifyContent="space-between" alignItems="center" ml="15px">
                  <Typography variant="h3" color={colors.grey[100]}>
                    ADMIN
                  </Typography>
                  <IconButton onClick={() => setIsCollapsed(!isCollapsed)}>
                    <FaBars />
                  </IconButton>
                </Box>
              )}
            </MenuItem>

            {!isCollapsed && (
              <Box mb="25px" textAlign="center">
                <Box display="flex" justifyContent="center">
                  <img
                    alt="profile-user"
                    width="100px"
                    height="100px"
                    src={profileImage}
                    style={{ cursor: "pointer", borderRadius: "50%" }}
                  />
                </Box>
                <Typography variant="h2" color={colors.grey[100]} fontWeight="bold" sx={{ m: "10px 0 0 0" }}>
                  Artinë Azemi
                </Typography>
                <Typography variant="h5" color={colors.greenAccent[500]}>
                  Collaborative Learning
                </Typography>
              </Box>
            )}

            <Box paddingLeft={isCollapsed ? undefined : "10%"}>
              <Item title="Dashboard" to="/" icon={<FaHome />} selected={selected} setSelected={setSelected} />

              <Typography variant="h6" color={colors.grey[300]} sx={{ m: "15px 0 5px 20px" }}>
                Data
              </Typography>
              <Item title="Manage Team" to="/team" icon={<FaUsers />} selected={selected} setSelected={setSelected} />
              <Item title="Students" to="/entities/student" icon={<FaUsers />} selected={selected} setSelected={setSelected} />
              <Item title="Groups" to="/entities/group" icon={<FaUsers />} selected={selected} setSelected={setSelected} />
              <Item title="Contacts Information" to="/contacts" icon={<FaClipboardList />} selected={selected} setSelected={setSelected} />

              <Typography variant="h6" color={colors.grey[300]} sx={{ m: "15px 0 5px 20px" }}>
                Pages
              </Typography>
              <Item title="Profile Form" to="/form" icon={<FaUser />} selected={selected} setSelected={setSelected} />
              <Item title="Calendar" to="/calendar" icon={<FaCalendarAlt />} selected={selected} setSelected={setSelected} />
              <Item title="FAQ Page" to="/faq" icon={<FaQuestionCircle />} selected={selected} setSelected={setSelected} />

              <Typography variant="h6" color={colors.grey[300]} sx={{ m: "15px 0 5px 20px" }}>
                Charts
              </Typography>
              <Item title="Bar Chart" to="/bar" icon={<FaChartBar />} selected={selected} setSelected={setSelected} />
              <Item title="Pie Chart" to="/pie" icon={<FaChartPie />} selected={selected} setSelected={setSelected} />
              <Item title="Line Chart" to="/line" icon={<FaChartLine />} selected={selected} setSelected={setSelected} />
              <Item title="Geography Chart" to="/geography" icon={<FaGlobe />} selected={selected} setSelected={setSelected} />
            </Box>
          </Menu>
        </Sidebar>
      </Box>
    </ProSidebarProvider>
  );
};

export default SidebarPro;