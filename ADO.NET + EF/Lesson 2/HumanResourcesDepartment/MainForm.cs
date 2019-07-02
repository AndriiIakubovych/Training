using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;

namespace HumanResourcesDepartment
{
    public partial class MainForm : Form
    {
        private List<Employee> employeesList;
        private Image noPhoto;
        private MemoryStream ms;

        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            UsersRightsForm usersRightsForm = new UsersRightsForm();
            SqlConnection connection = null;
            try
            {
                if (usersRightsForm.ShowDialog() == DialogResult.OK)
                {
                    int empId, empHiringOrderNumber, empFiringOrderNumber, bufferSize = 100, retval, startIndex;
                    string empName, empPosition;
                    DateTime empBirthdate;
                    Image empPhoto = null;
                    noPhoto = photo.Image;
                    connection = new SqlConnection("Data Source = .\\SQLEXPRESS; Initial Catalog = Enterprise; Integrated Security = True");
                    SqlCommand command = connection.CreateCommand();
                    ms = new MemoryStream();
                    byte[] buffer = new byte[bufferSize];
                    command.CommandType = CommandType.StoredProcedure;
                    command.CommandText = "GetEmployees";
                    connection.Open();
                    employeesList = new List<Employee>();
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        empId = reader.GetInt32(reader.GetOrdinal("Employee_id"));
                        empName = reader.GetString(reader.GetOrdinal("Employee_name"));
                        empBirthdate = reader.GetDateTime(reader.GetOrdinal("Birthdate"));
                        empPosition = reader.GetString(reader.GetOrdinal("Position"));
                        empHiringOrderNumber = reader.IsDBNull(4) ? 0 : reader.GetInt32(reader.GetOrdinal("Hiring_order_number"));
                        empFiringOrderNumber = reader.IsDBNull(5) ? 0 : reader.GetInt32(reader.GetOrdinal("Firing_order_number"));
                        if (reader.IsDBNull(6))
                            empPhoto = noPhoto;
                        else
                        {
                            startIndex = 0;
                            while (true)
                            {
                                retval = (int)reader.GetBytes(reader.GetOrdinal("Photo"), startIndex, buffer, 0, bufferSize);
                                if (retval < 1)
                                    break;
                                ms.Write(buffer, 0, retval);
                                ms.Flush();
                                startIndex += retval;
                            }
                            if (ms.Length < 1)
                                return;
                            empPhoto = Image.FromStream(ms);
                            ms.Seek(0, SeekOrigin.Begin);
                        }
                        employeesList.Add(new Employee(empId, empName, empBirthdate, empPosition, empHiringOrderNumber, empFiringOrderNumber, empPhoto));
                        employeeChoice.Items.Add(empName);
                        employeeChoice.Sorted = true;
                    }
                    if (employeeChoice.Items.Count > 0)
                    {
                        employeeChoice.SelectedIndex = 0;
                        employeeChoiceText.Enabled = employeeChoice.Enabled = employeeNameText.Enabled = employeeName.Enabled = birthdateText.Enabled = birthdate.Enabled = positionText.Enabled = position.Enabled = hiringOrderNumberText.Enabled = hiringOrderNumber.Enabled = firingOrderNumberText.Enabled = firingOrderNumber.Enabled = photo.Enabled = editEmployee.Enabled = deleteEmployee.Enabled = true;
                    }
                    if (usersRightsForm.UserType == 1)
                        addEmployee.Enabled = editEmployee.Enabled = deleteEmployee.Enabled = false;
                    reader.Close();
                    connection.Close();
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Ошибка подключения к БД!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                connection.Close();
                Close();
            }
        }

