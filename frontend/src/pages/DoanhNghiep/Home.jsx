import React, { useState, useEffect } from 'react';
import { Link } from 'react-router-dom';

const Home = () => {
  const [recruitments, setRecruitments] = useState([]);

  const simulatedData = [
    { id: 1, title: 'Frontend Developer', salaryRange: '20-30M', applyCount: 10, need: 3, deadline: '2024-12-31'},
    { id: 2, title: 'Backend Developer', salaryRange: '25-35M', applyCount: 5, need: 1, deadline: '2024-12-31'},
    { id: 3, title: 'UX/UI Designer', salaryRange: '18-25M', applyCount: 8, need: 2, deadline: '2024-12-31'},
  ];

  useEffect(() => {
    // Set the simulated data when the component mounts
    setRecruitments(simulatedData);
  }, []);

  return (
    <div className="flex flex-col mx-20 mt-10">
      <p className="text-3xl font-bold mb-4">Tin đăng tuyển của công ty</p>
      <div className="grid gap-4">
        {recruitments.map(job => (
          <Link to={"recruitments/" + job.id} key={job.id} className="border p-4 rounded shadow hover:bg-grey cursor-pointer">
            <p className="text-2xl font-bold">{job.title}</p>
            <p className="text-gray-700">Mức lương: {job.salaryRange}</p>
            <p className="text-gray-700">Số ứng viên/Số lượng tuyển: {job.applyCount} / {job.need}</p>
            <p className="text-gray-700">Hạn: {job.deadline}</p>
          </Link>
        ))}
        {recruitments.length === 0 && (
          <p className="text-gray-600">Không có tin tuyển dụng hiện tại.</p>
        )}
      </div>
    </div>
  );
};

export default Home;
