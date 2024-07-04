import React, { useState, useEffect } from "react";
import { Link, Outlet, useNavigate, NavLink } from "react-router-dom";
import deleteCookie from "../utils/deleteCookie";
import { isDoanhNghiepAuth } from "../fetchServices/Auth/checkAuth";
import logo from "../assets/logo.svg";

function Navbar() {
  const nav = useNavigate();
  const [isAuth, setIsAuth] = useState(false);

  useEffect(() => {
    if (isDoanhNghiepAuth()) {
      setIsAuth(true);
    } else {
      nav("/doanhnghiep/dangnhap");
    }
  }, []);

  function logoutHandle() {
    deleteCookie("AuthToken");
    setIsAuth(false);
    nav("/doanhnghiep/dangnhap");
  }
  return (
    <>
      <nav className="navbar">
        <Link to="/doanhnghiep" className="nav-logo flex-none w-20">
          <img src={logo} alt="JobRepo Logo" className="w-full" />
        </Link>
        <ul className="ml-5 flex justify-center space-x-10 font-semibold">
          <li>
            <Link to="/doanhnghiep" className="hover:text-dodger-blue">
              Trang chủ
            </Link>
          </li>
          <li>
            <Link to="dang-ky-dang-tuyen" className="hover:text-dodger-blue">
              Đăng tuyển
            </Link>
          </li>
          <li>
            <Link to="dangky" className="hover:text-dodger-blue">
              Đăng ký
            </Link>
          </li>
        </ul>
        {!isAuth && (
          <div className="ml-auto flex space-x-8">
            <NavLink to="dangnhap" className="btn-dark">
              Đăng Nhập
            </NavLink>
            <NavLink to="dangky" className="btn-light">
              Đăng Ký
            </NavLink>
          </div>
        )}

        {isAuth && (
          <div className="ml-auto flex space-x-8">
            <button onClick={logoutHandle} className="btn-light">
              Đăng Xuất
            </button>
          </div>
        )}
      </nav>
      <Outlet />
    </>
  );
}

export default Navbar;
