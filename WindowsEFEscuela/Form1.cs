using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsEFEscuela.Dac;
using WindowsEFEscuela.Models;

namespace WindowsEFEscuela
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
           
            TraerTodosLosAlumnos(); 
        }

      

        private void btnInsertar_Click(object sender, EventArgs e)
        {

            //Creamos un objeto instancia de Categoria
            Alumno alumno = new Alumno()
            { Nombre = txtNombre.Text,
                Apellido = txtApellido.Text,
                FechaNacimiento = new DateTime(1994, 12, 8),
                ProfesorId = 1
            };

            int filasAfectadas = AbmAlumno.Insert(alumno);

            if (filasAfectadas > 0)
            {
                MessageBox.Show("Insert OK");
                TraerTodosLosAlumnos();
            }

        } 
        private void TraerTodosLosAlumnos()
        {
            GridAlumnos.DataSource = AbmAlumno.SelectAll();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            Alumno alumno = new Alumno()
            {
                IdAlumno = Convert.ToInt32(txtId.Text),
                Nombre = txtNombre.Text,
                Apellido = txtApellido.Text,
                FechaNacimiento = new DateTime(1994, 12, 8),
                ProfesorId = 1
            };
            int filasAfectadas = AbmAlumno.Update(alumno);
            if (filasAfectadas > 0)
            {
                MessageBox.Show($"Update del alumno: {alumno.Nombre} {alumno.Apellido}");
                TraerTodosLosAlumnos();
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            Alumno alumno = new Alumno()
            {
                IdAlumno = Convert.ToInt32(txtId.Text),
            };

            int filasAfectadas = AbmAlumno.Delete(alumno);

            if (filasAfectadas > 0)
            {
                MessageBox.Show("Delete OK");
                TraerTodosLosAlumnos();
            }
        }

        private void btnBuscarPorId_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(txtId.Text);

            Alumno alumno = AbmAlumno.SelectWhereById(id);

            MessageBox.Show($"Alumno encontrado: {alumno.Nombre} {alumno.Apellido}");
        }
    }
}
