// Cart.jsx
import React, { useState } from 'react';
import './Cart.css'; // Feltételezve, hogy a stílusokat a Cart.css fájlban tartod

const Cart = () => {
  const [products, setProducts] = useState([]);

  const updateQuantity = (id, quantity) => {
    if (products.length === 0) return; // Ellenőrizd, hogy a termékek tömb üres-e
    const updatedProducts = products.map(product => {
      if (product.id === id) {
        return { ...product, quantity };
      }
      return product;
    });
    setProducts(updatedProducts);
  };

  const removeItem = (id) => {
    if (products.length === 0) return; // Ellenőrizd, hogy a termékek tömb üres-e
    const filteredProducts = products.filter(product => product.id !== id);
    setProducts(filteredProducts);
  };

  const calculateTotal = () => {
    if (products.length === 0) return 0; // Ellenőrizd, hogy a termékek tömb üres-e
    const subtotal = products.reduce((acc, product) => acc + (product.price * product.quantity), 0);
    const tax = subtotal * 0.05;
    const shipping = subtotal > 0 ? 15.00 : 0;
    return subtotal + tax + shipping;
  };

  return (
    <div className="shopping-cart">
      {/* Product List and Totals */}
      {products.map(product => (
        <div key={product.id} className="product">
          <div className="product-image">
            <img src={product.image} alt={product.title} />
          </div>
          <div className="product-details">
            <div className="product-title">{product.title}</div>
            <p className="product-description">{product.description}</p>
          </div>
          <div className="product-price">{product.price.toFixed(2)}</div>
          <div className="product-quantity">
            <input 
              type="number" 
              value={product.quantity} 
              min="1"
              onChange={(e) => updateQuantity(product.id, parseInt(e.target.value, 10))}
            />
          </div>
          <div className="product-removal">
            <button className="remove-product" onClick={() => removeItem(product.id)}>
              Remove
            </button>
          </div>
          <div className="product-line-price">{(product.price * product.quantity).toFixed(2)}</div>
        </div>
      ))}
      <div className="totals">
        {/* Subtotal, Tax, Shipping, and Grand Total Calculations */}
        <div className="totals-item">
          <label>Grand Total</label>
          <div className="totals-value" id="cart-total">{calculateTotal().toFixed(2)}</div>
        </div>
      </div>
      <button className="checkout">Checkout</button>
    </div>
  );
};

export default Cart;
