// components/Sidebar.js
import React from "react";
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

export default Sidebar;