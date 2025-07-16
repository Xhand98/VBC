Public Class History
    Private db As New Database("Data Source=history.db;Version=3;")
    Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick

    End Sub

    Private Sub History_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        DataGridView1.DataSource = db.GetHistory()
    End Sub
End Class