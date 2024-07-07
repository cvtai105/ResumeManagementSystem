using BusinessLogic;
using Microsoft.AspNetCore.Mvc;
using Models.Entities;
using Models.RequestModel;
using System.Threading.Tasks;
using System.Collections.Generic;
using System;
using Models.DTOs;

namespace Application.Controllers{
    [Route("api/dangkydangtuyen")]
    [ApiController]
    public class DangTuyenController : ControllerBase
    {
        private readonly DangTuyenBL _dangTuyenBL;

        public DangTuyenController(DangTuyenBL dangTuyenBL)
        {
            _dangTuyenBL = dangTuyenBL;
        }

        [HttpPost]
        public async Task<ActionResult<DangTuyen>> AddDangTuyen(DangTuyenRequestModel request)
        {
            var dangTuyen = new DangTuyen
            {
                TenViTri = request.JobPosition,
                SoLuong = request.NumberOfHires,
                MoTa = request.jobDescription,
                MucLuong = !request.negotiable ?  request.minSalary +  " - " + request.maxSalary + " VNĐ" : "Thỏa thuận",
                HinhThucDangTuyenId = request.PostingTypeId,
                ThoiGianDangTuyen = request.PostingDuration,
                DoanhNghiepId = request.DoanhNghiepId,
                NhanVienKiemDuyetId = null,
                UuDaiId = null,
                TieuChiTuyenDungs = request.Criteria.Split('\n').Select(c => new TieuChiTuyenDung { MoTa = c }).ToList(),
                NgayDangKy = DateTime.UtcNow,
                NgayBatDau = request.PaymentMethod == "Chuyển khoản" ?  DateTime.UtcNow.AddDays(10) : (DateTime?)null,
                NgayKetThuc = request.PaymentMethod == "Chuyển khoản" ? DateTime.UtcNow.AddDays(10).AddDays(request.PostingDuration) : (DateTime?)null,
                TrangThai = "Chờ duyệt",
                ThanhToans = new List<ThanhToan>
                {
                    new ThanhToan
                    {
                        SoTien = request.TotalAmount,
                        HanThanhToan = DateTime.UtcNow,
                        DaThanhToan = request.PaymentMethod == "Chuyển khoản",
                        HinhThucThanhToanId = request.PaymentMethod == "Chuyển khoản" ? 1 : 2,
                        DotThanhToans = new List<DotThanhToan>
                        {
                            new DotThanhToan
                            {
                                SoTien = request.PaymentType == "part" ? request.InstallmentAmount : request.TotalAmount,
                                NgayThanhToan = request.PaymentMethod == "Chuyển khoản" ? DateTime.UtcNow : null,
                                HinhThucThanhToanId = request.PaymentMethod == "Chuyển khoản" ? 1 : 2
                            }
                        } 
                    }
                }
            };


            var addedDangTuyen = await _dangTuyenBL.AddDangTuyen(dangTuyen);
            return CreatedAtAction(nameof(GetDangTuyenById), new { id = addedDangTuyen.Id }, addedDangTuyen);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<DangTuyen>> GetDangTuyenById(int id)
        {
            var dangTuyen = await _dangTuyenBL.GetDangTuyenById(id);
            if (dangTuyen == null)
            {
                return NotFound();
            }
            return Ok(dangTuyen);
        }
        [HttpGet("filter")]
        public async Task<ActionResult<IEnumerable<DangTuyen>>> GetFilteredDangTuyen()
        {
            var today = DateTime.Today;
            var filteredDangTuyens = await _dangTuyenBL.GetFilteredDangTuyen(today);
            return Ok(filteredDangTuyens);
        }
        [HttpGet("/api/doanhnghiep/dangtuyen/{id}")]
        public async Task<ActionResult<IEnumerable<Object>>> GetHoSoUngTuyenThuocIDUngTuyen(int id)
        {
            var hoSoUngTuyenThuocIDUngTuyens = await _dangTuyenBL.GetHoSoUngTuyenThuocIDUngTuyen(id);
            return Ok(hoSoUngTuyenThuocIDUngTuyens);
        }
       //le
       [HttpPut("update/{id}")]
        public async Task<IActionResult> UpdateNgayBatDau(int id, [FromBody] UpdateNgayBatDauDto dto)
        {
            var result = await _dangTuyenBL.UpdateNgayBatDau(id, dto.NgayBatDau);
            if (result)
            {
                return Ok(new { message = "NgayBatDau updated successfully" });
            }
            else
            {
                return BadRequest(new { message = "Failed to update NgayBatDau" });
            }
        }
        //le
        [HttpPut("update/thanhtoan/{id}")]
        public async Task<IActionResult> UpdatePaymentStatus(int id, [FromBody] UpdatePaymentStatusDto dto)
        {
            var result = await _dangTuyenBL.UpdatePaymentStatus(id, dto.DaThanhToan);
            if (result)
            {
                return Ok(new { message = "DaThanhToan updated successfully" });
            }
            else
            {
                return BadRequest(new { message = "Failed to update DaThanhToan" });
            }
        }
        //le
         [HttpGet("paid-amount/{id}")]
        public async Task<ActionResult<decimal>> GetPaidAmount(int id)
        {
            try
            {
                var paidAmount = await _dangTuyenBL.GetTotalPaidAmount(id);
                return Ok(paidAmount);
            }
            catch (Exception ex)
            {
                // Log the exception (not shown here)
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
          //le
         [HttpGet("payment/{id}")]
        public async Task<ActionResult<decimal>> GetPaymentAmount(int id)
        {
            try
            {
                var paidAmount = await _dangTuyenBL.GetPaymentAmount(id);
                return Ok(paidAmount);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
            [HttpGet("paymentstatus/{id}")]
        public async Task<ActionResult<decimal>> GetPaymentStatus(int id)
        {
            try
            {
                var status = await _dangTuyenBL.GetPaymentStatus(id);
                return Ok(status);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
    }
}