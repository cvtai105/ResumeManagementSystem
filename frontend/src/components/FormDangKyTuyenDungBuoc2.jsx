import React from "react";

const FormDangKyTuyenDungBuoc2 = ({
  nextStep,
  prevStep,
  handleChange,
  formData,
}) => {
  return (
    <div className="grid grid-cols-12 mt-10 mx-auto">
      <div className="container col-start-5 col-span-4 p-10 text-navy rounded-md shadow-lg space-y-5">
        <h2 className="text-xl font-bold mb-4">Hình Thức Và Thời Gian Đăng Tuyển</h2>
        <label className="block font-semibold">Hình thức đăng tuyển</label>
        <select
            className="border border-smoke rounded-lg w-full p-2"
          value={formData.postingType}
          onChange={handleChange("postingType")}
        >
          <option value="Newspaper">Báo giấy</option>
          <option value="Banner">Banner quảng cáo</option>
          <option value="Web">Trang mạng</option>
        </select>
        <label className="block font-semibold">Mô tả hình thức đăng tuyển</label>
        <p>{formData.postingDescription}</p>
        <label className="block font-semibold">Thời gian đăng tuyển</label>
        <div className="relative">
            <input
                type="number"
                className="mt-1 block w-full border border-smoke rounded-md p-2 pr-12"
                value={formData.postingDuration}
                onChange={handleChange('postingDuration')}
            />
            <span className="absolute inset-y-0 right-0 flex items-center pr-3 text-smoke">ngày</span>
        </div>
        <div className="flex justify-between">
            <button onClick={prevStep} className="text-dodger-blue">
            Quay lại
            </button>
            <button onClick={nextStep} className="btn-dark">
            Tiếp theo
            </button>
        </div>
        
      </div>
    </div>
  );
};

export default FormDangKyTuyenDungBuoc2;
