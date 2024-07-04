import React, { useState } from 'react';
function DataTable({formData}) {
  const data = [
    {
      contractCode: 'itcom03122401',
      employeeCode: 'mvdpt102938',
      applicantCode: '0000000000000',
      registrationCode: 'mvdpt102938',
      creationDate: '1/1/2024',
      evaluation: '50%'
    },
    {
      contractCode: 'itcom03122401',
      employeeCode: 'mvdpt102939',
      applicantCode: '0000000000001',
      registrationCode: 'mvdpt102939',
      creationDate: '1/1/2024',
      evaluation: '60%'
    },
    {
      contractCode: 'itcom03122401',
      employeeCode: 'mvdpt102940',
      applicantCode: '0000000000002',
      registrationCode: 'mvdpt102940',
      creationDate: '1/1/2024',
      evaluation: '70%'
    },
    {
      contractCode: 'itcom03122401',
      employeeCode: 'mvdpt102941',
      applicantCode: '0000000000003',
      registrationCode: 'mvdpt102941',
      creationDate: '1/1/2024',
      evaluation: '80%'
    },
    {
      contractCode: 'itcom03122401',
      employeeCode: 'mvdpt102942',
      applicantCode: '0000000000004',
      registrationCode: 'mvdpt102942',
      creationDate: '1/1/2024',
      evaluation: '90%'
    },
    {
      contractCode: 'itcom03122401',
      employeeCode: 'mvdpt102938',
      applicantCode: '0000000000000',
      registrationCode: 'mvdpt102938',
      creationDate: '1/1/2024',
      evaluation: '50%'
    },
    {
      contractCode: 'itcom03122401',
      employeeCode: 'mvdpt102939',
      applicantCode: '0000000000001',
      registrationCode: 'mvdpt102939',
      creationDate: '1/1/2024',
      evaluation: '60%'
    },
    {
      contractCode: 'itcom03122401',
      employeeCode: 'mvdpt102940',
      applicantCode: '0000000000002',
      registrationCode: 'mvdpt102940',
      creationDate: '1/1/2024',
      evaluation: '70%'
    },
    {
      contractCode: 'itcom03122401',
      employeeCode: 'mvdpt102941',
      applicantCode: '0000000000003',
      registrationCode: 'mvdpt102941',
      creationDate: '1/1/2024',
      evaluation: '80%'
    },
    {
      contractCode: 'itcom03122401',
      employeeCode: 'mvdpt102942',
      applicantCode: '0000000000004',
      registrationCode: 'mvdpt102942',
      creationDate: '1/1/2024',
      evaluation: '90%'
    },
    {
      contractCode: 'itcom03122401',
      employeeCode: 'mvdpt102940',
      applicantCode: '0000000000002',
      registrationCode: 'mvdpt102940',
      creationDate: '1/1/2024',
      evaluation: '70%'
    },
    {
      contractCode: 'itcom03122401',
      employeeCode: 'mvdpt102941',
      applicantCode: '0000000000003',
      registrationCode: 'mvdpt102941',
      creationDate: '1/1/2024',
      evaluation: '80%'
    },
    {
      contractCode: 'itcom03122401',
      employeeCode: 'mvdpt102942',
      applicantCode: '0000000000004',
      registrationCode: 'mvdpt102942',
      creationDate: '1/1/2024',
      evaluation: '90%'
    },
    {
      contractCode: 'itcom03122401',
      employeeCode: 'mvdpt102938',
      applicantCode: '0000000000000',
      registrationCode: 'mvdpt102938',
      creationDate: '1/1/2024',
      evaluation: '50%'
    },
    {
      contractCode: 'itcom03122401',
      employeeCode: 'mvdpt102939',
      applicantCode: '0000000000001',
      registrationCode: 'mvdpt102939',
      creationDate: '1/1/2024',
      evaluation: '60%'
    },
    {
      contractCode: 'itcom03122401',
      employeeCode: 'mvdpt102940',
      applicantCode: '0000000000002',
      registrationCode: 'mvdpt102940',
      creationDate: '1/1/2024',
      evaluation: '70%'
    },
    {
      contractCode: 'itcom03122401',
      employeeCode: 'mvdpt102942',
      applicantCode: '0000000000004',
      registrationCode: 'mvdpt102942',
      creationDate: '1/1/2024',
      evaluation: '90%'
    },
    {
      contractCode: 'itcom03122401',
      employeeCode: 'mvdpt102938',
      applicantCode: '0000000000000',
      registrationCode: 'mvdpt102938',
      creationDate: '1/1/2024',
      evaluation: '50%'
    },
    {
      contractCode: 'itcom03122401',
      employeeCode: 'mvdpt102939',
      applicantCode: '0000000000001',
      registrationCode: 'mvdpt102939',
      creationDate: '1/1/2024',
      evaluation: '60%'
    },
    {
      contractCode: 'itcom03122401',
      employeeCode: 'mvdpt102940',
      applicantCode: '0000000000002',
      registrationCode: 'mvdpt102940',
      creationDate: '1/1/2024',
      evaluation: '70%'
    },
    {
      contractCode: 'itcom03122401',
      employeeCode: 'mvdpt102941',
      applicantCode: '0000000000003',
      registrationCode: 'mvdpt102941',
      creationDate: '1/1/2024',
      evaluation: '80%'
    },
    {
      contractCode: 'itcom03122401',
      employeeCode: 'mvdpt102942',
      applicantCode: '0000000000004',
      registrationCode: 'mvdpt102942',
      creationDate: '1/1/2024',
      evaluation: '90%'
    },
    {
      contractCode: 'itcom03122401',
      employeeCode: 'mvdpt102940',
      applicantCode: '0000000000002',
      registrationCode: 'mvdpt102940',
      creationDate: '1/1/2024',
      evaluation: '70%'
    },
    {
      contractCode: 'itcom03122401',
      employeeCode: 'mvdpt102941',
      applicantCode: '0000000000003',
      registrationCode: 'mvdpt102941',
      creationDate: '1/1/2024',
      evaluation: '80%'
    },
    {
      contractCode: 'itcom03122401',
      employeeCode: 'mvdpt102942',
      applicantCode: '0000000000004',
      registrationCode: 'mvdpt102942',
      creationDate: '1/1/2024',
      evaluation: '90%'
    },
    {
      contractCode: 'itcom03122401',
      employeeCode: 'mvdpt102938',
      applicantCode: '0000000000000',
      registrationCode: 'mvdpt102938',
      creationDate: '1/1/2024',
      evaluation: '50%'
    },
    {
      contractCode: 'itcom03122401',
      employeeCode: 'mvdpt102939',
      applicantCode: '0000000000001',
      registrationCode: 'mvdpt102939',
      creationDate: '1/1/2024',
      evaluation: '60%'
    },
    {
      contractCode: 'itcom03122401',
      employeeCode: 'mvdpt102940',
      applicantCode: '0000000000002',
      registrationCode: 'mvdpt102940',
      creationDate: '1/1/2024',
      evaluation: '70%'
    },
  ];
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
    
    <div className="flex ml-[90px] items-center mt-10 bg-gray-100">
      <div className="bg-white shadow-lg rounded-lg p-6 w-full max-w-4xl">
          <div className="flex items-center mb-5">
          <input 
            className="p-2 mr-2 rounded border border-gray-300" 
            type="text" 
            placeholder="Tìm kiếm" 
          />
          <button className="px-4 py-2 btn-dark text-white rounded text-sm">
            Tìm kiếm
          </button>
        </div>
        <div className="overflow-x-auto">
          <table className="min-w-full bg-white border custom-border">
            <thead>
              <tr>
                <th className="px-6 py-3 border border-gray-300 text-left text-sm font-medium text-gray-700 bg-grey">Mã Hợp Đồng</th>
                <th className="px-6 py-3 border border-gray-300 text-left text-sm font-medium text-gray-700 bg-grey">Mã NV Duyệt Phiếu</th>
                <th className="px-6 py-3 border border-gray-300 text-left text-sm font-medium text-gray-700 bg-grey">Mã Ứng Viên</th>
                <th className="px-6 py-3 border border-gray-300 text-left text-sm font-medium text-gray-700 bg-grey">Mã PĐK Ứng Tuyển</th>
                <th className="px-6 py-3 border border-gray-300 text-left text-sm font-medium text-gray-700 bg-grey">Ngày Lập Phiếu</th>
                <th className="px-6 py-3 border border-gray-300 text-left text-sm font-medium text-gray-700 bg-grey">Đánh Giá</th>
              </tr>
            </thead>
            <tbody>
              {rows.map((row, index) => (
                <tr key={index} className="h-[42px]">
                  <td className="px-6  border border-gray-300 text-sm">{row.contractCode}</td>
                  <td className="px-6  border border-gray-300 text-sm">{row.employeeCode}</td>
                  <td className="px-6  border border-gray-300 text-sm">{row.applicantCode}</td>
                  <td className="px-6  border border-gray-300 text-sm">{row.registrationCode}</td>
                  <td className="px-6  border border-gray-300 text-sm">{row.creationDate}</td>
                  <td className="px-6  border border-gray-300 text-sm">{row.evaluation}</td>
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

export default DataTable;
