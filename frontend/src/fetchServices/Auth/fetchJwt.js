const hostApi = process.env.REACT_APP_API_URL;
const nhanvienAuthPath = '/auth/nhanvien';
const ungvienAuthPath = '/auth/ungvien';
const doanhnghiepAuthPath = '/auth/doanhnghiep';


export const fetchNhanVienJwt = async (data) => {
    console.log(data);
    console.log(hostApi + nhanvienAuthPath)
    return await fetchJwt(nhanvienAuthPath, data);
}

export const fetchUngVienJwt = async (data) => {
    return await fetchJwt(ungvienAuthPath, data);
}

export const fetchDoanhNghiepJwt = async (data) => {
    return await fetchJwt(doanhnghiepAuthPath, data);
}


const fetchJwt = async (path, data) => {
    try {
        const response = await fetch(hostApi + path, {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json',
            },
            body: JSON.stringify(data),
            credentials: 'include',
        });
        
        console.log(`request to ${hostApi}/${path} with data: ${JSON.stringify(data)}`)

        console.log(`response status: ${response.status}`);

        return await response.json();
    } catch (error) {
        return null;
    }
}