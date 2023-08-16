using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Sistema_Login_SCR.Models;

namespace Sistema_Login_SCR.Controllers
{
    public class LoginController : Controller
    {

        static string cadena = "Data Source=PC1\\SQLEXPRESS; Initial Catalog=REGISTRO_SCR; user id = sa; password=Dragones$14";

        // GET: Login
        public ActionResult Login()
        {
            return View();
        }

         [HttpPost]
         public ActionResult Login(Login_scr UsuarioLogin)
         {
           
                 using (SqlConnection Connection = new SqlConnection(cadena))
                 {
                     SqlCommand cmd = new SqlCommand("sp_ValidarUsuario", Connection);
                          cmd.Parameters.AddWithValue("Usuario",UsuarioLogin.Usuario);
                          cmd.Parameters.AddWithValue("Contrasenia",UsuarioLogin.Contrasenia);
                          cmd.CommandType = CommandType.StoredProcedure;

                         Connection.Open();

                     UsuarioLogin.IdUsuario = Convert.ToInt32(cmd.ExecuteScalar().ToString());
                 }
                  if (UsuarioLogin.IdUsuario != 0)
                  {
                         Session["Login_scr"] = UsuarioLogin;
                         return RedirectToAction("Index", "Home");

                  }else
                   {
                       ViewData["mensaje"] = "Acceso Denegado";
                       return View();
                   }
                  


             

         }

    }
}