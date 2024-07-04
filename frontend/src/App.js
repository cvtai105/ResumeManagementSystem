import React from 'react';
import { createRoutesFromElements, Route, RouterProvider } from 'react-router-dom';
import Navbar from './layouts/Navbar_DoanhNghiep';
import Footer from './components/Footer';
import NhanVienLayout from './layouts/NhanVien';
import UngVienLayout from './layouts/UngVien';
import DoanhNghiepLayout from './layouts/DoanhNghiep';
import NhanVienHome from './pages/NhanVien/Home';
import UngVienHome from './pages/UngVien/Home';
import DoanhNghiepHome from './pages/DoanhNghiep/Home';
import NhanVienLogin from './pages/NhanVien/Login';
import UngVienLogin from './pages/UngVien/Login';
import DoanhNghiepLogin from './pages/DoanhNghiep/Login';
import DangKyThongTinDangTuyen from './pages/DoanhNghiep/DangKyThongTinDangTuyen';
import { createBrowserRouter } from 'react-router-dom';
import Review from './pages/NhanVien/Review';
import XacThucDangKy from './pages/NhanVien/XacThucDangKy';
import DangKyThanhVienDoanhNghiep from './pages/DoanhNghiep/DangKyThanhVienDoanhNghiep'


const routes = createRoutesFromElements(
  <>
    <Route path="/" element={<UngVienLayout />} >
      <Route index element={<UngVienHome />} />
    </Route>

    <Route path="/nhanvien" element={<><NhanVienLayout /><Footer /></>} >
      <Route index element={<NhanVienHome />} />
      <Route path='xacthuc' element={<XacThucDangKy />} /> 
      <Route path="danhgia" element={<Review/>}/>
    </Route>
    <Route path="/dangnhap" element={<UngVienLogin />} />
    <Route path="/nhanvien/dangnhap" element={<NhanVienLogin />} />
    <Route path='/doanhnghiep/dangnhap' element={<DoanhNghiepLogin />} />

    <Route path="/doanhnghiep" element={<><Navbar /><Footer /></>}>
    <Route index element={<DoanhNghiepHome />} />
      <Route path="dang-ky-dang-tuyen" element={<DangKyThongTinDangTuyen/>}/>
      <Route path='dangky' element={<DangKyThanhVienDoanhNghiep />} />
    </Route>

    <Route path="*" element={<div>Not Found</div>} />
  </>
);

const router = createBrowserRouter(routes);

function App() {

  return (
    <RouterProvider router={router} />
  );
}

export default App
