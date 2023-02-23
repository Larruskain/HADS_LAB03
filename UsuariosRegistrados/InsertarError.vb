Public Class InsertarError
    Inherits ApplicationException
    Public Sub New(Optional ByVal Mezua As String = "Error: No se ha podido insertar ese usuario en la base de datos.")
        MyBase.New(Mezua)
    End Sub
End Class
