import React, { useState } from 'react';
import '../index.css'
function ListDetailCV() {
  const data = [
        {
            id: 1,
            name: "IELTS",
            discription: "IELST 7.0"

        },
        {
            id: 2,
            name: "IELTS",
            discription: "IELST 7.0"

        },
        {
            id: 3,
            name: "IELTS",
            discription: "IELST 7.0"

        },
        {
            id: 4,
            name: "IELTS",
            discription: "IELST 7.0"

        },
    ]
  const [currentPage, setCurrentPage] = useState(1);
    const itemsPerPage = 5;

    // Tính toán số trang
    const totalPages = Math.ceil(data.length / itemsPerPage);
  
    // Lọc dữ liệu cho trang hiện tại
    const currentData = data.slice((currentPage - 1) * itemsPerPage, currentPage * itemsPerPage);
  
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
              className={`px-3 py-1 bg-blue-100 text-blue-600 rounded border border-blue-600 text-sm ${currentPage === i ? 'btn-dark' : ''}`}
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
              className={`px-3 py-1 bg-blue-100 text-blue-600 rounded border border-blue-600 text-sm ${currentPage === 1 ? 'btn-dark' : ''}`}
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
                className={"px-3 py-1 bg-blue-100 text-blue-600 rounded border border-blue-600 btn-dark text-sm"}
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
              className={`px-3 py-1 bg-blue-100 text-blue-600 rounded border border-blue-600 text-sm ${currentPage === totalPages ? 'btn-dark' : ''}`}
              onClick={() => handlePageChange(totalPages)}
            >
              {totalPages}
            </button>
          );
      }
      return paginationButtons;
    };
  return (
    <div className="flex justify-right items-center mt-20 bg-gray-100 ">
      <div className="bg-white shadow-lg rounded-lg p-6 w-full max-w-4xl">
        <div className="overflow-x-auto">
          <table className="min-w-full bg-white border custom-border">
            <thead>
              <tr>
                <th className="bg-grey px-6 py-3 border border-gray-300 text-left text-sm font-medium text-gray-700">Số thứ tự</th>
                <th className="bg-grey px-6 py-3 border border-gray-300 text-left text-sm font-medium text-gray-700">Tên chi tiết hồ sơ</th>
                <th className="bg-grey px-6 py-3 border border-gray-300 text-left text-sm font-medium text-gray-700">Mô tả thêm</th>
              </tr>
            </thead>
            <tbody>
              {rows.map((row, index) => (
                <tr key={index} className="h-[42px]">
                  <td className="px-6  border border-gray-300 text-sm">{row.id}</td>
                  <td className="px-6  border border-gray-300 text-sm">{row.name}</td>
                  <td className="px-6  border border-gray-300 text-sm">{row.discription}</td>
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

export default ListDetailCV;
