using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using chatapp_server.Models;
using Newtonsoft.Json;

namespace chatapp_server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChatUserController : ControllerBase
    {
        private readonly ChatAppContext _context;

        public ChatUserController(ChatAppContext context)
        {
            _context = context;
        }

        // GET: api/ChatUser
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ChatUser>>> GetChatUsers()
        {
            return await _context.ChatUsers.ToListAsync();
        }

        // GET: api/ChatUser
        [HttpGet("{userName}/{passWord}")]
        public async Task<ActionResult<ChatUser>> Login(string username, string password)
        {
            var user = await _context.ChatUsers.Include(user => user.ChatGroups).FirstOrDefaultAsync(user =>
                user.UserName == username && user.Password == password);
                
            if (user == null)
            {
                return NotFound();
            }

            return user;
        }

        // GET: api/ChatUser
        [HttpGet("{userName}/{passWord}/{age}")]
        public async Task<ActionResult<IEnumerable<ChatUser>>> Login2(string username, string password)
        {
            var user = await _context.ChatUsers.Where(user => user.UserName == username && user.Password == password)
                .ToListAsync();

            if (user == null || user.Count <= 0)
            {
                return NotFound();
            }

            return user;
        }

        // GET: api/ChatUser/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ChatUser>> GetChatUser(Guid id)
        {
            var chatUser = await _context.ChatUsers.FindAsync(id);

            if (chatUser == null)
            {
                return NotFound();
            }

            return chatUser;
        }

        // PUT: api/ChatUser/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutChatUser(Guid id, ChatUser chatUser)
        {
            if (id != chatUser.UserId)
            {
                return BadRequest();
            }

            _context.Entry(chatUser).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ChatUserExists(id))
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

        // POST: api/ChatUser
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ChatUser>> PostChatUser(ChatUser chatUser)
        {
            _context.ChatUsers.Add(chatUser);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (ChatUserExists(chatUser.UserId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetChatUser", new { id = chatUser.UserId }, chatUser);
        }

        // DELETE: api/ChatUser/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteChatUser(Guid id)
        {
            var chatUser = await _context.ChatUsers.FindAsync(id);
            if (chatUser == null)
            {
                return NotFound();
            }

            _context.ChatUsers.Remove(chatUser);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ChatUserExists(Guid id)
        {
            return _context.ChatUsers.Any(e => e.UserId == id);
        }
    }
}