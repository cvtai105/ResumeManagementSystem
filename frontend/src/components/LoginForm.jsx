import React, { useState } from 'react';
import logo from '../assets/logo.png';


const LoginForm = ({submitHandler}) => {
    const [email, setEmail] = useState('nhanvien@email.com');
    const [password, setPassword] = useState('123456');
  
    const handleSubmit = (e) => {
        e.preventDefault();
        submitHandler({email, password});
    };
  
    return (
      <div className="min-h-screen flex items-center justify-center bg-gray-100">
        <div className="bg-white p-8 rounded shadow-md w-full max-w-sm">
            <img src={logo} alt="JobRepo Logo" className="h-14 w-36 mx-auto mb-6" />
          <h2 className="text-2xl text-center font-bold mb-6 text-gray-900">Chào mừng trở lại</h2>
          <form onSubmit={handleSubmit}>
            <div className="mb-4">
              <label className="block text-gray-700 text-sm font-bold mb-2" htmlFor="email">
                Email
              </label>
              <input
                type="email"
                id="email"
                className="shadow appearance-none border rounded w-full py-2 px-3 text-gray-700 leading-tight focus:outline-none focus:shadow-outline"
                value={email}
                onChange={(e) => setEmail(e.target.value)}
                required
              />
            </div>
            <div className="mb-6">
              <label className="block text-gray-700 text-sm font-bold mb-2" htmlFor="password">
                Mật khẩu
              </label>
              <input
                type="password"
                id="password"
                className="shadow appearance-none border rounded w-full py-2 px-3 text-gray-700 mb-3 leading-tight focus:outline-none focus:shadow-outline"
                value={password}
                onChange={(e) => setPassword(e.target.value)}
                required
              />
            </div>
            <div className="flex items-center justify-between">
              <button
                type="submit"
                className="font-bold py-2 px-4 w-full rounded focus:outline-none bg-royal-blue text-white hover:bg-royal-blue-dark"
              >
                Đăng nhập
              </button>
            </div>
          </form>
        </div>
      </div>
    );
  };
  
  export default LoginForm;