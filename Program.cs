using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jurnal_MOD5_1302204079_KPL
{
    class Program
    {
        static void Main(string[] args)
        {
            SayaTubeVideo tube = new SayaTubeVideo("tutorial...");
            tube.PrintVideoDetails();
            tube.IncreaseplayCount(1);
            tube.PrintVideoDetails();
        }
    }
    public class SayaTubeVideo
    {
        int id;
        string title;
        int playCount;


        public SayaTubeVideo(string judul)
        {
            Contract.Requires(judul != null, "input null!");
            Contract.Requires(judul.Length <= 200, "input terlalu panjang!");

            Random random = new();
            this.id = random.Next(99999);
            this.title = judul;
            this.playCount = 0;
        }

        public void IncreaseplayCount(int angka)
        {
            Contract.Requires(angka <= 25000000, "input terlalu besar!");
            try
            {
                checked
                {
                    this.playCount += angka;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        public int GetPlaycount()
        {
            return playCount;
        }

        public string GetTitle()
        {
            return title;
        }

        public void printVideoDetails()
        {
            Console.WriteLine("title: " + title);
            Console.WriteLine("id: " + id);
            Console.WriteLine("playCount:" + playCount);
        }

        internal void PrintVideoDetails()
        {
            throw new NotImplementedException();
        }
    }

    public class SayaTubeUser
    {
        private int id;
        internal string username;
        List<SayaTubeVideo> uploadedVideos;
        private object video;

        public SayaTubeUser(string username)
        {
            Random shuffle = new Random();
            this.id = shuffle.Next(0, 100000);
            this.uploadedVideos = new List<SayaTubeVideo>();
        }

        public int GetTotalVideoPlayCount()
        {
            int total = 0;
            foreach (SayaTubeVideo video in this.uploadedVideos)
            {
                total += video.GetPlaycount();
            }
            return total;
        }

        public void AddVideo(SayaTubeVideo video)
        {
            uploadedVideos.Add(video);
            this.video = this.video;

        }

        public void PrintAllVideoPlaycount()
        {
            Console.WriteLine("User : " + this.video);
            for (int i = 0; i < uploadedVideos.Count; i++)
            {
                Console.WriteLine("Video " + (i + 1) + " Judul : " + this.uploadedVideos[i].GetTitle());
            }
        }
    }
}


