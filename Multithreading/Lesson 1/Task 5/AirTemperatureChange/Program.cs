using System;
using System.Reflection;
using System.Threading;
using System.Windows.Forms;

namespace AirTemperatureChange
{
    static class Program
    {
        private static AppDomain graphView;
        private static AppDomain dataInput;
        private static Assembly graphViewAsm;
        private static Assembly dataInputAsm;
        private static Form graphViewWindow;
        private static Form dataInputWindow;

        [STAThread]
        [LoaderOptimization(LoaderOptimization.MultiDomain)]
        static void Main()
        {
            Application.EnableVisualStyles();
            dataInput = AppDomain.CreateDomain("TemperatureDataInput");
            graphView = AppDomain.CreateDomain("TemperatureGraphView");
            dataInputAsm = dataInput.Load(AssemblyName.GetAssemblyName("TemperatureDataInput.exe"));
            graphViewAsm = graphView.Load(AssemblyName.GetAssemblyName("TemperatureGraphView.exe"));
            graphViewWindow = Activator.CreateInstance(graphViewAsm.GetType("TemperatureGraphView.MainForm")) as Form;
            dataInputWindow = Activator.CreateInstance(dataInputAsm.GetType("TemperatureDataInput.MainForm"), new object[] { graphViewAsm.GetModule("TemperatureGraphView.exe"), graphViewWindow }) as Form;
            (new Thread(new ThreadStart(RunDataInput))).Start();
            (new Thread(new ThreadStart(RunGraphView))).Start();
        }

        public static void RunGraphView()
        {
            graphViewWindow.ShowDialog();
            AppDomain.Unload(graphView);
            try { Application.Exit(); }
            catch (Exception) { }
        }

        public static void RunDataInput()
        {
            dataInputWindow.ShowDialog();
            try { Application.Exit(); }
            catch (Exception) { }
        }
    }
}