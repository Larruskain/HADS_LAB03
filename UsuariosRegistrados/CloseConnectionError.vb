Public Class CloseConnectionError
    Inherits ApplicationException

    Public Sub New(Optional ByVal Mezua As String = "Error: No ha sido posible cerrar la conexión con la base de datos.")
        MyBase.New(Mezua)
    End Sub
End Class
