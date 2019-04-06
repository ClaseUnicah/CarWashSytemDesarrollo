Imports System.Data.SqlClient
Public Class FrmGestionColor

    Public Sub MostrarColor()
        If Cn.State = ConnectionState.Open Then
            Cn.Close()
        End If

        Using Cmd As New SqlCommand
            Try
                Cn.Open()
                With Cmd
                    .CommandText = "Sp_MostrarColor"
                    .CommandType = CommandType.StoredProcedure
                    .Connection = Cn
                End With

                Dim VerColores As SqlDataReader
                VerColores = Cmd.ExecuteReader()

                LsvColor.Items.Clear()

                While VerColores.Read = True
                    With LsvColor.Items.Add(VerColores("IdColor").ToString)
                        .SubItems.Add(VerColores("NombreColor").ToString)
                    End With
                End While
            Catch ex As Exception
                MessageBox.Show("Error de conexión a la base de datos" + ex.Message,
                                "CarWashSystem", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Finally
                Cn.Close()
            End Try
        End Using
    End Sub

    Public Sub BuscarColor()
        If Cn.State = ConnectionState.Open Then
            Cn.Close()
        End If

        Using Cmd As New SqlCommand
            Try
                Cn.Open()
                With Cmd
                    .CommandText = "Sp_BuscarColor"
                    .CommandType = CommandType.StoredProcedure
                    .Connection = Cn
                    .Parameters.Add("@NombreColor", SqlDbType.NVarChar, 20).Value = TxtBuscar.Text

                End With

                Dim VerColores As SqlDataReader
                VerColores = Cmd.ExecuteReader()

                LsvColor.Items.Clear()

                While VerColores.Read = True
                    With LsvColor.Items.Add(VerColores("IdColor").ToString)
                        .SubItems.Add(VerColores("NombreColor").ToString)
                    End With
                End While
            Catch ex As Exception
                MessageBox.Show("Error de conexión a la base de datos" + ex.Message,
                                "CarWashSystem", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Finally
                Cn.Close()
            End Try
        End Using
    End Sub

    Private Sub FrmGestionColor_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        MostrarColor()

    End Sub

    Private Sub BtnAgregar_Click(sender As Object, e As EventArgs) Handles BtnAgregar.Click
        FrmAgregarColor.ShowDialog()

    End Sub

    Private Sub EditarToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles EditarToolStripMenuItem.Click
        FrmModificarColor.TxtIdColor.Text = LsvColor.FocusedItem.SubItems(0).Text
        FrmModificarColor.TxtNombreColor.Text = LsvColor.FocusedItem.SubItems(1).Text
        FrmModificarColor.ShowDialog()
    End Sub

    Private Sub EliminarToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles EliminarToolStripMenuItem.Click
        EliminarColor()
        MostrarColor()
    End Sub

    Private Sub EliminarColor()
        If Cn.State = ConnectionState.Open Then
            Cn.Close()
        End If

        Dim IdColor As Integer
        IdColor = CInt(LsvColor.FocusedItem.SubItems(0).Text)

        Try
            Cn.Open()
            Using Cmd As New SqlCommand
                With Cmd
                    .CommandText = "Sp_EliminarColor"
                    .CommandType = CommandType.StoredProcedure
                    .Connection = Cn

                    ' Parámetros
                    .Parameters.Add("@IdColor", SqlDbType.Int).Value = IdColor
                    .ExecuteNonQuery()

                    MessageBox.Show("Registro eliminado satisfactoriamente", "CarWashSystem", MessageBoxButtons.OK, MessageBoxIcon.Information)
                End With
            End Using
        Catch ex As Exception
            MessageBox.Show("Error al eliminar el registro" + ex.Message, "CarWashSystem", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            Cn.Close()
        End Try
    End Sub

    Private Sub TxtBuscar_TextChanged(sender As Object, e As EventArgs) Handles TxtBuscar.TextChanged
        BuscarColor()
    End Sub


End Class
