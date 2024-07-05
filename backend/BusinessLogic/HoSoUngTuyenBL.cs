
using DataAccess.DAOs;
using Models.Entities;
using Models.RequestModel;
using DataAccess.Data;

public class HoSoUngTuyenBL
    {
        private readonly HoSoUngTuyenDAO _hoSoUngTuyenDAO;

        public HoSoUngTuyenBL(HoSoUngTuyenDAO hoSoUngTuyenDAO)
        {
            _hoSoUngTuyenDAO = hoSoUngTuyenDAO;
        }

        public async Task<IEnumerable<HoSoUngTuyen>> GetDoanhSachHSUTByIdUngTuyen(int id)
        {
            return await _hoSoUngTuyenDAO.GetDoanhSachHSUTByIdUngTuyen(id);
        }
    }