        private void employeeChoice_SelectedIndexChanged(object sender, EventArgs e)
        {
            foreach (Employee emp in employeesList)
                if (emp.EmployeeName == employeeChoice.Text)
                {
                    employeeName.Text = emp.EmployeeName;
                    birthdate.Text = emp.Birthdate.ToShortDateString();
                    position.Text = emp.Position;
                    hiringOrderNumber.Text = emp.HiringOrderNumber == 0 ? "" : emp.HiringOrderNumber.ToString();
                    firingOrderNumber.Text = emp.FiringOrderNumber == 0 ? "" : emp.FiringOrderNumber.ToString();
                    photo.Image = emp.Photo;
                }
        }

        public bool ThumbnailCallBack()
        {
            return false;
        }

        private void addEmployee_Click(object sender, EventArgs e)
        {
            AddEmployeeForm addEmployeeForm = new AddEmployeeForm();
            int max = 0;
            SqlConnection connection;
            SqlCommand command;
            Bitmap bitmap;
            Image imagePreview;
            BinaryReader br;
            byte[] image;
            try
            {
                if (addEmployeeForm.ShowDialog() == DialogResult.OK)
                {
                    connection = new SqlConnection("Data Source = .\\SQLEXPRESS; Initial Catalog = Enterprise; Integrated Security = True");
                    command = connection.CreateCommand();
                    command.CommandType = CommandType.StoredProcedure;
                    command.CommandText = "AddEmployee";
                    SqlParameter employeeIdParam = new SqlParameter();
                    employeeIdParam.ParameterName = "@employeeId";
                    employeeIdParam.SqlDbType = SqlDbType.Int;
                    employeeIdParam.Direction = ParameterDirection.Input;
                    foreach (Employee emp in employeesList)
                        if (emp.EmployeeId > max)
                            max = emp.EmployeeId;
                    employeeIdParam.Value = employeesList.Count > 0 ? max + 1 : 1;
                    SqlParameter employeeNameParam = new SqlParameter();
                    employeeNameParam.ParameterName = "@employeeName";
                    employeeNameParam.SqlDbType = SqlDbType.VarChar;
                    employeeNameParam.Direction = ParameterDirection.Input;
                    employeeNameParam.Value = addEmployeeForm.EmployeeName;
                    SqlParameter birthdateParam = new SqlParameter();
                    birthdateParam.ParameterName = "@birthdate";
                    birthdateParam.SqlDbType = SqlDbType.DateTime;
                    birthdateParam.Direction = ParameterDirection.Input;
                    birthdateParam.Value = addEmployeeForm.Birthdate;
                    SqlParameter positionParam = new SqlParameter();
                    positionParam.ParameterName = "@position";
                    positionParam.SqlDbType = SqlDbType.VarChar;
                    positionParam.Direction = ParameterDirection.Input;
                    positionParam.Value = addEmployeeForm.Position;
                    SqlParameter hiringOrderNumberParam = new SqlParameter();
                    hiringOrderNumberParam.ParameterName = "@hiringOrderNumber";
                    hiringOrderNumberParam.SqlDbType = SqlDbType.Int;
                    hiringOrderNumberParam.Direction = ParameterDirection.Input;
                    if (addEmployeeForm.HiringOrderNumber.Length > 0)
                        hiringOrderNumberParam.Value = addEmployeeForm.HiringOrderNumber;
                    else
                        hiringOrderNumberParam.Value = DBNull.Value;
                    SqlParameter firingOrderNumberParam = new SqlParameter();
                    firingOrderNumberParam.ParameterName = "@firingOrderNumber";
                    firingOrderNumberParam.SqlDbType = SqlDbType.Int;
                    firingOrderNumberParam.Direction = ParameterDirection.Input;
                    if (addEmployeeForm.FiringOrderNumber.Length > 0)
                        firingOrderNumberParam.Value = addEmployeeForm.FiringOrderNumber;
                    else
                        firingOrderNumberParam.Value = DBNull.Value;
                    SqlParameter photoParam = new SqlParameter();
                    photoParam.ParameterName = "@photo";
                    photoParam.SqlDbType = SqlDbType.Image;
                    photoParam.Direction = ParameterDirection.Input;
                    if (addEmployeeForm.PhotoFileName.Length > 0)
                    {
                        bitmap = new Bitmap(addEmployeeForm.PhotoFileName);
                        Image.GetThumbnailImageAbort callBack = new Image.GetThumbnailImageAbort(ThumbnailCallBack);
                        imagePreview = bitmap.GetThumbnailImage(photo.Width, photo.Height, callBack, IntPtr.Zero);
                        imagePreview.Save(ms, System.Drawing.Imaging.ImageFormat.Bmp);
                        ms.Flush();
                        ms.Seek(0, SeekOrigin.Begin);
                        br = new BinaryReader(ms);
                        image = br.ReadBytes((int)ms.Length);
                        photoParam.Value = image;
                        photo.Image = Image.FromStream(ms);
                    }
                    else
                        photoParam.Value = DBNull.Value;
                    command.Parameters.Add(employeeIdParam);
                    command.Parameters.Add(employeeNameParam);
                    command.Parameters.Add(birthdateParam);
                    command.Parameters.Add(positionParam);
                    command.Parameters.Add(hiringOrderNumberParam);
                    command.Parameters.Add(firingOrderNumberParam);
                    command.Parameters.Add(photoParam);
                    connection.Open();
                    command.ExecuteNonQuery();
                    employeesList.Add(new Employee(employeesList.Count > 0 ? max + 1 : 1, addEmployeeForm.EmployeeName, addEmployeeForm.Birthdate, addEmployeeForm.Position, addEmployeeForm.HiringOrderNumber.Length > 0 ? Convert.ToInt32(addEmployeeForm.HiringOrderNumber) : 0, addEmployeeForm.FiringOrderNumber.Length > 0 ? Convert.ToInt32(addEmployeeForm.FiringOrderNumber) : 0, ms != null ? Image.FromStream(ms) : noPhoto));
                    employeeChoice.Items.Add(addEmployeeForm.EmployeeName);
                    for (int i = 0; i < employeeChoice.Items.Count; i++)
                        if (employeeChoice.Items[i].ToString() == addEmployeeForm.EmployeeName)
                            employeeChoice.SelectedIndex = i;
                    if (employeeChoice.Items.Count > 0)
                        employeeChoiceText.Enabled = employeeChoice.Enabled = employeeNameText.Enabled = employeeName.Enabled = birthdateText.Enabled = birthdate.Enabled = positionText.Enabled = position.Enabled = hiringOrderNumberText.Enabled = hiringOrderNumber.Enabled = firingOrderNumberText.Enabled = firingOrderNumber.Enabled = photo.Enabled = editEmployee.Enabled = deleteEmployee.Enabled = true;
                    connection.Close();
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Ошибка подключения к БД!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void editEmployee_Click(object sender, EventArgs e)
        {
            int index = 0;
            EditEmployeeForm editEmployeeForm = new EditEmployeeForm();
            SqlConnection connection;
            SqlCommand command;
            Bitmap bitmap;
            Image imagePreview;
            BinaryReader br;
            byte[] image;
            try
            {
                for (int i = 0; i < employeesList.Count; i++)
                    if (employeesList[i].EmployeeName == employeeChoice.Text)
                    {
                        editEmployeeForm.EmployeeName = employeesList[i].EmployeeName;
                        editEmployeeForm.Birthdate = employeesList[i].Birthdate;
                        editEmployeeForm.Position = employeesList[i].Position;
                        editEmployeeForm.HiringOrderNumber = employeesList[i].HiringOrderNumber == 0 ? "" : employeesList[i].HiringOrderNumber.ToString();
                        editEmployeeForm.FiringOrderNumber = employeesList[i].FiringOrderNumber == 0 ? "" : employeesList[i].FiringOrderNumber.ToString();
                        index = i;
                        break;
                    }
                if (editEmployeeForm.ShowDialog() == DialogResult.OK)
                {
                    connection = new SqlConnection("Data Source = .\\SQLEXPRESS; Initial Catalog = Enterprise; Integrated Security = True");
                    command = connection.CreateCommand();
                    command.CommandType = CommandType.StoredProcedure;
                    command.CommandText = "EditEmployee";
                    SqlParameter employeeIdParam = new SqlParameter();
                    employeeIdParam.ParameterName = "@employeeId";
                    employeeIdParam.SqlDbType = SqlDbType.Int;
                    employeeIdParam.Direction = ParameterDirection.Input;
                    employeeIdParam.Value = employeesList[index].EmployeeId;
                    SqlParameter employeeNameParam = new SqlParameter();
                    employeeNameParam.ParameterName = "@employeeName";
                    employeeNameParam.SqlDbType = SqlDbType.VarChar;
                    employeeNameParam.Direction = ParameterDirection.Input;
                    employeeNameParam.Value = editEmployeeForm.EmployeeName;
                    SqlParameter birthdateParam = new SqlParameter();
                    birthdateParam.ParameterName = "@birthdate";
                    birthdateParam.SqlDbType = SqlDbType.DateTime;
                    birthdateParam.Direction = ParameterDirection.Input;
                    birthdateParam.Value = editEmployeeForm.Birthdate;
                    SqlParameter positionParam = new SqlParameter();
                    positionParam.ParameterName = "@position";
                    positionParam.SqlDbType = SqlDbType.VarChar;
                    positionParam.Direction = ParameterDirection.Input;
                    positionParam.Value = editEmployeeForm.Position;
                    SqlParameter hiringOrderNumberParam = new SqlParameter();
                    hiringOrderNumberParam.ParameterName = "@hiringOrderNumber";
                    hiringOrderNumberParam.SqlDbType = SqlDbType.Int;
                    hiringOrderNumberParam.Direction = ParameterDirection.Input;
                    if (editEmployeeForm.HiringOrderNumber.Length > 0)
                        hiringOrderNumberParam.Value = editEmployeeForm.HiringOrderNumber;
                    else
                        hiringOrderNumberParam.Value = DBNull.Value;
                    SqlParameter firingOrderNumberParam = new SqlParameter();
                    firingOrderNumberParam.ParameterName = "@firingOrderNumber";
                    firingOrderNumberParam.SqlDbType = SqlDbType.Int;
                    firingOrderNumberParam.Direction = ParameterDirection.Input;
                    if (editEmployeeForm.FiringOrderNumber.Length > 0)
                        firingOrderNumberParam.Value = editEmployeeForm.FiringOrderNumber;
                    else
                        firingOrderNumberParam.Value = DBNull.Value;
                    SqlParameter changePhotoParam = new SqlParameter();
                    changePhotoParam.ParameterName = "@changePhoto";
                    changePhotoParam.SqlDbType = SqlDbType.Bit;
                    changePhotoParam.Direction = ParameterDirection.Input;
                    SqlParameter photoParam = new SqlParameter();
                    photoParam.ParameterName = "@photo";
                    photoParam.SqlDbType = SqlDbType.Image;
                    photoParam.Direction = ParameterDirection.Input;
                    if (editEmployeeForm.ChangePhoto)
                    {
                        changePhotoParam.Value = true;
                        if (editEmployeeForm.PhotoFileName.Length > 0)
                        {
                            bitmap = new Bitmap(editEmployeeForm.PhotoFileName);
                            Image.GetThumbnailImageAbort callBack = new Image.GetThumbnailImageAbort(ThumbnailCallBack);
                            imagePreview = bitmap.GetThumbnailImage(photo.Width, photo.Height, callBack, IntPtr.Zero);
                            imagePreview.Save(ms, System.Drawing.Imaging.ImageFormat.Bmp);
                            ms.Flush();
                            ms.Seek(0, SeekOrigin.Begin);
                            br = new BinaryReader(ms);
                            image = br.ReadBytes((int)ms.Length);
                            photoParam.Value = image;
                        }
                        else
                        {
                            ms = null;
                            photoParam.Value = DBNull.Value;
                        }
                    }
                    else
                    {
                        changePhotoParam.Value = false;
                        ms = null;
                        photoParam.Value = DBNull.Value;
                    }
                    command.Parameters.Add(employeeIdParam);
                    command.Parameters.Add(employeeNameParam);
                    command.Parameters.Add(birthdateParam);
                    command.Parameters.Add(positionParam);
                    command.Parameters.Add(hiringOrderNumberParam);
                    command.Parameters.Add(firingOrderNumberParam);
                    command.Parameters.Add(changePhotoParam);
                    command.Parameters.Add(photoParam);
                    connection.Open();
                    command.ExecuteNonQuery();
                    employeesList[index].EmployeeName = editEmployeeForm.EmployeeName;
                    employeesList[index].Birthdate = editEmployeeForm.Birthdate;
                    employeesList[index].Position = editEmployeeForm.Position;
                    employeesList[index].HiringOrderNumber = editEmployeeForm.HiringOrderNumber.Length > 0 ? Convert.ToInt32(editEmployeeForm.HiringOrderNumber) : 0;
                    employeesList[index].FiringOrderNumber = editEmployeeForm.FiringOrderNumber.Length > 0 ? Convert.ToInt32(editEmployeeForm.FiringOrderNumber) : 0;
                    if (editEmployeeForm.ChangePhoto)
                        employeesList[index].Photo = (ms != null) ? Image.FromStream(ms) : noPhoto;
                    employeeChoice.Items[employeeChoice.SelectedIndex] = editEmployeeForm.EmployeeName;
                    ms = new MemoryStream();
                    connection.Close();
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Ошибка подключения к БД!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void deleteEmployee_Click(object sender, EventArgs e)
        {
            int index;
            SqlConnection connection;
            SqlCommand command;
            try
            {
                if (MessageBox.Show("Вы действительно хотите удалить данные о сотруднике?", "Удаление данных", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    for (int i = 0; i < employeesList.Count; i++)
                        if (employeesList[i].EmployeeName == employeeChoice.Text)
                        {
                            connection = new SqlConnection("Data Source = .\\SQLEXPRESS; Initial Catalog = Enterprise; Integrated Security = True");
                            command = connection.CreateCommand();
                            command.CommandType = CommandType.StoredProcedure;
                            command.CommandText = "DeleteEmployee";
                            SqlParameter employeeIdParam = new SqlParameter();
                            employeeIdParam.ParameterName = "@employeeId";
                            employeeIdParam.SqlDbType = SqlDbType.Int;
                            employeeIdParam.Direction = ParameterDirection.Input;
                            employeeIdParam.Value = employeesList[i].EmployeeId;
                            command.Parameters.Add(employeeIdParam);
                            connection.Open();
                            command.ExecuteNonQuery();
                            employeesList.RemoveAt(i);
                            index = employeeChoice.SelectedIndex;
                            employeeChoice.Items.RemoveAt(index);
                            if (employeeChoice.Items.Count > 0)
                                employeeChoice.SelectedIndex = index > 0 ? index - 1 : 0;
                            if (employeeChoice.Items.Count == 0)
                            {
                                employeeName.Text = birthdate.Text = position.Text = hiringOrderNumber.Text = firingOrderNumber.Text = "";
                                photo.Image = noPhoto;
                                employeeChoiceText.Enabled = employeeChoice.Enabled = employeeNameText.Enabled = employeeName.Enabled = birthdateText.Enabled = birthdate.Enabled = positionText.Enabled = position.Enabled = hiringOrderNumberText.Enabled = hiringOrderNumber.Enabled = firingOrderNumberText.Enabled = firingOrderNumber.Enabled = photo.Enabled = editEmployee.Enabled = deleteEmployee.Enabled = false;
                            }
                            connection.Close();
                            break;
                        }
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Ошибка подключения к БД!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (ms != null)
                ms.Close();
        }
    }
}