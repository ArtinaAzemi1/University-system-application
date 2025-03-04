import React, { useState } from "react";
import { useNavigate } from "react-router-dom";
import { Link } from "react-router-dom";
import {Button, Form, Col, Row} from 'react-bootstrap';
import "./../assets/css/Register.css";
import { ToastContainer, toast } from 'react-toastify';
import axios from 'axios';

const Register = () => {
  const [name, setName] = useState("");
  const [surname, setSurname] = useState("");
  const [username, setUsername] = useState("");
  const [email, setEmail] = useState("");
  const [password, setPassword] = useState("");

  const getToken = localStorage.getItem("token");

  const authentikimi = {
    headers: {
      Authorization: `Bearer ${getToken}`,
    },
  };

  const handleChange = (setState) => (event) => {
    setState(event.target.value);
  }

  function isNullOrEmpty(value) {
    return value === null || value === "" || value === undefined;
  }

  async function CreateAcc(e) {
    e.preventDefault();

    if (
      isNullOrEmpty(name) ||
      isNullOrEmpty(surname) ||
      isNullOrEmpty(username) ||
      isNullOrEmpty(email) ||
      isNullOrEmpty(password)
    ) {
      toast.error('Invalid Data!');
    } else {
      const kontrolloEmail = await axios.get(`https://localhost:7028/api/Auth/ControlEmail?email=${email}`, authentikimi)
      const passREGEX = /^[A-Z][A-Za-z0-9@$!%*?&]*[a-z][A-Za-z0-9@$!%*?&]*[0-9][A-Za-z0-9@$!%*?&]*$/
      if (kontrolloEmail.data === true) {
        toast.error('This email id not valid!');
      } else if (!passREGEX.test(password)) {
        toast.error('The password must contain <strong>letters, numbers and symbols and the first letter must be uppercase!')
      }
      else {
        axios
          .post("https://localhost:7028/api/Auth/register", {
            name: name,
            surname: surname,
            email: email,
            username: username,
            password: password
          }, authentikimi)
          .then(() => {
            toast.success('Welcome ! Your account has been created succesfully!')
          })
          .catch((error) => {
            console.error(error);
            toast.error('Theres been a mistake, please contant the staff.')
          });
      }
    }
  }

  /*const handleSubmit = async (e) => {
    e.preventDefault();
    setError("");

    const response = await fetch("http://localhost:5000/api/auth/register", {
      method: "POST",
      headers: { "Content-Type": "application/json" },
      body: JSON.stringify(formData),
    });

    const data = await response.json();
    if (response.ok) {
      navigate("/login"); // Përdoruesi shkon te login pas regjistrimit
    } else {
      setError(data.message || "Registration failed");
    }
  };*/

  return (
    <div className="register-container">
      <div className="register-box">
        <h2>Create Account</h2>
        <p>Register to access the system</p>
        <Form className="sign-up-form">
        <Row className="mb-3">
          <Form.Group as={Col} className="p-0" controlId="formGridName">
            <Form.Label>Name<span style={{ color: "red" }}>*</span></Form.Label>
            <Form.Control
              type="name"
              placeholder="Enter Name"
              value={name}
              onChange={handleChange(setName)}
              required
              autoFocus
            />
          </Form.Group>
          <br/>
          <Form.Group as={Col} className="p-2" controlId="formGridLastName">
            <Form.Label>Last Name<span style={{ color: "red" }}>*</span></Form.Label>
            <Form.Control
              type="surname"
              placeholder="Surname"
              value={surname}
              onChange={handleChange(setSurname)}
              required
            />
          </Form.Group>
        </Row> 
        <Row className="mb-3">
        <Form.Group as={Col} className="p-2" controlId="formGridUsername">
          <Form.Label className="reg-label">Username</Form.Label>
          <Form.Control
           placeholder="Username"
            value={username}
            onChange={handleChange(setUsername)}
            required
          />
        </Form.Group>
        <Form.Group  as={Col} className="p-0" controlId="formGridEmail">
          <Form.Label className="reg-label-email">Email</Form.Label>
          <Form.Control
            placeholder="example@hotmail.com"
            value={email}
            onChange={handleChange(setEmail)}
            required
          />
        </Form.Group>
        </Row>
        <Form.Group className="mb-3" controlId="formGridPassword">
          <Form.Label className="reg-label">Password<span style={{ color: "red" }}>*</span></Form.Label>
          <Form.Control
            type="password"
            placeholder="Password"
            value={password}
            onChange={handleChange(setPassword)}
            required
          />
        </Form.Group>
          {/*<button type="custom-btn">Rregister</button>*/}
          <Button type="custom-btn" variant="info" style={{width : "290px"}} onClick={CreateAcc}>REGISTER</Button>
          <p>
            Already have an account? <Link to="/login">Login here</Link>
          </p>
        </Form>
      </div>
    </div>
  );
};

