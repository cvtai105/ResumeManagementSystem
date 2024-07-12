import React, { useState, useEffect } from "react";
import Pagination from "../../components/Pagination";
import { Button } from '@mui/material';
import axios from 'axios';

const hostApi = process.env.REACT_APP_API_URL;

const PaymentConfirm = () => {
    const [totalPages, setTotalPages] = useState(1);
    const [currentPage, setCurrentPage] = useState(1);
    const [dangTuyenData, setDangTuyenData] = useState([]);
    const [paymentStatuses, setPaymentStatuses] = useState({});

    useEffect(() => {
        fetchDangTuyenData();
    }, [currentPage]);

    const fetchDangTuyenData = async () => {
        try {
            const response = await axios.get(`${hostApi}/recruitments?page=${currentPage}`);
            const { data, pageCount } = response.data;
            const formattedData = data.map(dangTuyen => ({
                Id: dangTuyen.id,
                doanhNghiep: dangTuyen.doanhNghiep?.tenDoanhNghiep || 'N/A',
                SoLuong: dangTuyen.soLuong || 0,
                TenViTri: dangTuyen.tenViTri || 'N/A',
                // NgayBatDau: dangTuyen.ngayBatDau ? formatDate(dangTuyen.ngayBatDau) : null,
                ThanhToan: dangTuyen.thanhToan || 0
            }));

            setDangTuyenData(formattedData);
            setTotalPages(pageCount);

            // Fetch payment status for each dangTuyen item
            formattedData.forEach(async (dangTuyen) => {
                const statusResponse = await axios.get(`${hostApi}/dangkydangtuyen/paymentstatus/${dangTuyen.Id}`);
                setPaymentStatuses(prevStatuses => ({
                    ...prevStatuses,
                    [dangTuyen.Id]: statusResponse.data
                }));
            });
        } catch (error) {
            console.error("Error fetching dangTuyen data:", error);
        }
    };

    const formatDate = (dateString) => {
        const date = new Date(dateString);
        const day = date.getDate().toString().padStart(2, '0');
        const month = (date.getMonth() + 1).toString().padStart(2, '0');
        const year = date.getFullYear();
        return `${day}/${month}/${year}`;
    };

    const handlePageChange = (page) => {
        setCurrentPage(page);
    };

    const formatDateTime = (date) => {
        const year = date.getFullYear();
        const month = String(date.getMonth() + 1).padStart(2, '0');
        const day = String(date.getDate()).padStart(2, '0');
        const hours = String(date.getHours()).padStart(2, '0');
        const minutes = String(date.getMinutes()).padStart(2, '0');
        const seconds = String(date.getSeconds()).padStart(2, '0');

        return `${year}-${month}-${day} ${hours}:${minutes}:${seconds}`;
    };

    const handleThanhToanClick = async (id) => {
        console.log(`Updating payment for ID: ${id}`);
        try {
            const currentDate = new Date();
            const newDate = new Date(currentDate); // Create a copy of the current date
            newDate.setDate(currentDate.getDate() + 10);
            await axios.put(`${hostApi}/dangkydangtuyen/update/${id}`, { NgayBatDau: newDate, NgayKetThuc: currentDate });
            await axios.put(`${hostApi}/dangkydangtuyen/update/thanhtoan/${id}`, { DaThanhToan: true });
            fetchDangTuyenData();
        } catch (error) {
            console.error("Error updating payment status:", error);
        }
    };
    

    return (
        <div className="px-44 min-h-screen bg-gray-100 text-center">
            <h5 className="text-2xl font-semibold text-blue-500 mt-6 mb-4">Danh Sách Đăng Tuyển</h5>
            <div className="payment-table">
                <table className="min-w-full bg-white border custom-border">
                    <thead className="bg-gray-100">
                        <tr>
                            <th className="px-5 py-2 border border-gray-300 text-left text-sm font-medium text-gray-700 bg-grey">Mã Đăng Tuyển</th>
                            <th className="px-5 py-2 border border-gray-300 text-left text-sm font-medium text-gray-700 bg-grey">Tên Công Ty</th>
                            <th className="px-5 py-2 border border-gray-300 text-left text-sm font-medium text-gray-700 bg-grey">Số Lượng</th>
                            <th className="px-5 py-2 border border-gray-300 text-left text-sm font-medium text-gray-700 bg-grey">Tên Vị Trí</th>
                            {/* <th className="px-5 py-2 border border-gray-300 text-left text-sm font-medium text-gray-700 bg-grey">Ngày Bắt Đầu</th> */}
                            <th className="px-5 py-2 border border-gray-300 text-left text-sm font-medium text-gray-700 bg-grey">Trạng Thái Thanh Toán</th>
                            <th className="px-5 py-2 border border-gray-300 text-left text-sm font-medium text-gray-700 bg-grey">Hành Động</th>
                        </tr>
                    </thead>
                    <tbody>
                        {dangTuyenData.map((dangTuyen) => (
                            <tr key={dangTuyen.Id}>
                                <td className="px-6 border border-gray-300 text-sm">{dangTuyen.Id}</td>
                                <td className="px-6 border border-gray-300 text-sm">{dangTuyen.doanhNghiep}</td>
                                <td className="px-6 border border-gray-300 text-sm">{dangTuyen.SoLuong}</td>
                                <td className="px-6 border border-gray-300 text-sm">{dangTuyen.TenViTri}</td>
                                {/* <td className="px-6 border border-gray-300 text-sm">{dangTuyen.NgayBatDau || 'N/A'}</td> */}
                                <td className="px-6 border border-gray-300 text-sm">
                                    {paymentStatuses[dangTuyen.Id] ? 'Đã thanh toán' : 'Chưa thanh toán'}
                                </td>
                                <td className="border border-gray-200 px-4 py-2">
                                    <Button
                                        className="px-6 py-2 mt-10 btn-dark text-white rounded"
                                        variant="contained"
                                        color="primary"
                                        size="small"
                                        onClick={() => handleThanhToanClick(dangTuyen.Id)}
                                        disabled={paymentStatuses[dangTuyen.Id]}
                                    >
                                        Thanh Toán
                                    </Button>
                                </td>
                            </tr>
                        ))}
                    </tbody>
                </table>
            </div>
            <div className="flex justify-center items-center mt-4">
                <Pagination onPageChange={handlePageChange} currentPage={currentPage} totalPages={totalPages} />
            </div>
        </div>
    );
};

export default PaymentConfirm;
