import React, { useState, useEffect } from "react";
import "bootstrap/dist/css/bootstrap.min.css";
import { BrowserRouter as Router, Routes, Route, Navigate } from "react-router-dom";
import Login from "./pages/Login";
import Register from "./pages/Register";
import Dashboard from "./pages/Dashboard";
import Courses from "./components/Courses";
import Layout from "./components/Layout";
import FixedPlugin from "./pages/FixedPlugin";
import Sidebar from "./pages/Sidebar";

function App() {
  return (
    <Router>
      <Routes>
        <Route path="/" element={<Navigate to="/login" />} />
        <Route path="/login" element={<Login /*setUser={setUser}*/ />} />
        <Route path="/register" element={<Register /*setUser={setUser}*/ />} />
        <Route element={<Layout/>}>
          <Route path="/dashboard" element={<Dashboard />} />
          <Route path="/courses" element={<Courses />} />
        </Route>
        {/*<Route path="/dashboard" element={<Layout><Dashboard /></Layout>} />}
        {/*<Route path="/courses" element={<Layout><Courses /></Layout>} />*/}
      </Routes>
      <FixedPlugin/>
    </Router>
  );
}

export default App;


