﻿using System;
using System.Collections.Generic;
using System.Text;
using RoomBookingSystem.Business.Entities;

namespace RoomBookingSystem.Business.IDAL
{
    public interface IBookingRepository
    {
        void CreateBookingAsync(Booking booking);

    }
}
