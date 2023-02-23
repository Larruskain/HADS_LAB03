
Public Class ConnectionError
    Inherits ApplicationException

    Public Sub New(Optional ByVal Mezua As String = "Error: No se ha podido realizar la conexión con la base de datos.")
        MyBase.New(Mezua)
    End Sub

End Class
