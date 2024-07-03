import React from 'react'
import { Link, Outlet } from 'react-router-dom'
import logo from '../assets/logo.svg'


const Navbar = () => {
  return (
    <>
    <nav className="navbar">
        <Link to="/doanhnghiep" className="nav-logo flex-none w-20">
          <img src={logo} alt="JobRepo Logo" className="w-full" />
        </Link>
        <ul className="ml-5 flex justify-center space-x-10 font-semibold">
            <li> 
                <Link to="/doanhnghiep" className="hover:text-dodger-blue">Trang chủ</Link>
            </li>
            <li>
                <Link to="dang-ky-dang-tuyen" className="hover:text-dodger-blue">Đăng tuyển</Link>
            </li>
            <li>
                <Link to="review" className="hover:text-dodger-blue">Đánh giá</Link>
            </li>

        </ul>
        <div className="ml-auto flex gap-10">
            <i class="text-3xl fi fi-rs-bell-notification-social-media"></i>
            <i className="text-3xl fi fi-rr-circle-user"></i>
        </div>
    </nav>
    <Outlet/>
    </>
  )
}

export default Navbar