import React, { useState } from 'react';
import { Link, useNavigate } from 'react-router-dom';
import { useCart } from './CartContext';
import './Navbar.css';
import logo from './logo.png'; // Assuming your logo is in the same folder
import login from './login.png';
import Cart from './cart.png';

function Navbar() {
  const { cartItems } = useCart();
  const [searchQuery, setSearchQuery] = useState('');
  const [showDropdown, setShowDropdown] = useState(false); // State for controlling dropdown visibility
  const navigate = useNavigate();

  const handleSearch = (e) => {
    if (e.key === 'Enter') {
      // Navigate to the search results page with the query
      navigate(`/search?q=${searchQuery}`);
      // Clear the search input
      setSearchQuery('');
    }
  };

  const handleLoginClick = () => {
    const userToken = localStorage.getItem('userToken');
    if (userToken) {
      setShowDropdown(!showDropdown); // Toggle dropdown visibility
    } else {
      navigate('/login'); // Redirect to login page
    }
  };

  const handleLogout = () => {
    // Clear user token from localStorage
    localStorage.removeItem('userToken');
    // Close dropdown
    setShowDropdown(false);
    // Redirect to home page
    navigate('/');
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
          <li className="dropdown">Women
            <div className="dropdown-content">
              <Link to="/shoes">Shoes</Link>
              <Link to="/women/shirts">Shirts</Link>
              <Link to="/women/pants">Pants</Link>
            </div>
          </li>
          <li className="dropdown">Men
            <div className="dropdown-content">
              <Link to="/men/shoes">Shoes</Link>
              <Link to="/men/shirts">Shirts</Link>
              <Link to="/men/pants">Pants</Link>
            </div>
          </li>
          <li className="dropdown">Children
            <div className="dropdown-content">
              <Link to="/children/shoes">Shoes</Link>
              <Link to="/children/shirts">Shirts</Link>
              <Link to="/children/pants">Pants</Link>
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
        {localStorage.getItem('userToken') ? (
          <div className="dropdown">
            <button className="login-link" onClick={handleLoginClick}>
              <img src={login} alt="Login" />
            </button>
            {showDropdown && (
              <div className="dropdown-content">
                <Link to="/profile">Profile</Link>
                <Link to="/" onClick={handleLogout}>Logout</Link>
              </div>
            )}
          </div>
        ) : (
          <Link to="/login" className="login-link">
            <img src={login} alt="Login" />
          </Link>
        )}
        <Link to="/cart" className="cart-icon">
          <img src={Cart} alt="Cart" />
          <span>Cart: {cartItems.length} items</span>
        </Link>
      </div>
    </header>
  );
}

export default Navbar;
