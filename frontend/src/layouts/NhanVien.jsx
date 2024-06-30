import { NavLink, Outlet } from "react-router-dom";
import logo from '../assets/logo.png';

function NhanVienLayout() {
  return (
    <>
      <header className="flex justify-between items-center bg-gray-100 py-4 px-8 border-b-2 border-blue-500">
          <div className="flex items-center space-x-2">
              <img src={logo} alt="JobRepo Logo" className="h-16 w-24" />
          </div>
          <nav className="flex space-x-4">
              <NavLink to="" className="text-black hover:text-royal-blue active:text-royal-blue">Trang Chủ</NavLink>
              <NavLink to="hopdong" className="text-black hover:text-royal-blue active:text-royal-blue">Hợp Đồng</NavLink>
          </nav>
          <div className="flex space-x-4">
              <NavLink to="dangnhap" className="text-black hover:text-royal-blue">Đăng Nhập</NavLink>
              <NavLink to="dangky" className="text-black hover:text-royal-blue">Đăng Ký</NavLink>
          </div>
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
