import React, { useState, useEffect } from 'react';
import { useCart } from './CartContext'; // Kosár kontextus importálása

function CShirts() {
  const { addToCart } = useCart();
  const [cshirts, setCShirts] = useState([]);
  const [categoryData, setCategoryData] = useState({});

  useEffect(() => {
    const fetchCShirts = async () => {
      try {
        const response = await fetch('https://localhost:7063/Termek');
        if (response.ok) {
          const fetchedCShirts = await response.json();
          setCShirts(fetchedCShirts);
        } else {
          throw new Error('API response was not ok.');
        }
      } catch (error) {
        console.error('Failed to fetch CShirts data:', error);
        setCShirts([]);
      }
    };

    fetchCShirts();
  }, []);

  const fetchCategory = async (categoryId) => {
    try {
      const response = await fetch(`https://localhost:7063/Kategoriafajtak/${categoryId}`);
      if (response.ok) {
        const categoryData = await response.json();
        setCategoryData((prevData) => ({
          ...prevData,
          [categoryId]: categoryData.kategoriaNev
        }));
      } else {
        throw new Error('API response was not ok.');
      }
    } catch (error) {
      console.error('Failed to fetch category data:', error);
    }
  };

  useEffect(() => {
    cshirts.forEach((cshirt) => {
      fetchCategory(cshirt.kategoriaId);
      console.log(cshirt);
    });
  }, [cshirts]);

  const handleBuyNow = (cshirt) => {
    // Ellenőrizze, hogy van-e userToken a localStorage-ban
    const userToken = localStorage.getItem('userToken');
    if (!userToken) {
      // Ha nincs, akkor átirányítás a Login oldalra
      window.location.href = '/login';
      return;
    }
    // Ha van userToken, akkor hozzáadja a terméket a kosárhoz
    addToCart(cshirt);
  };

  return (
    <div className="container">
      {cshirts.map((cshirt) => {
        if (categoryData[cshirt.kategoriaId] === "Póló" && cshirt.besorolasId === "80671620-c381-453f-b0cc-448feb115cc3") {
          return (
            <div className="card" key={cshirt.id}>
              <div className="imgBx">
                <img src={cshirt.kep} alt={cshirt.nev} />
              </div>
              <div className="details">
                <h2>{categoryData[cshirt.kategoriaId]}</h2>
                <h4>Product Details</h4>
                <p>{cshirt.leiras}</p>
                <h4>Size</h4>
                <ul className="size">
                  <li>{cshirt.meret}</li>
                </ul>
                <div className="group">
                  <h2><sup>Ft</sup>{cshirt.ar}<small>.99</small></h2>
                  <button onClick={() => handleBuyNow(cshirt)}>Buy Now</button> {/* Kosárhoz adás */}
                </div>
              </div>
            </div>
          );
        } else {
          return null;
        }
      })}
    </div>
  );
}

export default CShirts;
