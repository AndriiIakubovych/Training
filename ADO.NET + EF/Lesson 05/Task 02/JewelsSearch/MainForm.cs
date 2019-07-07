using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Linq;
using System.Xml;
using System.Xml.Linq;

namespace JewelsSearch
{
    public partial class MainForm : Form
    {

        private XDocument document;
        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            try
            {
                XmlReader reader = XmlReader.Create("jewels.xml");
                document = XDocument.Load(reader);
                IEnumerable<string> jewelColorQuery = from jewelItem in document.Descendants(XName.Get("jewel")) select jewelItem.Element(XName.Get("color")).Value;
                colorChoice.Items.Add("Любой");
                foreach (string jewelsColorItem in jewelColorQuery.Distinct())
                    colorChoice.Items.Add(jewelsColorItem);
                colorChoice.SelectedIndex = 0;
                colorChoiceText.Enabled = colorChoice.Enabled = find.Enabled = colorChoice.Items.Count > 0;
            }
            catch (Exception)
            {
                MessageBox.Show("Ошибка чтения данных!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Close();
            }
        }

        private void find_Click(object sender, EventArgs e)
        {
            ListViewItem it;
            try
            {
                var jewelQuery = from jewelItem in document.Descendants(XName.Get("jewel")) where jewelItem.Element(XName.Get("color")).Value == (colorChoice.SelectedIndex > 0 ? colorChoice.Text : jewelItem.Element(XName.Get("color")).Value) orderby jewelItem.Element(XName.Get("name")).Value select jewelItem;
                jewelsList.Clear();
                if (jewelQuery.Count() > 0)
                {
                    jewelsList.Columns.Add("Название");
                    jewelsList.Columns[0].Width = 100;
                    jewelsList.Columns.Add("Цвет");
                    jewelsList.Columns[1].Width = 150;
                    jewelsList.Columns.Add("Признак прозрачности");
                    jewelsList.Columns[2].Width = 130;
                    jewelsList.Columns.Add("Тип");
                    jewelsList.Columns[3].Width = 110;
                    jewelsList.Columns.Add("Описание");
                    jewelsList.Columns[4].Width = 700;
                    foreach (var jewelsItem in jewelQuery)
                    {
                        it = jewelsList.Items.Add(jewelsItem.Element(XName.Get("name")).Value);
                        it.SubItems.Add(jewelsItem.Element(XName.Get("color")).Value);
                        it.SubItems.Add(jewelsItem.Element(XName.Get("transparency")).Value);
                        it.SubItems.Add(jewelsItem.Element(XName.Get("type")).Value);
                        it.SubItems.Add(jewelsItem.Element(XName.Get("description")).Value);
                    }
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Ошибка чтения данных!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}