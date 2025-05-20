Imports AccesoDatos.NM.AccesoDatos
Imports System.Configuration
Imports System.Data.SqlClient

Public Class clsSucursal
    Implements IDisposable

#Region " Declaracion de Variables Miembro "
    Private _objConnexion As AccesoDatosSQLServer
    Private disposedValue As Boolean
#End Region

#Region " Definicion de Constructores "
    Sub New()
        _objConnexion = New AccesoDatosSQLServer(GeneradorCadenaConexion.enmBasesDatos.Conexion)
    End Sub

#End Region
#Region " Funciones SUCURSAL"
    Public Function obtenerSucursal() As DataTable
        Try

            Return _objConnexion.ObtenerDataTable("sp_obtenerSucursal")
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Function registrarSucursal(ByVal nombre As String,
                                      ByVal direccion As String,
                                      ByVal estado As String) As DataTable
        Try
            Dim objparametros() As Object = {"nombre", nombre,
                                             "direccion", direccion,
                                             "estado", estado}
            Return _objConnexion.ObtenerDataTable("sp_registrarSucursal", objparametros)
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Function registrarTipoDoc(ByVal tipoDoc As String,
                                      ByVal serie As String,
                                      ByVal secuencia As Integer,
                                     ByVal idsucursal As Integer) As DataTable
        Try
            Dim objparametros() As Object = {"tipoDoc", tipoDoc,
                                             "serie", serie,
                                             "secuencia", secuencia,
                                             "idsucursal", idsucursal}
            Return _objConnexion.ObtenerDataTable("sp_registrarSucursalCorrelativoComprob", objparametros)
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Function actualizarTipoDoc(ByVal tipoDoc As String,
                                      ByVal serie As String,
                                      ByVal secuencia As Integer,
                                     ByVal idsucursal As Integer) As DataTable
        Try
            Dim objparametros() As Object = {"tipoDoc", tipoDoc,
                                             "serie", serie,
                                             "secuencia", secuencia,
                                             "idsucursal", idsucursal}
            Return _objConnexion.ObtenerDataTable("sp_actualizarrSucursalCorrelativoComprob", objparametros)
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Function obtenerComprobanteVal(ByVal serie As String) As DataTable
        Try
            Dim objparametros() As Object = {"serie", serie}
            Return _objConnexion.ObtenerDataTable("sp_ValidarSerie", objparametros)
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Function obtenerComprobanteSucursal(ByVal idsucursal As Integer) As DataTable
        Try
            Dim objparametros() As Object = {"idsucursal", idsucursal}
            Return _objConnexion.ObtenerDataTable("sp_ComprobanteSucursal", objparametros)
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Function actualizarSucursal(ByVal id As Integer,
                                      ByVal nombre As String,
                                      ByVal direccion As String,
                                      ByVal estado As String) As DataTable
        Try
            Dim objparametros() As Object = {"id", id,
                                             "nombre", nombre,
                                             "direccion", direccion,
                                             "estado", estado}
            Return _objConnexion.ObtenerDataTable("sp_actualizarSucursal", objparametros)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

#End Region
#Region " Funciones CONFIGURACION"
    Public Function registrarConfigSunat(ByVal RUC As String,
                                      ByVal razonSocial As String,
                                      ByVal direccion As String,
                                      ByVal departamento As String,
                                      ByVal provincia As String,
                                      ByVal distrito As String,
                                      ByVal CuentaRUC As String,
                                      ByVal CuentaPass As String,
                                      ByVal CertPass As String,
                                      ByVal CertRuta As String) As DataTable
        Try
            Dim objparametros() As Object = {"RUC", RUC,
                                             "razonSocial", razonSocial,
                                             "direccion", direccion,
                                             "departamento", departamento,
                                             "provincia", provincia,
                                             "distrito", distrito,
                                             "CuentaRUC", CuentaRUC,
                                             "CuentaPass", CuentaPass,
                                             "CertPass", CertPass,
                                             "CertRuta", CertRuta}

            Return _objConnexion.ObtenerDataTable("sp_registrarConfigSUNAT", objparametros)
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Function actualizarConfigSunat(ByVal RUC As String,
                                      ByVal razonSocial As String,
                                      ByVal direccion As String,
                                      ByVal departamento As String,
                                      ByVal provincia As String,
                                      ByVal distrito As String,
                                      ByVal CuentaRUC As String,
                                      ByVal CuentaPass As String,
                                      ByVal CertPass As String,
                                      ByVal CertRuta As String) As DataTable
        Try
            Dim objparametros() As Object = {"RUC", RUC,
                                             "razonSocial", razonSocial,
                                             "direccion", direccion,
                                             "departamento", departamento,
                                             "provincia", provincia,
                                             "distrito", distrito,
                                             "CuentaRUC", CuentaRUC,
                                             "CuentaPass", CuentaPass,
                                             "CertPass", CertPass,
                                             "CertRuta", CertRuta}

            Return _objConnexion.ObtenerDataTable("sp_actualizarConfigSUNAT", objparametros)
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Function obtenerEmpresa() As DataTable
        Try

            Return _objConnexion.ObtenerDataTable("sp_obtenerEmpresa")
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Function actualizarLogo(ByVal logo As Byte()) As DataTable
        Try
            Dim objparametros() As Object = {"logo", logo}

            Return _objConnexion.ObtenerDataTable("sp_update_logo", objparametros)
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Function registrarMesas(ByVal nroOrden As Integer,
                                      ByVal salon As String,
                                      ByVal mesas As Integer,
                                      ByVal idSucursal As Integer) As DataTable
        Try
            Dim objparametros() As Object = {"nroOrden", nroOrden,
                                             "salon", salon,
                                             "mesas", mesas,
                                             "idSucursal", idSucursal}

            Return _objConnexion.ObtenerDataTable("sp_crearMesas", objparametros)
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Function actualizarMesas(ByVal nroOrden As Integer,
                                      ByVal salon As String,
                                      ByVal mesas As Integer,
                                      ByVal id As Integer) As DataTable
        Try
            Dim objparametros() As Object = {"nroOrden", nroOrden,
                                             "salon", salon,
                                             "mesas", mesas,
                                             "id", id}

            Return _objConnexion.ObtenerDataTable("sp_actualizarMesas", objparametros)
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Function eliminarMesas(ByVal id As Integer) As DataTable
        Try
            Dim objparametros() As Object = {"id", id}

            Return _objConnexion.ObtenerDataTable("sp_eliminarMesas", objparametros)
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Function obtenerMesas() As DataTable
        Try

            Return _objConnexion.ObtenerDataTable("sp_obtenerMesasPorSalon")
        Catch ex As Exception
            Throw ex
        End Try
    End Function
