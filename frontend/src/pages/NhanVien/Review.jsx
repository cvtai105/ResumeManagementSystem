import ListCompany from '../../components/ListCompany'
import React, {useState} from 'react'
import ChooseRegister from '../../components/ChooseRegister';
import ReviewCV from '../../components/ReviewCV'
import axios from 'axios';



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
    const getFilteredDangTuyens = async () => {
      try {
        const response = await axios.get('/api/dangkydangtuyen/filter');
        return response.data;
      } catch (error) {
        console.error('Error fetching filtered dang tuyens:', error);
        throw error;
      }
    };
    switch (step) {
      case 1:
        return <ListCompany nextStep={nextStep} handleChange={handleChange} formData={formData} getFilteredDangTuyens={getFilteredDangTuyens}/>;
      case 2:
        return <ChooseRegister nextStep={nextStep} prevStep={prevStep} handleChange={handleChange} formData={formData}/>;
      case 3:
        return <ReviewCV prevStep={prevStep} formData={formData} />;
      default:
        return <div>Something went wrong</div>;
    }
}

export default Review