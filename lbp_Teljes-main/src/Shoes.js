import React, { useState, useEffect } from 'react';
import { useCart } from './CartContext'; // Feltételezve, hogy van egy CartContexted
import './Shoes.css';

function Shoes() {
  // Statikus adatok
  const staticShoes = [
    // A korábban meghatározott cipőadatok
  ];

  const { addToCart } = useCart();
  const [shoes, setShoes] = useState([]);

  useEffect(() => {
    const fetchShoes = async () => {
      try {
        const response = await fetch('/api/shoes');
        if (response.ok) {
          const fetchedShoes = await response.json();
          setShoes(fetchedShoes);
        } else {
          throw new Error('API response was not ok.');
        }
      } catch (error) {
        console.error('Failed to fetch shoes data, using static data instead:', error);
        setShoes(staticShoes); // Ha az API hívás sikertelen, a statikus adatok használata
      }
    };

    fetchShoes();
  }, []);

  return (
    <div className="container">
      {shoes.map((shoe) => (
        <div className="card" key={shoe.id}>
          <div className="imgBx">
            <img src={shoe.imageUrl} alt={shoe.name} />
          </div>
          <div className="details">
            <h3>{shoe.name}<br /><span>{shoe.description}</span></h3>
            <h4>Product Details</h4>
            <p>{shoe.details}</p>
            <h4>Size</h4>
            <ul className="size">
              {shoe.sizes.map((size) => (
                <li key={size}>{size}</li>
              ))}
            </ul>
            <div className="group">
              <h2><sup>{shoe.currency}</sup>{shoe.price}<small>.99</small></h2>
              <button onClick={() => addToCart(shoe)}>Buy Now</button>
            </div>
          </div>
        </div>
      ))}
    </div>
  );
}

export default Shoes;
