using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using Calendar.Server.Models;
using Calendar.Server.ViewModels;

namespace Calendar.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private CalendarContext context;
        
        public AccountController(CalendarContext context)
        {
            this.context = context;
        }

        [HttpPost("register")]
        public ActionResult<User> Register([FromBody]RegisterViewModel model)
        {
            User user = context.Users.Where(u => u.Name == model.Name).SingleOrDefault();
            if (user != null)
                ModelState.AddModelError("Name", "Пользователь с таким именем уже существует!");
            user = context.Users.Where(u => u.Email == model.Email).SingleOrDefault();
            if (user != null)
                ModelState.AddModelError("Email", "Пользователь с таким почтовым адресом уже существует!");
            if (ModelState.ErrorCount > 0)
                return BadRequest(ModelState);
            user = new User() { Name = model.Name, Email = model.Email, Password = model.Password };
            user.Id = context.Users.Count() > 0 ? context.Users.Select(u => u.Id).Max() + 1 : 1;
            context.Users.Add(user);
            context.SaveChanges();
            return user;
        }

        [HttpPost("login")]
        public ActionResult<string> Login([FromBody]LoginViewModel model)
        {
            User user = context.Users.FirstOrDefault(u => u.Name == model.Name && u.Password == model.Password);
            ClaimsIdentity identity = GetIdentity(user);
            JwtSecurityToken jwt;
            DateTime now = DateTime.UtcNow;
            string encodedJwt;
            object response;
            if (identity == null)
            {
                ModelState.AddModelError("error", "Неправильный логин и (или) пароль!");
                return BadRequest(ModelState);
            }
            jwt = new JwtSecurityToken(issuer: AuthenticationOptions.ISSUER, audience: AuthenticationOptions.AUDIENCE, notBefore: now, claims: identity.Claims, expires: now.Add(TimeSpan.FromMinutes(AuthenticationOptions.LIFETIME)), signingCredentials: new SigningCredentials(AuthenticationOptions.GetSymmetricSecurityKey(), SecurityAlgorithms.HmacSha256));
            encodedJwt = new JwtSecurityTokenHandler().WriteToken(jwt);
            response = new { accessToken = encodedJwt, name = user.Name, email = user.Email };
            return JsonConvert.SerializeObject(response, new JsonSerializerSettings { Formatting = Formatting.Indented });
        }

        private ClaimsIdentity GetIdentity(User user)
        {
            List<Claim> claims;
            ClaimsIdentity claimsIdentity;
            if (user != null)
            {
                claims = new List<Claim> { new Claim(ClaimsIdentity.DefaultNameClaimType, user.Name) };
                claimsIdentity = new ClaimsIdentity(claims, "Token", ClaimsIdentity.DefaultNameClaimType, ClaimsIdentity.DefaultRoleClaimType);
                return claimsIdentity;
            }
            return null;
        }

        [Authorize]
        [HttpGet("getuserdata")]
        public UserViewModel GetUserData()
        {
            User user;
            List<EventViewModel> eventsList;
            List<UserEventTypeColorViewModel> userEventTypeColorsList;
            string name = User.Identity.Name;
            int i = 0, id;
            if (name == null)
                return null;
            user = context.Users.Where(u => u.Name == name).SingleOrDefault();
            if (user == null || user.Email == null)
                return null;
            id = context.UserEventTypeColors.Count() > 0 ? context.UserEventTypeColors.Select(u => u.Id).Max() + 1 : 1;
            foreach (EventType et in context.EventTypes)
                if (!context.UserEventTypeColors.Where(uetc => uetc.UserId == user.Id && uetc.TypeId == et.Id).Any())
                {
                    context.UserEventTypeColors.Add(new UserEventTypeColor() { Id = id + i, UserId = user.Id, TypeId = et.Id, Color = et.DefaultColor });
                    i++;
                }
            context.SaveChanges();
            eventsList = context.Events.Where(e => e.UserId == user.Id).Select(e => new EventViewModel() { Id = e.Id, Name = e.Name, DateStart = e.DateStart, DateEnd = e.DateEnd, Location = e.Location, Description = e.Description, Color = context.UserEventTypeColors.Where(uetc => uetc.UserId == user.Id && uetc.TypeId == e.TypeId).Select(uetc => uetc.Color).SingleOrDefault() }).ToList();
            userEventTypeColorsList = context.UserEventTypeColors.Where(uetc => uetc.UserId == user.Id).Select(uetc => new UserEventTypeColorViewModel() { Id = uetc.Id, Name = uetc.EventType.Name, Color = uetc.Color }).ToList();
            return new UserViewModel() { Id = user.Id, Name = user.Name, Email = user.Email, Events = eventsList, UserEventTypeColors = userEventTypeColorsList };
        }
    }
}