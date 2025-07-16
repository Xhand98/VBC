Imports System.Data.SQLite

Public Class Database
    Private conn As SQLiteConnection

    Public Property dbPath As String

    Public Sub New(ByVal url As String)
        Me.dbPath = url
    End Sub

    Public Sub CreateHistory()
        conn = New SQLiteConnection(dbPath)
        conn.Open()

        Dim createTable As String = "CREATE TABLE IF NOT EXISTS HISTORY (
                                        ID integer primary key,
                                        Operacion TXT Not Null,
                                        Result Integer Not Null
                                     )"
        Dim cmd As New SQLiteCommand(createTable, conn)
        cmd.ExecuteNonQuery()
        conn.Close()
    End Sub

    Public Sub AdddHistory(ByVal op As String, ByVal res As Integer)
        conn = New SQLiteConnection(dbPath)
        conn.Open()
        Dim insertQuery As String = "INSERT INTO HISTORY (Operacion, Result) VALUES (@op, @res)"
        Dim cmd As New SQLiteCommand(insertQuery, conn)
        cmd.Parameters.AddWithValue("@op", op)
        cmd.Parameters.AddWithValue("@res", res)
        cmd.ExecuteNonQuery()
        conn.Close()
    End Sub

    Public Function GetHistory() As DataTable
        Dim dt As New DataTable()
        conn = New SQLiteConnection(dbPath)
        conn.Open()
        Dim selectQuery As String = "SELECT * FROM HISTORY"
        Dim cmd As New SQLiteCommand(selectQuery, conn)
        Dim adapter As New SQLiteDataAdapter(cmd)
        adapter.Fill(dt)
        conn.Close()
        Return dt
    End Function

End Class
