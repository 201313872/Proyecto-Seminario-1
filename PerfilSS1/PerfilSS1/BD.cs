using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;

namespace PerfilSS1
{

   
    public class BD
    {
       // String Conexion="Data Source = DAVID\\SQLEXPRESS; Initial Catalog=SS1DB; Integrated Security=True";
        String Conexion = "Server=tcp:svss1.database.windows.net,1433;Initial Catalog=ss1db;Persist Security Info=False;User ID=david;Password=ss1Proyecto;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";

        public SqlConnection ConectarSQL = new SqlConnection();

        public BD(){
        
            ConectarSQL.ConnectionString=Conexion;

        }


        public void abrir(){
                try{
                    ConectarSQL.Open();
                    Console.Error.WriteLine("Conexion Realizada");
                }catch(Exception e){
                    Console.WriteLine("Error: "+e );
                }
        }


        public DataTable consultar() {
            SqlDataAdapter obtenerTabla = new SqlDataAdapter("SELECT NOMBRE AS Nombre, RECO AS Descripcion FROM RECOMENDACION;",ConectarSQL);
            DataTable tabla = new DataTable("Datos_Tabla");
            obtenerTabla.Fill(tabla);
            return tabla;
        }

        public int insertar(String nombre, String recomen) {
            SqlCommand comando = new SqlCommand(String.Format("INSERT INTO RECOMENDACION VALUES('{0}','{1}')",nombre,recomen),ConectarSQL);
            return comando.ExecuteNonQuery();
        }

        public void cerrar() {
            ConectarSQL.Close();
            Console.WriteLine("CONEXION CERRADA");
        }
    
    
    }
}