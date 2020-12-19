Module modMain
    Dim WithEvents a As New Ayo.AyoGame

    Sub Main()
        Console.WriteLine("Welcome to the VB version of Ayo")

        Console.ForegroundColor = ConsoleColor.White : Console.WriteLine("Select Play Mode:")
        Console.ForegroundColor = ConsoleColor.Yellow : Console.Write("1:") : Console.ForegroundColor = ConsoleColor.White : Console.WriteLine("Player Vs Player")
        Console.ForegroundColor = ConsoleColor.Yellow : Console.Write("2:") : Console.ForegroundColor = ConsoleColor.White : Console.WriteLine("Player Vs Computer")
        Console.ForegroundColor = ConsoleColor.Yellow : Console.Write("3:") : Console.ForegroundColor = ConsoleColor.White : Console.WriteLine("Computer Vs Player")
        Console.ForegroundColor = ConsoleColor.Yellow : Console.Write("4:") : Console.ForegroundColor = ConsoleColor.White : Console.WriteLine("Computer Vs Computer")
        Dim playMode As String = Console.ReadLine()
        If playMode = "1" Then
            PlayerVsPlayer()
        ElseIf playMode = "2" Then
            PlayerVsComputer()
        ElseIf playMode = "3" Then
            ComputerVsPlayer()
        ElseIf playMode = "4" Then
            ComputerVsComputer()
        End If
    End Sub
#Region "Vs"
    Sub PlayerVsPlayer()
        Console.WriteLine("Player Vs Player")
        Dim gameOver As Boolean = False
        Dim SelectedHole As Integer = 0
        DisplayBoard()
        While gameOver = False
            Console.ForegroundColor = ConsoleColor.Yellow
            Console.WriteLine("Enter number of the hole you want to play from")
            SelectedHole = Convert.ToInt32(Console.ReadLine())
            PlayTurn(SelectedHole)
            'Console.ForegroundColor = ConsoleColor.Yellow
            'Console.WriteLine("Enter number of the hole you want to play from")
            'SelectedHole = Convert.ToInt32(Console.ReadLine())
            'If SelectedHole > 0 And SelectedHole < 13 Then
            '    a.SelectPlayer(SelectedHole)
            '    '//expected format of entry is 1 based so adjust for 0 based index
            '    SelectedHole -= 1
            '    a.Iterate(SelectedHole)
            'End If
        End While
        'End If
    End Sub

    Sub ComputerVsPlayer()
        Dim gameOver As Boolean = False
        While gameOver = False
            If a.PlayersTurn = 1 Then
                'p.DisplayConsoleBoard(a, EventArgs.Empty);
                Console.ForegroundColor = ConsoleColor.Yellow
                Console.WriteLine("Enter number of the hole you want to play from")
                Dim SelectedHole As Integer = Convert.ToInt32(Console.ReadLine())
                a.SelectPlayer(SelectedHole)
                '//expected format of entry is 1 based so adjust for 0 based index
                SelectedHole -= 1
                a.Iterate(SelectedHole)
            End If
            If a.PlayersTurn = 0 Then
                '{
                Console.ForegroundColor = ConsoleColor.Red
                Console.WriteLine("Computer's Turn")
                System.Threading.Thread.Sleep(1000)
                Dim SelectedHole As Integer = a.ComputeriseTurnL2_ComputerVsPlayer()
                If SelectedHole = -1 Then
                    '{ 
                    gameOver = True
                    Console.ForegroundColor = ConsoleColor.Magenta
                    Console.WriteLine("GAME OVER!")
                    Console.ReadLine()
                    Exit While
                    '}
                Else
                    '{
                    PlayTurn(SelectedHole)
                    'a.SelectPlayer(SelectedHole)
                    'SelectedHole -= 1
                    'a.Iterate(SelectedHole)
                    '}
                End If
            End If
        End While
    End Sub

    Sub PlayerVsComputer()
        Dim gameOver As Boolean = False
        While gameOver = False
            If a.PlayersTurn = 0 Then
                'p.DisplayConsoleBoard(a, EventArgs.Empty);
                Console.ForegroundColor = ConsoleColor.Yellow
                Console.WriteLine("Enter number of the hole you want to play from")
                Dim SelectedHole As Integer = Convert.ToInt32(Console.ReadLine())
                a.SelectPlayer(SelectedHole)
                '//expected format of entry is 1 based so adjust for 0 based index
                SelectedHole -= 1
                a.Iterate(SelectedHole)
            End If
            If a.PlayersTurn = 1 Then
                '{
                Console.ForegroundColor = ConsoleColor.Red
                Console.WriteLine("Computer's Turn")
                System.Threading.Thread.Sleep(1000)
                Dim SelectedHole As Integer = a.ComputeriseTurnL2_PlayerVsComputer()
                If SelectedHole = -1 Then
                    '{ 
                    gameOver = True
                    Console.ForegroundColor = ConsoleColor.Magenta
                    Console.WriteLine("GAME OVER!")
                    'break()
                    Exit While
                    '}
                Else
                    '{
                    PlayTurn(SelectedHole)
                    'a.SelectPlayer(SelectedHole)
                    'SelectedHole -= 1
                    'a.Iterate(SelectedHole)
                    '}
                End If
            End If
        End While
    End Sub

    Sub ComputerVsComputer()
        Dim gameOver As Boolean = False
        While gameOver = False
            If a.PlayersTurn = 1 Then
                '{
                Console.ForegroundColor = ConsoleColor.Red
                Console.WriteLine("Computer's Turn")
                System.Threading.Thread.Sleep(1000)
                Dim SelectedHole As Integer = a.ComputeriseTurnL2_PlayerVsComputer()
                If SelectedHole = -1 Then
                    '{ 
                    gameOver = True
                    Console.ForegroundColor = ConsoleColor.Magenta
                    Console.WriteLine("GAME OVER!")
                    Console.ReadLine()
                    Exit While
                    '}
                Else
                    '{
                    PlayTurn(SelectedHole)
                    'a.SelectPlayer(SelectedHole)
                    'SelectedHole -= 1
                    'a.Iterate(SelectedHole)
                    '}
                End If
            End If
            If a.PlayersTurn = 0 Then
                '{
                Console.ForegroundColor = ConsoleColor.Red
                Console.WriteLine("Computer's Turn")
                System.Threading.Thread.Sleep(1000)
                Dim SelectedHole As Integer = a.ComputeriseTurnL2_ComputerVsPlayer()
                If SelectedHole = -1 Then
                    '{ 
                    gameOver = True
                    Console.ForegroundColor = ConsoleColor.Magenta
                    Console.WriteLine("GAME OVER!")
                    Console.ReadLine()
                    Exit While
                    '}
                Else
                    '{
                    PlayTurn(SelectedHole)
                    'a.SelectPlayer(SelectedHole)
                    'SelectedHole -= 1
                    'a.Iterate(SelectedHole)
                    '}
                End If
            End If
        End While
    End Sub
