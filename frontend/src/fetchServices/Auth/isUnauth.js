export default function isUnauth(response) {
    return response.status === 401;
}