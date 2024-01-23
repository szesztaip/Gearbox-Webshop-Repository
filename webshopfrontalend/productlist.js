import React from 'react';
import Product from './product';
import './ProductList.css';

const ProductList = ({ products }) => {
  return (
    <ul className="product-list">
      {products.map((product) => (
        <li key={product.id}>
          <Product product={product} />
        </li>
      ))}
    </ul>
  );
};

export default ProductList;