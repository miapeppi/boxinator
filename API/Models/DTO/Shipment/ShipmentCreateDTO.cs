﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace boxinator.Models.DTO.Shipment
{
    public class ShipmentCreateDTO
    {
        public string ReceiverName { get; set; }
        public double Cost { get; set; }
        public int CountryId { get; set; }
        public ICollection<ShipmentCreateDTO> ShipmentStatusLogList { get; set; }

    }
}