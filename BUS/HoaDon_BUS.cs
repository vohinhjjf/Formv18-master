using DAO;
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
        public static List<HoaDon_DTO> LocDSHoaDon(DateTime checkin, DateTime checkout)
        {
            return HoaDon_DAO.LocDsHoaDon(checkin,checkout);
        }
        public static bool XoaHoaDon(int ID)
        {
            return HoaDon_DAO.XoaHoaDon(ID);
        }
    }
}
