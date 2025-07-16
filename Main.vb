Public Class Main
    Dim num1 As String
    Dim num2 As String
    Dim isDone As Boolean = False
    Dim currOp As Char = ""
    Dim db As New Database("Data Source=history.db;Version=3;")

    Dim operations As New Dictionary(Of String, Func(Of Double, Double, Double)) From
    {
        {"+", Function(x As Double, y As Double) x + y},
        {"-", Function(x As Double, y As Double) x - y},
        {"*", Function(x As Double, y As Double) x * y},
        {"/", Function(x As Double, y As Double) If(y <> 0 AndAlso x <> 0, x / y, Double.NaN)}
    }


    Private Sub NumButton_Click(sender As Object, e As EventArgs) Handles Button0.Click, Button1.Click,
                                                                          Button2.Click, Button3.Click,
                                                                          Button4.Click, Button5.Click,
                                                                          Button6.Click, Button7.Click,
                                                                          Button8.Click, Button9.Click

        Dim but = CType(sender, Button)
        HandleNum(but.Text)
    End Sub

    Private Sub OpButton_Click(Sender As Object, e As EventArgs) Handles ButtonPlus.Click,
                                                                         ButtonMinus.Click,
                                                                         ButtonMult.Click,
                                                                         ButtonDiv.Click
        Dim but = CType(Sender, Button)
        HandleOp(but.Text)
    End Sub

    Private Sub OpenHist(sender As Object, e As EventArgs) Handles ButtonHist.Click
        Dim historyForm As New History()
        historyForm.Show()
    End Sub

    Private Sub Del(sender As Object, e As EventArgs) Handles ButtonDel.Click
        resBox.Text = resBox.Text.Substring(0, Math.Max(0, resBox.Text.Length - 1))
    End Sub

    Private Sub Clear(sender As Object, e As EventArgs) Handles ButtonClear.Click
        resBox.Text = ""
        num1 = ""
        num2 = ""
        currOp = ""
    End Sub

    Private Sub ButtonResult_Click(sender As Object, e As EventArgs) Handles ButtonResult.Click
        If num1 <> "" AndAlso num2 <> "" Then
            '            resBox.Text = Calculate(currOp, Double.Parse(num1), Double.Parse(num2))
            resBox.Text = operations(currOp)(Double.Parse(num1), Double.Parse(num2)).ToString()
            SaveHistory()
        ElseIf num1 = "" And num2 <> "" Then
            num1 = resBox.Text

            '           resBox.Text = Calculate(currOp, Double.Parse(num1), Double.Parse(num2))
            resBox.Text = operations(currOp)(Double.Parse(num1), Double.Parse(num2)).ToString()
            SaveHistory()
        ElseIf num1 <> "" And num2 = "" Then
            num2 = resBox.Text
            'resBox.Text = Calculate(currOp, Double.Parse(num1), Double.Parse(num2))
            resBox.Text = operations(currOp)(Double.Parse(num1), Double.Parse(num2)).ToString()
            SaveHistory()

        Else
            resBox.Text = "Error: No numbers to calculate"
        End If
        isDone = True
        num1 = ""
        num2 = ""
        currOp = ""
    End Sub

    Function Calculate(op As String, n1 As Double, n2 As Double) As String
        Select Case op
            Case "+" : Return (n1 + n2).ToString()
            Case "-" : Return (n1 - n2).ToString()
            Case "*" : Return (n1 * n2).ToString()
            Case "/" : If num2 <> 0 Then
                    Return (n1 / n2).ToString()
                Else
                    Return "Error: Division by zero"
                End If
        End Select
        Return "Error"
    End Function

    Private Sub HandleOp(op As Char)
        currOp = op
        If num1 = "" Then
            num1 = resBox.Text
            resBox.Text = ""
        ElseIf num2 = "" Then
            num2 = resBox.Text
            Dim n1, n2 As Double
            If Double.TryParse(num1, n1) AndAlso Double.TryParse(num2, n2) Then
                If currOp = "/" AndAlso n2 = 0 Then
                    resBox.Text = "Error: Division by zero"
                    Return
                End If
            Else
                resBox.Text = "Error: Invalid number"
                Return
            End If
            '            Dim result As String = Calculate(op, n1, n2)
            Dim result As String = operations(currOp)(Double.Parse(num1), Double.Parse(num2)).ToString()
            resBox.Text = result
            isDone = True
        Else
            num1 = resBox.Text
            resBox.Text = ""
            num2 = ""
            isDone = False
        End If
    End Sub

    Private Sub HandleNum(num As Char)
        If num = "."c AndAlso resBox.Text.Contains(".") Then Exit Sub

        If isDone Then
            resBox.Text = ""
            isDone = False
        End If

        resBox.Text = resBox.Text & num
    End Sub

    Private Sub SaveHistory()
        db.AdddHistory(num1 & " " & currOp & " " & num2, Double.Parse(resBox.Text))
    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        db.CreateHistory()
    End Sub


End Class