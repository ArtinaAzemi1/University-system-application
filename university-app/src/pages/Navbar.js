import React, { useState, useEffect, useRef } from "react";
import { Link, useLocation } from "react-router-dom";
import {
  Collapse,
  Navbar,
  NavbarToggler,
  NavbarBrand,
  Nav,
  NavItem,
  Dropdown,
  DropdownToggle,
  DropdownMenu,
  DropdownItem,
  Container,
} from "reactstrap";

const CustomNavbar = () => {
  const [isOpen, setIsOpen] = useState(false);
  const [dropdownOpen, setDropdownOpen] = useState(false);
  const [color, setColor] = useState("transparent");
  const sidebarToggle = useRef();
  const location = useLocation();

  const toggleNavbar = () => {
    setIsOpen(!isOpen);
    setColor(isOpen ? "transparent" : "dark");
  };

  const toggleDropdown = () => {
    setDropdownOpen(!dropdownOpen);
  };

  const openSidebar = () => {
    document.documentElement.classList.toggle("nav-open");
    sidebarToggle.current.classList.toggle("toggled");
  };

  useEffect(() => {
    const updateColor = () => {
      setColor(window.innerWidth < 993 && isOpen ? "dark" : "transparent");
    };

    window.addEventListener("resize", updateColor);
    return () => window.removeEventListener("resize", updateColor);
  }, [isOpen]);

  return (
    <Navbar
      color={location.pathname.includes("full-screen-maps") ? "dark" : color}
      expand="lg"
      className={`navbar-absolute fixed-top ${
        location.pathname.includes("full-screen-maps")
          ? ""
          : color === "transparent"
          ? "navbar-transparent"
          : ""
      }`}
    >
      <Container fluid>
        <div className="navbar-wrapper">
          <button
            type="button"
            ref={sidebarToggle}
            className="navbar-toggler"
            onClick={openSidebar}
          >
            <span className="navbar-toggler-bar bar1" />
            <span className="navbar-toggler-bar bar2" />
            <span className="navbar-toggler-bar bar3" />
          </button>
          <NavbarBrand href="/">Dashboard</NavbarBrand>
        </div>

        <NavbarToggler onClick={toggleNavbar}>
          <span className="navbar-toggler-bar navbar-kebab" />
          <span className="navbar-toggler-bar navbar-kebab" />
          <span className="navbar-toggler-bar navbar-kebab" />
        </NavbarToggler>

        <Collapse isOpen={isOpen} navbar className="justify-content-end">
          <Nav navbar>
            <NavItem>
              <Link to="#" className="nav-link btn-magnify">
                <i className="nc-icon nc-layout-11" />
                <p className="d-lg-none d-md-block">Stats</p>
              </Link>
            </NavItem>

            <NavItem>
              <Link to="#" className="nav-link btn-rotate">
                <i className="nc-icon nc-bell-55" />
                <p className="d-lg-none d-md-block">Notifications</p>
              </Link>
            </NavItem>

            <NavItem>
              <Dropdown nav isOpen={dropdownOpen} toggle={toggleDropdown}>
                <DropdownToggle caret nav>
                  <i className="nc-icon nc-settings-gear-65" />
                  <p className="d-lg-none d-md-block">Settings</p>
                </DropdownToggle>
                <DropdownMenu right>
                  <DropdownItem tag={Link} to="/">
                    <i className="nc-icon nc-single-02"> My Profile</i>
                  </DropdownItem>
                  <DropdownItem tag="a">
                    <i className="nc-icon nc-button-power"> Log out</i>
                  </DropdownItem>
                </DropdownMenu>
              </Dropdown>
            </NavItem>
          </Nav>
        </Collapse>
      </Container>
    </Navbar>
  );
};

export default CustomNavbar;