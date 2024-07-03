import { NavLink, Outlet } from "react-router-dom";
import logo from '../assets/logo.png';
import React, { useEffect, useState } from 'react';
import { isNhanVienAuth } from "../fetchServices/Auth/checkAuth";
import deleteCookie from "../utils/deleteCookie";
import { useNavigate  } from "react-router-dom";

function NhanVienLayout() {
  const nav = useNavigate();
  const [isAuth, setIsAuth] = useState(false);

  useEffect(() => {
    if(isNhanVienAuth()){
      setIsAuth(true);
    }else {
      nav('/nhanvien/dangnhap')
    }
  }, []);

  function logoutHandle() {
    deleteCookie('AuthToken');
    setIsAuth(false);
    nav('/nhanvien/dangnhap')
  }

  return (
    <>
      <header className="flex justify-between items-center bg-royal-blue-transparent py-4 px-8 ">
          <div className="flex items-center space-x-2">
              <img src={logo} alt="JobRepo Logo" className="h-14 w-36" />
          </div>
          <nav className="flex space-x-4">
              <NavLink to="" className=" font-semibold hover:text-royal-blue">Trang Chủ</NavLink>
              <NavLink to="hopdong" className=" hover:text-royal-blue">Hợp Đồng</NavLink>
              <NavLink to="danhgia" className=" hover:text-royal-blue">Đánh giá</NavLink>
          </nav>
          { !isAuth &&
            <div className="flex space-x-8">
              <NavLink to="dangnhap" className="">Đăng Nhập</NavLink>
              <NavLink to="dangky" className="">Đăng Ký</NavLink>
            </div>
          }

          {
            isAuth &&
            <div className="flex space-x-8">
              <button onClick={logoutHandle} className="">Đăng Xuất</button>
            </div>
          }
          
      </header>
      <main>
        <Outlet /> {/* This is where nested routes will be rendered */}
      </main>
    </>
  );
}

export default NhanVienLayout;
