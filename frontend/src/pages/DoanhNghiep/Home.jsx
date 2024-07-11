import React, { useState, useEffect } from 'react';
import { Link } from 'react-router-dom';
import JobCard from './JobCard.jsx'
import useFetch from '../../hooks/useFetch';
import formateDate from '../../utils/formateDate.js';
import { getDoanhNghiepId } from '../../utils/getUserId.js';
const hostApi = process.env.REACT_APP_API_URL;

const Home = () => {
  const doanhNghiepId = getDoanhNghiepId();

  const {data, loading, error} = useFetch(`${hostApi}/recruitments/for-company/${doanhNghiepId}`);

  const jobData = data || [];

  //sort by id desc
  jobData.sort((a, b) => b.id - a.id);
  console.log(jobData);

  

  return (
    <>
      <div className="px-44 mt-4 min-h-screen bg-f7f7f7">
            <div className="flex justify-between items-center">
                <h3 className="text-2xl font-semibold text-dodger-blue">Tin Đăng Tuyển của công ty</h3>
            </div>
            <div className="flex flex-col gap-4 text-sm">
            {jobData.map((job, index) => (
                <JobCard
                key={job.id}
                jobName={job.tenViTri}
                salaryRange={job.mucLuong}
                expiredDate={formateDate(job.ngayKetThuc)}
                applicantsCount={job.ungTuyens.length}
                positionCount={job.soLuong}
                applications={job.ungTuyens}
                />
            ))}
            </div>
        </div>
      </>
  );
};

export default Home;
