import React from 'react';

const LoginRequire = () => {
    return (
        <div className="flex flex-col items-center justify-center min-h-screen bg-gray-100 p-4">
            <h1 className="text-2xl font-bold mb-6">Đăng nhập để tiếp tục</h1>
            <div className="flex space-x-4">
                <button className="bg-blue-500 px-4 py-2 rounded hover:bg-blue-700 focus:outline-none">
                    Đăng nhập
                </button>
                <button className="bg-green-500 px-4 py-2 rounded hover:bg-green-700 focus:outline-none">
                    Đăng ký
                </button>
            </div>
        </div>
    );
}

export default LoginRequire;
