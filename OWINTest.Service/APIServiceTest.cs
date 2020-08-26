using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Owin.Hosting;
using System.Configuration;
using HelperUtilities.IO;

namespace OWINTest.Service
{
    public partial class APIServiceTest : ServiceBase
    {
        //public string baseAddress = "http://localhost:9000/";
        private IDisposable _server = null;
        private int port = 4500;
        private string baseAddress = "http://localhost/";


        public APIServiceTest()
        {
            InitializeComponent();
            Debugger.Launch();
            port = ConfigurationManager.AppSettings["Port"] == null ? port : Convert.ToInt16(ConfigurationManager.AppSettings.Get("Port").Trim());
            baseAddress = ConfigurationManager.AppSettings["BaseUrl"] == null ? baseAddress : ConfigurationManager.AppSettings.Get("BaseUrl").Trim();
            baseAddress = baseAddress.TrimEnd('/') + ":" + port.ToString() + "/";
        }

        protected override void OnStart(string[] args)
        {
           Debugger.Launch();
            Logger _logger = new Logger();
            _logger.AppendLog("test");

            //_server = WebApp.Start<Startup>(new StartOptions
            //{
            //    Port = port
                
            //});
            _logger.CommitLog("OnStart completed");
            _server = WebApp.Start<Startup>(url: baseAddress);
        }

        protected override void OnStop()
        {
            Logger _logger = new Logger();
            _logger = new Logger();
            if (_server != null)
            {
                _server.Dispose();
            }
            _logger.CommitLog("OnStop method called");
            base.OnStop();
        }
    }
}
