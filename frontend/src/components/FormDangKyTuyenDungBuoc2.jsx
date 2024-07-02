import React, {useState, useEffect} from "react";
import axios from 'axios';

const hostApi = process.env.REACT_APP_API_URL;

const FormDangKyTuyenDungBuoc2 = ({
  nextStep,
  prevStep,
  handleChange,
  formData,
  setFormData
}) => {
  const [errors, setErrors] = React.useState({});
  const [hinhThucDangTuyen, setHinhThucDangTuyen] = useState([]);

  useEffect(() => {
    axios.get(hostApi + '/hinhthucdangtuyen')
      .then(response => {
        setHinhThucDangTuyen(response.data);
      })
      .catch(error => {
        console.error('There was an error fetching the HinhThucDangTuyen!', error);
      });
  }, []);

  const validate = () => {
    let tempErrors = {};
    tempErrors.postingType = formData.postingType ? "" : "Vui lòng chọn hình thức đăng tuyển.";
    tempErrors.postingDuration = formData.postingDuration ? "" : "Vui lòng nhập thời gian đăng tuyển.";
    setErrors(tempErrors);

    return Object.values(tempErrors).every(x => x === "");
  };

  const handleSubmit = () => {
    if (validate()) {
      nextStep();
    }
  };

  const handleTypeChange = (e) => {
    const selectedType = e.target.value;
    const selectedDescription = hinhThucDangTuyen.find((type) => type.tenHinhThuc === selectedType)?.moTa || "";
    setFormData({ ...formData, postingType: selectedType, postingDescription: selectedDescription });
  };

  return (
    <div className="grid grid-cols-12 mt-10 mx-auto">
      <div className="container col-start-5 col-span-4 p-10 text-navy rounded-md shadow-lg space-y-5">
        <h2 className="text-xl font-bold mb-4">Hình Thức Và Thời Gian Đăng Tuyển</h2>
        <label className="block font-semibold">Hình thức đăng tuyển</label>
        <select
          className="border border-smoke rounded-lg w-full p-2"
          value={formData.postingType}
          onChange={handleTypeChange}
        >
          <option value="" disabled>Chọn hình thức</option>
          {hinhThucDangTuyen.map((type) => (
            <option key={type.id} value={type.tenHinhThuc}>{type.tenHinhThuc}</option>
          ))}
        </select>
        {errors.postingType && <p className="text-red">{errors.postingType}</p>}
        <label className="block font-semibold">Mô tả hình thức đăng tuyển</label>
        <p>{formData.postingDescription}</p>
        <label className="block font-semibold">Thời gian đăng tuyển</label>
        <div className="relative">
          <input
            type="number"
            className="mt-1 block w-full border border-smoke rounded-md p-2 pr-12"
            value={formData.postingDuration}
            onChange={handleChange('postingDuration')}
          />
          <span className="absolute inset-y-0 right-0 flex items-center pr-3 text-smoke">ngày</span>
        </div>
        {errors.postingDuration && <p className="text-red">{errors.postingDuration}</p>}
        <div className="flex justify-between">
          <button onClick={prevStep} className="text-dodger-blue">
            Quay lại
          </button>
          <button onClick={handleSubmit} className="btn-dark">
            Tiếp theo
          </button>
        </div>
      </div>
    </div>
  );
};

export default FormDangKyTuyenDungBuoc2;
