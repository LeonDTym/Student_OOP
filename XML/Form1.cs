using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using System.Xml.Serialization;



namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        [Serializable]
        public class Save
        {
            public List<Student> save_list = new List<Student>();//Список сохранения
        }

        public List<Student> student_list = new List<Student>();//Список студентов


        public Form1()
        {
            InitializeComponent();
            panel1.Hide();
        }

        private void Form1_Load(object sender, EventArgs e)
        {panel1.Hide();          
        }

        private void Add_student(object sender, EventArgs e)//Окно добавления студента
        {
            panel1.Show();
            button4.Show();
            button5.Hide(); 
        }

        private void Add_new_student(object sender, EventArgs e)//Добавление Студента
        {
            if (textBox5.Text == "") { MessageBox.Show("Birthday error .______."); }
            if (textBox1.Text != "" & textBox2.Text != "" & textBox3.Text != "" & textBox5.Text != "")
            {


                Student new_student = new Student();
                new_student.firts_name = textBox1.Text;
                new_student.second_name = textBox2.Text;
                new_student.third_name = textBox3.Text;
                new_student.b_date = textBox5.Text;
                new_student.group_name = textBox6.Text;


                student_list.Add(new_student);


                dataGridView1.Rows.Add(textBox1.Text, textBox2.Text, textBox3.Text, textBox5.Text, textBox6.Text);
                ClearAll();
             
                panel1.Hide();
            }

        }
        
        public void ClearAll()//Метод очистки
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox5.Clear();
            textBox6.Clear();
        }

        private void Change_student(object sender, EventArgs e)
        {
           
                if (dataGridView1.CurrentCell != null)
                {
                    panel1.Show();
                    button5.Show();
                    button4.Hide();
                 try{
                    textBox1.Text = student_list[dataGridView1.CurrentCell.RowIndex].firts_name;
                    textBox2.Text = student_list[dataGridView1.CurrentCell.RowIndex].second_name;
                    textBox3.Text = student_list[dataGridView1.CurrentCell.RowIndex].third_name;
                    textBox5.Text = student_list[dataGridView1.CurrentCell.RowIndex].b_date;
                    textBox6.Text = student_list[dataGridView1.CurrentCell.RowIndex].group_name;
                }
                catch (Exception ex) 
                { 
                MessageBox.Show("Empty field (ʘ ͟ʖ ʘ) " + ex.Message );
                panel1.Hide(); }
            }
        }

        private void Confirm_changes(object sender, EventArgs e)//Подтвердить изменение 
        {
            int n = dataGridView1.CurrentCell.RowIndex;
            student_list[n].firts_name = textBox1.Text;
            student_list[n].second_name = textBox2.Text;
            student_list[n].third_name = textBox3.Text;
            student_list[n].b_date = textBox5.Text;
            student_list[n].group_name = textBox6.Text;


            dataGridView1.Rows.RemoveAt(n);
            dataGridView1.Rows.Insert(n, student_list[n].firts_name, student_list[n].second_name,
                student_list[n].third_name, student_list[n].b_date, student_list[n].group_name);
            panel1.Hide();

            ClearAll();
        }

        private void Delete_student(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentCell != null)
            {
                int n = dataGridView1.CurrentCell.RowIndex;
                try
                {
                    student_list.RemoveAt(n);
                    dataGridView1.Rows.RemoveAt(n);
                    MessageBox.Show("Deleted");
                }
                catch(Exception ex) { MessageBox.Show("Ты чё (⊙_⊙)？ "+ex.Message); }
                
            }
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        { 
            if (dateTimePicker1.Value > DateTime.Now)
            {
                MessageBox.Show("О вы из будущего?");              
            }
            else
                textBox5.Text = String.Format(dateTimePicker1.Value.ToShortDateString());
        }

        private void button6_Click(object sender, EventArgs e)//Сокрытие панели
        {
            panel1.Hide();
        }

        private void sAVEToolStripMenuItem_Click(object sender, EventArgs e) //Сохраненние с помощью Serialize
        {

            Stream myStream = null;
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();//Запрашивает у пользователя местоположение для сохранения файла.
            saveFileDialog1.InitialDirectory = "d:\\";
            saveFileDialog1.Filter = "xml files (*.xml)|*.xml|All files (*.*)|*.*";
            saveFileDialog1.FileName = "XMLw";
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                if ((myStream = saveFileDialog1.OpenFile()) != null)
                {
                    using (myStream)
                    {
                        Save st = new Save();
                        st.save_list = student_list;
                        XmlSerializer ser = new XmlSerializer(typeof(Save));//     Инициализирует новый экземпляр System.Xml.Serialization.XmlSerializer документов
                                                                            //     класс, который может сериализовать объекты заданного типа в XML-документов, а
                                                                            //     также десериализовать XML в объекты заданного типа.
                                                                            // Параметры:type:                                                    
                        ser.Serialize(myStream, st);//Сериализует указанный Object и записывает XML-документ в файл с помощью заданного Stream.
                        MessageBox.Show("Файл сохранен");
                    }
                }
            }
        }

        private void oPENToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Stream myStream = null;//Предоставляет универсальное представление последовательности байтов. Этот класс является абстрактным.
            OpenFileDialog openFileDialog1 = new OpenFileDialog();//Отображает диалоговое окно, позволяющее пользователю открыть файл.
            openFileDialog1.InitialDirectory = "D:\\";
            openFileDialog1.Filter = "xml files (*.xml)|*.xml|All files (*.*)|*.*";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    if ((myStream = openFileDialog1.OpenFile()) != null)
                    {
                        using (myStream)
                        {
                            XmlSerializer formatter = new XmlSerializer(typeof(Save));
                            Save newPerson = (Save)formatter.Deserialize(myStream);//Десериализует XML-документ, содержащийся указанным Stream.
                                                                                   //Десериализация — это процесс чтения XML-документа и конструирования объекта, строго типизированного в схему XML (XSD) документа.
                                                                                   //Перед десериализацией необходимо создать XmlSerializer объект, который должен быть создан с помощью типа десериализуемого объекта.
                                                                                   //Используйте stream параметр, чтобы указать объект, который является производным от Stream класс, который предназначен для записи в поток.Классы, производные от Stream класса, включают:
                            student_list = newPerson.save_list;
                            //dataGridView1.Rows.Clear();
                            for (int n = 0; n < student_list.Count; n++)
                            {
                                dataGridView1.Rows.Add(student_list[n].firts_name, student_list[n].second_name,
                                    student_list[n].third_name, student_list[n].b_date, student_list[n].group_name);
                            }
                        }
                    }
                }
                catch (Exception ex)
                { MessageBox.Show(ex.Message); }
            }
        }
       
    }
}
 