export default function jwtDecode (token) {
    if (!token) {
        return null;
    }

    const tokenParts = token.split('.');
    if (tokenParts.length !== 3) {
        // Invalid JWT format
        return null;
    }

    try {
        const payload = JSON.parse(atob(tokenParts[1]));
        return payload;
    } catch (error) {
        console.error('Error parsing authToken:', error);
    }

    return null;
}