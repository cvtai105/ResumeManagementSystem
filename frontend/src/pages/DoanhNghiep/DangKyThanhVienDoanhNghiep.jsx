import React, { useEffect, useState } from "react";
import Select from "react-select";
import "./DangKyThanhVienDoanhNghiep.css";
const pcVN = require("pc-vn");
const province1 = pcVN.getProvinces();

const DangKyThanhVienDoanhNghiep = () => {
  const [province, setProvince] = useState("");
  const [district, setDistrict] = useState("");
  const [ward, setWard] = useState("");
  const [districts, setDistricts] = useState([]);
  const [wards, setWards] = useState([]);

  useEffect(() => {
    console.log(province);
    console.log(districts);
    console.log(wards);
  }, [province, districts, wards]);

  const handleProvinceChange = (value) => {
    const code = province1.find((obj) => value === obj.name).code;
    setDistricts(pcVN.getDistrictsByProvinceCode(code));
    setProvince(value);
  };

  const handleDistrictChange = (value) => {
    const code = districts.find((obj) => obj.name === value).code;
    setDistrict(value);
    setWards(pcVN.getWardsByDistrictCode(code));
  };

  return (
    <div>
      <div className="registration-form-container">
        <h2>Đăng Ký Thành Viên Doanh Nghiệp</h2>
        <form className="registration-form">
          <div className="form-group">
            <label htmlFor="companyName">Tên công ty</label>
            <input type="text" id="companyName" name="companyName" />
          </div>
          <div className="form-group">
            <label htmlFor="taxId">Mã số thuế</label>
            <input type="text" id="taxId" name="taxId" />
          </div>
          <div className="form-group">
            <label htmlFor="representative">Người đại diện</label>
            <input type="text" id="representative" name="representative" />
          </div>
          <div className="form-group">
            <label htmlFor="email">Email</label>
            <input type="email" id="email" name="email" />
          </div>
          <div className="form-group">
            <label htmlFor="city">Tỉnh/Thành phố</label>
            <select
              name="city"
              id="city"
              onChange={(e) => {
                handleProvinceChange(e.target.value);
              }}
              value={province}
            >
              {province1.map((pro, i) => (
                <option key={i} value={pro.name}>
                  {pro.name}
                </option>
              ))}
            </select>
          </div>
          <div className="form-group">
            <label htmlFor="district">Quận/Huyện</label>
            <select
              id="district"
              name="district"
              onChange={(e) => {
                handleDistrictChange(e.target.value);
              }}
              value={district}
            >
              {districts.map((district, i) => (
                <option key={i} value={district.name}>
                  {district.name}
                </option>
              ))}
            </select>
          </div>
          <div className="form-group">
            <label htmlFor="ward">Phường/Xã</label>
            <select
              id="ward"
              name="ward"
              value={ward}
              onChange={(e) => setWard(e.target.value)}
            >
              {wards.map((ward, i) => (
                <option key={i} value={ward.name}>
                  {ward.name}
                </option>
              ))}
            </select>
          </div>
          <div className="form-group">
            <label htmlFor="address">Địa chỉ</label>
            <input type="text" id="address" name="address" />
          </div>
          <button type="submit" className="submit-button">
            Đăng ký
          </button>
        </form>
      </div>
    </div>
  );
};

export default DangKyThanhVienDoanhNghiep;
