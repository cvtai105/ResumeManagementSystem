import React, { useEffect, useState } from "react";
import { toast } from "react-toastify";
import axios from "axios";
import "./XacThucDangKy.css";

const data = [
  {
    id: "itcom03112401",
    company: "IT Company",
    taxCode: "01 23456789 - 001",
    representative: "Nguyễn A",
    address: "12 Nguyễn Huệ, Q1, TPHCM",
    email: "abc@gmail.com",
  },
  {
    id: "itcom03112402",
    company: "IT Company",
    taxCode: "01 23456789 - 002",
    representative: "Nguyễn B",
    address: "12 Nguyễn Huệ, Q1, TPHCM",
    email: "abc@gmail.com",
  },
  {
    id: "itcom03112403",
    company: "IT Company",
    taxCode: "01 23456789 - 003",
    representative: "Nguyễn C",
    address: "12 Nguyễn Huệ, Q1, TPHCM",
    email: "abc@gmail.com",
  },
  {
    id: "itcom03112404",
    company: "IT Company",
    taxCode: "01 23456789 - 004",
    representative: "Nguyễn D",
    address: "12 Nguyễn Huệ, Q1, TPHCM",
    email: "abc@gmail.com",
  },
  {
    id: "itcom03112405",
    company: "IT Company",
    taxCode: "01 23456789 - 005",
    representative: "Nguyễn E",
    address: "12 Nguyễn Huệ, Q1, TPHCM",
    email: "abc@gmail.com",
  },
  {
    id: "itcom03112406",
    company: "IT Company",
    taxCode: "01 23456789 - 006",
    representative: "Nguyễn F",
    address: "12 Nguyễn Huệ, Q1, TPHCM",
    email: "abc@gmail.com",
  },
  {
    id: "itcom03112407",
    company: "IT Company",
    taxCode: "01 23456789 - 007",
    representative: "Nguyễn G",
    address: "12 Nguyễn Huệ, Q1, TPHCM",
    email: "abc@gmail.com",
  },
  {
    id: "itcom03112408",
    company: "IT Company",
    taxCode: "01 23456789 - 008",
    representative: "Nguyễn H",
    address: "12 Nguyễn Huệ, Q1, TPHCM",
    email: "abc@gmail.com",
  },
  {
    id: "itcom03112409",
    company: "IT Company",
    taxCode: "01 23456789 - 009",
    representative: "Nguyễn I",
    address: "12 Nguyễn Huệ, Q1, TPHCM",
    email: "abc@gmail.com",
  },
  // Các đối tượng khác...
];

const XacThucDangKy = () => {
  const [data, setData] = useState([]);

  useEffect(() => {
    const fetchData = async () => {
      try {
        const response = await axios.get(
          "http://localhost:5231/api/dangkydoanhnghiep/danhsach"
        );
        setData(response.data); // Update the state with fetched data
      } catch (error) {
        console.error("Error fetching doanh nghiep list:", error);
      }
    };
    fetchData();
    console.log(data);
  }, []);

  const handleVerify = async (id) => {
    try {
      await axios.patch(
        `http://localhost:5231/api/dangkydoanhnghiep/${id}/true`
      );
      toast.success("Đã xác nhận thành công", {
        autoClose: 8000, // Set to 8 seconds
      });
      window.location.reload();
    } catch (error) {
      toast.error("Có lỗi xảy ra khi xác thực: " + error.message, {
        autoClose: 8000, // Set to 8 seconds
      });
    }
  };

  const handleReject = async (id) => {
    try {
      await axios.patch(
        `http://localhost:5231/api/dangkydoanhnghiep/${id}/false`
      );
      toast.error("Đã từ chối thành công");
      window.location.reload();
    } catch (error) {
      toast.error("Có lỗi xảy ra khi từ chối:", error);
    }
  };

  return (
    <div>
      <p className="text-3xl font-semibold text-center mt-6 mb-2">
        Doanh nghiệp đăng ký thành viên
      </p>
      <div className="grid grid-cols-12">
        <div className="col-span-10 col-start-3">
          <input type="text" placeholder="Tìm kiếm" className="search-bar" />
          <table className="data-table">
            <thead>
              <tr>
                <th>Mã Công Ty</th>
                <th>Công Ty</th>
                <th>Mã Số Thuế</th>
                <th>Đại Diện</th>
                <th>Địa Chỉ</th>
                <th>Email</th>
                <th>Hành động</th>
              </tr>
            </thead>
            <tbody>
              {data.map((row, index) => (
                <tr key={index}>
                  <td>{row.id}</td>
                  <td>{row.tenDoanhNghiep}</td>
                  <td>{row.maSoThue}</td>
                  <td>{row.nguoiDaiDien}</td>
                  <td>{row.diaChi}</td>
                  <td>{row.email}</td>
                  <td>
                    <button
                      className="verify"
                      onClick={() => handleVerify(row.id)}
                    >
                      Xác thực
                    </button>
                    <button
                      className="reject"
                      onClick={() => handleReject(row.id)}
                    >
                      Từ chối
                    </button>
                  </td>
                </tr>
              ))}
            </tbody>
          </table>
        </div>
      </div>
      <div className="pagination">
        <button>&lt;</button>
        <button>1</button>
        <button>2</button>
        <button>...</button>
        <button>9</button>
        <button>10</button>
        <button>&gt;</button>
      </div>
    </div>
  );
};

export default XacThucDangKy;
