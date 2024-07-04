import React, { useState } from 'react';
import logo from '../assets/logo.png';


const LoginForm = ({submitHandler}) => {
    const [email, setEmail] = useState('ungvien@email.com');
    const [password, setPassword] = useState('123456');
    const [error, setError] = useState(null);
  
    const handleSubmit = async (e) => {
        e.preventDefault();
        const jwt = await submitHandler({email, password});
        console.log(jwt);
        if(!jwt) {
        //console.log("check")
            setError('Sai tên đăng nhập hoặc mật khẩu');
        }
    };
  
    return (
      <div className="min-h-screen flex items-center justify-center ">
        <div className=" p-8 rounded  w-full max-w-sm">
            <img src={logo} alt="JobRepo Logo" className="  mx-auto mb-6" />
          <p className="text-2xl text-center font-bold mb-6 text-gray-900">Chào mừng trở lại</p>
          <form onSubmit={handleSubmit}>
            <div className="mb-4">
              <label className="block text-gray-700 mb-2" htmlFor="email">
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
              <label className="block text-gray-700  mb-2" htmlFor="password">
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
              
            {error && <p className="text-red text-base italic">{error}</p>}
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