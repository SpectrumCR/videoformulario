using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using videoformulario.Modelo;

namespace videoformulario.Dato
{
    public class Usuario
    {
        List<UsuarioModel> lista = new List<UsuarioModel>();

        /// <summary>
        /// Consulta todos los usuarios
        /// </summary>
        /// <returns></returns>
        public List<UsuarioModel> Consultar()
        {
            return lista;
        }

        public List<UsuarioModel> LeerArchivo()
        {
            String linea;
            List<UsuarioModel> lista = new List<UsuarioModel>();
            try
            {
                StreamReader sr = new StreamReader(@"C:/Temp/ejemplo.txt");
                linea = sr.ReadLine();
                while (linea != null)
                {
                    string[] arreglo = linea.Split(',');
                    UsuarioModel modelo = new UsuarioModel(arreglo[0], int.Parse(arreglo[1]));
                    lista.Add(modelo);
                    linea = sr.ReadLine();
                }
                sr.Close();
            }
            catch (Exception e)
            {
                System.Windows.Forms.MessageBox.Show("Error: " + e.Message);
                return new List<UsuarioModel>();
            }
            return lista;
        }


        public void GuardarArchivo(DataTable tabla)
        {
            try
            {
                StreamWriter sw = new StreamWriter(@"C:/Temp/ejemplo.txt");
                foreach (DataRow item in tabla.Rows)
                {
                    sw.WriteLine(item["Nombre"] + "," + item["Edad"]);
                }
                sw.Close();
            }
            catch (Exception e)
            {
                System.Windows.Forms.MessageBox.Show("Error: " + e.Message);
            }
        }

    }
}
