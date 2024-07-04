import React from 'react';
import ContractDetails from './ContractDetail';
import RegistrationDetails from './RegisterDetail';
import ListRegister from './ListRegister';
function ChooseRegister({nextStep, prevStep, formData, setFormData}) {
    return (
        <div className="grid grid-cols-5 center">
            <div className=" col-span-3 center">
                <ContractDetails  jobId={formData.companyId}/>
                <ListRegister registerId={formData.companyId}/>
                <div className="flex items-center ml-[90px]">
                    <button className="px-4 py-2 mt-10 btn-dark text-white rounded" onClick={prevStep}>
                        Trở lại
                    </button>
                </div>
            </div>
            <div className='col-span-2 flex justify-center items-center'>
                <RegistrationDetails nextStep={nextStep} setFormData={setFormData}/>
            </div>

        </div>
    );
}

export default ChooseRegister;
