using System;
using Entities;
using System.Collections.Generic;
using DataAccess;

namespace BussinessLayer
{
    public class PacienteBL
    {
        public static List<Paciente> Listpacientes;
        public List<Paciente> GetPacientes()
        {
            string path = PacientesDAL.ConexionPacientes();  // obtiene ruta de la BD
            string P = $"{path}\\BD\\Pacientes.txt";
            string[] lines = System.IO.File.ReadAllLines($"{path}\\BD\\Pacientes.txt");   //lee BD y lo guarda en []
            Listpacientes = new List<Paciente>();
            foreach (var item in lines)
            {
                string Dni = item.Split(',')[0]; //SPLIT => parte la cadena por comas y tomas el [0]
                string Nombre = item.Split(',')[1];
                string Apellido = item.Split(',')[2];
                Paciente p = new Paciente(Dni, Nombre, Apellido);
                Listpacientes.Add(p);
            }
            return Listpacientes;
        }
    }
}
