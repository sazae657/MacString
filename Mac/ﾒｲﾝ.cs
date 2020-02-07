using System;
using System.IO;
using System.Text;
using MacString;
namespace Mac
{
    class ﾒｲﾝ
    {

        static void Main(string[] args) {
            string str = null;
            using (var stdin = Console.OpenStandardInput())
            using (var omg = new MemoryStream()) {
                var buffer = new byte[2048];
                int bytes;
                while ((bytes = stdin.Read(buffer, 0, buffer.Length)) > 0) {
                    omg.Write(buffer, 0, bytes);
                }
                omg.Close();
                //str = Encoding.Default.GetString(omg.ToArray());
                str = (System.Environment.OSVersion.Platform switch
                {
                    PlatformID.Win32NT => Encoding.Default,
                    PlatformID.Unix => Encoding.UTF8, //TODO: LANG取った方が良さげ
                    _ => throw new NotSupportedException()
                }).GetString(omg.ToArray());
            }
            Console.WriteLine(str);
        }
    }
}
