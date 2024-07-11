import React, { useState } from 'react';
import { FaListUl, FaDollarSign, FaCalendarAlt, FaUsers, FaBriefcase, FaEnvelope, FaFileAlt,FaBirthdayCake  } from 'react-icons/fa'; // Ensure you have react-icons installed
import formateDate from '../../utils/formateDate';

const hostUngVienImgUrl = process.env.REACT_APP_UNGVIENIMAGE_URL;
const hostCVUrl = process.env.REACT_APP_CV_URL;

const JobCard = ({ jobName, salaryRange, expiredDate, positionCount ,applicantsCount, applications }) => {
  const [showApplications, setShowApplications] = useState(false);

  const handleToggle = () => {
    setShowApplications(!showApplications);
  };
  const [hasReloadImage, setHasReloadImage] = useState(false);  

 

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
                    <span>{expiredDate == ""? "Chờ duyệt" : expiredDate}</span>
                  </div>
                  <hr className="mx-2 border border-gray-300 h-6" />
                  <div className="flex-2 flex items-center">
                    <FaUsers className="mr-2" />
                    <span>{applicantsCount} ứng viên / {positionCount} vị trí </span>
                  </div>
                </div>
                <FaListUl className="ml-4 text-gray-500 hover:text-gray-700" />
              </div>
              { applications.length !== 0 &&
              <div className={`overflow-hidden ${showApplications ? 'animate-expand' : 'animate-collapse'}`}>
                <div className="p-4 border border-t-0 border-gray-300 rounded-b-md">
                  {applications.map((application, index) => (
                    <div key={index} className="grid grid-cols-10 gap-4 p-2 border-b border-gray-200 last:border-0 items-center">
                      <div className="col-span-1">
                        { hasReloadImage && <img
                            src={'%PUBLIC_URL%/default.png'}
                            alt="Avatar"
                            className="w-12 h-12 rounded-full"
                        />}
                        { !hasReloadImage &&
                            <img
                            src={`${hostUngVienImgUrl}/${application.avatar}`}
                            className="w-12 h-12 rounded-full"
                            onError={(e) => {
                                setHasReloadImage(true);
                                console.log(1234567);
                            }}
                        />
                        }
                            
                      </div>
                      <div className="col-span-2">
                        <span className="font-medium">{application?.ungVien?.hoTen}</span>
                      </div>
                      <div className="col-span-2 flex items-center space-x-2">
                        <FaBirthdayCake className="text-gray-500" />
                        <span>{formateDate(application?.ungVien?.ngaySinh)}</span>
                      </div>
                      <div className="col-span-2 flex items-center space-x-2">
                        <FaEnvelope className="text-gray-500" />
                        <a href={`mailto:${application?.ungVien?.email}`} className="text-blue-500 hover:underline">{application?.ungVien?.email}</a>
                      </div>
                      <div className="col-span-2 flex items-center justify-center">
                        <FaFileAlt className="text-gray-500" />
                            <a href={`${hostCVUrl}/${application.hoSoUngTuyens[0]?.fileHoSo}`} target="_blank" rel="noopener noreferrer" className="ml-2 text-blue-500 hover:underline">CV.pdf</a>
                        </div>
                        <div className="col-span-1">
                        <span className="font-medium">{application.trangThai == ''? 'Chưa xử lý': application.trangThai }</span>
                      </div>
                    </div>
                  ))}
                </div>
              </div>
}
            </div>
            
          );
        };

export default JobCard;
