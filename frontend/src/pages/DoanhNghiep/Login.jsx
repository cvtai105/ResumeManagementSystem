import React, {useContext, useEffect } from "react";
import LoginForm from "../../components/LoginForm";
import { fetchDoanhNghiepJwt } from "../../fetchServices/Auth/fetchJwt";
import { useNavigate  } from "react-router-dom";
import { isDoanhNghiepAuth } from "../../fetchServices/Auth/checkAuth";
import AlreadyLogin from "../../components/AlreadyLogin";
import deleteCookie from "../../utils/deleteCookie";
import getCookie from "../../utils/getCookie";
import { DoanhNghiepContext } from "../../fetchServices/DoanhNghiep/DoanhNghiepContext";

function Login() {

    const navigate = useNavigate();
    const [error, setError] = React.useState(null);
    const [isAuth, setIsAuth] = React.useState(false);

    const { setIdDoanhNghiep } = useContext(DoanhNghiepContext);


    useEffect(() => {
        if(isDoanhNghiepAuth()) {
            setIsAuth(true);
        }
    }, []);

    async function submitHandler (data) {
       
        console.log(data);
        const res = await fetchDoanhNghiepJwt(data);
        console.log(res);
        if (res == null ){
            setError('Lỗi không xác định được / Lỗi đường truyền');
            return;
        }
        else if(res.status == 401) {
            setError('Sai tên đăng nhập hoặc mật khẩu');
        }
        else if (res.token) {
            navigate('/doanhnghiep');
        }
    }

    function homeRedirectHandle() {
        navigate('/doanhnghiep');
    }

    function logoutHandle() {
        deleteCookie('AuthToken');
        console.log(getCookie('AuthToken'));
        setIsAuth(false);
    }

    return (
        <div>
            {isAuth && <AlreadyLogin homeRedirectHandle={homeRedirectHandle} LogoutHandle={logoutHandle}/>}
            {!isAuth && <LoginForm submitHandler={submitHandler} />}
        </div>  
    );
}

export default Login;