import React, { useState } from "react";
import ReactQuill from "react-quill";
import "react-quill/dist/quill.snow.css";

const modules = {
  toolbar: [[{ list: "ordered" }], ["bold", "italic", "underline"]],
  clipboard: {
    matchVisual: false,
  },
};

const formats = ["list", "bold", "italic", "underline", "indent"];

const FormDangKyTuyenDungBuoc1 = ({
  nextStep,
  handleChange,
  formData,
  setFormData,
}) => {
  const [errors, setErrors] = useState({});
  const [negotiable, setNegotiable] = useState(false);

  const handleCriteriaChange = (value) => {
    setFormData({ ...formData, criteria: value });
  };

  const handleDescriptionChange = (value) => {
    setFormData({ ...formData, jobDescription: value });
  };

  

  const validate = () => {
    let tempErrors = {};

    tempErrors.jobPosition = formData.jobPosition
      ? ""
      : "Vui lòng nhập vị trí tuyển dụng.";
    tempErrors.numberOfHires = formData.numberOfHires
      ? ""
      : "Vui lòng nhập số lượng tuyển dụng.";

    tempErrors.jobDescription = formData.jobDescription ? "" : "Vui lòng nhập mô tả.";

    tempErrors.criteria = formData.criteria ? "" : "Vui lòng nhập tiêu chí.";

    if(!negotiable && formData.minSalary == null && formData.maxSalary == null){
      tempErrors.salary = "Vui lòng chọn mức lương.";
    }

    setErrors(tempErrors);

    return Object.values(tempErrors).every((x) => x === "");
  };

  const handleSubmit = () => {
    if (validate()) {
      nextStep();
    }
  };

  const handleNegotiableChange = (event) => {
    const isChecked = event.target.checked;
    setFormData({
      ...formData,
      negotiable: isChecked,
      minSalary: isChecked ? '' : formData.minSalary,
      maxSalary: isChecked ? '' : formData.maxSalary,
    });
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
        {errors.numberOfHires && (
          <p className="text-red">{errors.numberOfHires}</p>
        )}
        <div className="mb-4">
          <label className="block font-semibold">Mô tả công việc</label>
          <ReactQuill
            value={formData.jobDescription}
            onChange={handleDescriptionChange}
            className="mt-1 block w-full border border-smoke rounded-md resize-y fixed-toolbar"
            modules={modules}
            formats={formats}
          />
        </div>
        {errors.jobDescription && (
          <p className="text-red">{errors.jobDescription}</p>
        )}
       
       <div className="mb-4">
          <label className="block font-semibold">Mức lương</label>
          <div className="flex space-x-4">
            <div className="flex-1">
              <label className="block font-semibold">Từ</label>
              <input
                type="number"
                className="mt-1 block w-full border border-smoke rounded-md p-1"
                value={formData.minSalary}
                onChange={handleChange('minSalary')}
                disabled={formData.negotiable}
              />
            </div>
            <div className="flex-1">
              <label className="block font-semibold">Đến</label>
              <input
                type="number"
                className="mt-1 block w-full border border-smoke rounded-md p-1"
                value={formData.maxSalary}
                onChange={handleChange('maxSalary')}
                disabled={formData.negotiable}
              />
            </div>
          </div>
          <div className="mt-2">
            <label className="inline-flex items-center">
              <input
                type="checkbox"
                className="form-checkbox"
                checked={formData.negotiable}
                onChange={handleNegotiableChange}
              />
              <span className="ml-2">Mức lương thỏa thuận</span>
            </label>
          </div>
        </div>
        {errors.salary && (
          <p className="text-red">{errors.salary}</p>
        )}

        {/* <div className="mb-4">
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
        {errors.endDate && <p className="text-red">{errors.endDate}</p>} */}
        <div className="mb-4">
          <label className="block font-semibold">Tiêu chí phù hợp</label>
          <ReactQuill
            value={formData.criteria}
            onChange={handleCriteriaChange}
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
