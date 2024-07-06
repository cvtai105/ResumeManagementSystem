import React, { useState, useEffect } from "react";
import axios from 'axios';
import { Outlet, NavLink, Link } from "react-router-dom";



const hostApi = process.env.REACT_APP_API_URL;

const PaymentForm = ({
  prevStep,
  formData,
  setFormData,
  handleSubmit,
}) => {
  const [paymentStep, setPaymentStep] = useState(1);
  const [totalAmount, setTotalAmount] = useState(0);
  const [displayAmount, setDisplayAmount] = useState(0);
  const [hinhThucThanhToan, setHinhThucThanhToan] = useState([]);
  const [errors, setErrors] = useState({});
  const [success, setSuccess] = useState(false);

  useEffect(() => {
    axios.get(hostApi + '/hinhthucthanhtoan')
      .then(response => {
        console.log(response.data);
        setHinhThucThanhToan(response.data);
      })
      .catch(error => {
        console.error('There was an error fetching the HinhThucThanhToan!', error);
      });
  }, []);

  useEffect(() => {
    // Tính tổng tiền thanh toán dựa trên bảng giá và thời gian đăng tuyển
    let rate = 0;
    console.log(formData.postingType)
    switch (formData.postingType) {
      case "Website Công Ty":
        rate = 20000;
        break;
      case "Báo Giấy":
        rate = 10000;
        break;
      case "Banner Quảng cáo":
        rate = 50000;
        break;
      default:
        rate = 0;
    }
    const total = rate * formData.postingDuration;
    setTotalAmount(total);
    setDisplayAmount(formData.paymentType === 'part' ? total * 0.3 : total);
    setFormData(prevFormData => ({
        ...prevFormData,
        totalAmount: total,
        installmentAmount: formData.paymentType === 'part' ? total * 0.3 : total,
        paymentType: 'all',
        paymentMethod: formData.paymentMethod,
      }));
  }, [formData.postingType, formData.postingDuration, formData.paymentType, setFormData]);

  const handleNext = () => {
    let tempErrors = {};
    if (!formData.paymentType) {
      tempErrors.paymentType = "Vui lòng chọn kiểu thanh toán.";
    }
    if (!formData.paymentMethod) {
      tempErrors.paymentMethod = "Vui lòng chọn hình thức thanh toán.";
    }
    setErrors(tempErrors);

    if (Object.keys(tempErrors).length === 0) {
      setPaymentStep(2);
    }
  };

  const handleConfirm = (e) => {
    e.preventDefault();
    handleSubmit();
    setSuccess(true);
  };

  return (
    <div>
      {!success ? (
        paymentStep === 1 ? (
          <div className="grid grid-cols-12 mt-10 mx-auto">
            <div className="container col-start-5 col-span-4 p-10 text-navy rounded-md shadow-lg space-y-5">
              <h2>Thanh Toán</h2>
              <label className="block font-semibold">Chọn kiểu thanh toán</label>
              <select
                onChange={(e) =>
                  setFormData({ ...formData, paymentType: e.target.value })
                }
                className="border border-smoke rounded-lg w-full p-2"
              >
                <option value="" disabled>Chọn kiểu thanh toán</option>
                <option value="part" disabled={formData.postingDuration <= 30} >Theo đợt</option>
                <option value="all">Toàn bộ</option>
              </select>
              {errors.paymentType && <p className="text-red">{errors.paymentType}</p>}
              <label className="block font-semibold">Chọn hình thức thanh toán</label>
              <select
                onChange={(e) =>
                  setFormData({ ...formData, paymentMethod: e.target.value })
                }
                className="border border-smoke rounded-lg w-full p-2"
              >
                {hinhThucThanhToan.map((type) => (
                  <option key={type.id} value={type.tenHinhThuc}>{type.tenHinhThuc}</option>
                ))}
              </select>
              {errors.paymentMethod && <p className="text-red">{errors.paymentMethod}</p>}
              <div className="flex justify-between">
                  <button onClick={prevStep} className="text-dodger-blue">Quay lại</button>
                  <button onClick={handleNext} className="btn-dark">Tiếp theo</button>
              </div> 
            </div>
          </div>
        ) : (
          <div className="grid grid-cols-12 mt-10 mx-auto">
            <div className="container col-start-5 col-span-4 p-10 text-navy rounded-md shadow-lg space-y-5">
              <h2>Thanh Toán</h2>
              {formData.paymentType === "part" ? (
                <p><strong>Tổng tiền thanh toán lần đầu:</strong> {displayAmount.toLocaleString()} đồng</p>
              ):
              (
                <p><strong>Tổng tiền thanh toán:</strong> {totalAmount.toLocaleString()} đồng</p>
              )}
              
              {formData.paymentMethod === "transfer" ? (
                <div className="flex flex-col gap-3">
                  <p className="text-3xl font-semibold">Thông Tin Ngân Hàng</p>
                  <p><strong>Ngân hàng:</strong> Vietcombank</p>
                  <p><strong>Số tài khoản:</strong> 123456789000</p>
                  <p><strong>Tên thụ hưởng:</strong> Công ty JobRepo</p>
                </div>
              ) : (
                <div> 
                  <p className="text-xl font-semibold mb-3">Thông Tin Thanh Toán Trực Tiếp</p>
                  <p><strong>Địa chỉ:</strong> 123 Đường ABC, Quận 1, TP. Hồ Chí Minh</p>
                </div>
              )}
              <div className="flex justify-between">
                <button onClick={() => setPaymentStep(1)} className="text-dodger-blue">Quay lại</button>
                <button onClick={handleConfirm} className="btn-dark">Xác nhận</button>
              </div>
            </div>
          </div>
        )
      ) : (
<div className="grid grid-cols-12 mt-10 mx-auto">
  <div className="container col-start-5 col-span-4 p-5 pb-20 text-navy rounded-md shadow-lg space-y-5 text-center">
    <h3 className="text-lg font-bold mb-4">Thông báo</h3>
    <p className="p-2 ">Vui lòng thực hiện thanh toán theo hình thức đã chọn.</p>            
  </div>
</div>

      )}
    </div>
  );
};

export default PaymentForm;
