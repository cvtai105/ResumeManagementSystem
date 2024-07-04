import React , {useState} from 'react';
import './SearchBar.css';

const SearchBar = () => {

    const [keyword, setKeyword] = useState('');
    const location = ['Hồ Chí Minh', 'Hà Nội', 'Đà Nẵng', 'Khác']
    const major = ['IT', 'Kinh doanh', 'Marketing', 'Nhân sự', 'Khác']
    return (
        <div className="search-bar">
        <input type="text" placeholder="Vị trí tuyển dụng" className="search-input" />
        <span className="border-l h-6 mx-3 border-b-smoke"></span>
        <div className="dropdown">
            <select className="dropdown-select">
                {location.map((item, index) => (
                    <option key={index}>{item}</option>
                ))}
            </select>
        </div>
        
        <span className="border-l h-6 border-b-smoke mx-3"></span>
        <div className="dropdown">
            <select className="dropdown-select">
                {major.map((item, index) => (
                    <option key={index}>{item}</option>
                ))}
            </select>
        </div>
        <button className="search-button">Tìm kiếm</button>
        </div>
    );
};

export default SearchBar;
