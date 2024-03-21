import React, { useState } from 'react';
import './Footer.css';

const Footer = () => {
  const [email, setEmail] = useState('');

  const handleSubmit = async (e) => {
    e.preventDefault();
    
    // Elküldjük az email címet, tárgyat és testüzenetet a szervernek
    try {
      const response = await fetch("https://localhost:7063/Email", {
        method: "POST",
        headers: {
          "Content-Type": "application/json",
        },
        body: JSON.stringify({
          to: email,
          subject: "Sikeresen feliratkozás hírlevelünkre",
          body: "Köszönjük, hogy feliratkozott hírlevelünkre!"
        }),
      });

      if (response.ok) {
        console.log("Subscription email sent successfully!");
        // Töröljük az email input tartalmát a sikeres elküldés után
        setEmail('');
      } else {
        console.error("Failed to send subscription email:", response.status);
      }
    } catch (error) {
      console.error("An error occurred while sending subscription email:", error);
    }
  };

  return (
    <footer className="footer-section">
      {/* Footer tartalma */}
      <div className="footer-container">
        {/* Footer sorok */}
        <div className="footer-row">
          {/* Footer oszlopok */}
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
              <li>Shoes</li>
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
            {/* Feliratkozás űrlap */}
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
        {/* Footer alsó része */}
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
