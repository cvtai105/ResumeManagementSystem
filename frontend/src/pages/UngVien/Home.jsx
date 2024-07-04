import React, {useEffect, useState} from "react";
import SearchBar from "./SearchBar";
import JobCard from "./JobCard";
import Pagination from "../../components/Pagination";

function Home() {
    const jobData = [
        {
          jobName: "Nhân Viên Bán Hàng Tại Showroom",
          company: { image: "https://picsum.photos/200", name: "Công Ty TNHH Holsun" },
          salaryRange: "9 - 15 triệu",
          location: "Hà Nội, Hồ Chí Minh"
        },
        {
          jobName: "Kỹ Sư Phần Mềm",
          company: { image: "https://picsum.photos/200", name: "Công Ty ABC" },
          salaryRange: "20 - 30 triệu",
          location: "Đà Nẵng"
        },
        {
          jobName: "Nhân Viên Marketing",
          company: { image: "https://picsum.photos/200", name: "Công Ty XYZ" },
          salaryRange: "10 - 15 triệu",
          location: "Hồ Chí Minh"
        },
        {
          jobName: "Trưởng Phòng Kinh Doanh",
          company: { image: "https://picsum.photos/200", name: "Công Ty DEF" },
          salaryRange: "30 - 40 triệu",
          location: "Hà Nội"
        },
        {
          jobName: "Nhân Viên Chăm Sóc Khách Hàng",
          company: { image: "https://picsum.photos/200", name: "Công Ty GHI" },
          salaryRange: "7 - 10 triệu",
          location: "Cần Thơ"
        },
        {
          jobName: "Lập Trình Viên Frontend",
          company: { image: "https://picsum.photos/200", name: "Công Ty JKL" },
          salaryRange: "15 - 20 triệu",
          location: "Hà Nội"
        },
        {
          jobName: "Thiết Kế Đồ Họa",
          company: { image: "https://picsum.photos/200", name: "Công Ty MNO" },
          salaryRange: "12 - 18 triệu",
          location: "Hồ Chí Minh"
        },
        {
          jobName: "Nhân Viên Kế Toán",
          company: { image: "https://picsum.photos/200", name: "Công Ty PQR" },
          salaryRange: "8 - 12 triệu",
          location: "Đà Nẵng"
        }
    ];

    const [currentPage, setCurrentPage] = useState(1);
    const [totalPages, setTotalPages] = useState(20);
    
    return (
        <>
        <div className="flex justify-center items-center mt-6">
            <SearchBar />
        </div>
        <div className="px-44">
            <div className="flex justify-between items-center mt-6">
                <h3 className="text-2xl font-semibold text-dodger-blue">Việc làm mới</h3>
                <Pagination onPageChange={(x)=>setCurrentPage(x)} currentPage={currentPage} totalPages={totalPages}/>
            </div>
            <div className="job-card-grid text-sm">
            {jobData.map((job, index) => (
                <JobCard
                key={index}
                jobName={job.jobName}
                company={job.company}
                salaryRange={job.salaryRange}
                location={job.location}
                />
            ))}
            </div>
        </div>
        
        </>
    );
}

export default Home;
