import React, { useState } from 'react';
import { Link } from 'react-router-dom';

import './Footer.css';

const Footer = () => {
  const [email, setEmail] = useState('');

  const handleSubmit = (e) => {
    e.preventDefault();
    // Here you would typically handle the email subscription logic
    console.log(`Subscribing with ${email}`);
    setEmail(''); // Clear the input after submission
  };

  return (
    <footer className="footer-section">
      <div className="footer-container">
        <div className="footer-row">
          <div className="footer-column">
            <h5>Contact Us</h5>
            <p>123 Fashion Ave, New York, NY 10001</p>
            <p>Email: contact@example.com</p>
            <p>Phone: (123) 456-7890</p>
            <p>Hours: Mon-Fri, 9am-5pm</p>
          </div>
          <div className="footer-column">
            <h5>Popular Categories</h5>
            <ul>
             <Link to='/shoes'><li>Shoes</li></Link>
              <li>Shirts</li>
              <li>Pants</li>
              <li>Accessories</li>
            </ul>
          </div>
          <div className="footer-column">
            <h5>Latest News</h5>
            <ul>
              <li>New Spring Collection Arriving</li>
              <li>Winter Sale Starts Now!</li>
            </ul>
          </div>
          <div className="footer-column">
            <h5>Newsletter</h5>
            <p>Subscribe to get the latest updates and offers.</p>
            <form onSubmit={handleSubmit}>
              <input 
                type="email" 
                value={email} 
                onChange={(e) => setEmail(e.target.value)} 
                placeholder="Your Email Address"
              />
              <button type="submit">Subscribe</button>
            </form>
          </div>
        </div>
        <div className="footer-bottom">
          <p>© 2024 Fashion Store. All rights reserved.</p>
          <ul>
            <li>Terms & Conditions</li>
            <li>Privacy Policy</li>
          </ul>
        </div>
      </div>
    </footer>
  );
};

export default Footer;
