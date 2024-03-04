import React, { useState } from 'react';
import { useNavigate } from 'react-router-dom';
import './Login.css'

const Login = () => {
  const [email, setUserName] = useState('');
  const [jelszo, setHash] = useState('');
  const [passwordVisible, setPasswordVisible] = useState(false);
  const navigate = useNavigate();

  const login = async (e) => {
    e.preventDefault();
    try {
      const response = await fetch('https://localhost:7063/login/bejelentkezes', {
        method: 'POST',
        headers: {
          'Content-Type': 'application/json',
        },
        body: JSON.stringify({ email, jelszo }),
      });
      const data = await response.json();
      console.log(data.userToken);
      if (response.ok && data.userToken) {
        localStorage.setItem('authToken', data.userToken);
        navigate('/User');
        console.log("Sikeres")
      } else {
        // Itt kezelhetjük a nem sikeres bejelentkezést
        console.error('Bejelentkezés sikertelen, válasz státusz:', response.status);
      }
    } catch (error) {
      console.error('Hiba történt a bejelentkezés során:', error);
    }
  };


  return (
      <div className="login-root">
        <div className="box-root padding-top--24 flex-flex flex-direction--column" style={{ flexGrow: 1, zIndex: 9 }}>
          <div className="box-root padding-top--48 padding-bottom--24 flex-flex flex-justifyContent--center">
            <h1>Login</h1>
          </div>
          <div className="formbg-outer">
            <div className="formbg">
              <div className="formbg-inner padding-horizontal--48">
                <span className="padding-bottom--15">Sign in to your account</span>
                <form onSubmit={login}>
                  <div className="field padding-bottom--24">
                    <label htmlFor="userName">Email</label>
                    <input type="text" name="userName" value={email} onChange={(e) => setUserName(e.target.value)} />
                  </div>
                  <div className="field padding-bottom--24">
                    <label htmlFor="email">Password</label>
                    <input
                      type={passwordVisible ? "text" : "password"}
                      name="HASH"
                      value={jelszo}
                      onChange={(e) => setHash(e.target.value)}
                    />
                    <div className="field-checkbox padding-top--8">
                      <label>
                        <input
                          type="checkbox"
                          checked={passwordVisible}
                          onChange={() => setPasswordVisible(!passwordVisible)}
                        /> Show Password
                      </label>
                    </div>
                  </div>
                  <div className="field padding-bottom--24">
                    <input type="submit" name="submit" value="Sign in"/>
                  </div>
                </form>
              </div>
            </div>
          </div>
        </div>
      </div>
    );
  };
  
export default Login;
