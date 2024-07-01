import React, { useEffect } from "react";
import LoginForm from "../../components/LoginForm";
import { fetchNhanVienJwt } from "../../fetchServices/Auth/fetchJwt";
import { useNavigate  } from "react-router-dom";
import { isNhanVienAuth } from "../../fetchServices/Auth/checkAuth";
import AlreadyLogin from "../../components/AlreadyLogin";
import deleteCookie from "../../utils/deleteCookie";
import getCookie from "../../utils/getCookie";

function Login() {

    const navigate = useNavigate();
    const [error, setError] = React.useState(null);
    const [isAuth, setIsAuth] = React.useState(false);

    useEffect(() => {
        if(isNhanVienAuth()) {
            setIsAuth(true);
        }
    }, []);

    async function submitHandler (data) {
       
        console.log(data);
        const res = await fetchNhanVienJwt(data);
        if(res) {
            console.log(res);
            navigate('/nhanvien');
        }
        else {
            setError('Sai tên đăng nhập hoặc mật khẩu');
        }

        return res;
    }

    function homeRedirectHandle() {
        navigate('/nhanvien');
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