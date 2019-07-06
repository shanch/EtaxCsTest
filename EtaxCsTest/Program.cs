using CLCOMMUNICATIONLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EtaxCsTest
{
    class Program
    {
        static void Main(string[] args)
        {
            CLCCommunication com = new CLCCommunication();
            com.AttestationUrl = "CLCommunication.ini";

            Console.WriteLine(com.UserId);

            CLCHttpRequestSU00S010 request = com.CreateRequest("XU00S010");

            request.SetParameter("sUserId", "1010");

            try
            {
                dynamic response  = com.Send();
                Console.WriteLine(com.GetHttpStatusCode());

                object o = null;

                com.GetResponseXmlData(out o);

                Console.WriteLine(Encoding.UTF8.GetString((byte[])o));

            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);
            }
        }
    }
}
