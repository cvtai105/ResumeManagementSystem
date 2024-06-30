import React, {useState} from 'react'
import FormDangKyTuyenDungBuoc1 from '../../components/FormDangKyTuyenDungBuoc1'
import FormDangKyTuyenDungBuoc2 from '../../components/FormDangKyTuyenDungBuoc2';
import FormDangKyTuyenDungBuoc3 from '../../components/FormDangKyTuyenDungBuoc3';

const DangKyThongTinDangTuyen = () => {
    const [step, setStep] = useState(1);
    const [formData, setFormData] = useState({
      jobPosition: '',
      numberOfHires: '',
      startDate: '',
      endDate: '',
      criteria: '',
      postingType: '',
      postingDescription: 'Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum',
      postingDuration: ''
    });
  
    const nextStep = () => {
      setStep(step + 1);
    };
  
    const prevStep = () => {
      setStep(step - 1);
    };
  
    const handleChange = (input) => (e) => {
      setFormData({ ...formData, [input]: e.target.value });
    };
  
    switch (step) {
      case 1:
        return <FormDangKyTuyenDungBuoc1 nextStep={nextStep} handleChange={handleChange} formData={formData} setFormData={setFormData}/>;
      case 2:
        return <FormDangKyTuyenDungBuoc2 nextStep={nextStep} prevStep={prevStep} handleChange={handleChange} formData={formData} />;
      case 3:
        return <FormDangKyTuyenDungBuoc3 prevStep={prevStep} formData={formData} />;
      default:
        return <div>Something went wrong</div>;
    }
}

export default DangKyThongTinDangTuyen