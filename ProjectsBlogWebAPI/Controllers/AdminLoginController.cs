using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjectsBlogWebAPI.Data;
using ProjectsBlogWebAPI.Models;

namespace ProjectsBlogWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminLoginController : ControllerBase
    {
        private readonly ProjectsBlogDbContext _context;

        public AdminLoginController(ProjectsBlogDbContext context)
        {
            _context = context;
        }

        [HttpGet("GetAllAdmins")]
        public async Task<ActionResult<IEnumerable<Admin>>> GetAllAdmins()
        {
            return await _context.Admins.ToListAsync();
        }


        [HttpGet("{id}/GetAdmin")]
        public async Task<ActionResult<Admin>> GetAdmin(int id)
        {
            var admin = await _context.Admins.FindAsync(id);

            if (admin == null)
            {
                return NotFound();
            }

            return admin;
        }

        [HttpPost("NewAdmin")]
        public async Task<ActionResult<Admin>> NewAdmin(Admin admin)
        {
            var passwordHasher = new PasswordHasher<Admin>();
            admin.Password = passwordHasher.HashPassword(null, admin.Password);
            _context.Admins.Add(admin);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAdmin", new { id = admin.AdminId }, admin);
        }

        [HttpPut("{id}/EditAdmin")]
        public async Task<IActionResult> EditAdmin(int id, Admin admin)
        {
            if (id != admin.AdminId)
            {
                return BadRequest();
            }

            _context.Entry(admin).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AdminExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        [HttpPost("Authentication")]
        public Dictionary<string, object> Authentication(Admin values)
        {
            var passwordHasher = new PasswordHasher<Admin>();

            var user = _context.Admins.Where(x => x.Username == values.Username).FirstOrDefault();

            Dictionary<string, object> keyValuePairs = new Dictionary<string, object>();
            //var ll = passwordHasher.VerifyHashedPassword(null, user.Password, values.Password);


            if (user != null && passwordHasher.VerifyHashedPassword(null, user.Password, values.Password) == PasswordVerificationResult.Success)
            {
                var id = user.AdminId;
                keyValuePairs.Add("isLogged", true);
                keyValuePairs.Add("adminId", id);

            }
            else
            {
                keyValuePairs.Add("isLogged", false);
            }
            return keyValuePairs;
        }

        private bool AdminExists(int id)
        {
            return _context.Admins.Any(e => e.AdminId == id);
        }
    }
}
