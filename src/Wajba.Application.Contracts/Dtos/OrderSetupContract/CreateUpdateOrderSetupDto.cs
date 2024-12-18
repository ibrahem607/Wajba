﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wajba.Dtos.OrderSetupContract
{
    public class CreateUpdateOrderSetupDto
    {
        public int FoodPreparationTime { get; set; }
        public int ScheduleOrderSlotDuration { get; set; }
        public int FreeDeliveryKilometer { get; set; }
        public decimal BasicDeliveryCharge { get; set; }
        public decimal ChargePerKilo { get; set; }
        public bool IsTakeawayEnabled { get; set; }
        public bool IsDeliveryEnabled { get; set; }
    }
}
