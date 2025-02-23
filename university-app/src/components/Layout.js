/*import React from "react";
import Sidebar from "../pages/Sidebar";
import FixedPlugin from "../pages/FixedPlugin";

const Layout = ({ children }) => {
  return (
    <div className="layout-container">
      <Sidebar />
      <div className="content">{children}</div>
      <FixedPlugin />
    </div>
  );
};

export default Layout;*/

import React, { useState } from "react";
import { Outlet, useLocation } from "react-router-dom"; 
import Sidebar from "../pages/Sidebar";
//import Navbar from "./Navbar"; // Import Navbar
import FixedPlugin from "../pages/FixedPlugin";
import "../styles/Layout.css";

const Layout = () => {
  const [showFixedPlugin, setShowFixedPlugin] = useState(false);
  const location = useLocation();

  // Fshij Navbar-in nga login/register
  const hideNavbarRoutes = ["/login", "/register"];
  const shouldShowNavbar = !hideNavbarRoutes.includes(location.pathname);

  return (
    <div className="layout">
      <Sidebar />

        <div className="main-content">
          <Outlet />
        </div>

      {showFixedPlugin && <FixedPlugin />}
    </div>
  );
};

export default Layout;