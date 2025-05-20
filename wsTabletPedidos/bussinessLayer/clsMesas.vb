Imports AccesoDatos.NM.AccesoDatos
Imports System.Configuration
Imports System.Data.SqlClient
Public Class clsMesas
    Implements IDisposable
#Region " Declaracion de Variables Miembro "
    Private _objConnexion As AccesoDatosSQLServer
#End Region

#Region " Definicion de Constructores "
    Sub New()
        _objConnexion = New AccesoDatosSQLServer(GeneradorCadenaConexion.enmBasesDatos.Conexion)
    End Sub
#End Region
#Region " Funciones "

#End Region
#Region " Dispose "
    Public Sub Dispose() Implements System.IDisposable.Dispose
        _objConnexion.Dispose()
    End Sub
#End Region
End Class
