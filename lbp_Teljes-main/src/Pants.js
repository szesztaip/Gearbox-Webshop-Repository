import React, { useState, useEffect } from 'react';
import './Pants.css'; // Assuming you have a similar CSS file for styling

function Pants() {
  const [pants, setPants] = useState([]);

  // Statikus adatok a fallback-hez
  const staticPants = [
    {
      id: 1,
      name: "Casual Men's Pants",
      description: "Comfortable & Durable",
      details: "Lorem ipsum dolor sit amet.",
      imageUrl: "https://img1.theiconic.com.au/mSTi1741Un2QvLoWAtmTV1DTmOY=/634x811/filters:quality(95):fill(ffffff)/http%3A%2F%2Fstatic.theiconic.com.au%2Fp%2Fnew-balance-9702-7560981-1.jpg",
      sizes: ['28', '30', '32', '34', '36', '38'],
      price: "75.99",
    },
    {
      id: 2,
      name: "Formal Men's Pants",
      description: "Sleek & Stylish",
      details: "Lorem ipsum dolor sit amet.",
      imageUrl: "https://i5.walmartimages.com/seo/Mens-Plus-Size-Cargo-Pants-Outdoor-Casual-Solid-Loose-Hiking-Pants-Multiple-Pockets-Drawstring-Workout-Sweatpants-Tactical-Straight-Fit-Cropped-Trous_dd955fbd-465d-455b-9e66-1de4cf6df233.037118fdf30812ad4697498e6afc4636.jpeg?odnHeight=768&odnWidth=768&odnBg=FFFFFF",
      sizes: ['28', '30', '32', '34', '36', '38'],
      price: "95.99",
    },
    // További nadrágok statikus adatai...
  ];

  useEffect(() => {
    const fetchPants = async () => {
      try {
        const response = await fetch('https://example.com/api/pants');
        if (!response.ok) throw new Error('Network response was not ok.');
        const data = await response.json();
        setPants(data);
      } catch (error) {
        console.error('Failed to fetch pants data, using static data instead:', error);
        setPants(staticPants);
      }
    };

    fetchPants();
  }, []);

  return (
    <div className="container">
      {pants.map((pant) => (
        <div className="card" key={pant.id}>
          <div className="imgBx">
            <img src={pant.imageUrl} alt={pant.name} />
          </div>
          <div className="details">
            <h3>{pant.name}<br /><span>{pant.description}</span></h3>
            <h4>Product Details</h4>
            <p>{pant.details}</p>
            <h4>Size</h4>
            <ul className="size">
              {pant.sizes.map((size, index) => (
                <li key={index}>{size}</li>
              ))}
            </ul>
            <div className="group">
              <h2><sup>USD</sup>{pant.price}<small>.99</small></h2>
              <a href="/">Buy Now</a>
            </div>
          </div>
        </div>
      ))}
    </div>
  );
}

export default Pants;
