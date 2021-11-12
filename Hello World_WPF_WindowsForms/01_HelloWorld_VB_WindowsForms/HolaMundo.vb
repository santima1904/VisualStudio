Imports Mis_Clases

Public Class Form1

    ''' <summary>
    '''  Prototipo: Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
    '''  Descripcion: 
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        Dim opersona As clsPersona

        opersona = New clsPersona(TextBox1.Text)

        If (opersona.Nombre.Length > 0) Then

            MessageBox.Show("Hola " + opersona.Nombre, "Mensaje", MessageBoxButtons.OK)

        Else

            MessageBox.Show("Ponga algo")

        End If
    End Sub


End Class
