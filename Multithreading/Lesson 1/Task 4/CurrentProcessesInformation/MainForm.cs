using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading;
using System.Windows.Forms;
using System.Diagnostics;
using System.Management;

namespace CurrentProcessesInformation
{
    public partial class MainForm : Form
    {
        private List<ProcessInfo> processesInfoList = new List<ProcessInfo>();
        private List<Process> processesList;
        private List<TreeNode> expandedNodesList = new List<TreeNode>();
        private Thread thread;
        private TreeNode selectedNode;

        private event Action CreateProcessesTreeAction;

        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            ThreadStart threadStart = new ThreadStart(CreateProcessesTree);
            thread = new Thread(threadStart);
            CreateProcessesTreeAction += CreateProcessesTree;
            thread.Start();
        }

        private void CreateProcessesTree()
        {
            Process parentProcess = null;
            TreeNode node;
            Action action;
            List<Process> previousProcessesList = new List<Process>();
            TreeNode expandedNode;
            bool isProcessListChanged = false;
            while (true)
            {
                processesList = Process.GetProcesses().ToList();
                isProcessListChanged = previousProcessesList.Count != processesList.Count;
                if (isProcessListChanged)
                {
                    processesInfoList.Clear();
                    foreach (Process p in processesList)
                    {
                        parentProcess = GetParentProcess(p);
                        processesInfoList.Add(new ProcessInfo { Id = p.Id, ProcessName = p.ProcessName, Pid = (parentProcess != null) ? parentProcess.Id : -1 });
                    }
                    action = () => 
                    {
                        selectedNode = processesTree.SelectedNode;
                        foreach (TreeNode tn in processesTree.Nodes)
                        {
                            if (tn.IsExpanded)
                                expandedNodesList.Add(tn);
                            FindExpandedNodes(tn);
                        }
                        processesTree.Nodes.Clear();
                    };
                    Invoke(action);
                    foreach (ProcessInfo pil in processesInfoList)
                        if (pil.Pid == -1)
                        {
                            node = new TreeNode(pil.ProcessName + " (" + pil.Id.ToString() + ")");
                            if (selectedNode != null && selectedNode.Text == node.Text)
                                selectedNode = node;
                            expandedNode = expandedNodesList.SingleOrDefault(enl => enl.Text == node.Text);
                            if (expandedNode != null && node.Text == expandedNode.Text)
                                node.Expand();
                            AddChildProcesses(pil, node);
                            action = () => { processesTree.Nodes.Add(node); };
                            Invoke(action);
                        }
                    previousProcessesList.Clear();
                    expandedNodesList.Clear();
                    foreach (Process pl in processesList)
                        previousProcessesList.Add(pl);
                    action = () => 
                    {
                        if (processesTree.Nodes.Count > 0)
                            processesTree.SelectedNode = selectedNode != null ? selectedNode : processesTree.Nodes[0];
                        if (processesTree.SelectedNode == null)
                            processesTree.SelectedNode = processesTree.Nodes[0];
                    };
                    Invoke(action);
                }
                Thread.Sleep(10000);
            }
        }

        private Process GetParentProcess(Process process)
        {
            try
            {
                ManagementObject mo = new ManagementObject("win32_process.handle=" + process.Id);
                mo.Get();
                return Process.GetProcessById(Convert.ToInt32(mo["ParentProcessId"]));
            }
            catch (Exception)
            {
                return null;
            }
        }

        private void AddChildProcesses(ProcessInfo processInfo, TreeNode node)
        {
            List<ProcessInfo> childProcessesList = processesInfoList.Where(pl => pl.Pid == processInfo.Id).ToList();
            TreeNode childNode, expandedNode;
            foreach (ProcessInfo cpl in childProcessesList)
            {
                childNode = new TreeNode(cpl.ProcessName + " (" + cpl.Id.ToString() + ")");
                if (selectedNode != null && selectedNode.Text == childNode.Text)
                    selectedNode = childNode;
                expandedNode = expandedNodesList.SingleOrDefault(enl => enl.Text == childNode.Text);
                if (expandedNode != null && childNode.Text == expandedNode.Text)
                    childNode.Expand();
                AddChildProcesses(cpl, childNode);
                node.Nodes.Add(childNode);
            }
        }

        private void FindExpandedNodes(TreeNode node)
        {
            foreach (TreeNode tn in node.Nodes)
            {
                if (tn.IsExpanded)
                    expandedNodesList.Add(tn);
                FindExpandedNodes(tn);
            }
        }

        private void processesTree_AfterSelect(object sender, TreeViewEventArgs e)
        {
            int startPosition, endPosition, selectedProcessId;
            Process selectedProcess;
            startPosition = processesTree.SelectedNode.Text.IndexOf('(') + 1;
            endPosition = processesTree.SelectedNode.Text.LastIndexOf(')');
            selectedProcessId = Convert.ToInt32(processesTree.SelectedNode.Text.Substring(startPosition, endPosition - startPosition));
            selectedProcess = processesList.Where(pl => pl.Id == selectedProcessId).SingleOrDefault();
            processInformation.Text = "Идентификатор процесса: " + selectedProcess.Id;
            processInformation.Text += "\r\nИмя процесса: " + selectedProcess.ProcessName;
            processInformation.Text += "\r\nБазовый приоритет процесса: " + selectedProcess.BasePriority;
            processInformation.Text += "\r\nДескриптор главного окна процесса: " + selectedProcess.MainWindowHandle;
            processInformation.Text += "\r\nКоличество невыгружаемой системной памяти, выделенной для процесса: " + selectedProcess.NonpagedSystemMemorySize64 + " байт";
            processInformation.Text += "\r\nКоличество выгружаемой системной памяти, выделенной для процесса: " + selectedProcess.PagedMemorySize64 + " байт";
            processInformation.Text += "\r\nОбъём выгружаемой системной памяти, выделенной для процесса: " + selectedProcess.PagedSystemMemorySize64 + " байт";
            processInformation.Text += "\r\nМаксимальное количество памяти в файле подкачки виртуальной памяти, используемой процессом: " + selectedProcess.PeakPagedMemorySize64 + " байт";
            processInformation.Text += "\r\nМаксимальное количество виртуальной памяти, используемой процессом: " + selectedProcess.PeakVirtualMemorySize64 + " байт";
            processInformation.Text += "\r\nКоличество виртуальной памяти, выделенной для процесса: " + selectedProcess.VirtualMemorySize64 + " байт";
            processInformation.Text += "\r\nКоличество физической памяти, выделенной для процесса: " + selectedProcess.WorkingSet64 + " байт";
            processInformation.Text += "\r\nЗаголовок главного окна процесса: " + (selectedProcess.MainWindowTitle.Length > 0 ? selectedProcess.MainWindowTitle : "-");
            processInformation.Text += "\r\nИдентификатор сеанса служб терминалов для процесса: " + selectedProcess.SessionId;
        }

        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            thread.Abort();
        }
    }
}