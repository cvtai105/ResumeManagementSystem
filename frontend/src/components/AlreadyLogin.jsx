import React, { useState } from 'react';
import logo from '../assets/logo.png';

const AlreadyLogin = ({ homeRedirectHandle, LogoutHandle }) => {
  return (
    <div className="min-h-screen flex items-center justify-center bg-gray-100">
      <div className="bg-white p-8 rounded shadow-md w-full max-w-sm">
        <img src={logo} alt="JobRepo Logo" className="h-14 w-36 mx-auto mb-6" />
        <h2 className="text-2xl text-center font-bold mb-6 text-gray-900">
          Bạn Đã Đăng Nhập
        </h2>
        <div className="flex justify-between">
          <button onClick={homeRedirectHandle} className="text-dodger-blue">
            Về Trang Chủ
          </button>
          <button onClick={LogoutHandle} className="btn-dark">
            Đăng Xuất
          </button>
        </div>
      </div>
    </div>
  );
};

export default AlreadyLogin;
