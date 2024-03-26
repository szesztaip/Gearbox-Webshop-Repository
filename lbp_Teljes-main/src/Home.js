import React from 'react';
import './Home.css'
import { useState, useEffect } from 'react';

const Home = () => {

    const [data, setData] = useState([]);
  
    const CardComponent = ({ cardData }) => {
      return (
        <div className="card">
          <div className='title'>
          <h1>{cardData.nev}</h1>
          </div>
          <div className='content'>
          <p>{cardData.leiras}</p>
          </div>
          
          {/* Add more elements as needed */}
        </div>
      );
    };

    useEffect(() => {
      const fetchData = async () => {
        try {
          const response = await fetch('https://localhost:7063/Termek');
          if (!response.ok) {
            throw new Error('Network response was not ok');
          }
          const jsonData = await response.json();
          setData(jsonData);
        } catch (error) {
          console.log(error)
        }
      };
  
      fetchData();
    }, []);

  return (
      <div>
          <div>
              <div className="card-container">
                {data.map((cardData, index) => (
                <CardComponent key={index} cardData={cardData} />
                ))}
              </div>
            
          </div>

        

      </div>


  );
};

export default Home;