import React from "react";
import Footer from "../../components/Footer";
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
  {
    id: "itcom03112410",
    company: "IT Company",
    taxCode: "01 23456789 - 010",
    representative: "Nguyễn J",
    address: "12 Nguyễn Huệ, Q1, TPHCM",
    email: "abc@gmail.com",
  },
];

const XacThucDangKy = () => {
  return (
    <div>
      <h1>Doanh nghiệp đăng ký thành viên</h1>;
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
                <th>A</th>
              </tr>
            </thead>
            <tbody>
              {data.map((row, index) => (
                <tr key={index}>
                  <td>{row.id}</td>
                  <td>{row.company}</td>
                  <td>{row.taxCode}</td>
                  <td>{row.representative}</td>
                  <td>{row.address}</td>
                  <td>{row.email}</td>
                  <td>
                    <button className="verify">Xác thực</button>
                    <button className="reject">Từ chối</button>
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
      <Footer></Footer>
    </div>
  );
};

export default XacThucDangKy;
