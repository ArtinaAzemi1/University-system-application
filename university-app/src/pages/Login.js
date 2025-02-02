import React, { useState } from "react";
import { useNavigate } from "react-router-dom";
//import { setToken } from "../utils/auth";
import "./../styles/Login.css";

const Login = ({ setUser }) => {
  /*const [credentials, setCredentials] = useState({ username: "", password: "" });
  const [error, setError] = useState("");
  const navigate = useNavigate();

  const handleChange = (e) => {
    setCredentials({ ...credentials, [e.target.name]: e.target.value });
  };

  const handleSubmit = async (e) => {
    e.preventDefault();
    setError("");

    const response = await fetch("http://localhost:5000/api/auth/login", {
      method: "POST",
      headers: { "Content-Type": "application/json" },
      body: JSON.stringify(credentials),
    });

    const data = await response.json();
    if (response.ok) {
      setToken(data.token);
      setUser(data.user);
      navigate("/dashboard");
    } else {
      setError(data.message || "Invalid login credentials");
    }
  };*/

  return (
    <div className="login-container">
      <div className="login-box">
        <h2>Welcome Back</h2>
        <p>Please log in to your account</p>
        {/*error && <p className="error">{error}</p>*/}
        <form /*onSubmit={handleSubmit}*/>
          <div className="input-group">
            <label>Username</label>
            <input type="text" name="username" /*value={credentials.username} onChange={handleChange}*/ required />
          </div>
          <div className="input-group">
            <label>Password</label>
            <input type="password" name="password" /*value={credentials.password} onChange={handleChange}*/ required />
          </div>
          <button type="submit">Login</button>
        </form>
      </div>
    </div>
  );
};

export default Login;