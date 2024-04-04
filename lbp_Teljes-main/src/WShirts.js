import React, { useState, useEffect } from 'react';
import { useCart } from './CartContext'; // Kosár kontextus importálása

function Shirts() {
  const { addToCart } = useCart();
  const [shirts, setShirts] = useState([]);
  const [categoryData, setCategoryData] = useState({});

  useEffect(() => {
    const fetchShirts = async () => {
      try {
        const response = await fetch('https://localhost:7063/Termek');
        if (response.ok) {
          const fetchedShirts = await response.json();
          setShirts(fetchedShirts);
        } else {
          throw new Error('API response was not ok.');
        }
      } catch (error) {
        console.error('Failed to fetch shirts data:', error);
        setShirts([]);
      }
    };

    fetchShirts();
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
    shirts.forEach((shirt) => {
      fetchCategory(shirt.kategoriaId);
      console.log(shirt);
    });
  }, [shirts]);

  const handleBuyNow = (shirt) => {
    // Ellenőrizze, hogy van-e userToken a localStorage-ban
    const userToken = localStorage.getItem('userToken');
    if (!userToken) {
      // Ha nincs, akkor átirányítás a Login oldalra
      window.location.href = '/login';
      return;
    }
    // Ha van userToken, akkor hozzáadja a terméket a kosárhoz
    addToCart(shirt);
  };

  return (
    <div className="container">
      {shirts.map((shirt) => {
        if (categoryData[shirt.kategoriaId] === "Póló" && shirt.besorolasId === "46c33419-479b-40a5-9628-ec73a8dbe642") {
          return (
            <div className="card" key={shirt.id}>
              <div className="imgBx">
                <img src={shirt.kep} alt={shirt.nev} />
              </div>
              <div className="details">
                <h2>{categoryData[shirt.kategoriaId]}</h2>
                <h4>Product Details</h4>
                <p>{shirt.leiras}</p>
                <h4>Size</h4>
                <ul className="size">
                  <li>{shirt.meret}</li>
                </ul>
                <div className="group">
                  <h2><sup>Ft</sup>{shirt.ar}<small>.99</small></h2>
                  <button onClick={() => handleBuyNow(shirt)}>Buy Now</button> {/* Kosárhoz adás */}
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

export default Shirts;
