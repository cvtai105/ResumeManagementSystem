import getCookie from '../../utils/getCookie';
import isAuthTokenValid from '../../utils/isTokenValid';

export const isNhanVienAuth = () => { 
    const cook = getCookie('NhanVienAuthToken');
    console.log(1);
    return isAuthTokenValid(cook, 'nhanvien');
}

export const isUngVienAuth = () => { 
    const cook = getCookie('UngVienAuthToken');
    return isAuthTokenValid(cook, 'ungvien');
}

export const isDoanhNghiepAuth = () => { 
    const cook = getCookie('DoanhNghiepAuthToken');
    return isAuthTokenValid(cook, 'doanhnghiep');
}


