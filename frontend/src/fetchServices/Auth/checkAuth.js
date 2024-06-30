import getCookie from '../../utils/getCookie';
import isAuthTokenValid from '../../utils/isTokenValid';

export const isNhanVienAuth = () => { 
    const cook = getCookie('AuthToken');
    console.log(1);
    return isAuthTokenValid(cook, 'nhanvien');
}

export const isUngVienAuth = () => { 
    const cook = getCookie('AuthToken');
    return isAuthTokenValid(cook, 'ungvien');
}

export const isDoanhNghiepAuth = () => { 
    const cook = getCookie('AuthToken');
    return isAuthTokenValid(cook, 'doanhnghiep');
}


