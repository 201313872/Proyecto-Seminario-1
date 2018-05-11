using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;



namespace PerfilSS1
{
    public partial class Sitio : System.Web.UI.MasterPage
    {

        String Nombre_R;
        String Texto_R;
        public BD BDSQL = new BD();
        protected void Page_Load(object sender, EventArgs e)
        {
            BDSQL.abrir();
            TablaReco.DataSource = BDSQL.consultar();
            TablaReco.DataBind();
            BDSQL.cerrar();
        }

        protected void Recomendar_Click(object sender, EventArgs e)
        {
            int retorno=0;
            String Nombre_R;
            String Recomen_R;

            Nombre_R = Nombre.Text;
            Recomen_R = Recomenda.Text;
            Nombre.Text = String.Empty;
            Recomenda.Text = String.Empty;

            if (Nombre_R != String.Empty && Recomen_R != String.Empty)
            {
                if(Nombre_R !=null && Recomen_R != null){
                BDSQL.abrir();
                retorno = BDSQL.insertar(Nombre_R, Recomen_R);
                TablaReco.DataSource = BDSQL.consultar();
                TablaReco.DataBind();
                LabelError.Text = "";
               // Nombre.Text = retorno.ToString();
                BDSQL.cerrar();
                }else{
                    LabelError.Text = "Campos incorrectos!";
                Response.Redirect("#recomendacion");
                }
            }
            else {
                    LabelError.Text = "Campos incorrectos!";
                Response.Redirect("#recomendacion");
            }

        }
    }
}