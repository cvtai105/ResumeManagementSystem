
import getCookie from "./getCookie";
import jwtDecode from "./jwtDecode";

function getUserId(nameCookie) {
    const token = getCookie(nameCookie);
    const payload = jwtDecode(token);
    return parseInt(payload.nameid);
}

export function getDoanhNghiepId () {
    return getUserId('DoanhNghiepAuthToken');  
}

export function getNhanVienId () {
    return getUserId('NhanVienAuthToken');  
}

export function getUngVienId () {
    return getUserId('UngVienAuthToken');  
}