export default Register;


//import React from "react";
//import { Helmet } from "react-helmet";
//import NavBar from "../Components/layout/NavBar";
//import Footer from "../Components/layout/Footer";
//import Form from "react-bootstrap/Form";
//import Button from "react-bootstrap/esm/Button";
//import "./Styles/SignUp.css";
//import { useState } from "react";
//import axios from "axios";
//import Col from "react-bootstrap/Col";
//import { Row } from "react-bootstrap";
//import Mesazhi from "../Components/layout/Mesazhi";
//import { Link } from "react-router-dom";
//
//
//const Register = () => {
//  const [emri, setEmri] = useState("");
//  const [mbimeri, setMbiemri] = useState("");
//  const [username, setUsername] = useState("");
//  const [email, setEmail] = useState("");
//  const [password, setPassword] = useState("");
//  const [nrTelefonit, setNrTelefonit] = useState("");
//  const [qyteti, setQyteti] = useState("");
//  const [adresa, setAdresa] = useState("");
//  const [shteti, setShteti] = useState("");
//  const [zipKodi, setZipKodi] = useState("");
//
//  const [shfaqMesazhin, setShfaqMesazhin] = useState(false);
//  const [tipiMesazhit, setTipiMesazhit] = useState("");
//  const [pershkrimiMesazhit, setPershkrimiMesazhit] = useState("");
//
//  const getToken = localStorage.getItem("token");
//
//  const authentikimi = {
//    headers: {
//      Authorization: `Bearer ${getToken}`,
//    },
//  };
//
//  const handleChange = (setState) => (event) => {
//    setState(event.target.value);
//  }
//
//  const handleShtetiChange = (event) => {
//    setShteti(event.target.value);
//  };
//
//  function isNullOrEmpty(value) {
//    return value === null || value === "" || value === undefined;
//  }
//
//  async function CreateAcc(e) {
//    e.preventDefault();
//
//    if (
//      isNullOrEmpty(emri) ||
//      isNullOrEmpty(mbimeri) ||
//      isNullOrEmpty(username) ||
//      isNullOrEmpty(email) ||
//      isNullOrEmpty(password)
//    ) {
//      setPershkrimiMesazhit("<strong>Ju lutemi plotesoni te gjitha fushat me *</strong>");
//      setTipiMesazhit("danger");
//      setShfaqMesazhin(true);
//    } else {
//      const kontrolloEmail = await axios.get(`https://localhost:7285/api/Perdoruesi/KontrolloEmail?email=${email}`, authentikimi)
//      const passREGEX = /^[A-Z][A-Za-z0-9@$!%*?&]*[a-z][A-Za-z0-9@$!%*?&]*[0-9][A-Za-z0-9@$!%*?&]*$/
//      const telefoniREGEX = /^(?:\+\d{11}|\d{9})$/
//
//
//      if (kontrolloEmail.data === true) {
//        setPershkrimiMesazhit("<strong>Ky email nuk eshte i vlefshem!</strong>");
//        setTipiMesazhit("danger");
//        setShfaqMesazhin(true);
//      } else if (!passREGEX.test(password)) {
//        setPershkrimiMesazhit("Fjalekalimi duhet te permbaj <strong>shkronja, numra dhe simbole si dhe shkroja e pare duhet te jete e madhe!</strong>");
//        setTipiMesazhit("danger");
//        setShfaqMesazhin(true);
//      } else if (!isNullOrEmpty(nrTelefonit) && !telefoniREGEX.test(nrTelefonit)) {
//        setPershkrimiMesazhit("Numri telefonit duhet te jete ne formatin: <strong>045123123 ose +38343123132</strong>");
//        setTipiMesazhit("danger");
//        setShfaqMesazhin(true);
//      }
//
//      else {
//        axios
//          .post("https://localhost:7285/api/Authenticate/register", {
//            name: emri,
//            lastName: mbimeri,
//            email: email,
//            username: username,
//            password: password,
//            adresa: adresa,
//            qyteti: qyteti,
//            shteti: shteti,
//            zipKodi: zipKodi !== "" ? zipKodi : 0,
//            nrTelefonit: nrTelefonit
//          }, authentikimi)
//          .then(() => {
//            setPershkrimiMesazhit("<strong>Llogaria juaj u krija me sukses! Ju Deshirojme blerje te kendshme</strong>");
//            setTipiMesazhit("success");
//            setShfaqMesazhin(true);
//          })
//          .catch((error) => {
//            console.error(error);
//            setPershkrimiMesazhit("<strong>Ju lutemi kontaktoni me stafin pasi ndodhi nje gabim ne server!</strong>");
//            setTipiMesazhit("danger");
//            setShfaqMesazhin(true);
//          });
//      }
//    }
//  }
//
//  return (
//    <div className="sign-up">
//      <Helmet>
//        <title>Sign Up | Tech Store</title>
//      </Helmet>
//      <NavBar />
//      {shfaqMesazhin && <Mesazhi
//        setShfaqMesazhin={setShfaqMesazhin}
//        pershkrimi={pershkrimiMesazhit}
//        tipi={tipiMesazhit}
//      />}
//      <Form className="sign-up-form">
//        <Form.Text className="formTitle">Sign Up</Form.Text>
//
//        <Row className="mb-3">
//          <Form.Group as={Col} className="p-0" controlId="formGridName">
//            <Form.Label>Name<span style={{ color: "red" }}>*</span></Form.Label>
//            <Form.Control
//              type="name"
//              placeholder="Enter Name"
//              value={emri}
//              onChange={handleChange(setEmri)}
//              required
//              autoFocus
//            />
//          </Form.Group>
//
//          <Form.Group as={Col} className="p-0" controlId="formGridLastName">
//            <Form.Label>Last Name<span style={{ color: "red" }}>*</span></Form.Label>
//            <Form.Control
//              type="last name"
//              placeholder="Last Name"
//              value={mbimeri}
//              onChange={handleChange(setMbiemri)}
//              required
//            />
//          </Form.Group>
//        </Row>
//
//        <Form.Group className="mb-3" controlId="formGridUsername">
//          <Form.Label>Username<span style={{ color: "red" }}>*</span></Form.Label>
//          <Form.Control
//            placeholder="Username"
//            value={username}
//            onChange={handleChange(setUsername)}
//            required
//          />
//        </Form.Group>
//
//        <Form.Group className="mb-3" controlId="formGridEmail">
//          <Form.Label>Email<span style={{ color: "red" }}>*</span></Form.Label>
//          <Form.Control
//            placeholder="example@hotmail.com"
//            value={email}
//            onChange={handleChange(setEmail)}
//            required
//          />
//        </Form.Group>
//
//        <Form.Group className="mb-3" controlId="formGridPassword">
//          <Form.Label>Password<span style={{ color: "red" }}>*</span></Form.Label>
//          <Form.Control
//            type="password"
//            placeholder="Password"
//            value={password}
//            onChange={handleChange(setPassword)}
//            required
//          />
//        </Form.Group>
//
//        <Form.Group className="mb-3" controlId="formGridPhoneNumber">
//          <Form.Label>Phone Number</Form.Label>
//          <Form.Control
//            placeholder="045123123 ose +38343123132"
//            value={nrTelefonit}
//            onChange={handleChange(setNrTelefonit)}
//          />
//        </Form.Group>
//        <Row>
//          <Form.Group as={Col} className="p-0" controlId="formGridAdresa">
//            <Form.Label>Adresa</Form.Label>
//            <Form.Control
//              placeholder="Agim Bajrami 60"
//              value={adresa}
//              onChange={handleChange(setAdresa)}
//            />
//          </Form.Group>
//          <Form.Group as={Col} className="p-0" controlId="formGridQyteti">
//            <Form.Label>Qyteti</Form.Label>
//            <Form.Control
//              placeholder="Kaçanik"
//              value={qyteti}
//              onChange={handleChange(setQyteti)}
//            />
//          </Form.Group>
//        </Row>
//
//        <Row className="mb-3">
//          <Form.Group as={Col} className="p-0" controlId="formGridState">
//            <Form.Label>State</Form.Label>
//            <Form.Select value={setShteti} onChange={handleShtetiChange}>
//              <option hidden disabled>Zgjedhni Shtetin</option>
//              <option>Kosovë</option>
//              <option>Shqipëri</option>
//              <option>Maqedoni e Veriut</option>
//            </Form.Select>
//          </Form.Group>
//
//          <Form.Group as={Col} className="p-0" controlId="formGridZip">
//            <Form.Label>Zip</Form.Label>
//            <Form.Control
//              type="number"
//              placeholder="71000"
//              value={zipKodi}
//              onChange={handleChange(setZipKodi)}
//            />
//          </Form.Group>
//        </Row>
//        <div style={{ display: "flex", flexDirection: "column", width: "30%" }}>
//          <Link to="/login" className="text-white-20 mb-4 p-text">Keni llogari? Kyçuni</Link>
//          <Button variant="primary" type="submit" onClick={CreateAcc}>
//            Create Account
//          </Button>
//        </div>
//      </Form>
//      <Footer />
//    </div>
//  );
//};
//
//export default Register;
