using ESRI.ArcGIS.esriSystem;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace VolunteerMap1
{
    static class Program
    {
        public static Form_Log logForm;
        public static GdbDrive gdbDrive;

        private static LicenseInitializer m_AOLicenseInitializer = new VolunteerMap1.LicenseInitializer();

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            //ESRI License Initializer generated code.
            m_AOLicenseInitializer.InitializeApplication(new esriLicenseProductCode[] { esriLicenseProductCode.esriLicenseProductCodeEngine },
            new esriLicenseExtensionCode[] { });
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //ESRI License Initializer generated code.
            //Do not make any call to ArcObjects after ShutDownApplication()
            m_AOLicenseInitializer.ShutdownApplication();

            //Form_Log f1 = new Form_Log();
            //f1.ShowDialog();

            //while (true)
            //{
            //    MainForm newform = new MainForm(ref f1);

            //    // 打开主窗口
            //    if (f1.DialogResult == DialogResult.OK)
            //    {
            //        newform.ShowDialog();
            //    }

            //    // 打开登录窗口
            //    if (newform.DialogResult == DialogResult.OK)
            //    {
            //        f1.ShowDialog();
            //    }   
            //}

            gdbDrive = new GdbDrive();

            logForm = new Form_Log();

            logForm.ShowDialog();
            
        }
    }
}