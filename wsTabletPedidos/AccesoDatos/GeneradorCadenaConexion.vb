Option Strict On

Imports Microsoft.Win32
Imports System.IO
Imports System.Security
Imports System.Configuration

Namespace NM.AccesoDatos
    Public NotInheritable Class GeneradorCadenaConexion
        Public Enum enmBasesDatos As Integer
            Conexion = 0
        End Enum

        Private Shared m_strCadenaConexionSQLServer As String = _
            ConfigurationManager.ConnectionStrings("myConnectionString").ConnectionString

        Public Shared Function ObtenerCadenaConexionSQLServer(ByVal BaseDatos As enmBasesDatos) As String
            Try
                Dim strServidor, strBaseDatos, strUsuario, strPassword As String

                strServidor = ""
                strBaseDatos = ""
                strUsuario = ""
                strPassword = ""

                Select Case BaseDatos
                    Case Is = enmBasesDatos.Conexion
                        strServidor = "localhost" 'CType(Registry.LocalMachine.OpenSubKey("Software\NuevoMundo\NMREVFIN").GetValue("Servidor"), String)
                        strBaseDatos = "PVGPDB" 'CType(Registry.LocalMachine.OpenSubKey("Software\NuevoMundo\NMREVFIN").GetValue("BaseDatos"), String)
                        strUsuario = "dell" 'CType(Registry.LocalMachine.OpenSubKey("Software\NuevoMundo\NMREVFIN").GetValue("Usuario"), String)
                        strPassword = "123" 'CType(Registry.LocalMachine.OpenSubKey("Software\NuevoMundo\NMREVFIN").GetValue("Password"), String)
                End Select

                Return m_strCadenaConexionSQLServer
                'String.Format(m_strCadenaConexionSQLServer, _
                '   strServidor, _
                '   strBaseDatos, _
                '   strUsuario, _
                '   strPassword)

            Catch IOEx As IOException
                Throw IOEx
            Catch SecEx As SecurityException
                Throw SecEx
            End Try
        End Function
    End Class
End Namespace

