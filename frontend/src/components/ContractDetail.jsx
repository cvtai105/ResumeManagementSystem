import React, {useState, useEffect} from 'react';
import axios from 'axios';
function ContractDetails({jobId}) {
  const [jobPost, setJobPost] = useState(null);
  useEffect(() => {
    axios.get(`http://localhost:5231/api/dangkydangtuyen/${jobId}`)
      .then(response => {
        setJobPost(response.data);
      })
      .catch(error => {
        console.error("There was an error fetching the job post!", error);
      });
  }, []);
  if (!jobPost) {
    return <div>Loading...</div>;
  }
  return (
    <div className="flex justify-left ml-[90px] items-center mt-5 ">
      <div className="bg-white shadow-lg rounded-lg p-8 max-w-2xl w-full">
        <h3 className="text-xl font-bold mb-5">HỢP ĐỒNG: {jobPost.id}</h3>
        
        <div className="grid grid-cols-2 gap-4 center ">
          <div className="flex flex-col ml-5">
            <span className="font-semibold">Tên công ty</span>
            <span>{jobPost.doanhNghiep.tenDoanhNghiep}</span>
          </div>
          <div className="flex flex-col ml-5">
            <span className="font-semibold">Ngày bắt đầu</span>
            <span>{jobPost.ngayBatDau ? new Date(jobPost.ngayBatDau).toLocaleDateString('vn') : ''}</span>
          </div>
          <div className="flex flex-col ml-5">
            <span className="font-semibold">Tên công việc</span>
            <span>{jobPost.tenViTri}</span>
          </div>
          <div className="flex flex-col ml-5">
            <span className="font-semibold">Ngày kết thúc</span>
            <span>{jobPost.ngayKetThuc ? new Date(jobPost.ngayKetThuc).toLocaleDateString('vn') : ''}</span>
          </div>
          <div className="flex flex-col ml-5">
            <span className="font-semibold">Số lượng vị trí</span>
            <span>{jobPost.soLuong}</span>
          </div>
          <div className="flex flex-col ml-5">
            <span className="font-semibold">Số lượng ứng viên</span>
            <span>{jobPost.soLuongUngVien}</span>
          </div>
        </div>
      </div>
    </div>
  );
}

export default ContractDetails;
