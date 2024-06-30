import React from "react";
import LoginForm from "../../components/LoginForm";
import { fetchNhanVienJwt } from "../../fetchServices/Auth/fetchJwt";
import { useNavigate  } from "react-router-dom";

function Login() {

    const navigate = useNavigate();
    const [error, setError] = React.useState(null);

    const submitHandler = async (data) => {
       
        console.log(data);
        const res = await fetchNhanVienJwt(data);
        if(res) {
            alert(res);
            console.log(res);
        }
        else {
            alert('Sai tên đăng nhập hoặc mật khẩu');
            setError('Sai tên đăng nhập hoặc mật khẩu');
        }
    }

    return (
        <div>
            <LoginForm submitHandler={submitHandler} />
        </div>
    );
}

export default Login;