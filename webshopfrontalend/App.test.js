import React, { useState } from 'react';
import ProductList from './productlist';
import products from './products.json';

function App() {
  const [cart, setCart] = useState([]);

  const addToCart = (product) => {
    setCart([...cart, product]);
  };

  return (
    <div className="App">
      <h1>My Webshop</h1>
      <ProductList products={products} onAddToCart={addToCart} />
      <h2>Shopping Cart</h2>
      <ul>
        {cart.map((product) => (
          <li key={product.id}>{product.name}</li>
        ))}
      </ul>
    </div>
  );
}

export default App;