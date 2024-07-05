import React, { useState, useRef, useEffect } from 'react';

const ApplyModal = ({ setModalOpen, job }) => {
    const boxRef = useRef(null);
    const [useMyInfo, setUseMyInfo] = useState(false);
    
    function handleUseMyInfoChange(e) {
        setUseMyInfo(!e.target.checked);
        if(!useMyInfo){
            formData.name = '';
            formData.phone = '';
            formData.email = '';
            formData.cv_file = null;
        }
        else{
            formData.name = 'Chu Văn Tài';
            formData.phone = '0321231232';
            formData.email = 'a@a.com';
        }
    }
    const handleClickOutside = (event) => {
      if (boxRef.current && !boxRef.current.contains(event.target)) {
        setModalOpen(false);
      }
    };
  
    useEffect(() => {
      document.addEventListener("click", handleClickOutside);
      return () => {
        document.removeEventListener("click", handleClickOutside);
      };
    }, []);
  
    const [formData, setFormData] = useState({
        cv_file: null,
        name: '',
        email: '',
        phone: ''
    });

    const [fileName, setFileName] = useState(null);

    const handleInputChange = (e) => {
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
        if ( !formData.name || !formData.email || !formData.phone) {
          alert('Vui lòng điền đầy đủ thông tin!');
          return;
        }
      
        // Here you can handle the form submission, e.g., sending the form data to a server
        console.log(formData);
    };



    return (
        <div className="fixed inset-0 bg-black bg-opacity-50 flex justify-center items-center z-50">
        <div ref={boxRef} className="bg-white rounded-lg max-w-lg w-full pt-3">
            <div className="flex justify-between items-center px-8 bg-white">
                <p className="text-2xl font-bold">Ứng tuyển {job?.name}</p>
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
                            <input type="file" onChange={handleInputChange} name="cv_file" id="filer_input" className='hidden absolute cursor-pointer -left-full -top-full -z-50'  accept="doc, docx, pdf"/>
                            <div className="flex items-center justify-center mb-2">
                                <svg className="w-8 h-8 text-gray-400" fill="none" stroke="currentColor" viewBox="0 0 24 24" xmlns="http://www.w3.org/2000/svg">
                                    <path strokeLinecap="round" strokeLinejoin="round" strokeWidth="2" d="M12 4v16m8-8H4"></path>
                                </svg>
                            </div>
                            <p className="text-center text-gray-700 mb-2">Tải lên CV từ máy tính, chọn hoặc kéo thả</p>
                            <p className="text-center text-gray-500 text-sm">Hỗ trợ định dạng pdf có kích thước dưới 5MB</p>
                            {fileName && <p className="text-center  text-dark-cyan bg-grey rounded text-gray-500 mt-2 text-sm">File đã chọn: <span className="font-semibold text-gray-700">{fileName}</span></p>}

                            <p className="block w-full mt-4 py-2 text-center hover:bg-navy text-white bg-dark-cyan text-gray-700 rounded hover:bg-gray-300 ">Chọn CV</p>
                        </label>
                    </div>
                    
                    <div className='flex justify-between'>
                    <p className="text-green-600 mb-2">Vui lòng nhập đầy đủ thông tin chi tiết:</p>
                    <p className="text-right text-red-500 text-sm mb-2 text-red">(*) Thông tin bắt buộc.</p>
                    </div>
                    <label className="flex items-center mb-4">
                        <input
                            type="checkbox"
                            className="form-checkbox h-4 w-4 text-blue-600"
                            onChange={(e) => handleUseMyInfoChange(e)}
                        />
                        <span className="ml-2 text-gray-700">Sử dụng thông tin của tôi</span>
                    </label>
                    <div className="mb-4">
                        <label className="block text-gray-700  font-bold mb-1">
                            Họ và tên <span className="text-red ">*</span>
                        </label>
                        <input
                            type="text"
                            name="name"
                            required
                            value={formData.name}
                            onChange={handleInputChange}
                            className="w-full px-3 py-2 border rounded-lg focus:outline-none focus:ring-2 focus:ring-blue-500"
                            placeholder="Chu Văn Tài"
                        />
                    </div>
                    <div className="mb-4 grid grid-cols-2 gap-4">
                        <div>
                            <label className="block text-gray-700  font-bold mb-1">
                                Email <span className="text-red">*</span>
                            </label>
                            <input
                            onChange={handleInputChange}
                                type="email"
                                name="email"
                                value={formData.email}
                                required
                                className="w-full px-3 py-2 border rounded-lg focus:outline-none focus:ring-2 focus:ring-blue-500"
                                placeholder="cvtai02@gmail.com"
                            />
                        </div>
                        <div>
                            <label className="block text-gray-700  font-bold mb-1">
                                Số điện thoại <span className="text-red">*</span>
                            </label>
                            <input
                                type="tel"
                                name="phone"
                                value={formData.phone}
                                required
                                onChange={handleInputChange}
                                className="w-full px-3 py-2 border rounded-lg focus:outline-none focus:ring-2 focus:ring-blue-500"
                                placeholder="0321231232"
                            />
                        </div>
                    </div>
                    
                    <button onClick={handleSubmit} className='mb-4 bg-dodger-blue w-full p-2 mt-4 text-white hover:bg-navy rounded text-center'>
                        Nộp đơn ứng tuyển
                    </button>
                </form>
            </div>
        </div>
        </div>
    );
};

export default ApplyModal;