import React, { useState, useEffect } from 'react';
import axios from 'axios';

function ListCompany({nextStep, handleChange, setFormData}) {
  let [jobPosts, setDangTuyens] = useState([]);

  const getFilteredDangTuyens = async () => {
    try {
        const response = await axios.get('http://localhost:5231/api/dangkydangtuyen/filter');
        return response.data;
    } catch (error) {
        console.error('Error fetching filtered dang tuyens:', error);
        throw error;
    }
};

useEffect(() => {
    const fetchData = async () => {
        try {
            const data = await getFilteredDangTuyens();
            setDangTuyens(data);
        } catch (error) {
            console.error('Error fetching companies:', error);
        }
    };

    fetchData();
}, []);

  

    const [currentPage, setCurrentPage] = useState(1);
    const itemsPerPage = 5;

    // Tính toán số trang
    const totalPages = Math.ceil(jobPosts.length / itemsPerPage);


    //if(jobPosts.length === 0) return (<div>sdsfsdfsdf</div>)
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
              className={`px-3 py-1 bg-blue-100 text-blue-600 rounded border text-sm border-blue-600 ${currentPage === 1 ? 'btn-dark' : ''}`}
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
              className={`px-3 py-1 bg-blue-100 text-blue-600 rounded border text-sm border-blue-600 ${currentPage === totalPages ? 'btn-dark' : ''}`}
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
                  <th className="px-6 py-3 border-b border-gray-300 text-left text-sm font-medium text-gray-700 w-[200px]">Ngày Bắt Đầu</th>
                  <th className="px-6 py-3 border-b border-gray-300 text-left text-sm font-medium text-gray-700 w-[200px]">Ngày Kết Thúc</th>
                  <th className="px-6 py-3 border-b border-gray-300 text-left text-sm font-medium text-gray-700 w-[200px]">Số Vị Trí</th>
                  <th className="px-6 py-3 border-b border-gray-300 text-left text-sm font-medium text-gray-700 w-[200px]">Tên Công Việc</th>
                  <th className="px-6 py-3 border-b border-gray-300 text-left text-sm font-medium text-gray-700"></th>

                </tr>
              </thead>
              <tbody>
                {rows.map((row, index) => (
                  <tr key={index} className={`h-[42px]`}>
                    <td className="px-6  border-b border-gray-300 text-sm">{row.id}</td>
                    <td className="px-6  border-b border-gray-300 text-sm">{row.tenDoanhNghiep}</td>
                    <td className="px-6  border-b border-gray-300 text-sm">{row.ngayBatDau}</td>
                    <td className="px-6  border-b border-gray-300 text-sm">{row.ngayKetThuc}</td>
                    <td className="px-6  border-b border-gray-300 text-sm">{row.soLuong}</td>
                    <td className="px-6  border-b border-gray-300 text-sm">{row.tenViTri}</td>
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
