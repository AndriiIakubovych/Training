using System.Windows.Forms;

namespace EducationalInstitution
{
    public partial class AddBellForm : Form
    {
        public AddBellForm()
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
        }

        public string BellEndTime
        {
            get { return bellEndTime.Text; }
        }
    }
}