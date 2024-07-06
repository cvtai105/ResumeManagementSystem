
import getCookie from "./getCookie";
import jwtDecode from "./jwtDecode";

export default function getUserId() {
    const token = getCookie('authToken');
    const payload = jwtDecode(token);
    return parseInt(payload.nameid);
}