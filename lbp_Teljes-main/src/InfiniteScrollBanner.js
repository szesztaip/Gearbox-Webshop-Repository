import React, { useEffect, useState } from 'react';

const promotions = [
  { id: 1, text: "20% off on all shoes!" },
  { id: 2, text: "Buy one get one free on select shirts!" },
  { id: 3, text: "30% off on children's clothing!" },
  // Add more promotions as needed
];

const InfiniteScrollBanner = () => {
  const [currentIndex, setCurrentIndex] = useState(0);

  useEffect(() => {
    const intervalId = setInterval(() => {
      setCurrentIndex((currentIndex) => (currentIndex + 1) % promotions.length);
    }, 3000); // Change promotion every 3 seconds

    return () => clearInterval(intervalId); // Cleanup interval on component unmount
  }, []);

  return (
    <div style={{ display: 'flex', justifyContent: 'center', alignItems: 'center', height: '50px', backgroundColor: '#f4c242', color: '#333', fontWeight: 'bold' }}>
      {promotions[currentIndex].text}
    </div>
  );
};

export default InfiniteScrollBanner;
