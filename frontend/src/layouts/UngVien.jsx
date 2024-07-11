import { Outlet, NavLink } from "react-router-dom";
import logo from "../assets/logo.png";
import React, { useEffect, useState } from 'react';
import { isUngVienAuth } from "../fetchServices/Auth/checkAuth";
import deleteCookie from "../utils/deleteCookie";
import { useNavigate  } from "react-router-dom";
import './nav.css';
import getCookie from "../utils/getCookie";


function UngVienLayout() {
  const nav = useNavigate();
  const [isAuth, setIsAuth] = useState(false);

  useEffect(() => {
    if(isUngVienAuth()){
      setIsAuth(true);
    }else {
    }
    console.log('login cookie', getCookie('UngVienAuthToken'));
  }

  
  , [nav]);

  function logoutHandle() {
    deleteCookie('UngVienAuthToken');
    setIsAuth(false);
    nav('/dangnhap')
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
                                <NavLink to="" end className={({ isActive }) => isActive ? "navlink text-dodger-blue" : "navlink"} >Việc làm</NavLink>
                                <NavLink to="hoso" className={({ isActive }) => isActive ? "navlink text-dodger-blue" : "navlink"} >Hồ sơ & CV</NavLink>
                            </div>
                        </div>
                    </div>
                    { !isAuth &&
                      <div className="">
                        
                        <NavLink to="doanhnghiep" className="mx-10" >Đăng tuyển dụng</NavLink>
                        <NavLink to="dangnhap" className="login" >Đăng nhập</NavLink>
                        <NavLink className="login" >Đăng ký</NavLink>
                      </div>
                    }

                    {
                      isAuth &&
                      <div className="flex">
                        <div>
                        <div className="text-sm">Bạn là nhà tuyển dụng?</div>
                        <NavLink to="doanhnghiep" className="mr-20 text-base font-semibold" >Đăng tuyển ngay</NavLink>
                        </div>
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

export default UngVienLayout;
