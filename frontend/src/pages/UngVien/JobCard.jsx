import React from 'react';
import './JobCard.css';

const JobCard = ({ jobName, company, salaryRange, location, onClick }) => {
    return (
        <div className="job-card text-inherit" onClick={()=>onClick()}>
          <div className="job-card-left text-inherit">
            <img src={company.image} alt="Company Logo" className="company-logo" />
          </div>
          <div className="job-card-right text-inherit">
            <p className="job-title">{jobName}</p>
            <p className="company-name">{company.name}</p>
            <div className="job-attributes text-inherit">
              <span className="salary">{salaryRange}</span>
              <span className="location">{location}</span>
            </div>
            
          </div>
        </div>
      );
};

export default JobCard;
