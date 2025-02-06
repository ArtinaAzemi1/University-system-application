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
import FixedPlugin from "../pages/FixedPlugin";

const Layout = ({ children }) => {
  const [showFixedPlugin, setShowFixedPlugin] = useState(false);

  return (
    <div className="layout">
      {children}
      {showFixedPlugin && <FixedPlugin />}
    </div>
  );
};

export default Layout;