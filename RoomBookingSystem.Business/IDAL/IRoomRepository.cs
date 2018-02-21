using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using RoomBookingSystem.Business.Entities;

namespace RoomBookingSystem.Business.IDAL
{
    public interface IRoomRepository
    {
        Task<ICollection<Room>> GetAllRoomsAsync();
    }
}
