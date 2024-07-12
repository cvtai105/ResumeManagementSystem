import React from 'react';
import './JobCard.css';
import jwtDecode from '../../utils/jwtDecode';
import getCookie from '../../utils/getCookie';

const hostImgURL = process.env.REACT_APP_IMAGE_URL;

const JobCard = ({ jobName, company, salaryRange, location, onClick }) => {
    return (
        <div className="job-card text-inherit" onClick={()=>onClick()}>
          <div className="job-card-left text-inherit">
            <img 
            src={`${hostImgURL}/DoanhNghiep/${company.id}.jpg`} 
            alt="Company Logo" 
            className="company-logo"
            onError={(e)=>{
              e.target.onerror = null;
              e.target.src = `companyDefault.jpg`;
            }} />
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
