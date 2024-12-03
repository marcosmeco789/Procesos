using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Ejercicio3//Run app vacio, permisos, Array.Foreach
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();



        }

        private void viewProcesses()
        {
            Process[] p;

            p = Process.GetProcesses();

            textBox1.Clear();

            textBox1.AppendText(String.Format("{0,-30}", "PID:"));
            textBox1.AppendText(String.Format("{0,-30}", "Nombre:"));
            textBox1.AppendText(String.Format("{0,-30}", "Titulo:"));
            textBox1.AppendText("\r\n");

            Array.ForEach(p, item =>
            {
                textBox1.AppendText(String.Format("{0,-30}", item.Id.ToString()));      
                textBox1.AppendText(String.Format("{0,-30}", item.ProcessName));         
                textBox1.AppendText(String.Format("{0,-30}", item.MainWindowTitle));     
                acortarProcesos(item);                                                   
                textBox1.AppendText("---------------------------------------------------------------------------------------------\r\n");
            });


             
        }    

        private void acortarProcesos(Process item)
        {

            if (item.ProcessName.Length > 13)
            {
                textBox1.AppendText(String.Format("{0,-30}", item.ProcessName.Substring(0, 13) + "..."));
            }
            else
            {
                textBox1.AppendText(String.Format("{0,-30}", item.ProcessName));
            }


            if (item.MainWindowTitle.Length > 13)
            {
                textBox1.AppendText(String.Format("{0,-30}", item.MainWindowTitle.Substring(0, 13) + "..."));
            }
            else
            {
                textBox1.AppendText(String.Format("{0,-30}", item.MainWindowTitle));
            }
            textBox1.AppendText("\r\n");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            viewProcesses();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Process p;
            bool flag = false;
            int id = 0;

            flag = int.TryParse(textBox2.Text, out id);

            if (flag)
            {
                try
                {
                    p = Process.GetProcessById(id);
                    try
                    {
                        ProcessModuleCollection modules = p.Modules;
                        ProcessThreadCollection threads = p.Threads;

                        textBox1.Clear();

                        textBox1.AppendText("Nombre: " + p.ProcessName + " \r\n" + "ID: " + p.Id + " \r\n" + "Numeor de hilos: " + p.Threads.Count + "\r\n\r\n");

                        foreach (ProcessThread t in threads)
                        {
                            textBox1.AppendText(t.Id + " " + t.StartTime.ToShortTimeString() + " " + t.PriorityLevel + " " + t.ThreadState + "\r\n");
                        }

                        foreach (ProcessModule m in modules)
                        {
                            textBox1.AppendText(m.ModuleName + " " + m.FileVersionInfo + "\r\n");
                        }
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("No tienes permisos para ver ese proceso!", "ERROR ID",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);

                    }





                }
                catch (Exception)
                {
                    MessageBox.Show("No se ha encontrado ningun proceso con esa ID", "ERROR ID",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);

                }

            }
            else
            {
                MessageBox.Show("Solo numeros de IDs", "ERROR",
                 MessageBoxButtons.OK, MessageBoxIcon.Error);

            }

        }

        private void button3_Click(object sender, EventArgs e)
        {
            Process p;
            bool flag = false;
            int id = 0;

            flag = int.TryParse(textBox2.Text, out id);

            if (flag)
            {
                try
                {
                    p = Process.GetProcessById(id);

                    textBox1.Clear();
                    p.CloseMainWindow();
                    MessageBox.Show("Se ha cerrado el proceso", "Proceso cerrado exitosamente",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);




                }
                catch (ArgumentException)
                {
                    MessageBox.Show("No se ha encontrado ningun proceso con esa ID", "ERROR ID",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);

                }

            }
            else
            {
                MessageBox.Show("Solo numeros de IDs", "ERROR",
                 MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Process p;
            bool flag = false;
            int id = 0;

            flag = int.TryParse(textBox2.Text, out id);

            if (flag)
            {
                try
                {
                    p = Process.GetProcessById(id);

                    textBox1.Clear();
                    p.Kill();
                    MessageBox.Show("Se ha matado el proceso", "Kill exitoso",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);




                }
                catch (ArgumentException)
                {
                    MessageBox.Show("No se ha encontrado ningun proceso con esa ID", "ERROR ID",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);

                }

            }
            else
            {
                MessageBox.Show("Solo numeros de IDs", "ERROR",
                 MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Process p;
            string app;


            try
            {
                app = textBox2.Text;
                ProcessStartInfo startInfo = new ProcessStartInfo(app);
                p = Process.Start(startInfo);

            }
            catch (Exception)
            {
                MessageBox.Show("No se ha encontrado ninguna aplicacion con ese nombre/ruta", "ERROR",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }





        }

        private void button6_Click(object sender, EventArgs e)
        {
            Process[] p;
            string startsUpp = "";
            string startsLow = "";

            p = Process.GetProcesses();

            textBox1.Clear();
            startsUpp = textBox2.Text.Trim().ToUpper();
            startsLow = textBox2.Text.Trim().ToLower();

            textBox1.AppendText(String.Format("{0,-30}", "PID:"));
            textBox1.AppendText(String.Format("{0,-30}", "Nombre:"));
            textBox1.AppendText(String.Format("{0,-30}", "Titulo:"));
            textBox1.AppendText("\r\n");

            foreach (Process item in p)
            {
                if (item.ProcessName.StartsWith(startsUpp) || item.ProcessName.StartsWith(startsLow))
                {
                    textBox1.AppendText(String.Format("{0,-30}", item.Id.ToString()));
                    acortarProcesos(item);
                    textBox1.AppendText("---------------------------------------------------------------------------------------------\r\n");
                }


            }
        }
    }

}
