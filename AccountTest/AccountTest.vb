
Public Class AccountTest
    Dim BankAccount As New BankAccount(1111D)

    Enum EventType
        DEPOSIT
        WITHDRAW
    End Enum

    Private Sub AccountTest_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        DisplayAccountBalance()
    End Sub

    Private Sub depositButton_Click(sender As Object, e As EventArgs) Handles depositButton.Click
        'AccountEvent(inputTextBox.Text, EventType.DEPOSIT)
        Try
            BankAccount.Deposit(ConvertText(inputTextBox.Text))
        Catch ex As ArgumentOutOfRangeException
            MessageBox.Show(ex.Message)
        Catch ex As Exception
            DisplayErrorMessage()
        End Try

        DisplayAccountBalance()
    End Sub

    Private Sub withdrawButton_Click(sender As Object, e As EventArgs) Handles withdrawButton.Click
        'AccountEvent(inputTextBox.Text, EventType.WITHDRAW)

        Try
            BankAccount.Withdraw(ConvertText(inputTextBox.Text))
        Catch ex As ArgumentOutOfRangeException
            MessageBox.Show(ex.Message)
        Catch ex As Exception
            DisplayErrorMessage()
        End Try

        DisplayAccountBalance()
    End Sub

    'Private Sub AccountEvent(ByVal Input As String, ByVal EventType As EventType)
    '    Try
    '        Dim TempAccountInput = Convert.ToDecimal(Input)

    '        If (TempAccountInput < 0) Then
    '            Throw New Exception
    '        ElseIf (EventType = AccountTest.EventType.WITHDRAW And TempAccountInput > BankAccount.GetBalance()) Then
    '            Throw New Exception
    '        End If

    '        Select Case EventType
    '            Case AccountTest.EventType.DEPOSIT
    '                BankAccount.Deposit(TempAccountInput)
    '            Case AccountTest.EventType.WITHDRAW
    '                BankAccount.Withdraw(TempAccountInput)
    '        End Select
    '    Catch ex As Exception
    '        MessageBox.Show("Improper amount indicated, please use positive numeric values",
    '                        "Amount Input Error",
    '                        MessageBoxButtons.OK,
    '                        MessageBoxIcon.Exclamation)
    '    End Try
    'End Sub

    Private Sub DisplayAccountBalance()
        accountBalanceValueLabel.Text = BankAccount.GetBalance().ToString("c")
    End Sub

    Private Sub DisplayErrorMessage()
        MessageBox.Show("Improper amount indicated, please use positive numeric values",
                        "Amount Input Error",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Exclamation)
    End Sub

    Private Function ConvertText(ByVal AmountString As String) As Decimal
        Try
            Return Convert.ToDecimal(AmountString)
        Catch ex As Exception
            DisplayErrorMessage()
            Return 0D
        End Try
    End Function
End Class ' AccountTest
