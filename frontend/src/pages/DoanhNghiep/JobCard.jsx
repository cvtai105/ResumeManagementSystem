import React, { useState } from 'react';
import { FaListUl, FaDollarSign, FaCalendarAlt, FaUsers, FaBriefcase } from 'react-icons/fa'; // Ensure you have react-icons installed

const hostImgURL = process.env.REACT_APP_IMAGE_URL;

const JobCard = ({ jobName, salaryRange, expiredDate, applicantsCount, applications }) => {
  const [showApplications, setShowApplications] = useState(false);

  //fake data
  applications = [
    { name: 'John Doe', status: 'Applied' },
    { name: 'Jane Doe', status: 'Rejected' },
    { name: 'John Smith', status: 'Hired' },
  ];
  

  const handleToggle = () => {
    setShowApplications(!showApplications);
  };

  return (
    <div>
      <div 
        className="flex items-center p-4 border border-gray-300 rounded-md cursor-pointer" 
        onClick={handleToggle}
      >
        <div className="flex-grow flex">
          <div className="flex-4 flex items-center">
            <FaBriefcase className="mr-2" />
            <span className="font-semibold">{jobName}</span>
          </div>
          <hr className="mx-2 border border-gray-300 h-6" />
          <div className="flex-2 flex items-center">
            <FaDollarSign className="mr-2" />
            <span>{salaryRange}</span>
          </div>
          <hr className="mx-2 border border-gray-300 h-6" />
          <div className="flex-2 flex items-center">
            <FaCalendarAlt className="mr-2" />
            <span>{expiredDate}</span>
          </div>
          <hr className="mx-2 border border-gray-300 h-6" />
          <div className="flex-2 flex items-center">
            <FaUsers className="mr-2" />
            <span>{applicantsCount} Applicants</span>
          </div>
        </div>
        <FaListUl className="ml-4 text-gray-500 hover:text-gray-700" />
      </div>
      <div className={`overflow-hidden ${showApplications ? 'animate-expand' : 'animate-collapse'}`}>
        <div className="p-4 border border-t-0 border-gray-300 rounded-b-md">
          {applications?.map((application, index) => (
            <div key={index} className="application-item p-2 border-b border-gray-200 last:border-0">
              {application.name} - {application.status}
            </div>
          ))}
        </div>
      </div>
    </div>
  );
};

export default JobCard;
