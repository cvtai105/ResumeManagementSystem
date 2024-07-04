# Conventions:
1. Sử dụng dependency injection
2. Sử dụng async/await Task cho những tác vụ truy vấn DB, gọi API, ...
3. Đặt tên hàm rõ ràng, làm sao cho người đọc có thể hiểu khi đọc tên hàm và tham số

# Running:
1. cd backend
2. dotnet restore (hình như cái này tự động)
3. dotnet tool install --global dotnet-ef (có rồi thì không cần nữa)
4. dotnet ef database update --project DataAccess --startup-project Application (dùng lệnh này khi folder DataAccess/Migrations có thay đổi từ github)
5. dotnet watch run --project Application

# Khi muốn thay đổi database / relationship giữa các table / columns.
1. Chỉ cần chỉnh sửa trong folder entities. (các entities là các objects ánh xạ tới các bảng trong database)
2. dotnet ef migrations add tenPhienBan --project DataAccess --startup-project Application
3. folder DataAccess/Migrations thay đổi - thêm các design scripts cho database.
4. dotnet ef database update --project DataAccess --startup-project Application
5. note: ai thay đổi migrations nên báo cho mn. mọi người khi pull về chỉ cần chạy dòng lệnh số 4.

# Entity relationship convention:
1. khóa chính: id / classnameId
2. khóa ngoại: <navigation property><navigationtype primarykey> / <referenced entity class name><referenced entity class primary key>
3. nullable: type?
4. nếu không sử dụng các convention trên cần config trong appdbcontext.

# Thêm stored procedure:
1. dotnet ef migrations add tên-phiên-bản-đặt-kiểu-gì-cũng-dc-khác-nhau-là-dc --project DataAccess --startup-project Application
2. vào file vừa được thêm vào trong folder DataAccess/Migrations thêm procedure
3. dotnet ef database update --project DataAccess --startup-project Application

# Execute procedure
1. Thêm class/model cho kết quả của procedure
2. Thêm dataset trong dbcontext
3. Gọi context.dataset.FromSqlRaw("Exec procedurename {param}") để lấy kết quả.

# Đăng nhập 3 rolls:
nhanvien@email.com - 123456
ungvien@email.com - 124356
doanhnghiep@email.com - 123456
