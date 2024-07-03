import React, { useState } from 'react';

function ListCompany({nextStep, handleChange, setFormData}) {
    const jobPosts = [
      { id: 1, code: 'itcom03112401', company: 'IT Company', startDate: '1/1/2024', endDate: '1/1/2024', position: 5, jobTitle: 'Fullstack Dev' },
      { id: 2, code: 'itcom03112401', company: 'IT Company', startDate: '1/1/2024', endDate: '1/1/2024', position: 16, jobTitle: 'Fullstack Dev' },
      { id: 3, code: 'itcom03112401', company: 'IT Company', startDate: '1/1/2024', endDate: '1/1/2024', position: 10, jobTitle: 'Fullstack Dev' },
      { id: 4, code: 'itcom03112401', company: 'IT Company', startDate: '1/1/2024', endDate: '1/1/2024', position: 11, jobTitle: 'Fullstack Dev' },
      { id: 5, code: 'itcom03112401', company: 'IT Company', startDate: '1/1/2024', endDate: '1/1/2024', position: 11, jobTitle: 'Fullstack Dev' },
      { id: 6, code: 'itcom03112401', company: 'IT Company', startDate: '1/1/2024', endDate: '1/1/2024', position: 1, jobTitle: 'Fullstack Dev' },
      { id: 7, code: 'itcom03112401', company: 'IT Company', startDate: '1/1/2024', endDate: '1/1/2024', position: 1, jobTitle: 'Fullstack Dev' },
      { id: 8, code: 'itcom03112401', company: 'IT Company', startDate: '1/1/2024', endDate: '1/1/2024', position: 2, jobTitle: 'Fullstack Dev' },
      { id: 9, code: 'itcom03112401', company: 'IT Company', startDate: '1/1/2024', endDate: '1/1/2024', position: 4, jobTitle: 'Fullstack Dev' },
      { id: 10, code: 'itcom03112401', company: 'IT Company', startDate: '1/1/2024', endDate: '1/1/2024', position: 5, jobTitle: 'Fullstack Dev' },
      { id: 11, code: 'itcom03112401', company: 'IT Company', startDate: '1/1/2024', endDate: '1/1/2024', position: 16, jobTitle: 'Fullstack Dev' },
      { id: 12, code: 'itcom03112401', company: 'IT Company', startDate: '1/1/2024', endDate: '1/1/2024', position: 10, jobTitle: 'Fullstack Dev' },
      { id: 13, code: 'itcom03112401', company: 'IT Company', startDate: '1/1/2024', endDate: '1/1/2024', position: 11, jobTitle: 'Fullstack Dev' },
      { id: 14, code: 'itcom03112401', company: 'IT Company', startDate: '1/1/2024', endDate: '1/1/2024', position: 11, jobTitle: 'Fullstack Dev' },
      { id: 15, code: 'itcom03112401', company: 'IT Company', startDate: '1/1/2024', endDate: '1/1/2024', position: 1, jobTitle: 'Fullstack Dev' },
      { id: 16, code: 'itcom03112401', company: 'IT Company', startDate: '1/1/2024', endDate: '1/1/2024', position: 1, jobTitle: 'Fullstack Dev' },
      { id: 17, code: 'itcom03112401', company: 'IT Company', startDate: '1/1/2024', endDate: '1/1/2024', position: 2, jobTitle: 'Fullstack Dev' },
      { id: 18, code: 'itcom03112401', company: 'IT Company', startDate: '1/1/2024', endDate: '1/1/2024', position: 4, jobTitle: 'Fullstack Dev' },
      { id: 1, code: 'itcom03112401', company: 'IT Company', startDate: '1/1/2024', endDate: '1/1/2024', position: 5, jobTitle: 'Fullstack Dev' },
      { id: 2, code: 'itcom03112401', company: 'IT Company', startDate: '1/1/2024', endDate: '1/1/2024', position: 16, jobTitle: 'Fullstack Dev' },
      { id: 3, code: 'itcom03112401', company: 'IT Company', startDate: '1/1/2024', endDate: '1/1/2024', position: 10, jobTitle: 'Fullstack Dev' },
      { id: 4, code: 'itcom03112401', company: 'IT Company', startDate: '1/1/2024', endDate: '1/1/2024', position: 11, jobTitle: 'Fullstack Dev' },
      { id: 5, code: 'itcom03112401', company: 'IT Company', startDate: '1/1/2024', endDate: '1/1/2024', position: 11, jobTitle: 'Fullstack Dev' },
      { id: 6, code: 'itcom03112401', company: 'IT Company', startDate: '1/1/2024', endDate: '1/1/2024', position: 1, jobTitle: 'Fullstack Dev' },
      { id: 7, code: 'itcom03112401', company: 'IT Company', startDate: '1/1/2024', endDate: '1/1/2024', position: 1, jobTitle: 'Fullstack Dev' },
      { id: 8, code: 'itcom03112401', company: 'IT Company', startDate: '1/1/2024', endDate: '1/1/2024', position: 2, jobTitle: 'Fullstack Dev' },
      { id: 9, code: 'itcom03112401', company: 'IT Company', startDate: '1/1/2024', endDate: '1/1/2024', position: 4, jobTitle: 'Fullstack Dev' },
      { id: 10, code: 'itcom03112401', company: 'IT Company', startDate: '1/1/2024', endDate: '1/1/2024', position: 5, jobTitle: 'Fullstack Dev' },
      { id: 11, code: 'itcom03112401', company: 'IT Company', startDate: '1/1/2024', endDate: '1/1/2024', position: 16, jobTitle: 'Fullstack Dev' },
      { id: 12, code: 'itcom03112401', company: 'IT Company', startDate: '1/1/2024', endDate: '1/1/2024', position: 10, jobTitle: 'Fullstack Dev' },
      { id: 13, code: 'itcom03112401', company: 'IT Company', startDate: '1/1/2024', endDate: '1/1/2024', position: 11, jobTitle: 'Fullstack Dev' },
      { id: 14, code: 'itcom03112401', company: 'IT Company', startDate: '1/1/2024', endDate: '1/1/2024', position: 11, jobTitle: 'Fullstack Dev' },
      { id: 15, code: 'itcom03112401', company: 'IT Company', startDate: '1/1/2024', endDate: '1/1/2024', position: 1, jobTitle: 'Fullstack Dev' },
      { id: 16, code: 'itcom03112401', company: 'IT Company', startDate: '1/1/2024', endDate: '1/1/2024', position: 1, jobTitle: 'Fullstack Dev' },
      { id: 17, code: 'itcom03112401', company: 'IT Company', startDate: '1/1/2024', endDate: '1/1/2024', position: 2, jobTitle: 'Fullstack Dev' },
      { id: 18, code: 'itcom03112401', company: 'IT Company', startDate: '1/1/2024', endDate: '1/1/2024', position: 4, jobTitle: 'Fullstack Dev' },
    ];
  
    const [currentPage, setCurrentPage] = useState(1);
    const itemsPerPage = 5;

    // Tính toán số trang
    const totalPages = Math.ceil(jobPosts.length / itemsPerPage);
  
    // Lọc dữ liệu cho trang hiện tại
    const currentData = jobPosts.slice((currentPage - 1) * itemsPerPage, currentPage * itemsPerPage);
  
    // Hàm chuyển trang
    const handlePageChange = (page) => {
      setCurrentPage(page);
    };
  
    // Thêm các hàng trống nếu cần thiết
    const emptyRows = itemsPerPage - currentData.length;
    const rows = [...currentData, ...Array(emptyRows).fill({})];
  
    // Hàm để hiển thị các nút pagination với dấu ...
    const renderPaginationButtons = () => {
      const paginationButtons = [];
      if (totalPages <= 3) {
        for (let i = 1; i <= totalPages; i++) {
          paginationButtons.push(
            <button
              key={i}
              className={"px-3 py-1 bg-blue-100 text-blue-600 rounded border border-blue-600"}
              onClick={() => handlePageChange(i)}
            >
              {i}
            </button>
          );
        }
      } else {
        
          paginationButtons.push(
            <button
              key={1}
              className={`px-3 py-1 rounded ${currentPage === 1 ? 'bg-gray-200 text-blue-500 border border-blue-300' : 'bg-white text-gray-700 border border-gray-300'}`}
              onClick={() => handlePageChange(1)}
            >
              1
            </button>
          );
          if (currentPage > 2 ) paginationButtons.push(<span>...</span>);
  
          if(currentPage > 1 && currentPage < totalPages){

            paginationButtons.push(
              <button
                key={currentPage}
                className={"px-3 py-1 bg-blue-100 text-blue-600 rounded border border-blue-600 "}
                onClick={() => handlePageChange(currentPage)}
              >
                {currentPage}
              </button>
            );
          }
          if (currentPage < totalPages - 1) paginationButtons.push(<span>...</span>);
          
          paginationButtons.push(
            <button
              key={totalPages}
              className={"px-3 py-1 bg-blue-100 text-blue-600 rounded border border-blue-600"}
              onClick={() => handlePageChange(totalPages)}
            >
              {totalPages}
            </button>
          );
      }
      return paginationButtons;
    };
  
    return (
    
      <div className="flex justify-center items-center mt-10 bg-gray-100">
        <div className="bg-white shadow-lg rounded-lg p-6 w-full max-w-4xl">
            <div className="flex items-center mb-5">
          <input 
            className="p-2 mr-2 rounded border border-gray-300" 
            type="text" 
            placeholder="Tìm kiếm" 
          />
          <button className="px-4 py-2 text-white rounded btn-dark text-sm">
            Tìm kiếm
          </button>
        </div>
          <div className="overflow-x-auto">
            <table className="min-w-full bg-white border border-gray-300">
              <thead>
                <tr>
                  <th className="px-6 py-3 border-b border-gray-300 text-left text-sm font-medium text-gray-700">Mã Hợp Đồng</th>
                  <th className="px-6 py-3 border-b border-gray-300 text-left text-sm font-medium text-gray-700 w-[200px]">Tên Công Ty</th>
                  <th className="px-6 py-3 border-b border-gray-300 text-left text-sm font-medium text-gray-700">Ngày Bắt Đầu</th>
                  <th className="px-6 py-3 border-b border-gray-300 text-left text-sm font-medium text-gray-700">Ngày Kết Thúc</th>
                  <th className="px-6 py-3 border-b border-gray-300 text-left text-sm font-medium text-gray-700">Số Vị Trí</th>
                  <th className="px-6 py-3 border-b border-gray-300 text-left text-sm font-medium text-gray-700 w-[200px]">Tên Công Việc</th>
                  <th className="px-6 py-3 border-b border-gray-300 text-left text-sm font-medium text-gray-700"></th>

                </tr>
              </thead>
              <tbody>
                {rows.map((row, index) => (
                  <tr key={index} className={`h-[42px]`}>
                    <td className="px-6  border-b border-gray-300 text-sm">{row.code}</td>
                    <td className="px-6  border-b border-gray-300 text-sm">{row.company}</td>
                    <td className="px-6  border-b border-gray-300 text-sm">{row.startDate}</td>
                    <td className="px-6  border-b border-gray-300 text-sm">{row.endDate}</td>
                    <td className="px-6  border-b border-gray-300 text-sm">{row.position}</td>
                    <td className="px-6  border-b border-gray-300 text-sm">{row.jobTitle}</td>
                    <td>
                      {
                        row.id ? 
                        <button onClick={nextStep} className='btn-dark py-1 px-2 rounded text-sm'>
                          Chọn
                        </button> : ''  
                      }
                    </td>
                  </tr>
                ))}
              </tbody>
            </table>
          </div>
          
          <div className="flex justify-center mt-4 space-x-2">
              <button className="px-3 py-1 bg-blue-100 text-blue-600 rounded border border-blue-600"
                onClick={() => handlePageChange(currentPage - 1)}
                disabled={currentPage === 1}
              >
                {'<'}
              </button>
              {renderPaginationButtons()}
              <button className="px-3 py-1 bg-blue-100 text-blue-600 rounded border border-blue-600"
                onClick={() => handlePageChange(currentPage + 1)}
                disabled={currentPage === totalPages}
              >
                {'>'}
              </button>
            </div>
            
        </div>
  
      </div>
    );
  }
  
  export default ListCompany;
