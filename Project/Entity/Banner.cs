using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace Project.Entity
{
    public class Banner
    {
        public int AdvertisementID { get; set; }
        public string AdvertisementImage { get; set; }

        public Banner(int advertisementID, string advertisementImage)
        {
            AdvertisementID = advertisementID;
            AdvertisementImage = advertisementImage;
        }
    }

    public class BannerList
    {
        public static List<Banner> GetAllBanner()
        {
            List<Banner> BannerList = new List<Banner>();
            DataTable dt = Project.Data.BannerDAO.GetAllBanner();
            foreach (DataRow dr in dt.Rows)
            {
                Banner banner = new Banner(
                        Convert.ToInt32(dr["AdvertisementID"]),
                        dr["AdvertisementImage"].ToString()
                    );
                BannerList.Add(banner);
            }
            return BannerList;
        }
    }
}
