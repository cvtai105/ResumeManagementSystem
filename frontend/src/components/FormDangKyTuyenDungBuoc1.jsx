import React from "react";
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
  const handleQuillChange = (value) => {
    setFormData({ ...formData, criteria: value });
  };
  return (
    <div className="grid grid-cols-12 mt-10 mx-auto min-h-screen">
      <div className="container col-start-5 col-span-4 p-10 text-navy rounded-md shadow-lg space-y-5">
        <h2 className="text-xl font-bold mb-4">Mô Tả Công Việc</h2>
        <div className="mb-4">
          <label className="block font-semibold">Vị trí tuyển dụng</label>
          <input
            type="text"
            className="mt-1 block w-full border border-smoke rounded-md p-1"
            value={formData.jobPosition}
            onChange={handleChange("jobPosition")}
          />
        </div>
        <div className="mb-4">
          <label className="block font-semibold">
            Số người muốn tuyển dụng cho công việc này
          </label>
          <input
            type="number"
            className="mt-1 block w-full border border-smoke rounded-md p-1"
            value={formData.numberOfHires}
            onChange={handleChange("numberOfHires")}
          />
        </div>
        <div className="mb-4">
          <label className="block font-semibold">Ngày bắt đầu tuyển dụng*</label>
          <input
            type="date"
            className="mt-1 block w-full border border-smoke rounded-md p-1"
            value={formData.startDate}
            onChange={handleChange("startDate")}
          />
        </div>
        <div className="mb-4">
          <label className="block font-semibold">Ngày kết thúc tuyển dụng*</label>
          <input
            type="date"
            className="mt-1 block w-full border border-smoke rounded-md p-1"
            value={formData.endDate}
            onChange={handleChange("endDate")}
          />
        </div>
        <div className="mb-4">
          <label className="block font-semibold">Tiêu chí phù hợp</label>
          <ReactQuill
              value={formData.criteria}
              onChange={handleQuillChange}
              className="mt-1 block w-full border border-smoke rounded-md resize-y fixed-toolbar"
              modules={modules}
              formats={formats}
            />
        </div>
        <div className="flex justify-end">
          <button className="btn-dark justify-end" onClick={nextStep}>
            Tiếp theo
          </button>
        </div>
      </div>
    </div>
  );
};

export default FormDangKyTuyenDungBuoc1;
