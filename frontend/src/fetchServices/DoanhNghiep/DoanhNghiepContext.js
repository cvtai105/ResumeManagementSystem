import React, { createContext, useState } from 'react';

export const DoanhNghiepContext = createContext();

export const DoanhNghiepProvider = ({ children }) => {
  const [idDoanhNghiep, setIdDoanhNghiep] = useState(null);

  return (
    <DoanhNghiepContext.Provider value={{ idDoanhNghiep, setIdDoanhNghiep }}>
      {children}
    </DoanhNghiepContext.Provider>
  );
};