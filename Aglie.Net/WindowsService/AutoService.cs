using LogManager;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using WindowsService.Common;

namespace WindowsService
{
    public partial class AutoService : ServiceBase
    {
        private Logger logger = Logger.Instance;

        public AutoService()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
            try
            {
                TaskManager.TaskStart();

                logger.Info("Windows Service Start");
            }
            catch (Exception ex)
            {
                logger.Error("An exception occurred when the service starts", ex);
            }
        }

        protected override void OnStop()
        {
            logger.Info("Windows Service Stop");
        }
    }
}
