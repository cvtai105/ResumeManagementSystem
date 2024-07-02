import React, {useContext, useState, useEffect} from 'react'
import FormDangKyTuyenDungBuoc1 from '../../components/FormDangKyTuyenDungBuoc1'
import FormDangKyTuyenDungBuoc2 from '../../components/FormDangKyTuyenDungBuoc2';
import FormDangKyTuyenDungBuoc3 from '../../components/FormDangKyTuyenDungBuoc3';
import axios from 'axios';
import { DoanhNghiepContext } from '../../fetchServices/DoanhNghiep/DoanhNghiepContext';

const hostApi = process.env.REACT_APP_API_URL;

const DangKyThongTinDangTuyen = () => {
    const [step, setStep] = useState(1);
    const { idDoanhNghiep } = useContext(DoanhNghiepContext);
    const [formData, setFormData] = useState({
      jobPosition: '',
      numberOfHires: '',
      startDate: '',
      endDate: '',
      criteria: '',
      postingType: '',
      postingDescription: '',
      postingDuration: '',
      doanhNghiepId: idDoanhNghiep,
      NhanVienKiemDuyet: null,
      UuDaiId: null
    });

    console.log(idDoanhNghiep);
    const nextStep = () => {
      setStep(step + 1);
    };
  
    const prevStep = () => {
      setStep(step - 1);
    };
  
    const handleChange = (input) => (e) => {
      setFormData({ ...formData, [input]: e.target.value });
    };

    
  

    const handleSubmit = () => {
      // Fetch the HinhThucDangTuyen ID based on the name
      axios.get(hostApi + `/hinhthucdangtuyen/name/${formData.postingType}`)
        .then(response => {
          const postingTypeId = response.data.id;
          const dataToSubmit = { ...formData, postingTypeId };
          axios.post(hostApi + '/dangkydangtuyen', dataToSubmit)
            .then(response => {
              console.log(response.data);
            })
            .catch(error => {
              console.error('There was an error!', error);
            });
        })
        .catch(error => {
          console.error('Error fetching the posting type', error);
        });
      }
  
    switch (step) {
      case 1:
        return <FormDangKyTuyenDungBuoc1 nextStep={nextStep} handleChange={handleChange} formData={formData} setFormData={setFormData}/>;
      case 2:
        return <FormDangKyTuyenDungBuoc2 nextStep={nextStep} prevStep={prevStep} handleChange={handleChange} formData={formData} setFormData={setFormData}/>;
      case 3:
        return <FormDangKyTuyenDungBuoc3 prevStep={prevStep} formData={formData} handleSubmit={handleSubmit}/>;
      default:
        return <div>Something went wrong</div>;
    }
}

export default DangKyThongTinDangTuyen