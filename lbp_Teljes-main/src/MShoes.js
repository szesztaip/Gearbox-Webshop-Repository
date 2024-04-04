import React, { useState, useEffect } from 'react';
import { useCart } from './CartContext'; // Kosár kontextus importálása

function MShoes() {
  const { addToCart } = useCart();
  const [mshoes, setMShoes] = useState([]);
  const [categoryData, setCategoryData] = useState({});

  useEffect(() => {
    const fetchMShoes = async () => {
      try {
        const response = await fetch('https://localhost:7063/Termek');
        if (response.ok) {
          const fetchedMShoes = await response.json();
          setMShoes(fetchedMShoes);
        } else {
          throw new Error('API response was not ok.');
        }
      } catch (error) {
        console.error('Failed to fetch MShoes data:', error);
        setMShoes([]);
      }
    };

    fetchMShoes();
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
    mshoes.forEach((mshoe) => {
      fetchCategory(mshoe.kategoriaId);
      console.log(mshoe);
    });
  }, [mshoes]);

  const handleBuyNow = (mshoe) => {
    // Ellenőrizze, hogy van-e userToken a localStorage-ban
    const userToken = localStorage.getItem('userToken');
    if (!userToken) {
      // Ha nincs, akkor átirányítás a Login oldalra
      window.location.href = '/login';
      return;
    }
    // Ha van userToken, akkor hozzáadja a terméket a kosárhoz
    addToCart(mshoe);
  };

  return (
    <div className="container">
      {mshoes.map((mshoe) => {
        if (categoryData[mshoe.kategoriaId] === "Cipő" && mshoe.besorolasId === "113e047a-9143-4f25-bbec-a1695e395743") {
          return (
            <div className="card" key={mshoe.id}>
              <div className="imgBx">
                <img src={mshoe.kep} alt={mshoe.nev} />
              </div>
              <div className="details">
                <h2>{categoryData[mshoe.kategoriaId]}</h2>
                <h4>Product Details</h4>
                <p>{mshoe.leiras}</p>
                <h4>Size</h4>
                <ul className="size">
                  <li>{mshoe.meret}</li>
                </ul>
                <div className="group">
                  <h2><sup>Ft</sup>{mshoe.ar}<small>.99</small></h2>
                  <button onClick={() => handleBuyNow(mshoe)}>Buy Now</button> {/* Kosárhoz adás */}
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

export default MShoes;
