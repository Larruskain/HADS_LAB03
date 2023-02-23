Public Class ObtenerUsuarioError
    Inherits ApplicationException

    Public Sub New(Optional ByVal Mezua As String = "Error: En la base de datos no se encuentra ningún usuario con ese email.")
        MyBase.New(Mezua)
    End Sub
End Class
