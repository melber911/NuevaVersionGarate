Public Class ProductoCarta
    Private strCodigo As String

    Public Property Codigo() As String
        Get
            Return strCodigo
        End Get
        Set(ByVal value As String)
            strCodigo = value
        End Set
    End Property

    Private strDescripcion As String

    Public Property Descripcion() As String
        Get
            Return strDescripcion
        End Get
        Set(ByVal value As String)
            strDescripcion = value
        End Set
    End Property

    Private strPrecioUni As String

    Public Property PrecioUnitario() As String
        Get
            Return strPrecioUni
        End Get
        Set(ByVal value As String)
            strPrecioUni = value
        End Set
    End Property
End Class
