import React from 'react';
import './index.css';
import { FaChevronLeft, FaChevronRight } from 'react-icons/fa';

const Pagination = ({ currentPage, totalPages, onPageChange }) => {
  return (
    <div className="pagination">
      <button
        className="pagination-btn"
        disabled={currentPage === 1}
        onClick={() => onPageChange(currentPage - 1)}
      >
        <FaChevronLeft size={20} />
      </button>
      <div className='mx-1'></div>
      <span className="pagination-info">
        {currentPage} / {totalPages} trang
      </span>
      
      <div className='mx-1'></div>
      <button
        className="pagination-btn"
        disabled={currentPage === totalPages}
        onClick={() => onPageChange(currentPage + 1)}
      >
        
        <FaChevronRight size={20} />
      </button>
    </div>
  );
};

export default Pagination;
