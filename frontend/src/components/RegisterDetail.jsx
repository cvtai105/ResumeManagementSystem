import React from 'react';

function RegistrationDetails({nextStep, selectedRegister}) {
  return (
    <div className="flex mr-[100px] items-center bg-gray-100 px-130">
      <div className="bg-white shadow-lg rounded-lg p-8 max-w-md w-full">
        <h3 className="text-xl font-semibold mb-6">CHI TIẾT PHIẾU ĐĂNG KÝ</h3>
        
        <div className="mb-4">
          <label className="block text-gray-700 text-sm font-bold mb-2" htmlFor="applicantCode">
            Mã ứng tuyển:
          </label>
          <input
            value={selectedRegister?.id || ''}
            type="text"
            id="applicantCode"
            placeholder="0000000000000"
            className="shadow appearance-none border rounded w-full py-2 px-3 text-gray-700 leading-tight focus:outline-none focus:shadow-outline"
          />
        </div>
        
        
        
        <div className="mb-4">
          <label className="block text-gray-700 text-sm font-bold mb-2" htmlFor="employeeCode">
            Mã nhân viên đã duyệt phiếu:
          </label>
          <input
            value={selectedRegister?.nhanVienKiemDuyenId || ''}
            type="text"
            id="employeeCode"
            placeholder="nvdp102938"
            className="shadow appearance-none border rounded w-full py-2 px-3 text-gray-700 leading-tight focus:outline-none focus:shadow-outline"
          />
        </div>
        
        <div className="mb-4">
          <label className="block text-gray-700 text-sm font-bold mb-2" htmlFor="contractCode">
            Mã ứng viên:
          </label>
          <input
            value={selectedRegister?.ungVienId || ''}
            type="text"
            id="contractCode"
            placeholder="itcom03122401"
            className="shadow appearance-none border rounded w-full py-2 px-3 text-gray-700 leading-tight focus:outline-none focus:shadow-outline"
          />
        </div>
        
        <div className="mb-4">
          <label className="block text-gray-700 text-sm font-bold mb-2" htmlFor="creationDate">
            Ngày lập phiếu:
          </label>
          <input
            value={selectedRegister?.id ? new Date(selectedRegister?.ngayUngTuyen).toLocaleDateString('vn') || '' : ''}
            type="text"
            id="creationDate"
            placeholder="12/12/2022"
            className="shadow appearance-none border rounded w-full py-2 px-3 text-gray-700 leading-tight focus:outline-none focus:shadow-outline"
          />
        </div>
        <div className="mb-4">
          <label className="block text-gray-700 text-sm font-bold mb-2" htmlFor="registrationCode">
            Trạng thái:
          </label>
          <input
            value={selectedRegister?.id ? selectedRegister?.trangThai || 'Chưa xử lý' : ''}
            type="text"
            id="registrationCode"
            placeholder="Chưa xử lý"
            className="shadow appearance-none border rounded w-full py-2 px-3 text-gray-700 leading-tight focus:outline-none focus:shadow-outline"
          />
        </div>
        <button onClick={nextStep}
          type="button"
          className="mt-5 w-full btn-dark text-white py-2 px-4 hover:bg-blue-600 focus:outline-none focus:shadow-outline border rounded"
        >
          Đánh giá
        </button>
      </div>
    </div>
  );
}

export default RegistrationDetails;
