Imports System.Text
Imports AccesoDatos.NM.AccesoDatos
Imports System.Configuration
Imports System.Data.SqlClient
Imports System.Runtime.CompilerServices

Public Class clsProducto
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

    '*****************************************************************************************************
    'Objetivo   : 
    'Autor      : 
    'Creado     : 
    'Modificado : 
    '*****************************************************************************************************
    Public Function obtenerProductos(ByVal id_sucursal As Integer) As DataTable
        Try
            Dim objparametros() As Object = {"id_sucursal", id_sucursal}
            Return _objConnexion.ObtenerDataTable("sp_gp_obtenerProductos", objparametros)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function obtenerProductos_2(ByVal pvchCategoria As String,
                                       ByVal pvchSubCategoria As String) As DataTable
        Try
            Dim objparametros() As Object = {"pvchCategoria", pvchCategoria,
                                             "pvchSubCategoria", pvchSubCategoria}

            Return _objConnexion.ObtenerDataTable("sp_gp_obtenerProductos_2", objparametros)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function obtenerProductosBusqueda(ByVal pvchBusqueda As String,
                                             ByVal pstrValorBusqueda As String) As DataTable
        Try
            Dim objparametros() As Object = {"pvchBusqueda", pvchBusqueda,
                                             "pstrTipBus", pstrValorBusqueda}

            Return _objConnexion.ObtenerDataTable("sp_gp_obtenerProductosxBusqueda", objparametros)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function generarOrdenCab(ByVal pvchOrdTipo As String,
                                    ByVal pintSalon As Int32,
                                    ByVal pintMesa As Int32,
                                    ByVal pvchUsuario As String,
                                    ByVal pvchCliente As String,
                                    ByVal pvchEstado As String,
                                    ByVal pvchOrdenDiv As String,
                                    ByVal id_sucursal As Integer,
                                    ByVal cantidadPersonas As Integer) As DataTable
        Try
            Dim objparametros() As Object = {"pvchOrdTipo", pvchOrdTipo,
                                             "pintSalon", pintSalon,
                                             "pintMesa", pintMesa,
                                             "pvchUsuario", pvchUsuario,
                                             "pvchCliente", pvchCliente,
                                             "pvchEstado", pvchEstado,
                                             "pvchDiv", pvchOrdenDiv,
                                             "id_sucursal", id_sucursal,
                                             "cantidadPersonas", cantidadPersonas}

            Return _objConnexion.ObtenerDataTable("sp_gp_generarOrdenCabecera", objparametros)
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Function ConsultarDisponibilidadMesas(ByVal mesa As Integer,
                                    ByVal salon As Integer,
                                    ByVal id_sucursal As Integer) As DataTable
        Try
            Dim objparametros() As Object = {"mesa", mesa,
                                             "salon", salon,
                                             "id_sucursal", id_sucursal}

            Return _objConnexion.ObtenerDataTable("sp_gp_disponibilidadMesasSalon", objparametros)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function generarOrdenDet(ByVal pintOrden As Int32,
                                    ByVal pintCantidad As Int32,
                                    ByVal pintCodItem As Int32,
                                    ByVal pdblPrecioUni As Double,
                                    ByVal pvchComentario As String,
                                    ByVal pvchUsuario As String) As DataSet
        Try
            Dim objparametros() As Object = {"pintOrden", pintOrden,
                                             "pintCantidad", pintCantidad,
                                             "pintCodItem", pintCodItem,
                                             "pnumPrecioUni", pdblPrecioUni,
                                             "pvchComentario", pvchComentario,
                                             "pvchUsuario", pvchUsuario}

            Return _objConnexion.ObtenerDataSet("sp_gp_generarOrdenDet", objparametros)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function obtenerEstadoMesas(ByVal pvchAux As String,
                                       ByVal id_sucursal As Integer) As DataTable
        Try
            Dim objparametros() As Object = {"pvchAux", pvchAux,
                                            "id_sucursal", id_sucursal}

            Return _objConnexion.ObtenerDataTable("sp_gp_obtenerEstadoMesas", objparametros)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function obtenerListadoxUsuario(ByVal pvchUsuario As String,
                                           ByVal id_sucursal As Integer) As DataTable
        Try
            Dim objparametros() As Object = {"pvchUsuario", pvchUsuario,
                                            "id_sucursal", id_sucursal}

            Return _objConnexion.ObtenerDataTable("sp_gp_listadoOrdenesxUsuario", objparametros)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function obtenerDetalleOrden(ByVal pintOrdenID As Int32) As DataTable
        Try
            Dim objparametros() As Object = {"pintOrdenID", pintOrdenID}

            Return _objConnexion.ObtenerDataTable("sp_gp_obtenerDetalleOrdenId", objparametros)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function actualizarItemsOrden(ByVal pintOrdenID As Int32,
                                         ByVal pintCodItem As Int32,
                                         ByVal pintCantidad As Int32,
                                         ByVal pstrComentario As String,
                                         ByVal pstrUsuario As String) As DataTable
        Try
            Dim objparametros() As Object = {"pintOrdenID", pintOrdenID,
                                             "pintCodItem", pintCodItem,
                                             "pintCantidad", pintCantidad,
                                             "pvchComentario", pstrComentario,
                                             "pvchUsuario", pstrUsuario}

            Return _objConnexion.ObtenerDataTable("sp_gp_actualizarItems", objparametros) 'agregar set al comentario en el actualizar el producto
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function generarPreCuenta(ByVal pintOrdenID As Int32,
                                     ByVal pstrUsuario As String) As DataTable
        Try
            Dim objparametros() As Object = {"pintOrdenID", pintOrdenID,
                                             "pvchUsuario", pstrUsuario}

            Return _objConnexion.ObtenerDataTable("sp_gp_generarPreCuenta", objparametros)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function verificarMesero(ByVal pstrUsuario As String,
                                    ByVal pstrPass As String) As DataTable
        Try
            Dim objparametros() As Object = {"pvchUsuario", pstrUsuario,
                                             "pvchPass", pstrPass}

            Return _objConnexion.ObtenerDataTable("sp_gp_verificarMesero", objparametros)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function verificarLogin(ByVal pstrUsuario As String,
                                    ByVal pstrPass As String,
                                   ByVal pstrSucursal As Integer) As DataTable
        Try
            Dim objparametros() As Object = {"pvchUsuario", pstrUsuario,
                                             "pvchPass", pstrPass,
                                             "pvchSucursal", pstrSucursal}

            Return _objConnexion.ObtenerDataTable("sp_gp_verificarLogin", objparametros)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function verificarLoginMesero(ByVal pstrPass As String) As DataTable
        Try
            Dim objparametros() As Object = {
                                             "pvchPass", pstrPass
                                             }

            Return _objConnexion.ObtenerDataTable("sp_gp_verificarLoginMesero", objparametros)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function obtenerListadoxCobrar(ByVal pvchUsuario As String,
                                          ByVal id_sucursal As Integer) As DataTable
        Try
            Dim objparametros() As Object = {"pvchUsuario", pvchUsuario,
                                            "id_sucursal", id_sucursal}

            Return _objConnexion.ObtenerDataTable("sp_gp_listadoOrdenesxPagar", objparametros)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function obtenerListadoStatusSUNAT(ByVal pvchUsuario As String,
                                          ByVal id_sucursal As Integer) As DataTable
        Try
            Dim objparametros() As Object = {"pvchUsuario", pvchUsuario,
                                            "id_sucursal", id_sucursal}

            Return _objConnexion.ObtenerDataTable("sp_gp_listadoOrdenesxPagar_v2", objparametros)
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Function agregar() As DataTable
        Try

            Return _objConnexion.ObtenerDataTable("sp_gp_agregar")
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function obtenerListadoLlevarxCobrar(ByVal pvchUsuario As String,
                                                  ByVal id_sucursal As Integer) As DataTable
        Try
            Dim objparametros() As Object = {"pvchUsuario", pvchUsuario,
                                            "id_sucursal", id_sucursal}

            Return _objConnexion.ObtenerDataTable("sp_gp_listadoOrdenesLLevarxPagar", objparametros)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function obtenerListadoDivididoxCobrar(ByVal pvchUsuario As String,
                                                  ByVal id_sucursal As Integer) As DataTable
        Try
            Dim objparametros() As Object = {"pvchUsuario", pvchUsuario,
                                            "id_sucursal", id_sucursal}

            Return _objConnexion.ObtenerDataTable("sp_gp_listadoOrdenesDivididasxPagar", objparametros)
        Catch ex As Exception
            Throw ex
        End Try
    End Function


    Public Function generarComprobantePago(ByVal pstrNumDocumento As String,
                                           ByVal pstrTipDocumento As String,
                                           ByVal pstrFlagDeclara As String,
                                           ByVal pstrRucCli As String,
                                           ByVal pstrNombreCli As String,
                                           ByVal pstrMedioPago As String,
                                           ByVal pdblMontoPagar As Double,
                                           ByVal pdblMontoPagado As Double,
                                           ByVal pintOrdenID As Int32,
                                           ByVal pstrUsuario As String,
                                           ByVal pstrDireccion As String,
                                           ByVal pstrdetallePago As String,
                                           ByVal detalleVuelto As String) As DataTable
        Try
            Dim objparametros() As Object = {"pvchNumDocumento", pstrNumDocumento,
                                             "pvchTipDocumento", pstrTipDocumento,
                                             "pvchFlagDeclara", pstrFlagDeclara,
                                             "pvchRucCli", pstrRucCli,
                                             "pvchNombreCli", pstrNombreCli,
                                             "pvchMedioPago", pstrMedioPago,
                                             "pnumMontoPagar", pdblMontoPagar,
                                             "pnumMontoPagado", pdblMontoPagado,
                                             "pintOrdenID", pintOrdenID,
                                             "pvchUsuario", pstrUsuario,
                                             "pvchDirecc", pstrDireccion,
                                             "pvchDetallePago", pstrdetallePago,
                                             "detalleVuelto", detalleVuelto}

            Return _objConnexion.ObtenerDataTable("sp_gp_generaComprobantePago", objparametros)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function obtenerDatosDocumentoVenta(ByVal pstrNumDocu As String) As DataTable
        Try
            Dim objparametros() As Object = {"pvchNumDocu", pstrNumDocu}

            Return _objConnexion.ObtenerDataTable("sp_gp_obtenerDatosDocumento", objparametros)
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Function obtenerReporteCajaGlobal(ByVal comprobanteMovCaja As Integer) As DataTable
        Try
            Dim objparametros() As Object = {"comprobanteMovCaja", comprobanteMovCaja}

            Return _objConnexion.ObtenerDataTable("sp_ObtenerTotalesPorMedioPagoDetalle", objparametros)
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Function actualizaSerieDocumento(ByVal pstrTipDocumento As String) As DataTable
        Try
            Dim objparametros() As Object = {"pvchTipDocumento", pstrTipDocumento}

            Return _objConnexion.ObtenerDataTable("sp_gp_actualizaSerieDocumento", objparametros)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function actualizaDocumentoReferencia(ByVal pstrNumDocumento As String,
                                                 ByVal pstrNumDocumentoRef As String) As DataTable
        Try
            Dim objparametros() As Object = {"pvchNumDocumento", pstrNumDocumento,
                                             "pvchNumDocumentoRef", pstrNumDocumentoRef}

            Return _objConnexion.ObtenerDataTable("sp_gp_actualizarRefDocumento", objparametros)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function obtenerSerieDocumento(ByVal pstrFlagDeclara As String,
                                          ByVal pstrTipDocumento As String,
                                          ByVal id_sucursal As Integer) As DataTable
        Try
            Dim objparametros() As Object = {"pvchFlagDeclara", pstrFlagDeclara,
                                             "pvchTipDocumento", pstrTipDocumento,
                                             "id_sucursal", id_sucursal}

            Return _objConnexion.ObtenerDataTable("sp_gp_obtenerSerieDocumento", objparametros)
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Function validarOrdenesXcomprobante(ByVal idorden As Integer) As DataTable
        Try
            Dim objparametros() As Object = {"idorden", idorden}

            Return _objConnexion.ObtenerDataTable("sp_gp_validarOrdenesXcomprobante", objparametros)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function obtenerCajasTurno(ByVal pstrAuxi As String, ByVal idSucursal As Integer) As DataTable
        Try
            Dim objparametros() As Object = {"pvchAuxi", pstrAuxi,
                                            "idSucursal", idSucursal}

            Return _objConnexion.ObtenerDataTable("sp_gp_obtenerCajasAbiertas", objparametros)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function obtenerCajaID(ByVal pintMovCajaID As Int32) As DataTable
        Try
            Dim objparametros() As Object = {"pintMovCajaId", pintMovCajaID}

            Return _objConnexion.ObtenerDataTable("sp_gp_obtenerCajasAbiertasxMovCaja", objparametros)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function obtenerDatosMovCaja(ByVal pstrAuxi As String, ByVal idSucursal As Integer) As DataSet
        Try
            Dim objparametros() As Object = {"pvchAuxi", pstrAuxi,
                "idSucursal", idSucursal}

            Return _objConnexion.ObtenerDataSet("sp_gp_cargarDatosCaja", objparametros)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function actualizarCajaDatos(ByVal pintMovCajaID As Int32,
                                        ByVal pvchCajeroId As String,
                                        ByVal pnumMontoIni As Double) As DataTable
        Try
            Dim objparametros() As Object = {"pintMovCajaId", pintMovCajaID,
                                             "pvchCajeroId", pvchCajeroId,
                                             "pnumMontoIni", pnumMontoIni}

            Return _objConnexion.ObtenerDataTable("sp_gp_actualizarDatosCaja", objparametros)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function obtenerValoresArqueoPrevioCaja(ByVal pintMovCajaID As Int32) As DataTable
        Try
            Dim objparametros() As Object = {"pintMovCajaID", pintMovCajaID}

            Return _objConnexion.ObtenerDataTable("sp_gp_obtenerValoresArqueoPrevioCaja", objparametros)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function aperturarCaja(ByVal pstrCajaID As String,
                                  ByVal pstrEmpleadoID As String,
                                  ByVal pintTurno As Int32,
                                  ByVal pdblMontoIni As Double,
                                  ByVal pstrUsuario As String,
                                  ByVal idSucursal As Integer) As DataTable
        Try
            Dim objparametros() As Object = {"pvchCajaID", pstrCajaID,
                                             "pvchEmpleadoID", pstrEmpleadoID,
                                             "pintTurno", pintTurno,
                                             "pnumMontoIni", pdblMontoIni,
                                             "pvchUsuario", pstrUsuario,
                                             "idSucursal", idSucursal}

            Return _objConnexion.ObtenerDataTable("sp_gp_generarAperturaCaja", objparametros)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function obtenerValoresArqueoCierreCaja(ByVal pintMovCajaID As Int32,
                                                   ByVal pstrUsuario As String,
                                                   ByVal totalEfectivo As Double,
                                                   ByVal totalTarjeta As Double,
                                                   ByVal totalDeposito As Double,
                                                   ByVal CajaActualCajera As Double) As DataTable
        Try
            Dim objparametros() As Object = {"pintMovCajaID", pintMovCajaID,
                                             "pvchUsuario", pstrUsuario,
                                             "totalEfectivo", totalEfectivo,
                                             "totalTarjeta", totalTarjeta,
                                             "totalDeposito", totalDeposito,
                                             "CajaActualCajera", CajaActualCajera}

            Return _objConnexion.ObtenerDataTable("sp_gp_obtenerValoresArqueoCierreCaja", objparametros)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function validarCajaAperturada(ByVal pstrUsuario As String,
                                          ByVal id_sucursal As Integer) As DataTable
        Try
            Dim objparametros() As Object = {"pvchUsuario", pstrUsuario,
                                              "id_sucursal", id_sucursal}

            Return _objConnexion.ObtenerDataTable("sp_gp_validarCajaAperturada", objparametros)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function actualizarReimpresionDocu(ByVal pstrNumDocu As String,
                                              ByVal pstrRUC As String,
                                              ByVal pstrRazSocial As String) As DataTable
        Try
            Dim objparametros() As Object = {"pvchNumDocu", pstrNumDocu,
                                             "pvchRUC", pstrRUC,
                                             "pvchRazSocial", pstrRazSocial}

            Return _objConnexion.ObtenerDataTable("sp_gp_actualizarReimpresionDocu", objparametros)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function anularDocumentoCli(ByVal pstrNumDocu As String,
                                       ByVal pstrUsuario As String) As DataTable
        Try
            Dim objparametros() As Object = {"pvchNumDocu", pstrNumDocu,
                                             "pvchUsuario", pstrUsuario}

            Return _objConnexion.ObtenerDataTable("sp_gp_anularDocumentoCli", objparametros)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function cargarTmpPedidosAdic(ByVal pintOrden As Int32,
                                         ByVal pintCantidad As Int32,
                                         ByVal pintCodItem As Int32,
                                         ByVal pvchDeItem As String,
                                         ByVal pdblPrecioUni As Double,
                                         ByVal pvchComentario As String,
                                         ByVal pvchUsuario As String,
                                         ByVal id_sucursal As Integer) As DataSet
        Try
            Dim objparametros() As Object = {"pintOrdenID", pintOrden,
                                             "pintCantidad", pintCantidad,
                                             "pintCodItem", pintCodItem,
                                             "pvchDeItem", pvchDeItem,
                                             "pnumPrecioUni", pdblPrecioUni,
                                             "pvchComentario", pvchComentario,
                                             "pvchUsuario", pvchUsuario,
                                             "id_sucursal", id_sucursal}

            Return _objConnexion.ObtenerDataSet("sp_gp_cargarTmpPedidosAdic", objparametros)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function eliminaTmpPedidosAdic(ByVal pintOrden As Int32,
                                          ByVal pvchUsuario As String) As DataTable
        Try
            Dim objparametros() As Object = {"pintOrdenID", pintOrden,
                                             "pvchUsuario", pvchUsuario}

            Return _objConnexion.ObtenerDataTable("sp_gp_eliminaTmpPedidosAdic", objparametros)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function obtenerReImpresionComanda(ByVal pintOrden As Int32) As DataSet
        Try
            Dim objparametros() As Object = {"pintOrden", pintOrden}

            Return _objConnexion.ObtenerDataSet("sp_gp_obtenerReImpresionComanda", objparametros)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function obtenerReportedeVentas(ByVal pstrFechaIni As String,
                                           ByVal pstrFechaFin As String,
                                           ByVal idsucursal As Integer) As DataTable
        Try
            Dim objparametros() As Object = {"pvchFecIni", pstrFechaIni,
                                             "pvchFecFin", pstrFechaFin,
                                             "idsucursal", idsucursal}

            Return _objConnexion.ObtenerDataTable("sp_gp_genereReporteVentasxFecha", objparametros)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function obtenerReportedeVentasProducto(ByVal pstrFechaIni As String,
                                                   ByVal pstrFechaFin As String,
                                           ByVal idsucursal As Integer) As DataTable
        Try
            Dim objparametros() As Object = {"pvchFechaIni", pstrFechaIni,
                                             "pvchFechaFin", pstrFechaFin,
                                             "idsucursal", idsucursal}

            Return _objConnexion.ObtenerDataTable("sp_gp_reporte_reporte_productos_vendidos", objparametros)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function obtenerReportedeProductoAnulado(ByVal pstrFechaIni As String,
                                                    ByVal pstrFechaFin As String,
                                           ByVal idsucursal As Integer) As DataTable
        Try
            Dim objparametros() As Object = {"pvchFechaIni", pstrFechaIni,
                                             "pvchFechaFin", pstrFechaFin,
                                             "idsucursal", idsucursal}

            Return _objConnexion.ObtenerDataTable("sp_gp_reporte_reporte_productos_anulados", objparametros)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function obtenerReportedeProductoMasVendidos(ByVal pstrFechaIni As String,
                                                        ByVal pstrFechaFin As String,
                                           ByVal idsucursal As Integer) As DataTable
        Try
            Dim objparametros() As Object = {"pvchFechaIni", pstrFechaIni,
                                             "pvchFechaFin", pstrFechaFin,
                                             "idsucursal", idsucursal}

            Return _objConnexion.ObtenerDataTable("sp_gp_reporte_reporte_productos_mas_vendidos", objparametros)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function obtenerReportexMesero(ByVal pstrFechaIni As String,
                                          ByVal pstrFechaFin As String,
                                           ByVal idsucursal As Integer) As DataTable
        Try
            Dim objparametros() As Object = {"pvchFechaIni", pstrFechaIni,
                                             "pvchFechaFin", pstrFechaFin,
                                             "idsucursal", idsucursal}

            Return _objConnexion.ObtenerDataTable("sp_gp_reporte_reporte_x_mesero", objparametros)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function obtenerReporteCaja(ByVal pstrFecha As String,
                                       ByVal pintTurno As Int32,
                                           ByVal idsucursal As Integer) As DataTable
        Try
            Dim objparametros() As Object = {"pvchFecha", pstrFecha,
                                             "pintTurno", pintTurno,
                                             "idsucursal", idsucursal}

            Return _objConnexion.ObtenerDataTable("sp_gp_reporte_reporte_caja", objparametros)
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Function obtenerReporteCajaEgresos(ByVal pstrFechaInicio As DateTime,
                                      ByVal pstrFechaFin As DateTime,
                                          ByVal idsucursal As Integer) As DataTable
        Try
            Dim objparametros() As Object = {"pvchFechaInicio", pstrFechaInicio,
                                             "pvchFechaFin", pstrFechaFin,
                                             "idsucursal", idsucursal}

            Return _objConnexion.ObtenerDataTable("sp_gp_egresos_detalle", objparametros)
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Function anularOrdenPedido(ByVal pintOrdenId As Int32,
                                      ByVal pstrMotivo As String,
                                      ByVal pstrUsuario As String) As DataTable
        Try
            Dim objparametros() As Object = {"pintOrdenID", pintOrdenId,
                                             "pvchMotivo", pstrMotivo,
                                             "pvchUsuario", pstrUsuario}

            Return _objConnexion.ObtenerDataTable("sp_gp_anularOrdenPedido", objparametros)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function actualizarItemOrden(ByVal pintOrdenId As Int32,
                                        ByVal pintCodItem As Int32,
                                        ByVal pintCantidadN As Int32,
                                        ByVal pstrMotivo As String,
                                        ByVal pstrUsuario As String) As DataTable
        Try
            Dim objparametros() As Object = {"pintOrdenID", pintOrdenId,
                                             "pintCodItem", pintCodItem,
                                             "pintCantidadN", pintCantidadN,
                                             "pvchMotivo", pstrMotivo,
                                             "pvchUsuario", pstrUsuario}

            Return _objConnexion.ObtenerDataTable("sp_gp_actualizarItemOrden", objparametros)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function obtenerDatosxRuc(ByVal pstrRuc As String) As DataTable
        Try
            Dim objparametros() As Object = {"pvchRuc", pstrRuc}

            Return _objConnexion.ObtenerDataTable("sp_gp_obtenerDatosRuc", objparametros)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function obtenerDatosMesasDetalle(ByVal pstrSalon As String,
                                             ByVal pstrMesa As String,
                                             ByVal id_sucursal As Integer) As DataTable
        Try
            Dim objparametros() As Object = {"pvchSalon", pstrSalon,
                                             "pvchMesa", pstrMesa,
                                             "id_sucursal", id_sucursal}

            Return _objConnexion.ObtenerDataTable("sp_gp_obtenerDatosMesasDetalle", objparametros)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function obtenerMesasPendientes(ByVal pstrAuxi As Integer) As DataTable
        Try
            Dim objparametros() As Object = {"pvchauxi", pstrAuxi}

            Return _objConnexion.ObtenerDataTable("sp_gp_obtenerMesasPendientes", objparametros)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function obtenerCategorias(ByVal pstrAuxi As String) As DataTable
        Try
            Dim objparametros() As Object = {"pvchauxi", pstrAuxi}

            Return _objConnexion.ObtenerDataTable("sp_gp_obtenerDataCategorias", objparametros)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function obtenerSCategorias(ByVal pstrCategoria As String) As DataTable
        Try
            Dim objparametros() As Object = {"pvchCategoria", pstrCategoria}

            Return _objConnexion.ObtenerDataTable("sp_gp_obtenerDataSCategorias", objparametros)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function obtenerProductoBusqueda(ByVal pstrCategoria As String,
                                            ByVal pstrSCategoria As String,
                                            ByVal pstrBusqueda As String) As DataTable
        Try
            Dim objparametros() As Object = {"pvchCategoria", pstrCategoria,
                                             "pvchSCategoria", pstrSCategoria,
                                             "pvchBusqueda", pstrBusqueda}

            Return _objConnexion.ObtenerDataTable("sp_gp_obtenerDataProductoBusqueda", objparametros)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function obtenerDatosProductoID(ByVal pintProdID As Int32) As DataTable
        Try
            Dim objparametros() As Object = {"pintProdID", pintProdID}

            Return _objConnexion.ObtenerDataTable("sp_gp_obtenerDatosProducto", objparametros)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function actualizarDatosProductoMant(ByVal pintProdID As Int32,
                                                ByVal pstrCategoria As String,
                                                ByVal pstrSCategoria As String,
                                                ByVal pstrDescrip As String,
                                                ByVal pdblPrecio As Double,
                                                ByVal pstrEstado As String,
                                                ByVal pstrFlagTip As String) As DataTable
        Try
            Dim objparametros() As Object = {"pintProdID", pintProdID,
                                             "pvchCategoria", pstrCategoria,
                                             "pvchSCategoria", pstrSCategoria,
                                             "pvchDescrip", pstrDescrip,
                                             "pnumPrecio", pdblPrecio,
                                             "pstrEstado", pstrEstado,
                                             "pchrFlagTip", pstrFlagTip}

            Return _objConnexion.ObtenerDataTable("sp_gp_actualizarDatosProductoMant", objparametros)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function recuperarUltimaVistaProducto(ByVal pintProdID As Int32) As DataTable
        Try
            Dim objparametros() As Object = {"pintProdID", pintProdID}

            Return _objConnexion.ObtenerDataTable("sp_gp_recuperarUltimaVistaProducto", objparametros)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function grabarDatosProductoMant(ByVal pintProdID As Int32,
                                            ByVal pstrCategoria As String,
                                            ByVal pstrSCategoria As String,
                                            ByVal pstrDescrip As String,
                                            ByVal pdblPrecio As Double,
                                            ByVal pstrEstado As String,
                                            ByVal pstrFlagTip As String,
                                            ByVal id_sucursal As Integer) As DataTable
        Try
            Dim objparametros() As Object = {"pintProdID", pintProdID,
                                             "pvchCategoria", pstrCategoria,
                                             "pvchSCategoria", pstrSCategoria,
                                             "pvchDescrip", pstrDescrip,
                                             "pnumPrecio", pdblPrecio,
                                             "pstrEstado", pstrEstado,
                                             "pchrFlagTip", pstrFlagTip,
                                             "id_sucursal", id_sucursal}

            Return _objConnexion.ObtenerDataTable("sp_gp_grabarDatosProductoMant", objparametros)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function fn_obtenerMenuCarta() As DataSet
        Dim lstrQuery As String
        Dim lSQLCn As SqlConnection
        Dim lSQLCmd As SqlCommand
        Dim lSQLAdp As SqlDataAdapter
        Dim ldsRpta As DataSet

        lstrQuery = "sp_gp_obtenerMenuCarta"
        lSQLCn = New SqlConnection(ConfigurationManager.ConnectionStrings("myConnectionString").ConnectionString)
        lSQLCmd = New SqlCommand(lstrQuery, lSQLCn)

        lSQLCmd.CommandType = CommandType.StoredProcedure

        lSQLCn.Open()

        lSQLAdp = New SqlDataAdapter(lSQLCmd)
        ldsRpta = New DataSet()

        lSQLAdp.Fill(ldsRpta)

        Return ldsRpta

    End Function

    Public Function fn_obtenerCarta(ByVal pvchCategoria As String,
                                    ByVal pvchSubCategoria As String) As String
        'Dim lListaCarta As List(Of ProductoCarta)
        Dim lstrQuery As String
        Dim lSQLCn As SqlConnection
        Dim lSQLCmd As SqlCommand
        Dim lSQLAdp As SqlDataAdapter
        Dim ldsRpta As DataSet
        Dim lpSQLCategoria As SqlParameter
        Dim lpSQLSCategoria As SqlParameter
        'Dim lobjProductoCarta As ProductoCarta

        lstrQuery = "sp_gp_obtenerProductos"
        lSQLCn = New SqlConnection(ConfigurationManager.ConnectionStrings("myConnectionString").ConnectionString)
        lSQLCmd = New SqlCommand(lstrQuery, lSQLCn)

        lSQLCmd.CommandType = CommandType.StoredProcedure

        lpSQLCategoria = lSQLCmd.Parameters.Add("@pvchCategoria", SqlDbType.VarChar, 30)
        lpSQLSCategoria = lSQLCmd.Parameters.Add("@pvchSubCategoria", SqlDbType.VarChar, 30)

        lpSQLCategoria.Value = pvchCategoria
        lpSQLSCategoria.Value = pvchSubCategoria

        lSQLCn.Open()

        lSQLAdp = New SqlDataAdapter(lSQLCmd)
        ldsRpta = New DataSet()

        lSQLAdp.Fill(ldsRpta)

        'lListaCarta = New List(Of ProductoCarta)

        'For Each dtRow As DataRow In ldtRpta.Rows

        '    lobjProductoCarta = New ProductoCarta()

        '    lobjProductoCarta.Codigo = dtRow("vchCodigo").ToString()
        '    lobjProductoCarta.Descripcion = dtRow("vchDeItem").ToString()
        '    lobjProductoCarta.PrecioUnitario = dtRow("numPrecioUni").ToString()

        '    lListaCarta.Add(lobjProductoCarta)

        'Next

        'Return lListaCarta

        Return ldsRpta.GetXml()
    End Function

    Public Function grabarRespuestaSUNAT(ByVal pstrNumDocu As String,
                                          ByVal pintCodigoSUNAT As Int32,
                                          ByVal pstrQRValor As String,
                                          ByVal pstrEstado As String,
                                          ByVal pstrMensaje As String,
                                          ByVal pstrRutaCDR As String,
                                          ByVal pstrRutaPDF As String,
                                          ByVal pstrRutaXML As String,
                                          ByVal pstrNumTicket As String) As DataTable
        Try
            Dim objparametros() As Object = {"pvchNumDocu", pstrNumDocu,
                                             "pintCodigoSUNAT", pintCodigoSUNAT,
                                             "pvchQRValor", pstrQRValor,
                                             "pvchEstado", pstrEstado,
                                             "pvchMensaje", pstrMensaje,
                                             "pvchRutaCDR", pstrRutaCDR,
                                             "pvchRutaPDF", pstrRutaPDF,
                                             "pvchRutaXML", pstrRutaXML,
                                             "pvchNumTicket", pstrNumTicket}

            Return _objConnexion.ObtenerDataTable("sp_gp_obtenerRespuesta_SUNAT", objparametros)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function grabarRespuestaComBajaSUNAT(ByVal pstrNumDocu As String,
                                                ByVal pintCodigoSUNATComBaja As Int32,
                                                ByVal pstrEstadoComBaja As String,
                                                ByVal pstrMensajeComBaja As String,
                                                ByVal pstrRutaXMLComBaja As String,
                                                ByVal pstrNumTicketComBaja As String) As DataTable
        Try
            Dim objparametros() As Object = {"pvchNumDocu", pstrNumDocu,
                                             "pintCodigoSUNATComBaja", pintCodigoSUNATComBaja,
                                             "pvchEstadoComBaja", pstrEstadoComBaja,
                                             "pvchMensajeComBaja", pstrMensajeComBaja,
                                             "pvchRutaXMLComBaja", pstrRutaXMLComBaja,
                                             "pvchNumTicketComBaja", pstrNumTicketComBaja}

            Return _objConnexion.ObtenerDataTable("sp_gp_obtenerRespuestaComBaja_SUNAT", objparametros)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function registrarCategoria(ByVal pstrCategoria As String,
                                       ByVal pstrUsuario As String,
                                       ByVal pstrsucursal As Integer) As DataTable
        Try
            Dim objparametros() As Object = {"pvchCategoria", pstrCategoria,
                                             "pvchUsuario", pstrUsuario,
                                             "id_sucursal", pstrsucursal}

            Return _objConnexion.ObtenerDataTable("sp_gp_registrar_categoria", objparametros)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function registrarSCategoria(ByVal pstrSCategoria As String,
                                        ByVal pstrCategoria As String,
                                        ByVal pstrUsuario As String,
                                        ByVal id_sucursal As Integer) As DataTable
        Try
            Dim objparametros() As Object = {"pvchSCategoria", pstrSCategoria,
                                             "pvchCategoria", pstrCategoria,
                                             "pvchUsuario", pstrUsuario,
                                             "id_sucursal", id_sucursal}

            Return _objConnexion.ObtenerDataTable("sp_gp_registrar_subcategoria", objparametros)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function obtenerDatosProveedorSunat(ByVal pstrCodProveedor As String) As DataTable
        Try
            Dim objparametros() As Object = {"pstrCodProveedor", pstrCodProveedor}

            Return _objConnexion.ObtenerDataTable("sp_gp_obtenerDatosProveedorSunat", objparametros)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function obtenerProductosByIngresoStock(ByVal nombreProd As String,
                                                ByVal idSucursal As Int32) As DataTable
        Try
            Dim objparametros() As Object = {"NombreProd", nombreProd,
                                             "id_sucursal", idSucursal}

            Return _objConnexion.ObtenerDataTable("sp_gp_GetProductosIngresoStock", objparametros)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function obtenerNumeroLoteIngresoStock() As DataTable
        Try
            Return _objConnexion.ObtenerDataTable("SP_GetNumeroLoteIngresoStock")
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function obtenerNumeroLoteSalidaStock() As DataTable
        Try
            Return _objConnexion.ObtenerDataTable("SP_GetNumeroLoteSalidaStock")
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function generarIngresoStockInventario(CodLote, IdSucursal, Total, UsuarioRegistro) As DataTable
        Try
            Dim objparametros() As Object = {"CodLote", CodLote,
                                             "IdSucursal", IdSucursal,
                                             "Total", Total,
                                             "UsuarioRegistro", UsuarioRegistro}
            Return _objConnexion.ObtenerDataTable("SP_GenerarRegistroIngresoInventario", objparametros)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function generarIngresoDetStockInventario(IdIngresoStock, IdProducto, Cantidad, CostoUnitario, IdAlmacen, FechaVencimiento, UsuarioRegistro) As DataTable
        Try
            Dim objparametros() As Object = {"IdIngresoStock", IdIngresoStock,
                                             "IdProducto", IdProducto,
                                             "Cantidad", Cantidad,
                                             "CostoUnitario", CostoUnitario,
                                             "IdAlmacen", IdAlmacen,
                                             "FechaVencimiento", FechaVencimiento,
                                             "UsuarioRegistro", UsuarioRegistro}
            Return _objConnexion.ObtenerDataTable("SP_GenerarRegistroDetIngresoInventario", objparametros)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function getIngresoStockByProducto(IdProducto, IdSucursal) As DataTable
        Try
            Dim objparametros() As Object = {"IdProducto", IdProducto,
                                             "IdSucursal", IdSucursal}
            Return _objConnexion.ObtenerDataTable("SP_GetIngresosStockByProducto", objparametros)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function editarRegistroIngresoStock(IdAlmacenProd, UsuarioModificacion, FechaVencimiento, Descripcion, Costo) As DataTable
        Try
            Dim objparametros() As Object = {"IdAlmacenProd", IdAlmacenProd,
                                             "UsuarioModificacion", UsuarioModificacion,
                                             "FechaVencimiento", FechaVencimiento,
                                             "Descripcion", Descripcion,
                                             "Costo", Costo}
            Return _objConnexion.ObtenerDataTable("SP_EditarRegistroIngresoInventario", objparametros)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function getStockByProducto(CodProducto) As DataTable
        Try
            Dim objparametros() As Object = {"CodProducto", CodProducto}
            Return _objConnexion.ObtenerDataTable("SP_GetStockActualByProducto", objparametros)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function actualizarStock(Cantidad, IdProducto) As DataTable
        Try
            Dim objparametros() As Object = {"Cantidad", Cantidad,
                                             "IdProducto", IdProducto}
            Return _objConnexion.ObtenerDataTable("SP_ActualizarStock", objparametros)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function obtenerProductosBySalidaStock(ByVal nombreProd As String,
                                                ByVal idSucursal As Int32) As DataTable
        Try
            Dim objparametros() As Object = {"NombreProd", nombreProd,
                                             "IdSucursal", idSucursal}

            Return _objConnexion.ObtenerDataTable("sp_gp_GetProductosSalidaStock", objparametros)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function obtenerDetalleProdSalidaStock(ByVal idProducto As Int32) As DataTable
        Try
            Dim objparametros() As Object = {"IdProducto", idProducto}

            Return _objConnexion.ObtenerDataTable("SP_MostrarDetalleProductoSalidaStock", objparametros)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function generarSalidaStockInventario(CodLote, IdSucursal, Total, UsuarioRegistro) As DataTable
        Try
            Dim objparametros() As Object = {"CodLote", CodLote,
                                             "IdSucursal", IdSucursal,
                                             "Total", Total,
                                             "UsuarioRegistro", UsuarioRegistro}
            Return _objConnexion.ObtenerDataTable("SP_GenerarRegistroSalidaInventario", objparametros)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function generarSalidaDetStockInventario(IdIngresoStock, IdAlmProducto, IdProducto, Cantidad, CostoUnitario, UsuarioRegistro, CodLoteIS) As DataTable
        Try
            Dim objparametros() As Object = {"IdSalidaStock", IdIngresoStock,
                                             "IdAlmacenProd", IdAlmProducto,
                                             "IdProducto", IdProducto,
                                             "Cantidad", Cantidad,
                                             "CostoUnitario", CostoUnitario,
                                             "UsuarioRegistro", UsuarioRegistro,
                                             "CodLoteIS", CodLoteIS}
            Return _objConnexion.ObtenerDataTable("SP_GenerarRegistroDetSalidaInventario", objparametros)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function obtenerReporteConsolidado(ByVal idsucursal As Integer) As DataTable
        Try
            Dim objparametros() As Object = {"idsucursal", idsucursal}
            Return _objConnexion.ObtenerDataTable("SP_GetReporteConsolidado", objparametros)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function salidaStockAgrupacion(IdProducto, IdSucursal, Cantidad) As DataTable
        Try
            Dim objparametros() As Object = {"IdProd", IdProducto,
                                             "IdSucursal", IdSucursal,
                                             "Cantidad", Cantidad}
            Return _objConnexion.ObtenerDataTable("SP_SalidaStockAgrupacion", objparametros)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function ingresoStockAgrupacion(IdProducto, IdSucursal, Cantidad) As DataTable
        Try
            Dim objparametros() As Object = {"IdProd", IdProducto,
                                             "IdSucursal", IdSucursal,
                                             "Cantidad", Cantidad}
            Return _objConnexion.ObtenerDataTable("SP_IngresoStockAgrupacion", objparametros)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function getProductoPrincipalGrupo(filtro) As DataTable
        Try
            Dim objparametros() As Object = {"FILTRO", filtro}
            Return _objConnexion.ObtenerDataTable("SP_GetProductosPrincipalesForGrupo", objparametros)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function getProductosSinGrupo(nombProd) As DataTable
        Try
            Dim objparametros() As Object = {"NombreProd", nombProd}
            Return _objConnexion.ObtenerDataTable("SP_GetProductosSinGrupo", objparametros)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function registrarGrupo(idProducto, idProductoPrincipal) As DataTable
        Try
            Dim objparametros() As Object = {"IdProducto", idProducto,
                                             "IdProductoPrincipal", idProductoPrincipal}
            Return _objConnexion.ObtenerDataTable("SP_GenerarRegistroGrupo", objparametros)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function getProductosAgrupadosByIdProdPrincipal(idProducto) As DataTable
        Try
            Dim objparametros() As Object = {"IdProducto", idProducto}
            Return _objConnexion.ObtenerDataTable("SP_GetProductosAgrupados", objparametros)
        Catch ex As Exception
            Throw ex
        End Try
    End Function


    Public Function eliminarProductoGrupo(idProducto) As DataTable
        Try
            Dim objparametros() As Object = {"IdProductoAgrup", idProducto}
            Return _objConnexion.ObtenerDataTable("SP_EliminarProductoDeGrupo", objparametros)
        Catch ex As Exception
            Throw ex
        End Try
    End Function


    Public Function actualizarVenta(idVenta, infoStock) As DataTable
        Try
            Dim objparametros() As Object = {"IdVenta", idVenta,
                                             "DataVenta", infoStock}
            Return _objConnexion.ObtenerDataTable("SP_ActualizarInfVenta", objparametros)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function obtenerInformacionStock(idVenta) As DataTable
        Try
            Dim objparametros() As Object = {"IdPedido", idVenta}
            Return _objConnexion.ObtenerDataTable("up_Obtener_Informacion_Stock", objparametros)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function RegresoStockXAnularPedido(IdStockProd, Cantidad) As DataTable
        Try
            Dim objparametros() As Object = {"idStockProducto", IdStockProd,
                                             "Cantidad", Cantidad}
            Return _objConnexion.ObtenerDataTable("sp_ActualizarStockByAnulacion", objparametros)
        Catch ex As Exception
            Throw ex
        End Try
    End Function


    Public Function ObtenerIdProducto(IdStockProd) As DataTable
        Try
            Dim objparametros() As Object = {"IDProductoStock", IdStockProd}
            Return _objConnexion.ObtenerDataTable("sp_ObtenerIdProductoByRegresoStock", objparametros)
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Function obtenerUsuarios() As DataTable
        Try
            Return _objConnexion.ObtenerDataTable("SP_ObtenerUsuarios")
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Function obtenerRoles() As DataTable
        Try
            Return _objConnexion.ObtenerDataTable("SP_ObtenerRoles")
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Function registrarUsuario(nombres, apellidos, idrol, estado, username, password, id_sucursal) As DataTable
        Try
            Dim objparametros() As Object = {"nombres", nombres,
                                             "apellidos", apellidos,
                                             "idrol", idrol,
                                             "estado", estado,
                                             "username", username,
                                             "password", password,
                                             "id_sucursal", id_sucursal}
            Return _objConnexion.ObtenerDataTable("SP_RegistrarUsuario", objparametros)
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Function actualizarUsuarioPass(opcion, empid, nombres, apellidos, idrol, estado, pass) As DataTable
        Try
            Dim objparametros() As Object = {"opcion", opcion,
                                             "empid", empid,
                                             "nombres", nombres,
                                             "apellidos", apellidos,
                                             "idrol", idrol,
                                             "estado", estado,
                                             "pass", pass}
            Return _objConnexion.ObtenerDataTable("SP_ActualizarUsuario", objparametros)
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


