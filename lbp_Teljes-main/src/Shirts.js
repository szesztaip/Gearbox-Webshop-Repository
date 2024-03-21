import React, { useState, useEffect } from 'react';
import './Shirts.css';

function Shirts() {
  const [shirts, setShirts] = useState([]);

  // Statikus (fallback) adatok
  const staticShirts = [
    {
      name: "Casual Men's Shirt",
      tagline: "Stylish & Comfortable",
      description: "Lorem ipsum dolor sit amet.",
      imageUrl: "https://5.imimg.com/data5/SELLER/Default/2023/7/323558100/VW/IN/FH/19086680/white-t-shirts-250x250.jpg",
      sizes: ['S', 'M', 'L', 'XL', 'XXL'],
      price: "59.99",
      currency: "USD",
    },
    {
      name: "Formal Men's Shirt",
      tagline: "Elegant & Sophisticated",
      description: "Consectetur adipiscing elit, sed do eiusmod tempor incididunt.",
      imageUrl: "https://rukminim2.flixcart.com/image/550/650/xif0q/shirt/x/m/n/40-men-regular-slim-fit-solid-button-down-collar-formal-shirt-original-imagf4mn9zg7qrmf-bb.jpeg?q=90&crop=false",
      sizes: ['S', 'M', 'L', 'XL', 'XXL'],
      price: "79.99",
      currency: "USD",
    },
    // További ingek statikus adatai...
  ];
  useEffect(() => {
    const fetchShirts = async () => {
      try {
        const response = await fetch('/api/shirts');
        if (response.ok) {
          const data = await response.json();
          setShirts(data);
        } else {
          throw new Error('API response was not ok.');
        }
      } catch (error) {
        console.error("Failed to fetch shirts from the API, using static data instead:", error);
        setShirts(staticShirts); // Ha az API hívás nem sikerül, használja a statikus adatokat
      }
    };
  
    fetchShirts();
  }, []);

  return (
    <div className="container">
      {shirts.map((shirt, index) => (
        <div key={index} className="card">
          <div className="imgBx">
            <img src={shirt.imageUrl} alt={shirt.name} />
          </div>
          <div className="details">
            <h3>{shirt.name}<br /><span>{shirt.tagline}</span></h3>
            <h4>Product Details</h4>
            <p>{shirt.description}</p>
            <h4>Size</h4>
            <ul className="size">
              {shirt.sizes.map((size, sizeIndex) => (
                <li key={sizeIndex}>{size}</li>
              ))}
            </ul>
            <div className="group">
              <h2><sup>{shirt.currency}</sup>{shirt.price}</h2>
              <a href="/">Buy Now</a>
            </div>
          </div>
        </div>
      ))}
    </div>
  );
}

export default Shirts;
