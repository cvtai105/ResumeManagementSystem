# Conventions:

1. Sử dụng dependency injection
2. Sử dụng async/await Task cho những tác vụ truy vấn DB, gọi API, ...
3. Đặt tên hàm rõ ràng, làm sao cho người đọc có thể hiểu khi đọc tên hàm và tham số

# Chạy migration Database (tự động tạo database):

1. cd ... (tới backend)

2. dotnet tool install --global dotnet-ef (có rồi thì không cần nữa)
3. dotnet restore
4. dotnet ef database update --project DataAccess --startup-project Application

# Khi muốn thay đổi entities / relationship giữa các entities.

1. Chỉ cần chỉnh sửa trong folder entities.
2. dotnet ef migrations add tenPhienBan --project DataAccess --startup-project Application
3. folder migrations tự động thay đổi
4. dotnet ef database update --project DataAccess --startup-project Application
5. note: ai thay đổi migrations nên báo cho mn. mọi người khi pull về chỉ cần chạy dòng lệnh số 4.

# Thêm stored procedure:

1. dotnet ef migrations add tên-phiên-bản-đặt-kiểu-gì-cũng-dc-khác-nhau-là-dc --project DataAccess --startup-project Application
2. vào file vừa được thêm vào trong folder DataAccess/Migrations thêm procedure
3. dotnet ef database update --project DataAccess --startup-project Application

# execute procedure

1. Thêm class/model cho kết quả của procedure
2. Thêm dataset trong dbcontext
3. Gọi context.dataset.FromSqlRaw("Exec procedurename {param}") để lấy kết quả.

# Running instruction

1. cd application
2. dotnet watch run

# Đăng nhập 3 rolls:

nhanvien@email.com - 123456
ungvien@email.com - 124356
doanhnghiep@email.com - 123456

# các package:

dotnet add package Swashbuckle.AspNetCore
