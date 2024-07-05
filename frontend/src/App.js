import React from 'react';
import { createRoutesFromElements, Route, RouterProvider } from 'react-router-dom';
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
import JobDetail from './pages/UngVien/JobDetail';
import Recruitment from './pages/DoanhNghiep/Recruitment';
import { ToastContainer } from 'react-toastify';
import 'react-toastify/dist/ReactToastify.css';

const routes = createRoutesFromElements(
  <>
    <Route path="/" element={<UngVienLayout />} >
      <Route index element={<UngVienHome />} />
      <Route path="search" element = {<UngVienHome/>}>
      </Route>
      <Route path="jobs/:id" element={<JobDetail />} />
    </Route>

    <Route path="/nhanvien" element={<><NhanVienLayout /><Footer /></>} >
      <Route index element={<XacThucDangKy />} />
      <Route path='xacthuc' element={<XacThucDangKy />} /> 
      <Route path="danhgia" element={<Review/>}/>
    </Route>

    <Route path="/doanhnghiep" element={ <DoanhNghiepLayout/>}>
      <Route index element={<DoanhNghiepHome />} />
      <Route path="dang-ky-dang-tuyen" element={<DangKyThongTinDangTuyen/>}/>
      <Route path="recruitments/:id" element={<Recruitment/>}/>
    </Route>

    <Route path="/dangnhap" element={<UngVienLogin />} />
    <Route path="/nhanvien/dangnhap" element={<NhanVienLogin />} />
    <Route path='/doanhnghiep/dangnhap' element={<DoanhNghiepLogin />} />
    <Route path='/doanhnghiep/dangky' element={<DangKyThanhVienDoanhNghiep />} />

    <Route path="*" element={<div>Not Found</div>} />
  </>
);

const router = createBrowserRouter(routes);

function App() {

  return (
    <>
    <RouterProvider router={router} />
    <ToastContainer />
    </>
    
  );
}

export default App
