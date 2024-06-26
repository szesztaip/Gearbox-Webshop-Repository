import React, { useState } from 'react';
import { useNavigate } from 'react-router-dom';
import jwt_decode from './jwt_decode'; // importáld a jwt_decode modult

import './Login.css';

const Login = ({ isLoggedIn, toggleLogin = () => {} }) => {
  const [felhasznalonev, setUserName] = useState('');
  const [jelszo, setPassword] = useState('');
  const [email, setEmail] = useState('');
  const [telefonszam, setPhoneNumber] = useState('');
  const [passwordVisible, setPasswordVisible] = useState(false);
  const [view, setView] = useState('login');
  const [termsAccepted, setTermsAccepted] = useState(false); // Hozzáadott állapot a feltételek elfogadásának nyomon követésére
  const navigate = useNavigate();

  const handleLogin = async (e) => {
    e.preventDefault();
    try {
      const response = await fetch("https://localhost:7063/login/bejelentkezes", {
        method: "POST",
        headers: {
          "Content-Type": "application/json",
        },
        body: JSON.stringify({ email, jelszo }),
      });
      const data = await response.json();
      if (response.ok && data.userToken) {
        localStorage.setItem("userToken", data.userToken);
        toggleLogin();
        navigate("/");
      } else {
        console.error("Login failed, response status:", response.status);
      }
    } catch (error) {
      console.error("An error occurred during login:", error);
    }
  };

  const handleRegister = async (e) => {
    e.preventDefault();
    // Ellenőrizzük, hogy a feltételeket elfogadták-e
    if (!termsAccepted) {
      alert("A regisztrációhoz kérem fogadja el a felhasználói feltételeket!");
      return;
    }
    try {
      const response = await fetch("https://localhost:7063/regisztracio", {
        method: "POST",
        headers: {
          "Content-Type": "application/json",
        },
        body: JSON.stringify({
          felhasznalonev,
          telefonszam,
          email,
          jelszo,
        }),
      });
  
      if (response.ok) {
        console.log("Registration successful");
        setUserName(felhasznalonev);
        setEmail(email);
        setPassword(jelszo);
        setPhoneNumber(telefonszam);
        handleLogin(e);
        // Sikeres regisztráció esetén küldjünk egy üdvözlő e-mailt
        try {
          const emailResponse = await fetch("https://localhost:7063/Email", {
            method: "POST",
            headers: {
              "Content-Type": "application/json",
            },
            body: JSON.stringify({
              to: email,
              subject: "Üdvözlünk webáruházunkba",
              body: "Köszönjük, hogy a mi webáruházunkat választotta!",
            }),
          });
          if (emailResponse.ok) {
            console.log("Welcome email sent successfully!");
          } else {
            console.error("Failed to send welcome email:", emailResponse.status);
          }
        } catch (error) {
          console.error("An error occurred while sending welcome email:", error);
        }
  
        // Sikeres regisztráció után dekódold a JWT tokent
        const userToken = localStorage.getItem("userToken");
        if (userToken) {
          const decodedToken = jwt_decode(userToken);
          console.log("Decoded token:", decodedToken);
          // Kinyerjük az ameidentifier-t a decoded tokentől
          const nameidentifier = decodedToken.nameidentifier;
          // Elküldjük az ameidentifier-t az endpointon keresztül
          try {
            const cartConnectionResponse = await fetch("https://localhost:7063/KosarKapcsolat", {
              method: "POST",
              headers: {
                "Content-Type": "application/json",
              },
              body: JSON.stringify({
                vasarloId: nameidentifier,
              }),
            });
            if (cartConnectionResponse.ok) {
              console.log("Cart connection successful");
            } else {
              console.error("Failed to establish cart connection:", cartConnectionResponse.status);
            }
          } catch (error) {
            console.error("An error occurred while establishing cart connection:", error);
          }
        } else {
          console.error("User token not found in localStorage");
        }
  
        navigate("/");
      } else {
        console.error("Registration failed, response status:", response.status);
      }
    } catch (error) {
      console.error("An error occurred during registration:", error);
    }
  };


  const switchToRegister = () => setView('register');
  const switchToLogin = () => setView('login');

  return (
    <div className="hero">
      <div className="form-box">
        <div className="button-box">
          <div id="btn" style={{ left: view === 'login' ? '0px' : '110px' }}></div>
          <button type="button" className="toggle-btn" onClick={switchToLogin}>Log In</button>
          <button type="button" className="toggle-btn" onClick={switchToRegister}>Register</button>
        </div>

        {view === 'login' && (
          <form id="login" className="input-group" onSubmit={handleLogin}>
            <input type="text" className="input-field" placeholder="Email" required value={email} onChange={(e) => setEmail(e.target.value)} />
            <input type={passwordVisible ? "text" : "password"} className="input-field" placeholder="Password" required value={jelszo} onChange={(e) => setPassword(e.target.value)} />
            <div className="field-checkbox padding-top--8">
              <label>
                <input type="checkbox" checked={passwordVisible} onChange={() => setPasswordVisible(!passwordVisible)} className="check-box" />
                <span>Show Password</span>
              </label>
            </div>
            <button className="submit-btn" type="submit">Log In</button>
          </form>
        )}

        {view === 'register' && (
          <form id="register" className="input-group" style={{ left: view === 'login' ? '450px' : '50px' }} onSubmit={handleRegister}>
            <input type="text" className="input-field" placeholder="Username" required value={felhasznalonev} onChange={(e) => setUserName(e.target.value)} />
            <input type="email" className="input-field" placeholder="Email" required value={email} onChange={(e) => setEmail(e.target.value)} />
            <input type="tel" className="input-field" placeholder="Phone number" required value={telefonszam} onChange={(e) => setPhoneNumber(e.target.value)} />
            <input type="password" className="input-field" placeholder="Password" required value={jelszo} onChange={(e) => setPassword(e.target.value)} />
            <div className="field-checkbox padding-top--8">
              <label>
                <input type="checkbox" className="check-box" checked={termsAccepted} onChange={(e) => setTermsAccepted(e.target.checked)} />
                <span>I agree to the terms & conditions</span>
              </label>
            </div>
            <button className="submit-btn" type="submit">Register</button>
          </form>
        )}
      </div>
    </div>
  );
};

export default Login;
