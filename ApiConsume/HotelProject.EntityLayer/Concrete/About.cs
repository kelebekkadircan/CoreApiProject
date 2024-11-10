﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelProject.EntityLayer.Concrete
{
    public class About
    {
        public int AboutID { get; set; }

        public string Title { get; set; }

        public string Content { get; set; }

        public int RoomCount { get; set; }

        public int StaffCount { get; set; }

        public int CustomerCount { get; set; }


    }
}
