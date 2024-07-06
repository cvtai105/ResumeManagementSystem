import React, { useState, useRef, useEffect } from 'react';
import validateEmail from '../../utils/validateEmail';
import validatePhoneNumber from '../../utils/validatePhoneNumber';
import { AiOutlineInfoCircle } from 'react-icons/ai';
import useFetch from '../../hooks/useFetch';

const hostApi = process.env.REACT_APP_API_URL;


const ApplyModal = ({ setModalOpen, job, userId, setHasApplied }) => {
    const boxRef = useRef(null);
    // const [useMyInfo, setUseMyInfo] = useState(false);
    const {data: user, loading} = useFetch(`${hostApi}/ungvien/${userId}`);
    
    const [formData, setFormData] = useState({
        cv_file: null,
        name: user?.hoTen || '',
        email: user?.email || '',
        phone: user?.soDienThoai || '',
    });

    useEffect(() => {
        setFormData({
            cv_file: formData.cv_file,
            name: user?.hoTen || '',
            email: user?.email || '',
            phone: user?.soDienThoai || '',
        });
    }, [user]);


    const [fileName, setFileName] = useState(null);
    
    // function handleUseMyInfoChange(e) {
    //     setUseMyInfo(e.target.checked);
    //     console.log(useMyInfo);
    //     if(useMyInfo){
    //         setFormData( {
    //             name: '',
    //             phone: '',
    //             email: '',
    //             cv_file: formData.cv_file
    //         });
    //     }
    //     else{
    //         setFormData({
    //             name: 'Chu Văn Tài',
    //             phone: '0321231232',
    //             email: 'x@x.com',
    //             cv_file: formData.cv_file
    //         });
    //     }

    //     console.log(formData);
    // }
    
    const handleClickOutside = (event) => {
      if (boxRef.current && !boxRef.current.contains(event.target)) {
        setModalOpen(false);
      }
    };
  
    useEffect(() => {
      document.addEventListener("click", handleClickOutside);
    }, []);
  
    

    const handleInputChange = (e) => {
        e.preventDefault();
        const { name, value, files } = e.target;
        if (name === 'cv_file' && files.length > 0) {
            setFileName(files[0].name);
            const file = files[0];
            if (file.size > 5 * 1024 * 1024) {
                alert('File size should be less than 5MB');
                setFileName('');
                setFormData({ ...formData, cv_file: null });
                return;
            }
        }
        setFormData({
          ...formData,
          [name]: files ? files[0] : value
        });
    };

    const handleSubmit = (e) => {
        e.preventDefault();
      
        // Check if any required field is null or empty
        if ( !formData.cv_file ){
          alert('Vui lòng chọn file CV');
          return;
        }
        if( loading){
            alert('Đang lấy thông tin của bạn, vui lòng đợi');
            return;
        }
        
        console.log(formData);
        
        const sendRequest = async () => {
            const form = new FormData();
            form.append('cv', formData.cv_file);
            form.append('name', formData.name);
            form.append('email', formData.email);
            form.append('phone', formData.phone);
            form.append('dangTuyenId', `${job.id}`);
            const response = await fetch(`${hostApi}/ungtuyen/create`, {
                method: 'POST',
                body: form,
            });
            const data = await response.json();
            console.log(data);
            if (response.ok) {
                alert('Ứng tuyển thành công');
                setHasApplied(true);
                window.location.reload();
                setModalOpen(false);
            } else {
                alert('Ứng tuyển thất bại');
            }
        };

        sendRequest();

    };



    return (
        <div className="fixed inset-0 bg-black bg-opacity-50 flex justify-center items-center z-50">
        <div ref={boxRef} className="bg-white rounded-lg max-w-lg w-full pt-3">
            <div className="flex justify-between items-center px-8 bg-white">
                <p className="text-2xl font-bold">Ứng tuyển <span className='text-2xl font-bold text-dark-cyan'>{job?.tenViTri}</span></p>
                <button
                    onClick={() => setModalOpen(false)}
                    className="text-4xl bg-transparent border-0 text-smoke float-right leading-none outline-none focus:outline-none"
                >
                    &times;
                </button>
            </div>

            

            <div className="max-w-lg mx-auto px-8">
                <form className="">
                    <div className='mb-2 border-b border-grey pb-4'>
                        <label htmlFor='filer_input' className="border-b  cursor-pointer border-grey ">
                            <input type="file" 
                                onChange={handleInputChange} 
                                name="cv_file" id="filer_input" 
                                className='hidden absolute cursor-pointer -left-full -top-full -z-50' 
                                accept='application/pdf'  />
                            <div className="flex items-center justify-center mb-2">
                                <svg className="w-8 h-8 text-gray-400" fill="none" stroke="currentColor" viewBox="0 0 24 24" xmlns="http://www.w3.org/2000/svg">
                                    <path strokeLinecap="round" strokeLinejoin="round" strokeWidth="2" d="M12 4v16m8-8H4"></path>
                                </svg>
                            </div>
                            <p className="text-center text-gray-700 mb-2">Tải lên CV từ máy tính, chỉ chấp nhận file .pdf</p>
                            <p className="text-center text-gray-500 text-sm">Hỗ trợ định dạng pdf có kích thước dưới 5MB</p>
                            {fileName && <p className="text-center  text-dark-cyan bg-grey rounded text-gray-500 mt-2 text-sm">File đã chọn: <span className="font-semibold text-gray-700">{fileName}</span></p>}

                            <p className="block w-full mt-4 py-2 text-center hover:bg-navy text-white bg-dark-cyan text-gray-700 rounded hover:bg-gray-300 ">Chọn CV</p>
                        </label>
                    </div>
                    
                    <div className='flex justify-between'>
                    </div>
                    <label className="flex items-center mb-4">
                        <span className="mr-2 text-dark  font-bold">Thông tin của tôi</span>
                        <AiOutlineInfoCircle className="font-bold text-dodger-blue" />
                        {/* <input
                            type="checkbox"
                            checked='checked'
                            readOnly = 'readonly'
                            className="form-checkbox h-4 w-4 text-blue-600"
                            // onChange={handleUseMyInfoChange}
                        /> */}
                    </label>
                    <div className="mb-4">
                        <label className="block text-dark-grey  font-bold mb-1">
                            Họ và tên <span className="text-red ">*</span>
                        </label>
                        <input
                            type="text"
                            name="name"
                            required
                            readOnly = 'readonly'
                            value={user?.hoTen}
                            // onChange={(e)=>handleInputChange(e)}
                            className="w-full px-3 py-2 border rounded-lg focus:outline-none focus:ring-2 focus:ring-blue-500"
                            placeholder="Chu Văn Tài"
                        />
                    </div>
                    <div className="mb-4 grid grid-cols-2 gap-4">
                        <div>
                            <label className="block text-dark-grey  font-bold mb-1">
                                Email <span className="text-red">*</span>
                            </label>
                            <input
                                // /onChange={(e)=>handleInputChange(e)}
                                type="email"
                                
                                readOnly = 'readonly'
                                name="email"
                                value={user?.email}
                                required
                                className="w-full px-3 py-2 border rounded-lg focus:outline-none focus:ring-2 focus:ring-blue-500"
                                placeholder="cvtai02@gmail.com"
                            />
                        </div>
                        <div>
                            <label className="block text-dark-grey  font-bold mb-1">
                                Số điện thoại <span className="text-red">*</span>
                            </label>
                            <input
                                type="tel"
                                name="phone"
                                readOnly = 'readonly'
                                value={user?.soDienThoai}
                                // onChange={(e) => handleInputChange(e)}
                                className="w-full px-3 py-2 border rounded-lg focus:outline-none focus:ring-2 focus:ring-blue-500"
                                placeholder="0321231232"
                            />
                        </div>
                    </div>
                    
                    <button onClick={handleSubmit} className='mb-4 bg-royal-blue w-full p-2 mt-4 text-white hover:bg-navy rounded text-center'>
                        Nộp đơn ứng tuyển
                    </button>
                </form>
            </div>
        </div>
        </div>
    );
};

export default ApplyModal;