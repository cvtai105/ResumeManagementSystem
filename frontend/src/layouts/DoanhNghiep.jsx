import { Outlet } from "react-router-dom";

function DoanhNghiepLayout() {
  return (
    <>
      <header>
        <h1>DoanhNghiep  Header</h1>
      </header>
      <main>
        <Outlet /> {/* This is where nested routes will be rendered */}
      </main>
      <footer>
        <p>Doanh Nghiệp Footer</p>
      </footer>
    </>
  );
}

export default DoanhNghiepLayout;
