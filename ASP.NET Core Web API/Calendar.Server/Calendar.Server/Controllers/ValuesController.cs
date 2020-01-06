using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using Calendar.Server.Models;
using Calendar.Server.ViewModels;

namespace Calendar.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private CalendarContext context;
        
        public ValuesController(CalendarContext context)
        {
            this.context = context;
        }

        [HttpGet("/")]
        public string Get()
        {
            return "Сервер запущен!";
        }

        [HttpPost("addevent")]
        public EventViewModel AddEvent([FromBody]Event newEvent)
        {
            newEvent.Id = context.Events.Count() > 0 ? context.Events.Select(e => e.Id).Max() + 1 : 1;
            newEvent.DateStart = newEvent.DateStart.ToLocalTime();
            newEvent.DateEnd = newEvent.DateEnd.ToLocalTime();
            newEvent.TypeId = GetEventTypeId(newEvent.DateStart, newEvent.DateEnd);
            context.Events.Add(newEvent);
            context.SaveChanges();
            return new EventViewModel() { Id = newEvent.Id, Name = newEvent.Name, DateStart = newEvent.DateStart, DateEnd = newEvent.DateEnd, Location = newEvent.Location, Description = newEvent.Description, Color = context.UserEventTypeColors.Where(uetc => uetc.UserId == newEvent.UserId && uetc.TypeId == newEvent.TypeId).Select(uetc => uetc.Color).SingleOrDefault() };
        }

        [HttpPut("editevent")]
        public EventViewModel EditEvent([FromBody]Event newEvent)
        {
            Event requiredEvent = context.Events.Find(newEvent.Id);
            requiredEvent.Name = newEvent.Name;
            requiredEvent.DateStart = newEvent.DateStart.ToLocalTime();
            requiredEvent.DateEnd = newEvent.DateEnd.ToLocalTime();
            requiredEvent.TypeId = GetEventTypeId(requiredEvent.DateStart, requiredEvent.DateEnd);
            requiredEvent.Location = newEvent.Location;
            requiredEvent.Description = newEvent.Description;
            context.Entry(requiredEvent).State = EntityState.Modified;
            context.SaveChanges();
            return new EventViewModel() { Id = requiredEvent.Id, Name = requiredEvent.Name, DateStart = requiredEvent.DateStart, DateEnd = requiredEvent.DateEnd, Location = requiredEvent.Location, Description = requiredEvent.Description, Color = context.UserEventTypeColors.Where(uetc => uetc.UserId == requiredEvent.UserId && uetc.TypeId == requiredEvent.TypeId).Select(uetc => uetc.Color).SingleOrDefault() };
        }

        [HttpDelete("deleteevent/{id}")]
        public int DeleteEvent(int id)
        {
            Event requiredEvent = context.Events.Find(id);
            context.Entry(requiredEvent).State = EntityState.Deleted;
            context.SaveChanges();
            return requiredEvent.Id;
        }

        [HttpPut("changecolor")]
        public List<int> ChangeColor([FromBody]UserEventTypeColor userEventTypeColor)
        {
            UserEventTypeColor requiredUserEventTypeColor = context.UserEventTypeColors.Find(userEventTypeColor.Id);
            requiredUserEventTypeColor.Color = userEventTypeColor.Color;
            context.Entry(requiredUserEventTypeColor).State = EntityState.Modified;
            context.SaveChanges();
            return context.Events.Where(e => e.TypeId == requiredUserEventTypeColor.TypeId).Select(e => e.Id).ToList();
        }

        public int GetEventTypeId(DateTime dateStart, DateTime dateEnd)
        {
            int typeId;
            if (dateStart.Day == dateEnd.Day)
                typeId = (int)EventsTypes.SHORT + 1;
            else
            {
                if ((dateEnd - dateStart).Days <= 3)
                    typeId = (int)EventsTypes.MIDDLE + 1;
                else
                    typeId = (int)EventsTypes.LONG + 1;
            }
            return typeId;
        }
    }
}