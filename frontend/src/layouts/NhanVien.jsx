import { Outlet } from "react-router-dom";

function NhanVienLayout() {
  return (
    <>
      <header>
        <h1>NhanVien Header</h1>
      </header>
      <main>
        <Outlet /> {/* This is where nested routes will be rendered */}
      </main>
      <footer>
        <p>NhanVien Footer</p>
      </footer>
    </>
  );
}

export default NhanVienLayout;
