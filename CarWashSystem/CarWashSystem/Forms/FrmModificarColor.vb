Imports System.Data.SqlClient
Public Class FrmModificarColor
    Private Sub BtnAplicar_Click(sender As Object, e As EventArgs) Handles BtnAplicar.Click
        If ValidarTextBox() = True Then
            ActualizarColor()
            Limpiar()
        End If

    End Sub

    Private Sub Limpiar()
        TxtIdColor.Text = Nothing
        TxtNombreColor.Text = Nothing

    End Sub

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

    Private Sub ActualizarColor()
        If Cn.State = ConnectionState.Open Then
            Cn.Close()
        End If

        Try
            Cn.Open()
            Using Cmd As New SqlCommand
                With Cmd
                    .CommandText = "Sp_ModificarColor"
                    .CommandType = CommandType.StoredProcedure
                    .Connection = Cn

                    ' Parámetros
                    .Parameters.Add("@NombreColor", SqlDbType.NVarChar, 20).Value = TxtNombreColor.Text
                    .Parameters.Add("@IdColor", SqlDbType.Int).Value = CInt(TxtIdColor.Text)
                    .ExecuteNonQuery()

                    MessageBox.Show("Registro modificado satisfactoriamente", "CarWashSystem", MessageBoxButtons.OK, MessageBoxIcon.Information)
                End With


            End Using
        Catch ex As Exception
            MessageBox.Show("Error al almacenar el registro" + ex.Message, "CarWashSystem", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            Cn.Close()
        End Try
    End Sub
End Class