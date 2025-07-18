using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Windows.Forms;

namespace _1
{
    class Horario
    {
        public string NumTrabajador { get; set; }
        public string Turno { get; set; }
        public string LunesAM { get; set; }
        public string MartesAM { get; set; }
        public string MiercolesAM { get; set; }
        public string JuevesAM { get; set; }
        public string ViernesAM { get; set; }
        public string LunesPM { get; set; }
        public string MartesPM { get; set; }
        public string MiercolesPM { get; set; }
        public string JuevesPM { get; set; }
        public string ViernesPM { get; set; }

        public bool GuardarHorario(clsconeccion conexion)
        {
            try
            {
                string sql = @"INSERT INTO horario (
                    `NUM-TRABAJADOR`, TURNO, `LUNES-am`, `MARTES-am`, `MIERCOLES-am`, `JUEVES-am`, `VIERNES-am`,
                    `lunes-pm`, `martes-pm`, `miercoles-pm`, `jueves-pm`, `viernes-pm`
                    ) VALUES (
                     @num, @turno, @l1, @l2, @l3, @l4, @l5,
                      @p1, @p2, @p3, @p4, @p5
                       )";

                MySqlCommand cmd = new MySqlCommand(sql, conexion.Abrir());
                cmd.Parameters.AddWithValue("@num", NumTrabajador);
                cmd.Parameters.AddWithValue("@turno", Turno);
                cmd.Parameters.AddWithValue("@l1", LunesAM);
                cmd.Parameters.AddWithValue("@l2", MartesAM);
                cmd.Parameters.AddWithValue("@l3", MiercolesAM);
                cmd.Parameters.AddWithValue("@l4", JuevesAM);
                cmd.Parameters.AddWithValue("@l5", ViernesAM);
                cmd.Parameters.AddWithValue("@p1", LunesPM);
                cmd.Parameters.AddWithValue("@p2", MartesPM);
                cmd.Parameters.AddWithValue("@p3", MiercolesPM);
                cmd.Parameters.AddWithValue("@p4", JuevesPM);
                cmd.Parameters.AddWithValue("@p5", ViernesPM);

                int filas = cmd.ExecuteNonQuery();
                conexion.Cerrar();
                return filas > 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al guardar horario: " + ex.Message);
                conexion.Cerrar();
                return false;
            }
        }
    }
}
