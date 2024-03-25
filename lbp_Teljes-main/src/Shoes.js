import React, { useState, useEffect } from 'react';
import { useCart } from './CartContext'; // Feltételezve, hogy van egy CartContext

function Shoes() {
  const { addToCart } = useCart();
  const [shoes, setShoes] = useState([]);
  const [categoryData, setCategoryData] = useState({}); // Állapot az aktuális kategória adatok tárolására

  useEffect(() => {
    const fetchShoes = async () => {
      try {
        const response = await fetch('https://localhost:7063/Termek');
        if (response.ok) {
          const fetchedShoes = await response.json();
          setShoes(fetchedShoes);
        } else {
          throw new Error('API response was not ok.');
        }
      } catch (error) {
        console.error('Failed to fetch shoes data:', error);
        setShoes([]);
      }
    };

    fetchShoes();
  }, []);

  // Új HTTP kérés az egyes kategóriák lekérésére a kategoriaId alapján
  const fetchCategory = async (categoryId) => {
    try {
      const response = await fetch(`https://localhost:7063/Kategoriafajtak/${categoryId}`);
      if (response.ok) {
        const categoryData = await response.json();
        setCategoryData((prevData) => ({
          ...prevData,
          [categoryId]: categoryData.kategoriaNev // Kategória név tárolása az állapotba
        }));
      } else {
        throw new Error('API response was not ok.');
      }
    } catch (error) {
      console.error('Failed to fetch category data:', error);
    }
  };

  // Komponens újrarajzolásakor a kategoriaId alapján fetcheljük az adatokat
  useEffect(() => {
    shoes.forEach((shoe) => {
      fetchCategory(shoe.kategoriaId);
    });
  }, [shoes]);

  return (
    <div className="container">
      {shoes.map((shoe) => {
        if (categoryData[shoe.kategoriaId] === "Cipő") {
          return (
            <div className="card" key={shoe.id}>
              <div className="imgBx">
                <img src={shoe.kep} alt={shoe.nev} />
              </div>
              <div className="details">
                <h2>{categoryData[shoe.kategoriaId]}</h2> {/* categoryData felhasználása */}
                <h4>Product Details</h4>
                <p>{shoe.leiras}</p>
                <h4>Size</h4>
                <ul className="size">
                  <li>{shoe.meret}</li>
                </ul>
                <div className="group">
                  <h2><sup>Ft</sup>{shoe.ar}<small>.99</small></h2>
                  <button onClick={() => addToCart(shoe)}>Buy Now</button>
                </div>
              </div>
            </div>
          );
        } else {
          return null; // Nem cipő kategóriájú termékek elhagyása
        }
      })}
    </div>
  );
}

export default Shoes;
