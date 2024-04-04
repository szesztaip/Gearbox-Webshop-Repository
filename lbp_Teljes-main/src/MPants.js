import React, { useState, useEffect } from 'react';
import { useCart } from './CartContext'; // Kosár kontextus importálása

function MPants() {
  const { addToCart } = useCart();
  const [mpants, setMPants] = useState([]);
  const [categoryData, setCategoryData] = useState({});

  useEffect(() => {
    const fetchMPants = async () => {
      try {
        const response = await fetch('https://localhost:7063/Termek');
        if (response.ok) {
          const fetchedMPants = await response.json();
          setMPants(fetchedMPants);
        } else {
          throw new Error('API response was not ok.');
        }
      } catch (error) {
        console.error('Failed to fetch MPants data:', error);
        setMPants([]);
      }
    };

    fetchMPants();
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
    mpants.forEach((mpant) => {
      fetchCategory(mpant.kategoriaId);
      console.log(mpant);
    });
  }, [mpants]);

  const handleBuyNow = (mpant) => {
    // Ellenőrizze, hogy van-e userToken a localStorage-ban
    const userToken = localStorage.getItem('userToken');
    if (!userToken) {
      // Ha nincs, akkor átirányítás a Login oldalra
      window.location.href = '/login';
      return;
    }
    // Ha van userToken, akkor hozzáadja a terméket a kosárhoz
    addToCart(mpant);
  };

  return (
    <div className="container">
      {mpants.map((mpant) => {
        if (categoryData[mpant.kategoriaId] === "Nadrág" && mpant.besorolasId === "113e047a-9143-4f25-bbec-a1695e395743") {
          return (
            <div className="card" key={mpant.id}>
              <div className="imgBx">
                <img src={mpant.kep} alt={mpant.nev} />
              </div>
              <div className="details">
                <h2>{categoryData[mpant.kategoriaId]}</h2>
                <h4>Product Details</h4>
                <p>{mpant.leiras}</p>
                <h4>Size</h4>
                <ul className="size">
                  <li>{mpant.meret}</li>
                </ul>
                <div className="group">
                  <h2><sup>Ft</sup>{mpant.ar}<small>.99</small></h2>
                  <button onClick={() => handleBuyNow(mpant)}>Buy Now</button> {/* Kosárhoz adás */}
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

export default MPants;
