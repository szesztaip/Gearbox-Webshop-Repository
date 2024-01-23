import React from 'react';
import './Product.css';

const Product = ({ product }) => {
  return (
    <div className="product">
      <h3>{product.name}</h3>
      <p>{product.description}</p>
      <p>{product.price}</p>
      <button>Add to cart</button>
    </div>
  );
};

export default Product;