Public Class BankAccount
    Private BalanceDecimal As Decimal

    Private Property AccountBalance() As Decimal
        Get
            Return BalanceDecimal
        End Get

        Set(ByVal AccountEventDecimal As Decimal)
            BalanceDecimal = AccountEventDecimal
        End Set
    End Property

    ' Default constructor
    Public Sub New()
        BalanceDecimal = 0
    End Sub

    ' Custom constructor (overloaded method)
    Public Sub New(ByVal StartingBalance As Decimal)
        BalanceDecimal = StartingBalance
    End Sub

    Public Sub Withdraw(ByVal TempAmount As Decimal)
        ' Check input is positive
        CheckForPositiveAmount(TempAmount)

        ' Check that incoming amount is not greater than current balance
        If (TempAmount > BalanceDecimal) Then
            Throw New ArgumentOutOfRangeException("Withdrawl amount greater than account balance")
        Else
            AccountBalance -= TempAmount
        End If
    End Sub

    Public Sub Deposit(ByVal TempAmount As Decimal)
        CheckForPositiveAmount(TempAmount)

        AccountBalance += TempAmount
    End Sub

    Public Function GetBalance() As Decimal
        Return BalanceDecimal
    End Function

    Private Sub CheckForPositiveAmount(ByVal AmountToCheck As Decimal)
        If (AmountToCheck < 0) Then
            Throw New ArgumentOutOfRangeException("Amount must be positive")
        End If
    End Sub

End Class
