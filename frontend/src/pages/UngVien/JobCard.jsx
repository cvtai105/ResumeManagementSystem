import React from 'react';
import './JobCard.css';
import jwtDecode from '../../utils/jwtDecode';
import getCookie from '../../utils/getCookie';

const hostImgURL = process.env.REACT_APP_IMAGE_URL;

const JobCard = ({ jobName, company, salaryRange, location, onClick }) => {
    console.log(`${hostImgURL}/DoanhNghiep/${company.id}.jpg`);
    return (
        <div className="job-card text-inherit" onClick={()=>onClick()}>
          <div className="job-card-left text-inherit">
            <img 
            src={`${hostImgURL}/DoanhNghiep/${company.id}.jpg`} 
            alt="Company Logo" 
            onError={(e)=>{e.target.onerror = null; e.target.src='%PUBLIC_URL%/default.png'}}
            className="company-logo" />
          </div>
          <div className="job-card-right text-inherit">
            <p className="job-title">{jobName}</p>
            <p className="company-name">{company.tenDoanhNghiep}</p>
            <div className="job-attributes text-inherit">
              <span className="salary">{salaryRange}</span>
              <span className="location">{location}</span>
            </div>
            
          </div>
        </div>
      );
};

export default JobCard;
