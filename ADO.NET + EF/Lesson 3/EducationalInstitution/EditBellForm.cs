using System.Windows.Forms;

namespace EducationalInstitution
{
    public partial class EditBellForm : Form
    {
        public EditBellForm()
        {
            InitializeComponent();
        }

        private void ok_MouseDown(object sender, MouseEventArgs e)
        {
            if (bellEndTime.Value > bellBeginTime.Value)
                ok.DialogResult = DialogResult.OK;
            else
                MessageBox.Show("Дата окончания занятия должна быть позднее даты начала занятия!", "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public string BellBeginTime
        {
            get { return bellBeginTime.Text; }
            set { bellBeginTime.Text = value; }
        }

        public string BellEndTime
        {
            get { return bellEndTime.Text; }
            set { bellEndTime.Text = value; }
        }
    }
}