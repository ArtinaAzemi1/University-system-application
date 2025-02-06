// pages/Dashboard.js
import React from "react";
import Sidebar from "../pages/Sidebar";
import FixedPlugin from "../pages/FixedPlugin";
import "../styles/Dashboard.css";

const Dashboard = (/*{ user }*/) => {
  return (
    <div className="dashboard-container">
      <Sidebar />
      <div className="dashboard-content">
        <h1>Welcome, user</h1>
        <p>Role: user</p>
        <div className="stats-grid">
          <div className="card">📚 Total Students: 120</div>
          <div className="card">🎓 Total Professors: 25</div>
          <div className="card">🏛 Departments: 5</div>
        </div>
      </div>
    </div>
  );
};

export default Dashboard;