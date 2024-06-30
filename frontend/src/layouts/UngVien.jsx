import { Outlet } from "react-router-dom";

function UngVienLayout() {
  return (
    <>
      <header>
        <h1>Ứng Viên header</h1>
      </header>
      <main>
        <Outlet /> {/* This is where nested routes will be rendered */}
      </main>
      <footer>
        <p>Ứng viên Footer</p>
      </footer>
    </>
  );
}

export default UngVienLayout;
