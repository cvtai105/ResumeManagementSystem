import React, {useEffect, useState} from 'react';
import './JobDetail.css';
import { FontAwesomeIcon } from '@fortawesome/react-fontawesome';
import { faClock } from '@fortawesome/free-solid-svg-icons';
import ApplyModal from './ApplyModal';
import useFetch from '../../hooks/useFetch';
import { useParams } from 'react-router-dom';
import formateDate from '../../utils/formateDate';
import jwtDecode from '../../utils/jwtDecode';
import getCookie from '../../utils/getCookie';
const hostApi = process.env.REACT_APP_API_URL;
const hostImgURL = process.env.REACT_APP_IMAGE_URL;
const hostDefaultImg = process.env.REACT_APP_DOMAIN;



const JobDetail = () => {
  
    const [hasApplied, setHasApplied] = useState(false);
    const jobId = useParams().id;
    const { data: job, error: fetchJobErr } = useFetch(`${hostApi}/recruitments/${jobId}`);
    console.log(job);
    const token = getCookie('UngVienAuthToken');
    const user = jwtDecode(token);
    console.log(user);
    useEffect(() => {
        if(job && user){
            const isApplied = job?.ungTuyens?.some(ungTuyen => ungTuyen.ungVienId === parseInt(user.nameid));
            setHasApplied(isApplied);
        }
        else{
            setHasApplied(false);
            console.log('no job or no user');
        }
    }, [job, user])



    const ApplyClickHandle = (e) => {
        if(user){
            setTimeout(() => {
                setShowModal(true);
            }, 0)
        }
        else{
            alert('Bạn cần đăng nhập để ứng tuyển');
        }
    }

    const [showModal, setShowModal] = useState(false)
    return (
        <div className='jobdetail-container'>
            {   showModal && <ApplyModal setModalOpen={setShowModal} job ={job} userId={user.nameid} setHasApplied={setHasApplied} /> }
            <div className='job-detail'>
                <div className='job-detail__left'>
                    <div className=' job-detail__left-items '>
                        <div className='text-2xl font-semibold '>
                            {job?.tenViTri}
                        </div>
                        <div className="job-detail__info--sections ">
                            <div className="job-detail__info--section">
                                <div className="job-detail__info--section-icon">
                                    <svg xmlns="http://www.w3.org/2000/svg" width="24" height="24" viewBox="0 0 24 24" fill="none">
                                        <path d="M21.92 16.75C21.59 19.41 19.41 21.59 16.75 21.92C15.14 22.12 13.64 21.68 12.47 20.82C11.8 20.33 11.96 19.29 12.76 19.05C15.77 18.14 18.14 15.76 19.06 12.75C19.3 11.96 20.34 11.8 20.83 12.46C21.68 13.64 22.12 15.14 21.92 16.75Z" fill="white"></path>
                                        <path d="M9.99 2C5.58 2 2 5.58 2 9.99C2 14.4 5.58 17.98 9.99 17.98C14.4 17.98 17.98 14.4 17.98 9.99C17.97 5.58 14.4 2 9.99 2ZM9.05 8.87L11.46 9.71C12.33 10.02 12.75 10.63 12.75 11.57C12.75 12.65 11.89 13.54 10.84 13.54H10.75V13.59C10.75 14 10.41 14.34 10 14.34C9.59 14.34 9.25 14 9.25 13.59V13.53C8.14 13.48 7.25 12.55 7.25 11.39C7.25 10.98 7.59 10.64 8 10.64C8.41 10.64 8.75 10.98 8.75 11.39C8.75 11.75 9.01 12.04 9.33 12.04H10.83C11.06 12.04 11.24 11.83 11.24 11.57C11.24 11.22 11.18 11.2 10.95 11.12L8.54 10.28C7.68 9.98 7.25 9.37 7.25 8.42C7.25 7.34 8.11 6.45 9.16 6.45H9.25V6.41C9.25 6 9.59 5.66 10 5.66C10.41 5.66 10.75 6 10.75 6.41V6.47C11.86 6.52 12.75 7.45 12.75 8.61C12.75 9.02 12.41 9.36 12 9.36C11.59 9.36 11.25 9.02 11.25 8.61C11.25 8.25 10.99 7.96 10.67 7.96H9.17C8.94 7.96 8.76 8.17 8.76 8.43C8.75 8.77 8.81 8.79 9.05 8.87Z" fill="white"></path>
                                    </svg>
                                </div>
                                <div className="job-detail__info--section-content">
                                    <div className="job-detail__info--section-content-title">Mức lương</div>
                                    <div className="job-detail__info--section-content-value">{job?.mucLuong}</div>
                                </div>
                            </div>
                            <div className="job-detail__info--section">
                                <div className="job-detail__info--section-icon">
                                    <svg xmlns="http://www.w3.org/2000/svg" width="25" height="24" viewBox="0 0 25 24" fill="none">
                                        <path d="M21.2866 8.45C20.2366 3.83 16.2066 1.75 12.6666 1.75C12.6666 1.75 12.6666 1.75 12.6566 1.75C9.1266 1.75 5.0866 3.82 4.0366 8.44C2.8666 13.6 6.0266 17.97 8.8866 20.72C9.9466 21.74 11.3066 22.25 12.6666 22.25C14.0266 22.25 15.3866 21.74 16.4366 20.72C19.2966 17.97 22.4566 13.61 21.2866 8.45ZM12.6666 13.46C10.9266 13.46 9.5166 12.05 9.5166 10.31C9.5166 8.57 10.9266 7.16 12.6666 7.16C14.4066 7.16 15.8166 8.57 15.8166 10.31C15.8166 12.05 14.4066 13.46 12.6666 13.46Z" fill="white"></path>
                                    </svg>
                                </div>
                                <div className="job-detail__info--section-content">
                                    <div className="job-detail__info--section-content-title">Địa điểm</div>
                                    <div className="job-detail__info--section-content-value">{job?.khuVuc}</div>
                                </div>
                            </div>
                            <div className="job-detail__info--section" id="job-detail-info-experience">
                                <div className="job-detail__info--section-icon">
                                    <svg xmlns="http://www.w3.org/2000/svg" width="24" height="24" viewBox="0 0 24 24" fill="none">
                                        <path d="M17.39 15.67L13.35 12H10.64L6.59998 15.67C5.46998 16.69 5.09998 18.26 5.64998 19.68C6.19998 21.09 7.53998 22 9.04998 22H14.94C16.46 22 17.79 21.09 18.34 19.68C18.89 18.26 18.52 16.69 17.39 15.67ZM13.82 18.14H10.18C9.79998 18.14 9.49998 17.83 9.49998 17.46C9.49998 17.09 9.80998 16.78 10.18 16.78H13.82C14.2 16.78 14.5 17.09 14.5 17.46C14.5 17.83 14.19 18.14 13.82 18.14Z" fill="white"></path>
                                        <path d="M18.35 4.32C17.8 2.91 16.46 2 14.95 2H9.04998C7.53998 2 6.19998 2.91 5.64998 4.32C5.10998 5.74 5.47998 7.31 6.60998 8.33L10.65 12H13.36L17.4 8.33C18.52 7.31 18.89 5.74 18.35 4.32ZM13.82 7.23H10.18C9.79998 7.23 9.49998 6.92 9.49998 6.55C9.49998 6.18 9.80998 5.87 10.18 5.87H13.82C14.2 5.87 14.5 6.18 14.5 6.55C14.5 6.92 14.19 7.23 13.82 7.23Z" fill="white"></path>
                                    </svg>
                                </div>
                                <div className="job-detail__info--section-content">
                                    <div className="job-detail__info--section-content-title">Số lượng ứng viên</div>
                                    <div className="job-detail__info--section-content-value">{job?.soLuongUngVien} đơn / {job?.soLuong} slot</div>
                                </div>
                            </div>
                        </div>
                        <div className="job-deadline">
                            <FontAwesomeIcon icon={faClock} />
                            <p>Hạn nộp hồ sơ: {formateDate(job?.ngayKetThuc)}</p>
                        </div>

                        {
                            hasApplied && <button className='text-dark-grey'>Bạn đã ứng tuyển vào vị trí này</button>
                        }
                        {
                            !hasApplied && <button
                                className='bg-royal-blue hover:bg-navy rounded-lg py-2 text-white'
                                onClick={ApplyClickHandle}>
                                Ứng tuyển ngay
                            </button>
                        }

                    </div>
                    
                    <div className='job-detail__left-items'>
                        <div className='text-2xl font-semibold'>
                            Chi tiết tuyển dụng
                        </div>
                        <div className='text-xl font-semibold'>
                            Mô tả
                        </div>
                        <div
                            dangerouslySetInnerHTML ={{__html: job?.moTa.split('\n').map(line => `<p>${line}</p>`).join('')}}
                        >

                        </div>
                       
                    </div>
                </div>
                <div className='job-detail__right'>
                    <div className='job-detail__left-items'>
                        <div className='text-2xl font-semibold flex gap-4'>
                            <img className='w-20 h-20' src={`${hostImgURL}/DoanhNghiep/${job?.doanhNghiep?.id}.jpg`}
                                onError={(e) => {
                                    e.target.onerror = null;
                                    console.log(`${hostDefaultImg}/companyDefault.jpg`);
                                    e.target.src = `${hostDefaultImg}/companyDefault.jpg`;
                                }}
                                alt='logo'  />
                            {job?.doanhNghiep?.tenDoanhNghiep}
                        </div>
                        <div className='flex flex-col '>
                            <div className='flex flex-col mt-4 '>
                                <div className='text-xl'>Khu Vực</div>
                                <div className='text-xl font-semibold'>{job?.khuVuc}</div>
                            </div>
                            <div className='flex flex-col mt-4 '>
                                <div className='text-xl'>Website công ty</div>                                
                             <a className='text-royal-blue' href="https://www.facebook.com/cv.tai02">example.com</a>

                            </div>
                        </div>
                        
                    </div>
                    <div className='job-detail__left-items'>
                        <div className='text-2xl font-semibold'>
                            Yêu cầu chung
                        </div>
                        {
                            job?.tieuChiTuyenDungs?.map((tieuChi, index) => (
                                <div key={index}>
                                    <div className='text-xl font-semibold'>{tieuChi.tenTieuChi}</div>
                                    <div dangerouslySetInnerHTML={{ __html: tieuChi.moTa }}></div>
                                </div>
                            ))
                        }
                    </div>
                </div>
               
            </div>
        </div>
    );
}

export default JobDetail;