import React , {useState} from 'react';
import './SearchBar.css';
import { useNavigate } from 'react-router-dom';

const SearchBar = () => {

    const [location, setLocation] = useState('Hồ Chí Minh');
    const [major, setMajor] = useState('IT');
    const [keyword, setKeyword] = useState('');
    const locations = ['Hồ Chí Minh', 'Hà Nội', 'Đà Nẵng', 'Khác']
    const majors = ['IT', 'Kinh doanh', 'Marketing', 'Nhân sự', 'Khác']
    
    const navigate = useNavigate();


    return (
        <div className="search-bar">
            <input 
                type="text" 
                placeholder="Vị trí tuyển dụng" 
                onChange={(e) => setKeyword(e.target.value)}
                className="search-input" />
        <span className="border-l h-6 mx-3 border-b-smoke"></span>
        <div className="dropdown">
            <select 
                className="dropdown-select"
                onChange={(e) => setLocation(e.target.value)}
                >
                {locations.map((item, index) => (
                    <option key={index}>{item}</option>
                ))}
            </select>
        </div>
        
        <span className="border-l h-6 border-b-smoke mx-3"></span>
        <div className="dropdown">
            <select className="dropdown-select"  onChange={(e) => setMajor(e.target.value)}> 
                {majors.map((item, index) => (
                    <option key={index}>{item}</option>
                ))}
            </select>
        </div>
            <button className="search-button" onClick={()=>navigate(`jobs?keyword="${keyword}&location=${location}&branch${major}"`)}>Tìm kiếm</button>
        </div>
    );
};

export default SearchBar;
