﻿using DAO;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS
{
    public class HoaDon_BUS
    {
        public static List<HoaDon_DTO> DSHoaDon()
        {
            return HoaDon_DAO.DsHoaDon();
        }
    }
}
