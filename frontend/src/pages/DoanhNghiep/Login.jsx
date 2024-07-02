import React, { useEffect } from "react";
import LoginForm from "../../components/LoginForm";
import { fetchDoanhNghiepJwt } from "../../fetchServices/Auth/fetchJwt";
import { useNavigate  } from "react-router-dom";
import { isDoanhNghiepAuth } from "../../fetchServices/Auth/checkAuth";
import AlreadyLogin from "../../components/AlreadyLogin";
import deleteCookie from "../../utils/deleteCookie";
import getCookie from "../../utils/getCookie";

function Login() {

    const navigate = useNavigate();
    const [error, setError] = React.useState(null);
    const [isAuth, setIsAuth] = React.useState(false);

    useEffect(() => {
        if(isDoanhNghiepAuth()) {
            setIsAuth(true);
        }
    }, []);

    async function submitHandler (data) {
       
        console.log(data);
        const res = await fetchDoanhNghiepJwt(data);
        if(res) {
            console.log(res);
            navigate('/doanhnghiep');
        }
        else {
            setError('Sai tên đăng nhập hoặc mật khẩu');
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
            {error && <p>{error}</p>}
            {isAuth && <AlreadyLogin homeRedirectHandle={homeRedirectHandle} LogoutHandle={logoutHandle}/>}
            {!isAuth && <LoginForm submitHandler={submitHandler} />}
        </div>  
    );
}

export default Login;