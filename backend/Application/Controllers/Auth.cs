using System.ComponentModel;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using BusinessLogic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Models.RequestRecords;

namespace Application.Controllers
{
    [Route("api/auth")]
    [ApiController]
    public class Auth : ControllerBase
    {
        public Auth(NhanVienBL nhanVienBL, UngVienBL ungVienBL, DoanhNghiepBL doanhNghiepBL)
        {
            _nhanVienBL = nhanVienBL;
            _ungVienBL = ungVienBL;
            _doanhNghiepBL = doanhNghiepBL;

            //logger dùng để ghi log, fix bug, log ra file hoặc console, debugconsole, ...
        }
        private readonly NhanVienBL _nhanVienBL;
        private readonly UngVienBL _ungVienBL;
        private readonly DoanhNghiepBL _doanhNghiepBL;
        private const string _secret = "PLEASE_ENTER_A_RANDOM_STRING_MORE_THAN_16_CHARACTERS";
        private const string _issuer = "http://localhost:5231";  
        private const string _audience = "http://localhost:5231";   
        private readonly TimeSpan _expiration = TimeSpan.FromHours(24);   

        [HttpPost("nhanvien")]
        public async Task<IActionResult> NhanVienAuthorize([FromBody] LoginRecord loginInfo)
        {
            var nhanVien = await _nhanVienBL.IsValidUser(loginInfo);

            if (nhanVien != null)
            {
                var tokenString = GenerateToken(nhanVien.Email, nhanVien.Id, "nhanvien");

                var cookieOptions = new CookieOptions
                {
                    HttpOnly = false,
                    Expires = DateTime.UtcNow.AddHours(1)
                };

                Response.Cookies.Append("NhanVienAuthToken", tokenString, cookieOptions);

                return Ok(new { Token = tokenString,  });
            }

            return Unauthorized();
        }

        [HttpPost("doanhnghiep")]
        public async Task<IActionResult> DoanhNghiepAuthorize([FromBody] LoginRecord loginInfo)
        {
            var doanhNghiep = await _doanhNghiepBL.IsValidUser(loginInfo);
            if (doanhNghiep != null)
            {
                var tokenString = GenerateToken(doanhNghiep.Email, doanhNghiep.Id, "doanhnghiep");

                var cookieOptions = new CookieOptions
                {
                    HttpOnly = false,
                    Expires = DateTime.UtcNow.AddHours(1)
                };

                Response.Cookies.Append("DoanhNghiepAuthToken", tokenString, cookieOptions);

#pragma warning disable CS8602 // Dereference of a possibly null reference.
                return Ok(new { Token = tokenString, IdDoanhNghiep = doanhNghiep.Id });
#pragma warning restore CS8602 // Dereference of a possibly null reference.
            }

            return Unauthorized();
        }

        [HttpPost("ungvien")]
        public async Task<IActionResult> UngVienAuthorize([FromBody] LoginRecord loginInfo)
        {
            var ungVien = await _ungVienBL.IsValidUser(loginInfo);
            if (ungVien != null)
            {

                var tokenString = GenerateToken(ungVien.Email,ungVien.Id, "ungvien");

                var cookieOptions = new CookieOptions
                {
                    SameSite = SameSiteMode.None,
                    Secure = true,
                    HttpOnly = false,
                    Expires = DateTime.UtcNow.AddHours(1)
                };

                Response.Cookies.Append("UngVienAuthToken", tokenString, cookieOptions);

                return Ok(new { Token = tokenString });
            }

            return Unauthorized();
        }
        

        private string GenerateToken(string email, int id, string role)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.UTF8.GetBytes(_secret);

            var claims = new List<Claim>
            {
                new(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new(JwtRegisteredClaimNames.Email, email),
                new(JwtRegisteredClaimNames.Sub, email),
                new(ClaimTypes.Role, role),
                new(ClaimTypes.NameIdentifier, id.ToString())
            };

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.UtcNow.Add(_expiration),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature),
                Issuer = _issuer,
                Audience = _audience,
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }

    }
}