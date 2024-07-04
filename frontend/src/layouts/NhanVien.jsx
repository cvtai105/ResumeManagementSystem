import { NavLink, Outlet } from "react-router-dom";
import logo from '../assets/logo.png';
import React, { useEffect, useState } from 'react';
import { isNhanVienAuth } from "../fetchServices/Auth/checkAuth";
import deleteCookie from "../utils/deleteCookie";
import { useNavigate  } from "react-router-dom";
import './nav.css';


function NhanVienLayout() {
  const nav = useNavigate();
  const [isAuth, setIsAuth] = useState(false);

  useEffect(() => {
    if(isNhanVienAuth()){
      setIsAuth(true);
    }else {
      nav('/nhanvien/dangnhap')
    }
  }, [nav]);

  function logoutHandle() {
    deleteCookie('NhanVienAuthToken');
    setIsAuth(false);
    nav('/nhanvien/dangnhap')
  }

  return (
    <>
      <nav className="bg-white shadow-md">
            <div className="max-w-7xlpx-2 sm:px-6 lg:px-8">
                <div className="relative flex items-center justify-between h-16">
                    <div className="flex-1 flex  items-center justify-center sm:items-stretch sm:justify-start">
                        <div className="flex-shrink-0">
                            <img className="h-12 w-auto" src={logo} alt="Logo" />
                        </div>
                        <div className="ml-10 flex ">
                            <div className="m-auto">
                                <NavLink to="" end className={({ isActive }) => isActive ? "navlink text-dodger-blue" : "navlink"} >Trang Chủ</NavLink>
                                <NavLink to="xacthuc" className={({ isActive }) => isActive ? "navlink text-dodger-blue" : "navlink"} >Xác Thực</NavLink>
                                <NavLink to="danhgia" className={({ isActive }) => isActive ? "navlink text-dodger-blue" : "navlink"} >Đánh Giá</NavLink>
                            </div>
                        </div>
                    </div>
                    { !isAuth &&
                      <div className="">
                        <NavLink to="dangnhap" className="login" >Đăng nhập</NavLink>
                        <NavLink className="login" >Đăng ký</NavLink>
                      </div>
                    }

                    {
                      isAuth &&
                      <div className="flex">
                        <NavLink onClick={logoutHandle} className='m-auto'>Đăng xuất</NavLink>
                      </div>
                    }
                    
                </div>
            </div>
        </nav>
      <main>
        <Outlet /> {/* This is where nested routes will be rendered */}
      </main>

      
    </>
  );
}

export default NhanVienLayout;
