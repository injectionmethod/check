Module check
    Sub Main()
        Dim args As String() = Strings.Split(Environment.GetCommandLineArgs(1), ",")
        For Each entry In args
            api_handler.PerformCheck(entry)
        Next
    End Sub
End Module