import { Outlet, NavLink } from "react-router-dom";
import logo from "../assets/logo.png";
import React, { useEffect, useState } from 'react';
import { isUngVienAuth } from "../fetchServices/Auth/checkAuth";
import deleteCookie from "../utils/deleteCookie";
import { useNavigate  } from "react-router-dom";


function UngVienLayout() {
  const nav = useNavigate();
  const [isAuth, setIsAuth] = useState(false);

  useEffect(() => {
    if(isUngVienAuth()){
      setIsAuth(true);
    }else {
      nav('/dangnhap')
    }
  }
  , [nav]);

  function logoutHandle() {
    deleteCookie('AuthToken');
    setIsAuth(false);
    nav('/dangnhap')
  }
  
  return (
    <>
      <header className="flex justify-between items-center  bg-royal-blue-transparent py-4 px-8 ">
          <div className="flex items-center space-x-2">
              <img src={logo} alt="JobRepo Logo" className="h-14 w-36" />
          </div>
          <nav className="flex space-x-12">
              <NavLink to="" className={({ isActive }) => isActive ? 'text-royal-blue' : 'hover:text-royal-blue'}>Trang Chủ</NavLink>
              <NavLink to="timviec" className={({ isActive }) => isActive ? 'text-royal-blue' : 'hover:text-royal-blue'}>Tìm việc</NavLink>
          </nav>
          { !isAuth &&
            <div className="flex space-x-8">
              <NavLink to="dangnhap" className="hover:text-royal-blue">Đăng Nhập</NavLink>
              <NavLink to="dangky" className="hover:text-royal-blue">Đăng Ký</NavLink>
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

export default UngVienLayout;