#End Region
#Region "CAJA INGRESOS"
    Public Function obtenerOtrosIngresos(ByVal movCajaID As Integer) As DataTable
        Try
            Dim objparametros() As Object = {"movCajaID", movCajaID}
            Return _objConnexion.ObtenerDataTable("sp_obtenerOtrosIngresos", objparametros)
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Function agregarOtrosIngresos(ByVal movCajaID As Integer,
                                         ByVal tipo As String,
                                         ByVal Precio As Double,
                                         ByVal Observacion As String) As DataTable
        Try
            Dim objparametros() As Object = {"movCajaID", movCajaID,
                                             "tipo", tipo,
                                             "Precio", Precio,
                                             "Observacion", Observacion}
            Return _objConnexion.ObtenerDataTable("sp_agregarOtrosIngresos", objparametros)
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Function modificarOtrosIngresos(ByVal ID As Integer, ByVal movCajaID As Integer,
                                         ByVal tipo As String,
                                         ByVal Precio As Double,
                                         ByVal Observacion As String) As DataTable
        Try
            Dim objparametros() As Object = {"ID", ID, "movCajaID", movCajaID,
                                             "tipo", tipo,
                                             "Precio", Precio,
                                             "Observacion", Observacion}
            Return _objConnexion.ObtenerDataTable("sp_modificarOtrosIngresos", objparametros)
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Function eliminarOtrosIngresos(ByVal ID As Integer) As DataTable
        Try
            Dim objparametros() As Object = {"ID", ID}
            Return _objConnexion.ObtenerDataTable("sp_eliminarOtrosIngresos", objparametros)
        Catch ex As Exception
            Throw ex
        End Try
    End Function
#End Region
#Region "CAJA EGRESOS"
    Public Function obtenerOtrosEgresos(ByVal movCajaID As Integer) As DataTable
        Try
            Dim objparametros() As Object = {"movCajaID", movCajaID}
            Return _objConnexion.ObtenerDataTable("sp_obtenerOtrosEgresos", objparametros)
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Function agregarOtrosEgresos(ByVal movCajaID As Integer,
                                         ByVal tipo As String,
                                         ByVal Precio As Double,
                                         ByVal motivo As String,
                                         ByVal Observacion As String) As DataTable
        Try
            Dim objparametros() As Object = {"movCajaID", movCajaID,
                                             "tipo", tipo,
                                             "Precio", Precio,
                                             "motivo", motivo,
                                             "Observacion", Observacion}
            Return _objConnexion.ObtenerDataTable("sp_agregarOtrosEgresos", objparametros)
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Function modificarOtrosEgresos(ByVal ID As Integer, ByVal movCajaID As Integer,
                                         ByVal tipo As String,
                                         ByVal Precio As Double,
                                         ByVal motivo As String,
                                         ByVal Observacion As String) As DataTable
        Try
            Dim objparametros() As Object = {"ID", ID, "movCajaID", movCajaID,
                                             "tipo", tipo,
                                             "Precio", Precio,
                                             "motivo", motivo,
                                             "Observacion", Observacion}
            Return _objConnexion.ObtenerDataTable("sp_modificarOtrosEgresos", objparametros)
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Function eliminarOtrosEgresos(ByVal ID As Integer) As DataTable
        Try
            Dim objparametros() As Object = {"ID", ID}
            Return _objConnexion.ObtenerDataTable("sp_eliminarOtrosEgresos", objparametros)
        Catch ex As Exception
            Throw ex
        End Try
    End Function
#End Region
#Region " Dispose "
    Public Sub Dispose() Implements System.IDisposable.Dispose
        _objConnexion.Dispose()
    End Sub
#End Region
End Class
