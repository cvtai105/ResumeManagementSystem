import React from 'react';
import ListCriteria from './ListCriteria';
import ListDetailCV from './ListDetailCV';

function ReviewCV({ prevStep}) {
    return (
        <div className="grid grid-cols-4 center">
            <div className="col-span-2 ">
                <div className='flex justify-center'>
                    <ListDetailCV/>
                </div>
            </div>
            <div className="col-span-2">
                <div className='flex justify-center'>
                    <ListCriteria/>
                </div>
            </div>
            <div className="items-center justify-center center col-span-4">
                    <button className="px-6 py-2 mt-10 btn-dark text-white rounded" onClick={prevStep}>
                        Đánh giá
                    </button>
                </div>
        </div>
    );
}

export default ReviewCV;