#End Region
    Sub PlayTurn(ByVal SelectedHole As Integer)
        'Console.ForegroundColor = ConsoleColor.Yellow
        'Console.WriteLine("Enter number of the hole you want to play from")
        'SelectedHole = Convert.ToInt32(Console.ReadLine())
        If SelectedHole > 0 And SelectedHole < 13 Then
            a.SelectPlayer(SelectedHole)
            '//expected format of entry is 1 based so adjust for 0 based index
            SelectedHole -= 1
            a.Iterate(SelectedHole)
        End If
    End Sub
    Private Sub a_Changed(ByVal sender As Object, ByVal e As System.EventArgs) Handles a.Changed
        Dim ag As Ayo.AyoGame = sender
        Dim Board() As Integer = ag.Board

        '//this gives an animated effect
        Console.Clear()
        '//core display
        Console.ForegroundColor = ConsoleColor.Green
        Console.WriteLine("({0}) ({1}) ({2}) ({3}) ({4}) ({5})", Board(11), Board(10), Board(9), Board(8), Board(7), Board(6))
        Console.WriteLine("({0}) ({1}) ({2}) ({3}) ({4}) ({5})", Board(0), Board(1), Board(2), Board(3), Board(4), Board(5))
        Console.WriteLine("scoop:{0} turnCount0:{1} turnCount:{2} currentPlayer:{3}", ag.Scoop, ag.TurnCount0, ag.TurnCount, ag.CurrentPlayer)
        Console.WriteLine("dropCount:{1} pickCount:{2} checksum:{0}", ag.BoardChecksum, ag.DropCount, ag.PickCount)
        'Console.WriteLine("currentPlayer:{0} acc(0):{1} acc(1):{2}", ag.CurrentPlayer, ag.Accumulator(0), ag.Accumulator(1))
        Console.WriteLine("playersTurn:{0} chopCount:{1} currentHole:{2} activeHole:{3}", ag.PlayersTurn, ag.ChopCount, ag.CurrentHole, ag.ActiveHole)
        Console.ForegroundColor = ConsoleColor.Yellow : Console.WriteLine("acc(0):{0} acc(1):{1}", ag.Accumulator(0), ag.Accumulator(1))
        Console.ForegroundColor = ConsoleColor.Green : Console.WriteLine("-------------------------------------------------")
        '//this gives an animated effect
        System.Threading.Thread.Sleep(ag.AnimationInterval)
    End Sub
    Sub DisplayBoard()
        Dim ag As Ayo.AyoGame = a
        Dim Board() As Integer = ag.Board

        '//this gives an animated effect
        Console.Clear()
        '//core display
        Console.ForegroundColor = ConsoleColor.Green
        Console.WriteLine("({0}) ({1}) ({2}) ({3}) ({4}) ({5})", Board(11), Board(10), Board(9), Board(8), Board(7), Board(6))
        Console.WriteLine("({0}) ({1}) ({2}) ({3}) ({4}) ({5})", Board(0), Board(1), Board(2), Board(3), Board(4), Board(5))
        Console.WriteLine("scoop:{0} turnCount0:{1} turnCount:{2} currentPlayer:{3}", ag.Scoop, ag.TurnCount0, ag.TurnCount, ag.CurrentPlayer)
        Console.WriteLine("dropCount:{1} pickCount:{2} checksum:{0}", ag.BoardChecksum, ag.DropCount, ag.PickCount)
        Console.WriteLine("playersTurn:{0} chopCount:{1} currentHole:{2} activeHole:{3}", ag.PlayersTurn, ag.ChopCount, ag.CurrentHole, ag.ActiveHole)
        Console.ForegroundColor = ConsoleColor.White : Console.WriteLine("acc(0):{0} acc(1):{1}", ag.Accumulator(0), ag.Accumulator(1))
        Console.ForegroundColor = ConsoleColor.Green : Console.WriteLine("-------------------------------------------------")
    End Sub
End Module
