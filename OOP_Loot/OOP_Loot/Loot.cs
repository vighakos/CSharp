using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_Loot
{
    class Loot
    {
        public string InstanceName { get; set; }
        public string BossName { get; set; }
        public string ItemName { get; set; }
        public string ItemQuality { get; set; }
        public int ItemID { get; set; }
        public string Url { get; set; }
        public string ZoneName { get; set; }

        public Loot(string sor)
        {
            List<string> sornyiadat = sor.Split(';').ToList();

            InstanceName = sornyiadat[0];
            BossName = sornyiadat[1];
            ItemName = sornyiadat[2];
            ItemQuality = sornyiadat[3];
            ItemID = Convert.ToInt32(sornyiadat[4]);
            Url = sornyiadat[5];
            ZoneName = sornyiadat[6];
        }
    }
}
