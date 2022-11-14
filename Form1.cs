using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MoreLinq;
namespace NewProject
{
    public partial class Form1 : Form
    {
        List<Human> list = new List<Human>();
        public Form1()
        {
            InitializeComponent();
            humanBindingSource.DataSource = list.ToDataTable();
            dataGridView1.DataSource = humanBindingSource;
        }

        private void tabPage1_Click(object sender, EventArgs e)
        {
          
        }
        public bool IsNotEmpty(string str)
        {
            if (string.IsNullOrWhiteSpace(str))
                return false;
            else return true;
        }
        private void buttonCreate_Click(object sender, EventArgs e)
        {
            int age = 0;
                string name = textBoxName.Text;
                //int age = int.Parse(textBoxAge.Text);
                string country = textBoxCountry.Text;
                if (IsNotEmpty(name) && IsNotEmpty(age.ToString()) && IsNotEmpty(country))
                {
                try
                {
                    age = int.Parse(textBoxAge.Text);
                    if (age > 0)
                    {
                        Human human = new Human(name, age, new Address(country));
                        list.Add(human);
                        humanBindingSource.DataSource = list.ToDataTable();
                        dataGridView1.DataSource = humanBindingSource;
                        buildfunct();
                        buildtree();
                        textBoxAge.BackColor = Color.White;
                    }
                    else
                    {
                        MessageBox.Show("Наверный тип поля возраст", "Ошибка");
                        textBoxAge.BackColor = Color.Red;
                    }
                }
                catch
                {
                    MessageBox.Show("Неверный тип возраста!");
                    textBoxAge.BackColor = Color.Red;
                }
                    /*if(age > 0) {
                        Human human = new Human(name, age, new Address(country));
                        list.Add(human);
                        humanBindingSource.DataSource = list.ToDataTable();
                        dataGridView1.DataSource = humanBindingSource;
                        buildfunct();
                        buildtree();
                       textBoxAge.BackColor = Color.White;
                }
                    else
                    {
                        MessageBox.Show("Наверный тип поля возраст", "Ошибка");
                        textBoxAge.BackColor = Color.Red;
                    }*/
                    
                }
                else
                {
                    MessageBox.Show("Вы заполнили не все поля!", "Ошибка");
                }
            }
        private void buildfunct()
        {
            this.chart1.Series["Age"].Points.Clear();
            this.chart1.Series["Age"].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Bar;
            //this.chart1.ChartAreas[0].Area3DStyle.Enable3D = true;

            int number = 0;
            for (int i = 0; i < list.Count; i++)
            {
                //this.chart1.Series["Series1"].Points.AddXY(listteach.ListTeacher[i].Name, listteach.ListTeacher[i].ListStudent.Count);
                if (list != null)
                {
                    number = list[i].Age;
                }
                else
                {
                    list = new List<Human>();
                    number = list[i].Age;
                }
                this.chart1.Series["Age"].Points.AddXY(list[i].Name, number);
            }



        }
        private void buildtree()
        {
            treeView1.Nodes.Clear();
            int c = 0;
            if (list != null)
            {
                foreach (Human human in list)
            {
                treeView1.Nodes.Add(human.Name);
                treeView1.Nodes[c].Nodes.Add(human.Country);
                    c++;
                }
                
            }
            treeView1.EndUpdate();
        }
    }

}
