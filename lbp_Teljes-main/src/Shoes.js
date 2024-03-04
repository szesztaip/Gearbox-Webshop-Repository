import React from 'react';
import './Shoes.css';

function Shoes() {
  return (
    <div className="container"> 
      <div className="card">
        <div className="imgBx">
          <img src="https://static.nike.com/a/images/t_PDP_1728_v1/f_auto,q_auto:eco/4b3db02b-53b3-4add-8db7-cc56a40356b2/air-max-plus-cipo-NGV34z.png" alt="Nike Air Max Men's Shoe" />
        </div>
        <div className="details">
          <h3>Nike Air Max<br /><span>Men's Shoe</span></h3>
          <h4>Product Details</h4>
          <p>Lorem ipsum dolor, sit amet consectetur adipisicing elit. Nulla ducimus iusto.</p>
          <h4>Size</h4>
          <ul className="size">
            <li>36</li>
            <li>38</li>
            <li>40</li>
            <li>42</li>
            <li>44</li>
          </ul>
          <div className="group">
            <h2><sup>EUR</sup>145<small>.99</small></h2>
            <a href="/">Buy Now</a>
          </div>
        </div>
      </div>
      <div className="card">
        <div className="imgBx">
          <img src="https://static.nike.com/a/images/t_PDP_1728_v1/f_auto,q_auto:eco/9bf81cc2-7757-4c02-b1af-f3c060404afe/air-max-plus-ferficipo-D5RqNV.png" alt="Nike Air Max Men's Shoe" />
        </div>
        <div className="details">
          <h3>Nike Air Max Plus<br /><span>Men's Shoe</span></h3>
          <h4>Product Details</h4>
          <p>Lorem ipsum dolor, sit amet consectetur adipisicing elit. Nulla ducimus iusto.</p>
          <h4>Size</h4>
          <ul className="size">
            <li>36</li>
            <li>38</li>
            <li>40</li>
            <li>42</li>
            <li>44</li>
          </ul>
          <div className="group">
            <h2><sup>EUR</sup>145<small>.99</small></h2>
            <a href="/">Buy Now</a>
          </div>
        </div>
      </div>
    </div>
  );
}

export default Shoes;
