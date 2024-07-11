import React, { useState, useEffect } from "react";
import axios from "axios";
function DataTable({ registerId, handleRowClick, step }) {
  let [data, setDangTuyens] = useState([]);

  const getUngTuyenByIdDangTuyen = async (registerId) => {
    try {
      const response = await axios.get(
        `http://localhost:5231/api/ungtuyen/danhsach/${registerId}`
      );
      return response.data;
    } catch (error) {
      console.error("Error fetching filtered dang tuyens:", error);
      throw error;
    }
  };

  useEffect(() => {
    const fetchData = async () => {
      try {
        const temp = await getUngTuyenByIdDangTuyen(registerId);
        setDangTuyens(temp);
      } catch (error) {
        console.error("Error fetching companies:", error);
      }
    };

    fetchData();
  }, [registerId, step]);
  const [currentPage, setCurrentPage] = useState(1);
  const itemsPerPage = 5;

  // Tính toán số trang
  const totalPages = Math.ceil(data.length / itemsPerPage);

  // Lọc dữ liệu cho trang hiện tại
  const currentData = data.slice(
    (currentPage - 1) * itemsPerPage,
    currentPage * itemsPerPage
  );

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
            className={`px-3 py-1 bg-blue-100 text-blue-600 rounded border border-blue-600 text-sm ${
              currentPage === i ? "btn-dark" : ""
            }`}
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
          className={`px-3 py-1 bg-blue-100 text-blue-600 rounded border border-blue-600 text-sm ${
            currentPage === 1 ? "btn-dark" : ""
          }`}
          onClick={() => handlePageChange(1)}
        >
          1
        </button>
      );
      if (currentPage > 2) paginationButtons.push(<span>...</span>);

      if (currentPage > 1 && currentPage < totalPages) {
        paginationButtons.push(
          <button
            key={currentPage}
            className={
              "px-3 py-1 bg-blue-100 text-blue-600 rounded border border-blue-600 btn-dark text-sm"
            }
            onClick={() => handlePageChange(currentPage)}
          >
            {currentPage}
          </button>
        );
      }
      if (currentPage < totalPages - 1)
        paginationButtons.push(<span>...</span>);

      paginationButtons.push(
        <button
          key={totalPages}
          className={`px-3 py-1 bg-blue-100 text-blue-600 rounded border border-blue-600 text-sm ${
            currentPage === totalPages ? "btn-dark" : ""
          }`}
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
                <th className="px-6 py-3 border border-gray-300 text-left text-sm font-medium text-gray-700 bg-grey">
                  Mã Ứng Tuyển
                </th>
                <th className="px-6 py-3 border border-gray-300 text-left text-sm font-medium text-gray-700 bg-grey">
                  Mã NV Duyệt Phiếu
                </th>
                <th className="px-6 py-3 border border-gray-300 text-left text-sm font-medium text-gray-700 bg-grey">
                  Mã Ứng Viên
                </th>
                <th className="px-6 py-3 border border-gray-300 text-left text-sm font-medium text-gray-700 bg-grey">
                  Ngày Lập Phiếu
                </th>
                <th className="px-6 py-3 border border-gray-300 text-left text-sm font-medium text-gray-700 bg-grey">
                  Trạng thái
                </th>
              </tr>
            </thead>
            <tbody>
              {rows.map((row, index) => (
                <tr
                  key={index}
                  className="h-[42px]"
                  onClick={() => handleRowClick(row)}
                >
                  <td className="px-6  border border-gray-300 text-sm">
                    {row.id}
                  </td>
                  <td className="px-6  border border-gray-300 text-sm">
                    {row.nhanVienKiemDuyenId}
                  </td>
                  <td className="px-6  border border-gray-300 text-sm">
                    {row.ungVienId}
                  </td>
                  <td className="px-6  border border-gray-300 text-sm">
                    {row.idm ?
                      row.ngayUngTuyen ? 
                      new Date(row.ngayUngTuyen).toLocaleDateString("vn") : ''
                      : ""}
                  </td>
                  <td className="px-6  border border-gray-300 text-sm">
                    {row.id
                      ? row.trangThai
                        ? row.trangThai
                        : "Chưa xử lý"
                      : ""}
                  </td>
                </tr>
              ))}
            </tbody>
          </table>
        </div>

        <div className="flex justify-center mt-4 space-x-2">
          <button
            className="px-3 py-1 bg-blue-100 text-blue-600 rounded border border-blue-600"
            onClick={() => handlePageChange(currentPage - 1)}
            disabled={currentPage === 1}
          >
            {"<"}
          </button>
          {renderPaginationButtons()}
          <button
            className="px-3 py-1 bg-blue-100 text-blue-600 rounded border border-blue-600"
            onClick={() => handlePageChange(currentPage + 1)}
            disabled={currentPage === totalPages}
          >
            {">"}
          </button>
        </div>
      </div>
    </div>
  );
}

export default DataTable;
