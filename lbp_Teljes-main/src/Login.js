import React, { useState } from 'react';
import { useNavigate } from 'react-router-dom';
import './Login.css';

const Login = ({ isLoggedIn, toggleLogin = () => {} }) =>{
  const [felhasznalonev, setUserName] = useState('');
  const [jelszo, setPassword] = useState('');
  const [email, setEmail] = useState('');
  const [telefonszam, setPhoneNumber] = useState('');
  const [passwordVisible, setPasswordVisible] = useState(false);
  const [view, setView] = useState('login');

  const navigate = useNavigate();

  const handleLogin = async (e) => {
    e.preventDefault();
    try {
      const response = await fetch("https://localhost:7063/login/bejelentkezes", {
        method: "POST",
        headers: {
          "Content-Type": "application/json",
        },
        body: JSON.stringify({ email, jelszo}),
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
  
        // Sikeres regisztráció esetén hívjuk meg a handleLogin-t és adjuk át neki az adatokat
        handleLogin(e);
  
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
           <form id="register" className="input-group" style={{ left: view === 'login' ? '450px' : '50px' }}  onSubmit={handleRegister}>
           <input type="text" className="input-field" placeholder="Username" required value={felhasznalonev} onChange={(e) => setUserName(e.target.value)} />
           <input type="email" className="input-field" placeholder="Email" required value={email} onChange={(e) => setEmail(e.target.value)} />
           <input type="tel" className="input-field" placeholder="Phone number" required value={telefonszam} onChange={(e) => setPhoneNumber(e.target.value)} />
           <input type="password" className="input-field" placeholder="Password" required value={jelszo} onChange={(e) => setPassword(e.target.value)} />
           <div className="field-checkbox padding-top--8">
             <label>
               <input type="checkbox" className="check-box" />
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
