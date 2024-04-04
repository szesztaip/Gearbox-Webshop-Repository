import React, { useState, useEffect } from 'react';
import { useCart } from './CartContext'; // Kosár kontextus importálása

function Pants() {
  const { addToCart } = useCart();
  const [pants, setPants] = useState([]);
  const [categoryData, setCategoryData] = useState({});

  useEffect(() => {
    const fetchPants = async () => {
      try {
        const response = await fetch('https://localhost:7063/Termek');
        if (response.ok) {
          const fetchedPants = await response.json();
          setPants(fetchedPants);
        } else {
          throw new Error('API response was not ok.');
        }
      } catch (error) {
        console.error('Failed to fetch pants data:', error);
        setPants([]);
      }
    };

    fetchPants();
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
    pants.forEach((pant) => {
      fetchCategory(pant.kategoriaId);
      console.log(pant);
    });
  }, [pants]);

  const handleBuyNow = (pant) => {
    // Ellenőrizze, hogy van-e userToken a localStorage-ban
    const userToken = localStorage.getItem('userToken');
    if (!userToken) {
      // Ha nincs, akkor átirányítás a Login oldalra
      window.location.href = '/login';
      return;
    }
    // Ha van userToken, akkor hozzáadja a terméket a kosárhoz
    addToCart(pant);
  };

  return (
    <div className="container">
      {pants.map((pant) => {
        if (categoryData[pant.kategoriaId] === "Nadrág" && pant.besorolasId === "46c33419-479b-40a5-9628-ec73a8dbe642") {
          return (
            <div className="card" key={pant.id}>
              <div className="imgBx">
                <img src={pant.kep} alt={pant.nev} />
              </div>
              <div className="details">
                <h2>{categoryData[pant.kategoriaId]}</h2>
                <h4>Product Details</h4>
                <p>{pant.leiras}</p>
                <h4>Size</h4>
                <ul className="size">
                  <li>{pant.meret}</li>
                </ul>
                <div className="group">
                  <h2><sup>Ft</sup>{pant.ar}<small>.99</small></h2>
                  <button onClick={() => handleBuyNow(pant)}>Buy Now</button> {/* Kosárhoz adás */}
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

export default Pants;
