﻿Imports System.Data.SqlClient

Public Class TareaGenericasAlumnos
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Session("codAsig") = DropDownList1.SelectedValue
        Dim Ad As New UsuariosRegistrados.AccesoDatos()
        Ad.Conectar()
        Dim alumnoAsignaturas As SqlDataReader = Ad.ObtenerAsigDeAlumno(Session("email"))
        While (alumnoAsignaturas.Read())
            DropDownList1.Items.Add(alumnoAsignaturas.GetValue(0))
        End While
        Ad.CerrarConexion()
    End Sub

    Protected Sub DropDownList1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles DropDownList1.SelectedIndexChanged
        Dim codAsig = DropDownList1.SelectedValue
        Dim Ad As New UsuariosRegistrados.AccesoDatos()
        Dim tareas As SqlDataReader = Ad.ObtenerTareasAsignAlumno(Session("email"), codAsig)
        Dim dt As New DataTable
        dt.Columns.AddRange(New DataColumn() {New DataColumn("Código", GetType(String)), New DataColumn("Descripción", GetType(String)), New DataColumn("Horas Estimadas", GetType(Integer)), New DataColumn("Tipo", GetType(String))})
        dt.Rows.Add(tareas.GetValue(0))


    End Sub

End Class