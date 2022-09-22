using System;
using System.Data;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class GPA : Form
    {
        DataTable table = new DataTable("table");
        GpaCalculation obj = new GpaCalculation();
        int index;

        public GPA()
        {
            this.Icon = Properties.Resources.calculator;
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string name, grade;
            double hrs, mids, ass, quiz, Final, sessional, total, gradepoint;

            try
            {
                if (string.IsNullOrEmpty(Namee.Text) == true)
                {
                    Namee.Focus();
                    errorProvider1.SetError(this.Namee, "Please Enter Name");
                }
                else if (comboBox1.SelectedItem == null)
                {
                    comboBox1.Focus();
                    errorProvider6.SetError(this.comboBox1, "Please Select Credit Hour");
                }
                else if (string.IsNullOrEmpty(Mid.Text) == true)
                {
                    Mid.Focus();
                    errorProvider2.SetError(this.Mid, "Please Enter Mid Marks");

                }
                else if (string.IsNullOrEmpty(Quiz.Text) == true)
                {
                    Quiz.Focus();
                    errorProvider3.SetError(this.Quiz, "Please Enter Quiz Marks");

                }
                else if (string.IsNullOrEmpty(Ass.Text) == true)
                {
                    Ass.Focus();
                    errorProvider4.SetError(this.Ass, "Please Enter Assignment Marks");

                }
                else if (string.IsNullOrEmpty(final.Text) == true)
                {
                    final.Focus();
                    errorProvider5.SetError(this.final, "Please Enter Final Marks");

                }
                else
                {
                    name = Namee.Text;
                    hrs = Convert.ToDouble(this.comboBox1.SelectedItem);
                    obj.setCrdHrs(hrs);
                    mids = Convert.ToDouble(this.Mid.Text);

                    if (mids < 0 || mids > 20)
                    {
                        Mid.Focus();
                        errorProvider2.SetError(Mid, "Value Must Be Between 0 to 20");
                        Mid.Text = null;
                    }
                    else
                    {
                        obj.SetMids(mids);
                    }
                   
                    quiz = Convert.ToDouble(this.Quiz.Text);
                    if (quiz < 0 || quiz > 10)
                    {
                        Quiz.Focus();
                        errorProvider3.SetError(Quiz, "Value Must Be Between 0 to 10");
                        Quiz.Text = null;
                    }
                    else
                    {
                        obj.setQuiz(quiz);
                    }
                    ass = Convert.ToDouble(this.Ass.Text);
                    if (ass < 0 || ass > 20)
                    {
                        Ass.Focus();
                        errorProvider4.SetError(Ass, "Value Must Be Between 0 to 20");
                        Ass.Text = null;
                    }
                    else
                    {
                        obj.setAssignment(ass);
                    }
                    Final = Convert.ToDouble(this.final.Text);
                    if (Final < 0 || Final > 50)
                    {
                        final.Focus();
                        errorProvider5.SetError(final, "Value Must Be Between 0 to 50");
                        final.Text = null;
                    }
                    else
                    {
                        obj.setFinal(Final);
                    }
                    if ((mids >= 0 && mids <= 20) && (quiz >= 0 && quiz <= 10) && (ass >= 0 && ass <= 20) && (Final >= 0 && Final <= 50))
                    {

                        sessional = obj.SessionalCal();
                        total = obj.totalCal();
                        gradepoint = obj.GradePoint();
                        grade = obj.Gradee(gradepoint);

                        obj.cal();
                        table.Rows.Add(Namee.Text, comboBox1.SelectedItem.ToString(), sessional, total, gradepoint, grade);
                        clear();
                        Namee.Focus();
                    }

                }
            }
            catch (Exception exc)
            {
                MessageBox.Show("Invalid Input");
            }

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            table.Columns.Add("Name", Type.GetType("System.String"));
            table.Columns.Add("CrdHrs", Type.GetType("System.Int32"));
            table.Columns.Add("Sessional", Type.GetType("System.Double"));
            table.Columns.Add("Total", Type.GetType("System.Double"));
            table.Columns.Add("GradePoint", Type.GetType("System.Double"));
            table.Columns.Add("Grade", Type.GetType("System.String"));
            dataGridView1.DataSource = table;
        }

        public void clear()
        {
            Namee.Text = null;
            comboBox1.SelectedItem = null;
            Mid.Text = null;
            Ass.Text = null;
            Quiz.Text = null;
            final.Text = null;
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            index = e.RowIndex;
            DataGridViewRow row = dataGridView1.Rows[index];
            Namee.Text = row.Cells[0].Value.ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            errorProvider1.Clear();
            try
            {

            index = dataGridView1.CurrentCell.RowIndex;
          
            dataGridView1.Rows.RemoveAt(index);
            clear();
            label7.Text = null;
            }
            catch
            {


            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            errorProvider1.Clear();
            double var = obj.Gpa();
          var=  Math.Round(var, 2);
            label7.Text =var.ToString();
        }



        private void Namee_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(Namee.Text) == true)
            {
                errorProvider1.SetError(this.Namee, "Please Enter Name");
                Namee.Focus();
            }
            else
            {
                errorProvider1.Clear();
            }
        }

        private void Mid_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(Mid.Text) == true)
            {
                errorProvider2.SetError(this.Mid, "Please Enter Mid Marks");
                Mid.Focus();

            }
            else
            {
                errorProvider2.Clear();
            }
        }

        private void Quiz_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(Quiz.Text) == true)
            {
                errorProvider3.SetError(this.Quiz, "Please Enter Quiz Marks");
                Quiz.Focus();

            }
            else
            {
                errorProvider3.Clear();
            }
        }

        private void Ass_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(Ass.Text) == true)
            {
                errorProvider4.SetError(this.Ass, "Please Enter Assignment Marks");
                Ass.Focus();

            }
            else
            {
                errorProvider4.Clear();
            }
        }

        private void final_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(final.Text) == true)
            {
                errorProvider5.SetError(this.final, "Please Enter Final Marks");
                final.Focus();

            }
            else
            {
                errorProvider5.Clear();
            }
        }

        private void comboBox1_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(comboBox1.Text) == true)
            {
                errorProvider6.SetError(this.comboBox1, "Please Select Credit Hour");
                comboBox1.Focus();

            }
            else
            {
                errorProvider6.Clear();
            }
        }

        private void Namee_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;
            if (char.IsLetter(ch) == true)
            {
                e.Handled = false;
            }
            else if (ch == 8)
            {
                e.Handled = false;
            }
            else if (ch == 32)
            {
                e.Handled = false;

            }
            else
            {
                e.Handled = true;
            }
        }

        private void Mid_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;
            if (char.IsDigit(ch) == true)
            {
                e.Handled = false;
            }
            else if (ch == 8)
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }

        private void Quiz_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;
            if (char.IsDigit(ch) == true)
            {
                e.Handled = false;
            }
            else if (ch == 8)
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }

        private void Ass_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;
            if (char.IsDigit(ch) == true)
            {
                e.Handled = false;
            }
            else if (ch == 8)
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }

        private void final_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;
            if (char.IsDigit(ch) == true)
            {
                e.Handled = false;
            }
            else if (ch == 8)
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }
    }
}
