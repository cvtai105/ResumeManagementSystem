# Quy Ước: 
1. Sử dụng dependency injection
2. Sử dụng async/await Task cho những tác vụ truy vấn DB, gọi API, ...
4. Đặt tên hàm rõ ràng, làm sao cho người đọc có thể hiểu khi đọc tên hàm và tham số

# Chạy migration Database (tự động tạo database):
1. dotnet tool install --global dotnet-ef
2. dotnet restore 
3. cd .. (tới directory backend)
4. dotnet ef database update --project DataAccess --startup-project Application



# Đăng nhập 3 rolls:
nhanvien@email.com - 123456
ungvien@email.com - 124356
doanhnghiep@email.com - 123456
