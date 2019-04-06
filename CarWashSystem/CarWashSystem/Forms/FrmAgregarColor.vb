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
            If ExisteColor() = False Then
                InsertarColor()
                Limpiar()
                FrmGestionColor.MostrarColor()
                Close()
            End If

        End If


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

    Private Function ExisteColor() As Boolean
        If Cn.State = ConnectionState.Open Then
            Cn.Close()
        End If

        Dim Estado As Boolean = False

        Try
            Cn.Open()
            Using Cmd As New SqlCommand
                With Cmd
                    .CommandText = "Sp_ExisteColor"
                    .CommandType = CommandType.StoredProcedure
                    .Connection = Cn

                    ' Parámetros
                    .Parameters.Add("@NombreColor", SqlDbType.NVarChar, 20).Value = TxtNombreColor.Text.Trim

                End With

                Dim Existe As Integer = Cmd.ExecuteScalar()

                If Existe <> 0 Then
                    Estado = True
                    MessageBox.Show("Ya está registrado este color " + TxtNombreColor.Text, "CarWashSystem", MessageBoxButtons.OK, MessageBoxIcon.Information)

                End If

            End Using
        Catch ex As Exception
            MessageBox.Show("Error al almacenar el registro" + ex.Message, "CarWashSystem", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            Cn.Close()
        End Try
        Return Estado

    End Function

    Public Sub InvestigarCorrelativo()
        If Cn.State = ConnectionState.Open Then
            Cn.Close()
        End If

        Try
            Dim ListaColor As New SqlCommand("Sp_InvestigarCorrelativoColor", Cn)
            ListaColor.CommandType = CommandType.StoredProcedure
            Dim ListarColor As SqlDataReader
            Cn.Open()

            ListarColor = ListaColor.ExecuteReader
            If ListarColor.Read = True Then
                If ListarColor("IdColor") Is DBNull.Value Then
                    TxtIdColor.Text = 1
                Else
                    TxtIdColor.Text = ListarColor("IdColor").ToString
                End If
            End If
        Catch ex As Exception
            MessageBox.Show("Error de conexión a la base de datos" + ex.Message,
                                "CarWashSystem", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            Cn.Close()
        End Try

    End Sub

    Private Sub FrmAgregarColor_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        InvestigarCorrelativo()

    End Sub
End Class