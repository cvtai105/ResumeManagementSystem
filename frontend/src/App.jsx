import { useState } from "react";
import { Routes, Route } from "react-router-dom";
import Navbar from "./components/Navbar";
import Footer from "./components/Footer";
import DangKyThongTinDangTuyen from "./pages/DoanhNghiep/DangKyThongTinDangTuyen";

function App() {
  const [count, setCount] = useState(0);

  return (
    <Routes>
      <Route path="/" element={<><Navbar /><Footer /></>}>
        <Route path="dang-ky-dang-tuyen" element={<DangKyThongTinDangTuyen />} />
      </Route>
    </Routes> 
  );
}

export default App;
