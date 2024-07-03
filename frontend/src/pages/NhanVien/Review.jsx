import ListCompany from '../../components/ListCompany'
import React, {useState} from 'react'
import ChooseRegister from '../../components/ChooseRegister';
import ReviewCV from '../../components/ReviewCV'
const Review = () => {
    const [step, setStep] = useState(1);
    const [formData, setFormData] = useState({
      companyId: '',
      employeeId: '',
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
        return <ListCompany nextStep={nextStep} handleChange={handleChange} formData={formData}/>;
      case 2:
        return <ChooseRegister nextStep={nextStep} prevStep={prevStep} handleChange={handleChange} formData={formData} />;
      case 3:
        return <ReviewCV prevStep={prevStep} formData={formData} />;
      default:
        return <div>Something went wrong</div>;
    }
}

export default Review