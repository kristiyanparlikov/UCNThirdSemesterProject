﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UCNThirdSemesterProject.ModelLayer;

namespace ModelLayer.Booking
{
    public class LivingState : BookingState
    {
        public override void Accept(BookingModel booking)
        {
            //living state cannot be accepted
        }

        public override void Cancel(BookingModel booking)
        {
            booking.TransitionToState(new NoticeState());
        }

        public override void Create(BookingModel booking, DateTime moveInDate, DateTime moveOutDate)
        {
            throw new NotImplementedException();
        }

        public override void EnterState(BookingModel booking)
        {
            throw new NotImplementedException();
        }
    }
}
