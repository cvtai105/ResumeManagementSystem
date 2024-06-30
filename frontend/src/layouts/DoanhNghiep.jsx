import { Outlet } from "react-router-dom";
import Navbar from "../components/Navbar";
import Footer from "../components/Footer";

function DoanhNghiepLayout() {
  return (
    <>
      <header>
        <Navbar/>
      </header>
      <main>
        <Outlet /> {/* This is where nested routes will be rendered */}
       
      </main>
      <footer>
        <Footer/>
      </footer>
    </>
  );
}

export default DoanhNghiepLayout;
