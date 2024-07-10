import { useState, useEffect } from 'react';
import React  from 'react';

const fetchThongKe = async () => {
    const response = await fetch('http://localhost:5231/api/dangkydangtuyen/thongke');
    const data = await response.json();
    return data;
};

const ThongKeHoSoSapHetHan = () => {
    const [data, setData] = useState([]);
    useEffect(() => {
        fetchthongKe();
    }, []);

    return (
        <div className="container mx-auto p-4">
            <h1 className="text-xl font-bold mb-4">Hợp đồng sắp hết hạn</h1>
            <div className="overflow-x-auto">
                <table className="min-w-full bg-white border border-gray-200">
                    <thead>
                        <tr className="bg-gray-100 border-b">
                            <th className="py-2 px-4 border-r">Mã Hợp Đồng</th>
                            <th className="py-2 px-4 border-r">Công Ty</th>
                            <th className="py-2 px-4 border-r">Ngày Tới Hạn</th>
                            <th className="py-2 px-4 border-r">Ứng Viên</th>
                            <th className="py-2 px-4 border-r">Vị Trí</th>

                        </tr>
                    </thead>
                    <tbody>
                        {data.map((item, index) => (
                            <tr key={index} className="border-b hover:bg-gray-50">
                                <td className="py-2 px-4 border-r">{item.maHopDong}</td>
                                <td className="py-2 px-4 border-r">{item.congTy}</td>
                                <td className="py-2 px-4 border-r">{item.ngayToiHan}</td>
                                <td className="py-2 px-4 border-r">{item.ungVien}</td>
                                <td className="py-2 px-4 border-r">{item.viTri}</td>
                            </tr>
                        ))}
                    </tbody>
                </table>
            </div>
            <div className="flex justify-center mt-4">
                {/* Pagination buttons can be added here */}
            </div>
        </div>
    );
};

export default ThongKeHoSoSapHetHan;