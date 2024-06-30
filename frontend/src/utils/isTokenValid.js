export default function isAuthTokenValid(authToken, role) {
    if (!authToken) {
        return false;
    }

    const tokenParts = authToken.split('.');
    if (tokenParts.length !== 3) {
        // Invalid JWT format
        return false;
    }

    try {
        const payload = JSON.parse(atob(tokenParts[1]));
        // Check if token has expired
        if (payload.exp ) {
            const now = Math.floor(Date.now() / 1000); // current time in seconds
            return payload.exp > now && payload.role === role;
        }
        
    } catch (error) {
        console.error('Error parsing authToken:', error);
    }

    return false;
}