import React, { useState, useEffect } from 'react';
import { useCart } from './CartContext'; // Kosár kontextus importálása

function CPants() {
  const { addToCart } = useCart();
  const [cpants, setCPants] = useState([]);
  const [categoryData, setCategoryData] = useState({});

  useEffect(() => {
    const fetchCPants = async () => {
      try {
        const response = await fetch('https://localhost:7063/Termek');
        if (response.ok) {
          const fetchedCPants = await response.json();
          setCPants(fetchedCPants);
        } else {
          throw new Error('API response was not ok.');
        }
      } catch (error) {
        console.error('Failed to fetch CPants data:', error);
        setCPants([]);
      }
    };

    fetchCPants();
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
    cpants.forEach((cpant) => {
      fetchCategory(cpant.kategoriaId);
      console.log(cpant);
    });
  }, [cpants]);

  const handleBuyNow = (cpant) => {
    // Ellenőrizze, hogy van-e userToken a localStorage-ban
    const userToken = localStorage.getItem('userToken');
    if (!userToken) {
      // Ha nincs, akkor átirányítás a Login oldalra
      window.location.href = '/login';
      return;
    }
    // Ha van userToken, akkor hozzáadja a terméket a kosárhoz
    addToCart(cpant);
  };

  return (
    <div className="container">
      {cpants.map((cpant) => {
        if (categoryData[cpant.kategoriaId] === "Nadrág" && cpant.besorolasId === "80671620-c381-453f-b0cc-448feb115cc3") {
          return (
            <div className="card" key={cpant.id}>
              <div className="imgBx">
                <img src={cpant.kep} alt={cpant.nev} />
              </div>
              <div className="details">
                <h2>{categoryData[cpant.kategoriaId]}</h2>
                <h4>Product Details</h4>
                <p>{cpant.leiras}</p>
                <h4>Size</h4>
                <ul className="size">
                  <li>{cpant.meret}</li>
                </ul>
                <div className="group">
                  <h2><sup>Ft</sup>{cpant.ar}<small>.99</small></h2>
                  <button onClick={() => handleBuyNow(cpant)}>Buy Now</button> {/* Kosárhoz adás */}
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

export default CPants;
