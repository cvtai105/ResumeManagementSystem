import React, {useState} from "react";
import ReactQuill from 'react-quill';
import 'react-quill/dist/quill.snow.css';

const modules = {
  toolbar: [
    [{ 'list': 'ordered' }],
    ['bold', 'italic', 'underline'],
  ],
  clipboard: {
    matchVisual: false,
  },
};

const formats = [
  'list',
  'bold', 'italic', 'underline',
  'indent'
];

const FormDangKyTuyenDungBuoc1 = ({ nextStep, handleChange, formData, setFormData }) => {
  const [errors, setErrors] = useState({});

  const handleQuillChange = (value) => {
    setFormData({ ...formData, criteria: value });
  };

  const validate = () => {
    let tempErrors = {};
    const today = new Date().toISOString().split('T')[0]; // Get today's date in YYYY-MM-DD format

    tempErrors.jobPosition = formData.jobPosition ? "" : "Vui lòng nhập vị trí tuyển dụng.";
    tempErrors.numberOfHires = formData.numberOfHires ? "" : "Vui lòng nhập số lượng tuyển dụng.";
    tempErrors.startDate = formData.startDate ? "" : "Vui lòng nhập ngày bắt đầu tuyển dụng.";
    tempErrors.endDate = formData.endDate ? "" : "Vui lòng nhập ngày kết thúc tuyển dụng.";
    tempErrors.endDate = formData.criteria ? "" : "Vui lòng nhập tiêu chí.";
    
    if (formData.startDate && formData.startDate < today) {
      tempErrors.startDate = "Ngày bắt đầu tuyển dụng không hợp lệ.";
    }

    if (formData.startDate && formData.endDate && formData.endDate <= formData.startDate) {
      tempErrors.endDate = "Ngày kết thúc tuyển dụng phải lớn hơn ngày bắt đầu tuyển dụng.";
    }

    setErrors(tempErrors);

    return Object.values(tempErrors).every(x => x === "");
  };

  const handleSubmit = () => {
    if (validate()) {
      nextStep();
    }
  };

  return (
    <div className="grid grid-cols-12 mt-10 mx-auto">
      <div className="container col-start-5 col-span-4 p-10 text-navy rounded-md shadow-lg space-y-5">
        <h2 className="text-xl font-bold mb-4">Mô Tả Công Việc</h2>
        <div className="mb-4">
          <label className="block font-semibold">Vị trí tuyển dụng*</label>
          <input
            type="text"
            className="mt-1 block w-full border border-smoke rounded-md p-1"
            value={formData.jobPosition}
            onChange={handleChange("jobPosition")}
          />
        </div>
        {errors.jobPosition && <p className="text-red">{errors.jobPosition}</p>}
        <div className="mb-4">
          <label className="block font-semibold">
            Số người muốn tuyển dụng cho công việc này*
          </label>
          <input
            type="number"
            className="mt-1 block w-full border border-smoke rounded-md p-1"
            value={formData.numberOfHires}
            onChange={handleChange("numberOfHires")}
          />
        </div>
        {errors.numberOfHires && <p className="text-red">{errors.numberOfHires}</p>}
        <div className="mb-4">
          <label className="block font-semibold">Ngày bắt đầu tuyển dụng*</label>
          <input
            type="date"
            className="mt-1 block w-full border border-smoke rounded-md p-1"
            value={formData.startDate}
            onChange={handleChange("startDate")}
          />
        </div>
        {errors.startDate && <p className="text-red">{errors.startDate}</p>}
        <div className="mb-4">
          <label className="block font-semibold">Ngày kết thúc tuyển dụng*</label>
          <input
            type="date"
            className="mt-1 block w-full border border-smoke rounded-md p-1"
            value={formData.endDate}
            onChange={handleChange("endDate")}
          />
        </div>
        {errors.endDate && <p className="text-red">{errors.endDate}</p>}
        <div className="mb-4">
          <label className="block font-semibold">Tiêu chí phù hợp</label>
          <ReactQuill
              value={formData.criteria}
              onChange={handleQuillChange}
              className="mt-1 block w-full border border-smoke rounded-md resize-y fixed-toolbar"
              modules={modules}
              formats={formats}
            />
            {errors.criteria && <p className="text-red">{errors.criteria}</p>}
        </div>
        <div className="flex justify-end">
          <button className="btn-dark justify-end" onClick={handleSubmit}>
            Tiếp theo
          </button>
        </div>
      </div>
    </div>
  );
};

export default FormDangKyTuyenDungBuoc1;
