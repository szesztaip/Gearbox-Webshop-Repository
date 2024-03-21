import React from 'react';
import { BrowserRouter as Router, Route, Routes } from 'react-router-dom';
import Navbar from './Navbar';
import InfiniteScrollBanner from './InfiniteScrollBanner';
import Home from './Home';
import Women from './Women';
import Men from './Men';
import Children from './Children';
import Shoes from './Shoes';
import Shirts from './Shirts';
import Pants from './Pants';
import Cart from './Cart';
import Footer from './Footer';
import Login from './Login';
import User from './User';
import { Hover } from './Hover';
import { CartProvider } from './CartContext';

import './App.css';


const App = () => {

  return (
    <Router>
      <div className="app-container">
      <CartProvider>
          <Navbar />

          <InfiniteScrollBanner />

          

          <div className="content-container">
            <Routes>
              <Route path="/" element={<Home />} />
              <Route path="/women" element={<Women />} />
              <Route path="/men" element={<Men />} />
              <Route path="/children" element={<Children />} />
              <Route path="/shoes" element={<Shoes />} />
              <Route path="/Shirts" element={<Shirts/>} />
              <Route path="/pants" element={<Pants/>} />
              <Route path="/login" element={<Login />} />
              <Route path="/Cart" element={<Cart/>} />
              <Route path="/user" element={<User />} /> {/* Adjuk hozzá az új útvonalat */}
            </Routes>
          </div>

          <Hover />
        <Footer />
        </CartProvider>
      </div>
    </Router>
  );
};

export default App;
