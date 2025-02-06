/*import React from "react";

import { Button } from "reactstrap";
import "../styles/FixedPlugin.css";

function FixedPlugin(props) {
  const [classes, setClasses] = React.useState("dropdown show");
  const handleClick = () => {
    if (classes === "dropdown") {
      setClasses("dropdown show");
    } else {
      setClasses("dropdown");
    }
  };
  return (
    <div className="fixed-plugin">
      <div className={classes}>
        <div onClick={handleClick}>
          <i className="fa fa-cog fa-2x" />
        </div>
        <ul className="dropdown-menu show">
          <li className="header-title">SIDEBAR BACKGROUND</li>
          <li className="adjustments-line">
            <div className="badge-colors text-center">
              <span
                className={
                  props.bgColor === "black"
                    ? "badge filter badge-dark active"
                    : "badge filter badge-dark"
                }
                data-color="black"
                onClick={() => {
                  props.handleBgClick("black");
                }}
              />
              <span
                className={
                  props.bgColor === "white"
                    ? "badge filter badge-light active"
                    : "badge filter badge-light"
                }
                data-color="white"
                onClick={() => {
                  props.handleBgClick("white");
                }}
              />
            </div>
          </li>
          <li className="header-title">SIDEBAR ACTIVE COLOR</li>
          <li className="adjustments-line">
            <div className="badge-colors text-center">
              <span
                className={
                  props.activeColor === "primary"
                    ? "badge filter badge-primary active"
                    : "badge filter badge-primary"
                }
                data-color="primary"
                onClick={() => {
                  props.handleActiveClick("primary");
                }}
              />
              <span
                className={
                  props.activeColor === "info"
                    ? "badge filter badge-info active"
                    : "badge filter badge-info"
                }
                data-color="info"
                onClick={() => {
                  props.handleActiveClick("info");
                }}
              />
              <span
                className={
                  props.activeColor === "success"
                    ? "badge filter badge-success active"
                    : "badge filter badge-success"
                }
                data-color="success"
                onClick={() => {
                  props.handleActiveClick("success");
                }}
              />
              <span
                className={
                  props.activeColor === "warning"
                    ? "badge filter badge-warning active"
                    : "badge filter badge-warning"
                }
                data-color="warning"
                onClick={() => {
                  props.handleActiveClick("warning");
                }}
              />
              <span
                className={
                  props.activeColor === "danger"
                    ? "badge filter badge-danger active"
                    : "badge filter badge-danger"
                }
                data-color="danger"
                onClick={() => {
                  props.handleActiveClick("danger");
                }}
              />
            </div>
          </li>
          <li className="header-title">Want to know more?</li>
          <li className="button-container">
            <Button
              href="https://www.creative-tim.com/product/paper-dashboard-react/#/documentation/tutorial?ref=pdr-fixed-plugin"
              color="primary"
              block
              className="btn-round"
              
            >
              <i className="nc-icon nc-paper" /> Documentation
            </Button>
          </li>
          <li className="header-title">Thank you for sharing !</li>
          <li className="button-container">
            <Button
              href="https://www.creative-tim.com/product/paper-dashboard-pro-react?ref=pdr-fixed-plugin"
              color="danger"
              block
              className="btn-round"
              target="_blank"
            >
              Get pro version
            </Button>
          </li>
        </ul>
      </div>
    </div>
  );
}

export default FixedPlugin;*/

import React, { useState } from "react";
import { Button } from "reactstrap";
import "../styles/FixedPlugin.css"; // Shto stilizimin

function FixedPlugin() {
  const [open, setOpen] = useState(false);

  return (
    <div className={`fixed-plugin-container ${open ? "open" : ""}`}>
      {/* Butoni i vogël anash */}
      <Button className="fixed-plugin-button" onClick={() => setOpen(!open)}>
        <i className="fa fa-cog fa-2x" />
      </Button>

      {/* Mini-sidebar që hapet */}
      <div className="fixed-plugin-panel">
        <h5>SIDEBAR BACKGROUND</h5>
        <div className="badge-colors">
          <span className="badge filter badge-dark" data-color="black" />
          <span className="badge filter badge-light" data-color="white" />
        </div>

        <h5>SIDEBAR ACTIVE COLOR</h5>
        <div className="badge-colors">
          <span className="badge filter badge-primary" data-color="primary" />
          <span className="badge filter badge-info" data-color="info" />
          <span className="badge filter badge-success" data-color="success" />
          <span className="badge filter badge-warning" data-color="warning" />
          <span className="badge filter badge-danger" data-color="danger" />
        </div>

        <Button color="primary" block>
          Documentation
        </Button>
        <Button color="danger" block>
          Get Pro Version
        </Button>
      </div>
    </div>
  );
}

export default FixedPlugin;