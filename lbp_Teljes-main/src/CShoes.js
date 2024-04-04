import React, { useState, useEffect } from 'react';
import { useCart } from './CartContext'; // Kosár kontextus importálása

function CShoes() {
  const { addToCart } = useCart();
  const [cshoes, setCShoes] = useState([]);
  const [categoryData, setCategoryData] = useState({});

  useEffect(() => {
    const fetchCShoes = async () => {
      try {
        const response = await fetch('https://localhost:7063/Termek');
        if (response.ok) {
          const fetchedCShoes = await response.json();
          setCShoes(fetchedCShoes);
        } else {
          throw new Error('API response was not ok.');
        }
      } catch (error) {
        console.error('Failed to fetch CShoes data:', error);
        setCShoes([]);
      }
    };

    fetchCShoes();
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
    cshoes.forEach((cshoe) => {
      fetchCategory(cshoe.kategoriaId);
      console.log(cshoe);
    });
  }, [cshoes]);

  const handleBuyNow = (cshoe) => {
    // Ellenőrizze, hogy van-e userToken a localStorage-ban
    const userToken = localStorage.getItem('userToken');
    if (!userToken) {
      // Ha nincs, akkor átirányítás a Login oldalra
      window.location.href = '/login';
      return;
    }
    // Ha van userToken, akkor hozzáadja a terméket a kosárhoz
    addToCart(cshoe);
  };

  return (
    <div className="container">
      {cshoes.map((cshoe) => {
        if (categoryData[cshoe.kategoriaId] === "Cipő" && cshoe.besorolasId === "80671620-c381-453f-b0cc-448feb115cc3") {
          return (
            <div className="card" key={cshoe.id}>
              <div className="imgBx">
                <img src={cshoe.kep} alt={cshoe.nev} />
              </div>
              <div className="details">
                <h2>{categoryData[cshoe.kategoriaId]}</h2>
                <h4>Product Details</h4>
                <p>{cshoe.leiras}</p>
                <h4>Size</h4>
                <ul className="size">
                  <li>{cshoe.meret}</li>
                </ul>
                <div className="group">
                  <h2><sup>Ft</sup>{cshoe.ar}<small>.99</small></h2>
                  <button onClick={() => handleBuyNow(cshoe)}>Buy Now</button> {/* Kosárhoz adás */}
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

export default CShoes;
