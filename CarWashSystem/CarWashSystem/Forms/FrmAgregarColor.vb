Imports System.Data.SqlClient

Public Class FrmAgregarColor

    Private Function ValidarTextBox() As Boolean

        Dim Estado As Boolean

        If TxtNombreColor.Text = Nothing Then
            EpMensaje.SetError(TxtNombreColor, "Tiene que ingrear el nombre del color.")
            TxtNombreColor.BackColor = Color.LightBlue
            TxtNombreColor.Focus()
            Estado = False
        Else
            Estado = True
            EpMensaje.SetError(TxtNombreColor, "")
        End If
        Return Estado

    End Function

    Private Sub BtnAplicar_Click(sender As Object, e As EventArgs) Handles BtnAplicar.Click

        If ValidarTextBox() = True Then
            InsertarColor()
            Limpiar()
        End If
        FrmGestionColor.MostrarColor()
        Close()

    End Sub

    Private Sub Limpiar()
        TxtIdColor.Text = Nothing
        TxtNombreColor.Text = Nothing

    End Sub
    Private Sub InsertarColor()
        If Cn.State = ConnectionState.Open Then
            Cn.Close()
        End If

        Try
            Cn.Open()
            Using Cmd As New SqlCommand
                With Cmd
                    .CommandText = "Sp_InsertarColor"
                    .CommandType = CommandType.StoredProcedure
                    .Connection = Cn

                    ' Parámetros
                    .Parameters.Add("@NombreColor", SqlDbType.NVarChar, 20).Value = TxtNombreColor.Text
                    .ExecuteNonQuery()

                    MessageBox.Show("Registro almacenado satisfactoriamente", "CarWashSystem", MessageBoxButtons.OK, MessageBoxIcon.Information)
                End With


            End Using
        Catch ex As Exception
            MessageBox.Show("Error al almacenar el registro" + ex.Message, "CarWashSystem", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            Cn.Close()
        End Try
    End Sub
End Class