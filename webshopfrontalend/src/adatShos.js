import React, { useState, useEffect } from 'react';
import './Shoes.css';

function Shoes() {
  const [products, setProducts] = useState([]);

  useEffect(() => {
    // Az adatok lekérése az adatbázisból vagy egy API-ból
    const fetchProducts = async () => {
      try {
        // Itt cserélje le az URL-t az Ön API végpontjára, ami visszaadja a termékek listáját.
        const response = await fetch('https://your-api.com/products');
        const data = await response.json();
        setProducts(data);
      } catch (error) {
        console.error('Error fetching products:', error);
      }
    };

    fetchProducts();
  }, []); // Az üres függőségi tömb biztosítja, hogy a useEffect csak a komponens betöltődésekor fut le egyszer.

  if (products.length === 0) {
    return <div>Loading...</div>;
  }

  return (
    <div className="products">
      {products.map(product => (
        <div key={product.id} className="card">
          <div className="imgBx">
            <img src={product.imageUrl} alt={product.name} />
          </div>
          <div className="details">
            <h3>{product.name}<br /><span>Men's Shoe</span></h3>
            <h4>Product Details</h4>
            <p>{product.description}</p>
            <h4>Size</h4>
            <ul className="size">
              {product.sizes.map(size => <li key={size}>{size}</li>)}
            </ul>
            <div className="group">
              <h2><sup>$</sup>{product.price}<small>.99</small></h2>
              <button onClick={() => console.log('Buying', product.name)}>Buy Now</button>
            </div>
          </div>
        </div>
      ))}
    </div>
  );
}

export default Shoes;
