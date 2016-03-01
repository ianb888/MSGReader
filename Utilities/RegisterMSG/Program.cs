using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace RegisterMSG
{
    class Program
    {
        static void Main(string[] args)
        {
            string progPath = string.Empty;
            string iconPath = string.Empty;

            if (args.Length > 0)
            {
                if (args[0] == "NSIS")
                {
                    Console.WriteLine("!define PRODUCT_VERSION \"{0}\"", AssemblyVersion);
                    Environment.Exit(0);
                }

                progPath = args[0];

                if (args.Length > 1)
                {
                    iconPath = args[1];
                }
            }

            RegisterExtension(".eml", "message/rfc822", progPath, iconPath);
            RegisterExtension(".msg", "application/vnd.ms-outlook", progPath, iconPath);
        }

        static void RegisterExtension(string ext, string contentType, string progPath, string iconPath)
        {
            try
            {
                FileAssociationInfo fai = new FileAssociationInfo(ext);
                if (fai.Exists)
                {
                    fai.Delete();
                }

                fai.Create("MsgViewer");

                // Specify MIME type (optional)
                fai.ContentType = contentType;

                // Programs automatically displayed in open with list
                fai.OpenWithList = new string[] { "MsgViewer.exe" };

                ProgramAssociationInfo pai = new ProgramAssociationInfo(fai.ProgID);
                if (pai.Exists)
                {
                    pai.Delete();
                }

                pai.Create
                (
                    "Email Message",
                    new ProgramVerb("Open", progPath + " %1")
                );

                // Optional
                if (!string.IsNullOrEmpty(iconPath))
                {
                    pai.DefaultIcon = new ProgramIcon(iconPath);
                }
            }
            catch (Exception eX)
            {
                Console.Error.WriteLine(eX);
            }
#if DEBUG
            Console.WriteLine("Completed: {0} is installed as the default handler for {1} files.", progPath, ext);
            Console.ReadLine();
#endif
        }

        /// <summary>
        /// Returns the current AssemblyVersion
        /// </summary>
        public static string AssemblyVersion
        {
            get
            {
                return Assembly.GetExecutingAssembly().GetName().Version.ToString();
            }
        }
    }
}