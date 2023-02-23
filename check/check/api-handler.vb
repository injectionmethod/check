Module api_handler
    Dim API_POOL As String() = {"http://viz.greynoise.io/api/v3/internal/ip/"}
    Function PerformCheck(address As String)
        Try
            Console.WriteLine("{+} Checking API Pool For Record Of Address >>> {" + address + "}")
            Threading.Thread.Sleep(1000)
            For Each API In API_POOL
                Dim API_SEND As System.Net.HttpWebRequest
                Dim API_RESP As System.Net.HttpWebResponse

                API_SEND = CType(System.Net.WebRequest.Create(API + address), System.Net.HttpWebRequest)
                API_SEND.UserAgent = "Mozilla/4.0 (compatible; MSIE 8.0; Windows NT 6.1; WOW64; Trident/4.0; SLCC2;"
                API_SEND.AllowAutoRedirect = True
                API_SEND.Method = "GET"
                API_SEND.Timeout = 3000
                API_SEND.ContentType = "application/json"
                API_RESP = API_SEND.GetResponse

                Dim API_WRITE As New System.IO.StreamReader(API_RESP.GetResponseStream)
                Console.WriteLine(ChopString(ArrangeString(API_WRITE.ReadToEnd, ","), {"}", "{", "[", "]"}, ""))
            Next
        Catch ex As Exception
            Console.WriteLine("{+} No Record Found")
        End Try
        Return Nothing
    End Function
    Function ChopString(INPUT As String, CHARSETT As String(), CHARTOREPLACE As String)
        Dim RET = INPUT
        For Each CHARR In CHARSETT
            RET = RET.Replace(CHARR, CHARTOREPLACE)
        Next
        Return [RET]
    End Function
    Function ArrangeString(INPUT As String, CHARR As String)
        Dim RET = INPUT.Replace(CHARR, vbNewLine).Replace("""", "")
        Return [RET]
    End Function
End Module