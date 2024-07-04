import { Outlet, NavLink, Link } from "react-router-dom";
import logo from "../assets/logo.png";
import React, { useEffect, useState } from 'react';
import { isDoanhNghiepAuth } from "../fetchServices/Auth/checkAuth";
import deleteCookie from "../utils/deleteCookie";
import { useNavigate  } from "react-router-dom";
import './nav.css';
import Footer from '../components/Footer';

function DoanhNghiepLayout() {
  const nav = useNavigate();
  const [isAuth, setIsAuth] = useState(false);

  useEffect(() => {
    if(isDoanhNghiepAuth()){
      setIsAuth(true);
    }else {
      setIsAuth(false)
    }
  }
  , [nav]);

  function logoutHandle() {
    deleteCookie('DoanhNghiepAuthToken');
    setIsAuth(false);
    nav('/doanhnghiep/dangnhap')
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
                                <NavLink to="" end  className={({ isActive }) => isActive ? "navlink text-dodger-blue" : "navlink"} >Dashboard</NavLink>
                                <NavLink to="dang-ky-dang-tuyen" className={({ isActive }) => isActive ? "navlink text-dodger-blue" : "navlink"} >Đăng Tuyển</NavLink>
                            </div>
                        </div>
                    </div>
                    { !isAuth &&
                      <div className="">
                        <NavLink to="dangnhap" className="login" >Đăng nhập</NavLink>
                        <NavLink to="dangky" className="login" >Đăng ký</NavLink>
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

      
      { isAuth &&
          <main>
            <Outlet /> {/* This is where nested routes will be rendered */}
          </main>
      }

      { !isAuth &&
      <div className="flex items-center justify-center my-64">
        <div>
          <Link to="/doanhnghiep/dangnhap" className="text-center">
            <h3>Đăng nhập để tiếp tục</h3>
          </Link>
          <h4 className="text-center"> hoặc </h4>
          <Link to="/doanhnghiep/dangky" className="text-center">
            <h3>Đăng ký thành viên</h3>
          </Link>
        </div>
    </div>
    }
      
      <footer>
        <Footer/>
      </footer>
    </>
  );
}

export default DoanhNghiepLayout;
