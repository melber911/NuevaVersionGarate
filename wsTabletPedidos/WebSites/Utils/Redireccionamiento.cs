using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace WebSites.Utils
{
    public class Redireccionamiento
    {
        public static void Login(System.Web.UI.Page page, Type tipo)
        {
            string script = @"
            function getCookie(name) {
                const value = `; ${document.cookie}`;
                const parts = value.split(`; ${name}=`);
                return parts.length === 2 ? parts.pop().split(';').shift() : null;
            }
    
            const privileges = getCookie('privileges');
    
            swal({
                title: 'Aviso',
                text: 'La sesión ha expirado, redirigiendo...',
                timer: 3000,
                showConfirmButton: false
            },function() {
                if (privileges=='Mesero' || privileges=='Cajero') {
                    window.location.href = 'frmMeseroIndex';
                } else {
                    window.location.href = 'index';
                }
            });";
            page.Page.ClientScript.RegisterStartupScript(tipo.GetType(), "script", script, true);
            ScriptManager.RegisterStartupScript(page, tipo.GetType(), "script", script, true);
        }
        public static void Login(System.Web.UI.MasterPage masterPage, Type tipo)
        {
            string script = @"
            function getCookie(name) {
                const value = `; ${document.cookie}`;
                const parts = value.split(`; ${name}=`);
                return parts.length === 2 ? parts.pop().split(';').shift() : null;
            }
    
            const privileges = getCookie('privileges');
    
            swal({
                title: 'Aviso',
                text: 'La sesión ha expirado, redirigiendo...',
                timer: 3000,
                showConfirmButton: false
            },function() {
                if (privileges=='Mesero' || privileges=='Cajero') {
                    window.location.href = 'frmMeseroIndex';
                } else {
                    window.location.href = 'index';
                }
            });";
            masterPage.Page.ClientScript.RegisterStartupScript( tipo.GetType(), "script", script, true);
        }
    }
}