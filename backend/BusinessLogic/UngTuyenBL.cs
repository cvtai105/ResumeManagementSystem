
using DataAccess.DAOs;
using Models.Entities;
using Models.RequestModel;
using DataAccess.Data;

public class UngTuyenBL
    {
        private readonly UngTuyenDAO _ungTuyenDAO;
        private UngVienDAO _ungvienDAO;
        private HoSoUngTuyenDAO _hoSoUngTuyenDAO;

    public UngTuyenBL(UngTuyenDAO ungTuyenDAO, UngVienDAO ungvienDAO, HoSoUngTuyenDAO hoSoUngTuyenDAO)
        {
            _ungTuyenDAO = ungTuyenDAO;
            _ungvienDAO = ungvienDAO;
            _hoSoUngTuyenDAO = hoSoUngTuyenDAO;
        }

        public async Task<IEnumerable<UngTuyen>> GetDoanhSachUngTuyenByIdBaiDang(int id)
        {
            return await _ungTuyenDAO.GetDoanhSachUngTuyenByIdBaiDang(id);
        }

        public async Task<bool> UpdateStatus(int id, string status)
        {
            return await _ungTuyenDAO.UpdateStatus(id, status);
        }

        public async Task<UngTuyen?> UngTuyen(string email, string name, string phone, int dangTuyenId, string cvPath)
        {
            //get ung vien by email
            var ungVien = await _ungvienDAO.GetByEmail(email);
            ungVien ??= await _ungvienDAO.Add(
                new UngVien
                {
                    Email = email,
                    HoTen = name,
                    SoDienThoai = phone
                }
            );

            //create ung tuyen
            var ungTuyen = new UngTuyen
            {
                UngVienId = ungVien.Id,
                DangTuyenId = dangTuyenId,
                NgayKiemDuyen = DateTime.Now,
            };

            //get ung tuyen by ung vien id and dang tuyen id
            var existedUngTuyen = await _ungTuyenDAO.GetByUngVienIdAndDangTuyenId(ungVien.Id, dangTuyenId);
            if (existedUngTuyen != null)
            {
                return null;
            }

            ungTuyen = await _ungTuyenDAO.Add(ungTuyen);

            //add cv
            var cv = new HoSoUngTuyen
            {
                FileHoSo = cvPath,
                UngTuyenId = ungTuyen.Id,
                TenHoSo = "CV"
            };

            var _ = await _hoSoUngTuyenDAO.Add(cv);
            return ungTuyen;
        }
    
    }