using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WindowsEFEscuela.Data;
using WindowsEFEscuela.Models;

namespace WindowsEFEscuela.Dac
{
    public static class AbmAlumno
    {
        private static DBEscuelaEFContext context = new DBEscuelaEFContext();
        
        //Traer todos
        public static List<Alumno> SelectAll()
        {
            return context.Alumnos.ToList();
        }

        //Traer uno por ID
        public static Alumno SelectWhereById(int id)
        {
            return context.Alumnos.Find(id);
        }

        //Insertar un alumno
        public static int Insert(Alumno alumno)
        {
            context.Alumnos.Add(alumno);
            return context.SaveChanges();
        }

        //Modificar un Alumno
        public static int Update(Alumno alumno)
        {
            Alumno alumnoOrigen = context.Alumnos.Find(alumno.IdAlumno);
            alumnoOrigen.Nombre = alumno.Nombre;
            alumnoOrigen.Apellido = alumno.Apellido;
            alumnoOrigen.FechaNacimiento = alumno.FechaNacimiento;
            return context.SaveChanges();
        }

        //Eliminar un Alumno
        public static int Delete(Alumno alumno)
        {
            Alumno alumnoOrigen = context.Alumnos.Find(alumno.IdAlumno);
            if (alumnoOrigen != null)
            {
                context.Alumnos.Remove(alumnoOrigen);
                return context.SaveChanges();
            }
            return 0;

        }
    }
}
