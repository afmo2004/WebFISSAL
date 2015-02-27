using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using FISSAL.Datos;
using FISSAL.Entidad;
using FISSAL.Negocio;

namespace FISSAL
{
    public partial class material_comunicacional : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Page.Title = "Material de difusión | FISSAL";
            ListarMateriales();
        }

        protected void ListarMateriales()
        {
            MaterialNegocio materialNegocio = new MaterialNegocio();
            List<Material> lista = materialNegocio.ListarMaterialActivo();
            int intContador = 0;
            bool bCierra = false;
            foreach (Material material in lista)
            {
                if ((intContador % 2 == 0))
                {
                    litMateriales.Text += @"<div class='cuerpo_superior'>";
                    litMateriales.Text += "<div class='difusion-izquierda'>";
                    litMateriales.Text += "   <div class='contenedor'>";
                    litMateriales.Text += "         <div class='caja1'><img src='images/" + material.vchImagen + "' width='304' height='208'/></div>";
                    litMateriales.Text += "         <div class='caja2'>";
                    litMateriales.Text += "            <div style='width:304px; height:auto;'>";
                    litMateriales.Text += "               <div class='imgdownload'><h6>" + material.vchTitulo +"</h6><p>" + material.vchDescripcion + "</p></div>";
                    litMateriales.Text += "               <div class='texdesc'><a href='materiales/" + material.vchArchivo + "'><img src='images/downloadwhite.png' align='right'/></a></div>";
                    litMateriales.Text += "               <div class='clear'></div>";
                    litMateriales.Text += "            </div>";
                    litMateriales.Text += "         </div>";
                    litMateriales.Text += "   </div>";
                    litMateriales.Text += "</div>";
                    bCierra = false;
                }
                else
                {
                    litMateriales.Text += "<div class='difusion-derecha'>";
                    litMateriales.Text += "   <div class='contenedor'>";
                    litMateriales.Text += "         <div class='caja1'><img src='images/" + material.vchImagen + "' width='304' height='208'/></div>";
                    litMateriales.Text += "         <div class='caja2'>";
                    litMateriales.Text += "            <div style='width:304px; height:auto;'>";
                    litMateriales.Text += "               <div class='imgdownload'><h6>" + material.vchTitulo + "</h6><p>" + material.vchDescripcion + "</p></div>";
                    litMateriales.Text += "               <div class='texdesc'><a href='materiales/" + material.vchArchivo + "'><img src='images/downloadwhite.png' align='right'/></a></div>";
                    litMateriales.Text += "               <div class='clear'></div>";
                    litMateriales.Text += "            </div>";
                    litMateriales.Text += "         </div>";
                    litMateriales.Text += "   </div>";
                    litMateriales.Text += "</div>";
                    if (!bCierra)
                    {
                        litMateriales.Text += "<div class='clear'></div>";
                        litMateriales.Text += "</div>";
                        bCierra = true;
                    }
                }
                intContador++;
            }
            if (!bCierra)
            {
                litMateriales.Text += "<div class='clear'></div>";
                litMateriales.Text += "</div>";
            }
        }
    }
}