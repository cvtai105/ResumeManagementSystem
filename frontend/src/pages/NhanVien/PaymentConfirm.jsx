import React, { useState, useEffect } from "react";
import Pagination from "../../components/Pagination";
import { Button } from '@mui/material';
import axios from 'axios';

import "./PaymentConfirm.css";

const hostApi = process.env.REACT_APP_API_URL;

const PaymentConfirm = () => {
    const [totalPages, setTotalPages] = useState(1);
    const [currentPage, setCurrentPage] = useState(1);
    const [dangTuyenData, setDangTuyenData] = useState([]);

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
                NgayBatDau: dangTuyen.ngayBatDau ? formatDate(dangTuyen.ngayBatDau) : null, 
                ThanhToan: dangTuyen.thanhToan || 0 
            }));

            setDangTuyenData(formattedData);
            setTotalPages(pageCount);
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
        try {
            const currentDate = formatDateTime(new Date());
            console.log(currentDate);
            
            await axios.put(`${hostApi}/dangkydangtuyen/update/${id}`, { NgayBatDau: currentDate });
            fetchDangTuyenData();
        } catch (error) {
            console.error("Error updating payment status:", error);
        }
    };

    const isDateBeforeOrEqualTo = (dateString, compareToDateString) => {
        if (!dateString) return false; 
        const date = new Date(dateString);
        const compareTo = new Date(compareToDateString);
        console.log(date, "**************", compareTo);
        return date <= compareTo;
    };

    return (
        <div className="px-44 min-h-screen bg-gray-100 text-center">
            <h3 className="text-2xl font-semibold text-blue-500 mt-6 mb-4">Danh Sách Đăng Tuyển</h3>
            <div className="payment-table">
                <table className="w-full border-collapse border border-gray-200">
                    <thead className="bg-gray-100">
                        <tr>
                            <th className="border border-gray-200 px-4 py-2">Mã Đăng Tuyển</th>
                            <th className="border border-gray-200 px-4 py-2">Tên Công Ty</th>
                            <th className="border border-gray-200 px-4 py-2">Số Lượng</th>
                            <th className="border border-gray-200 px-4 py-2">Tên Vị Trí</th>
                            <th className="border border-gray-200 px-4 py-2">Ngày Bắt Đầu</th>
                            <th className="border border-gray-200 px-4 py-2">Trạng Thái Thanh Toán</th>
                            <th className="border border-gray-200 px-4 py-2">Hành Động</th>
                        </tr>
                    </thead>
                    <tbody>
                        {dangTuyenData.map((dangTuyen) => (
                            <tr key={dangTuyen.Id}>
                                <td className="border border-gray-200 px-4 py-2">{dangTuyen.Id}</td>
                                <td className="border border-gray-200 px-4 py-2">{dangTuyen.doanhNghiep}</td>
                                <td className="border border-gray-200 px-4 py-2">{dangTuyen.SoLuong}</td>
                                <td className="border border-gray-200 px-4 py-2">{dangTuyen.TenViTri}</td>
                                <td className="border border-gray-200 px-4 py-2">{dangTuyen.NgayBatDau || 'N/A'}</td>
                                <td className="border border-gray-200 px-4 py-2">
                                    {!dangTuyen.NgayBatDau ? 'Chưa thanh toán' : 'Đã thanh toán'}
                                </td>
                                <td className="border border-gray-200 px-4 py-2">
                                    <Button
                                        variant="contained"
                                        color="primary"
                                        size="small"
                                        onClick={() => handleThanhToanClick(dangTuyen.Id)}
                                        disabled={dangTuyen.NgayBatDau}
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

