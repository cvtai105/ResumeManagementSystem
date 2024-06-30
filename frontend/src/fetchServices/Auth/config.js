export async function fetchWithAuth(url, options = {}) {
    const token = localStorage.getItem('jwtToken'); // Lấy token từ localStorage (hoặc nơi bạn lưu trữ token)
  
    // Thêm Authorization header nếu token tồn tại
    const headers = {
      ...options.headers,
      'Authorization': `Bearer ${token}`,
    };
  
    const response = await fetch(url, {
      ...options,
      headers,
    });
  
    // Kiểm tra xem phản hồi có lỗi 403 không
    if (response.status === 403) {
      // Thực hiện hành động mặc định, ví dụ: chuyển hướng đến trang đăng nhập
      window.location.href = '/login';
      throw new Error('Forbidden');
    }
  
    return response;
  }