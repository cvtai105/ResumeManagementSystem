import React, { useEffect, useState } from "react";
import "./DangKyThanhVienDoanhNghiep.css";
import { toast } from "react-toastify";
import axios from "axios";
const pcVN = require("pc-vn");
const province1 = pcVN.getProvinces();

const hostApi = process.env.REACT_APP_API_URL;

const DangKyThanhVienDoanhNghiep = () => {
  const [province, setProvince] = useState("");
  const [district, setDistrict] = useState("");
  const [ward, setWard] = useState("");
  const [districts, setDistricts] = useState([]);
  const [wards, setWards] = useState([]);

  const [tendoanhnghiep, setTendoanhnghiep] = useState("");
  const [masothue, setMasothue] = useState("");
  const [nguoidaidien, setNguoidaidien] = useState("");
  const [email, setEmail] = useState("");
  const [matkhau, setMatKhau] = useState("");
  const [dienthoai, setDienthoai] = useState("");
  const [diachi, setDiachi] = useState("");

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

  const handleSubmit = async (e) => {
    e.preventDefault();

    if (
      !tendoanhnghiep ||
      !masothue ||
      !nguoidaidien ||
      !dienthoai ||
      !diachi ||
      !ward ||
      !district ||
      !province ||
      !email ||
      !matkhau
    ) {
      toast.error("Điền thiếu thông tin");
      return;
    }

    const currentDate = new Date().toISOString();

    const data = {
      TenDoanhNghiep: tendoanhnghiep,
      MaSoThue: masothue,
      NguoiDaiDien: nguoidaidien,
      DienThoai: dienthoai,
      NhanVienDangKyId: 0,
      DiaChi: diachi + "," + ward + "," + district + "," + province,
      XacNhan: true,
      Email: email,
      MatKhau: matkhau,
      NgayDangKy: currentDate,
    };
    console.log(data);
    await axios
      .post(hostApi + "/dangkydoanhnghiep", data)
      .then((response) => {
        console.log(response);
        toast.success("Đã ghi nhận thông tin đăng ký");
        window.location.href = "/doanhnghiep/dangnhap";
      })
      .catch((err) => {
        console.log(err);
        toast.error("Lỗi trong quá trình đăng ký");
      });
  };

  return (
    <div>
      <div className="registration-form-container">
        <p>Đăng Ký Thành Viên Doanh Nghiệp</p>
        <form className="registration-form" onSubmit={handleSubmit}>
          <div className="form-group">
            <label htmlFor="companyName">Tên công ty</label>
            <input
              type="text"
              id="companyName"
              required="required"
              name="companyName"
              placeholder="ABC"
              onChange={(e) => setTendoanhnghiep(e.target.value)}
            />
          </div>
          <div className="form-group">
            <label htmlFor="taxId">Mã số thuế</label>
            <input
              type="text"
              id="taxId"
              name="taxId"
              placeholder="01 23456789 - 001"
              onChange={(e) => setMasothue(e.target.value)}
            />
          </div>
          <div className="form-group">
            <label htmlFor="representative">Người đại diện</label>
            <input
              type="text"
              id="representative"
              name="representative"
              placeholder="Nguyen Van A"
              onChange={(e) => setNguoidaidien(e.target.value)}
            />
          </div>
          <div className="form-group">
            <label htmlFor="email">Email</label>
            <input
              type="email"
              id="email"
              required="required"
              name="email"
              placeholder="abc@email.com"
              onChange={(e) => setEmail(e.target.value)}
            />
          </div>
          <div className="form-group">
            <label htmlFor="matkhau">Mật khẩu</label>
            <input
              type="text"
              id="matkhau"
              name="matkhau"
              placeholder="abc@12345"
              onChange={(e) => setMatKhau(e.target.value)}
            />
          </div>
          <div className="form-group">
            <label htmlFor="dienthoai">Số điện thoại</label>
            <input
              type="text"
              id="dienthoai"
              name="dienthoai"
              placeholder="0123456789"
              onChange={(e) => setDienthoai(e.target.value)}
            />
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
              <option value="">Chọn tỉnh/thành phố</option>
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
              <option value="">Chọn quận/huyện</option>
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
              <option value="">Chọn phường/xã</option>
              {wards.map((ward, i) => (
                <option key={i} value={ward.name}>
                  {ward.name}
                </option>
              ))}
            </select>
          </div>

          <div className="form-group">
            <label htmlFor="address">Địa chỉ</label>
            <input
              type="text"
              id="address"
              name="address"
              placeholder="123, toa A, duong XYZ"
              onChange={(e) => setDiachi(e.target.value)}
            />
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
