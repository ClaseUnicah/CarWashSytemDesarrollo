Imports System.Data.SqlClient
Public Class FrmGestionColor

    Private Sub MostrarColor()
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

    Private Sub FrmGestionColor_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        MostrarColor()

    End Sub
End Class
