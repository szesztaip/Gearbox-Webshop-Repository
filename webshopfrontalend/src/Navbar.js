import React, { useState } from 'react';
import { Link, useNavigate } from 'react-router-dom';
import './Navbar.css';
import logo from './logo.png'; // Assuming your logo is in the same folder


const Navbar = () => {
  const [searchQuery, setSearchQuery] = useState('');
  const navigate = useNavigate();

  const handleSearch = (e) => {
    if (e.key === 'Enter') {
      // Navigate to the search results page with the query
      navigate(`/search?q=${searchQuery}`);
      // Clear the search input
      setSearchQuery('');
    }
  };

  return (
    <header className="site-header">
      <div className="logo-container">
        <Link to="/">
          <img src={logo} alt="Logo" className="navbar-logo" />
        </Link>
      </div>
      <div className="navbar-middle">
        <ul className="navbar-nav">
          <li><Link to="/">Home</Link></li>
          <li><Link to="/Women">Women</Link></li>
          <li><Link to="/men">Men</Link></li>
          <li><Link to="/children">Children</Link></li>
          <li className="dropdown">
            <Link to="/category">Category</Link>
            <div className="dropdown-content">
              <Link to="/shoes">Shoes</Link>
              <Link to="/shirts">Shirts</Link>
              <Link to="/pants">Pants</Link>
            </div>
          </li>
        </ul>
      </div>
      <div className="navbar-right">
        <div className="search-container">
          <input 
            type="text" 
            placeholder="Search..." 
            className="search-input" 
            value={searchQuery}
            onChange={(e) => setSearchQuery(e.target.value)}
            onKeyPress={handleSearch}
          />
        </div>
        <Link to="/login" className="login-link">Login</Link>
      </div>
      <div className="cart-icon">
        <Link to="/cart">
             <img src="/shopping-cart.png" alt="" />
        </Link>
      </div>
    </header>
  );
};

export default Navbar;
