using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace DistanceFinder
{
    class Distance
    {
        static void Main(String[] args)
        {

            String originAddress = "101 SIVLEY RD";
            String originZip = "35801";
            String destAddress = "1613 NORTH MCKENZIE STREET1";
            String destZip = "36535";

            //Console.WriteLine(destAddress.Substring(20,6));

            double x = getDistance(originAddress, originZip, destAddress, destZip);
            Console.WriteLine("DISTANCE: " + x + " miles");

            Console.ReadKey();

        }

        private static double getDistance(String originAddress, String originZip, String destAddress, String destZip)
        {
            double distance = 0;
            List<String> data = getJSON(originAddress, originZip, destAddress, destZip);

            int index = 0;
            
            for (int i = 0; i < data.Count; i++)
            {
                if (data.ElementAt(i).Length > 9 && data.ElementAt(i).Substring(1, 8).Equals("distance"))
                {
                    index = i;
                    break;
                }
            }

            index++;

            int length = data.ElementAt(index).Length;
            
            distance = Double.Parse(data.ElementAt(index).Substring(8, data.ElementAt(index).Length-12));
            return distance;
        }

        private static List<String> getJSON(String originAddress, String originZip, String destAddress, String destZip)
        {

            List<String> result = new List<String>();

            String address;

            String[] temp;
            temp = originAddress.Split(new char[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries);
            String newOA = temp[0];
            for (int i = 1; i < temp.Length; i++)
            {
                newOA = newOA + "+" + temp[i];
            }

            temp = destAddress.Split(new char[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries);
            String newDA = temp[0];
            for (int i = 1; i < temp.Length; i++)
            {
                newDA = newDA + "+" + temp[i];
            }

            address = "https://maps.googleapis.com/maps/api/directions/json?origin=" + newOA.ToLower() + ",+" + originZip + "&destination=" + newDA.ToLower() + ",+" + destZip;

            try
            {
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(address);
                request.AutomaticDecompression = DecompressionMethods.GZip;

                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                Stream stream = response.GetResponseStream();
                StreamReader r = new StreamReader(stream);

                Console.WriteLine("Sending GET request to URL: " + address);

                String line;

                while ((line = r.ReadLine()) != null)
                {
                    result.Add(line.Replace(" ", ""));
                }
                r.Close();

            }
            catch (Exception e)
            {
                Console.WriteLine("ERROR: Data could not be loaded");
            }

            return result;
        }
    }
}
