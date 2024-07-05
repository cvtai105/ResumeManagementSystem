import React, {useState} from 'react';
import ListCriteria from './ListCriteria';
import ListDetailCV from './ListDetailCV';
import axios from 'axios';
function ReviewCV({ prevStep, formData}) {
    const updateApplicationStatus = async (applicationId, newStatus) => {
        try {
          const response = await axios.put(`http://localhost:5231/api/ungtuyen/update/${applicationId}`, {
            status: newStatus
          });
          console.log(response.data);
        } catch (error) {
          console.error('Error updating application status:', error);
        }
      };
    const [review, setReview] = useState(null);
    const handleButtonClick = () => {
        // Chuyển sang trang khác sau khi thay đổi companyId
        //prevStep();
        
        updateApplicationStatus(formData.registrationId, review ? "Đạt" : "Không đạt");
        prevStep();
      };
    return (
        <div className="grid grid-cols-4 center">
            <div className="col-span-2 ">
                <div id='test'></div>
                <div className='flex justify-center'>
                    <ListDetailCV formData={formData}/>
                </div>
            </div>
            <div className="col-span-2">
                <div className='flex justify-center'>
                    <ListCriteria setReview={setReview} formData={formData}/>
                </div>
            </div>
            <div className="items-center justify-center center col-span-4">
                    <button className="px-6 py-2 mt-10 btn-dark text-white rounded" onClick={() => handleButtonClick()}>
                        Đánh giá
                    </button>
                </div>
        </div>
    );
}

export default ReviewCV;