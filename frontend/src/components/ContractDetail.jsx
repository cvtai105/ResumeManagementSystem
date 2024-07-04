import React from 'react';

function ContractDetails() {
  return (
    <div className="flex justify-left ml-[90px] items-center mt-5 ">
      <div className="bg-white shadow-lg rounded-lg p-8 max-w-2xl w-full">
        <h3 className="text-xl font-bold mb-5">HỢP ĐỒNG: itcom03122401</h3>
        
        <div className="grid grid-cols-2 gap-4 center ">
          <div className="flex flex-col ml-5">
            <span className="font-semibold">Tên công ty</span>
            <span>BIDV</span>
          </div>
          <div className="flex flex-col ml-5">
            <span className="font-semibold">Ngày bắt đầu</span>
            <span>01/01/2024</span>
          </div>
          <div className="flex flex-col ml-5">
            <span className="font-semibold">Tên công việc</span>
            <span>Full-Stack</span>
          </div>
          <div className="flex flex-col ml-5">
            <span className="font-semibold">Ngày kết thúc</span>
            <span>01/01/2025</span>
          </div>
          <div className="flex flex-col ml-5">
            <span className="font-semibold">Số lượng vị trí</span>
            <span>5</span>
          </div>
          <div className="flex flex-col ml-5">
            <span className="font-semibold">Số lượng ứng viên</span>
            <span>10</span>
          </div>
        </div>
      </div>
    </div>
  );
}

export default ContractDetails;
