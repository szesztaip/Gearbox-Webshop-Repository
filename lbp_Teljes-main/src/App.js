import React from 'react';
import { BrowserRouter as Router, Route, Routes } from 'react-router-dom';
import Navbar from './Navbar';
import InfiniteScrollBanner from './InfiniteScrollBanner';
import Home from './Home';
import Women from './Women';
import Men from './Men';
import Children from './Children';
import Shoes from './Shoes';
import Footer from './Footer';
import Login from './Login';
import User from './User'; // Importáld a User komponenst
import { Hover } from './Hover';
import './App.css';
const App = () => {

  return (
    <Router>
      <div className="app-container">
        
          <Navbar />

          <InfiniteScrollBanner />

          

          <div className="content-container">
            <Routes>
              <Route path="/" element={<Home />} />
              <Route path="/women" element={<Women />} />
              <Route path="/men" element={<Men />} />
              <Route path="/children" element={<Children />} />
              <Route path="/shoes" element={<Shoes />} />
              <Route path="/login" element={<Login />} />
              <Route path="/user" element={<User />} /> {/* Adjuk hozzá az új útvonalat */}
            </Routes>
          </div>

          <Hover />
        <Footer />
      </div>
    </Router>
  );
};

export default App;
