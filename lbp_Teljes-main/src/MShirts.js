import React, { useState, useEffect } from 'react';
import { useCart } from './CartContext'; // Kosár kontextus importálása

function MShirts() {
  const { addToCart } = useCart();
  const [mshirts, setMShirts] = useState([]);
  const [categoryData, setCategoryData] = useState({});

  useEffect(() => {
    const fetchMShirts = async () => {
      try {
        const response = await fetch('https://localhost:7063/Termek');
        if (response.ok) {
          const fetchedMShirts = await response.json();
          setMShirts(fetchedMShirts);
        } else {
          throw new Error('API response was not ok.');
        }
      } catch (error) {
        console.error('Failed to fetch MShirts data:', error);
        setMShirts([]);
      }
    };

    fetchMShirts();
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
    mshirts.forEach((mshirt) => {
      fetchCategory(mshirt.kategoriaId);
      console.log(mshirt);
    });
  }, [mshirts]);

  const handleBuyNow = (mshirt) => {
    // Ellenőrizze, hogy van-e userToken a localStorage-ban
    const userToken = localStorage.getItem('userToken');
    if (!userToken) {
      // Ha nincs, akkor átirányítás a Login oldalra
      window.location.href = '/login';
      return;
    }
    // Ha van userToken, akkor hozzáadja a terméket a kosárhoz
    addToCart(mshirt);
  };

  return (
    <div className="container">
      {mshirts.map((mshirt) => {
        if (categoryData[mshirt.kategoriaId] === "Póló" && mshirt.besorolasId === "113e047a-9143-4f25-bbec-a1695e395743") {
          return (
            <div className="card" key={mshirt.id}>
              <div className="imgBx">
                <img src={mshirt.kep} alt={mshirt.nev} />
              </div>
              <div className="details">
                <h2>{categoryData[mshirt.kategoriaId]}</h2>
                <h4>Product Details</h4>
                <p>{mshirt.leiras}</p>
                <h4>Size</h4>
                <ul className="size">
                  <li>{mshirt.meret}</li>
                </ul>
                <div className="group">
                  <h2><sup>Ft</sup>{mshirt.ar}<small>.99</small></h2>
                  <button onClick={() => handleBuyNow(mshirt)}>Buy Now</button> {/* Kosárhoz adás */}
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

export default MShirts;