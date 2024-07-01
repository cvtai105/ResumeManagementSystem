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
      postingDescription: '',
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
        return <FormDangKyTuyenDungBuoc2 nextStep={nextStep} prevStep={prevStep} handleChange={handleChange} formData={formData} setFormData={setFormData}/>;
      case 3:
        return <FormDangKyTuyenDungBuoc3 prevStep={prevStep} formData={formData} />;
      default:
        return <div>Something went wrong</div>;
    }
}

export default DangKyThongTinDangTuyen