import React from 'react';
import { createRoutesFromElements, Route, RouterProvider } from 'react-router-dom';
import NhanVienLayout from './layouts/NhanVien';
import UngVienLayout from './layouts/UngVien';
import DoanhNghiepLayout from './layouts/DoanhNghiep';
import NhanVienHome from './pages/NhanVien/Home';
import UngVienHome from './pages/UngVien/Home';
import DoanhNghiepHome from './pages/DoanhNghiep/Home';
import NhanVienLogin from './pages/NhanVien/Login';
import UngVienLogin from './pages/UngVien/Login';
import DoanhNghiepLogin from './pages/DoanhNghiep/Login';
import { createBrowserRouter } from 'react-router-dom';


const routes = createRoutesFromElements(
  <>
    <Route path="/" element={<UngVienLayout />} >
      <Route index element={<UngVienHome />} />
      <Route path="login" element={<UngVienLogin />} />
    </Route>
    <Route path="/nhanvien" element={<NhanVienLayout />} >
      <Route index element={<NhanVienHome />} />
      <Route path="login" element={<NhanVienLogin />} />
    </Route>
    <Route path="/doanhnghiep" element={<DoanhNghiepLayout />} >
      <Route index element={<DoanhNghiepHome />} />
      <Route path="login" element={<DoanhNghiepLogin />} />
    </Route>
  </>
);

const router = createBrowserRouter(routes);

function App() {

  return (
    <RouterProvider router={router} />
  );
}

export default App
