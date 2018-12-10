Imports System.Math
Public Class Form1

    Private Sub Form1_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        Select Case e.KeyCode
            Case Keys.Left
                If Me.picBar.Bounds.IntersectsWith(Me.borderLeft.Bounds) Then
                Else
                    Me.picBar.Left -= 5

                End If

            Case Keys.Right
                If Me.picBar.Bounds.IntersectsWith(Me.borderRight.Bounds) Then
                Else
                    Me.picBar.Left += 5

                End If
        End Select
    End Sub

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Call createBricks()
    End Sub

    Function RndInt(ByVal HighNum As Integer, ByVal LowNum As Integer) As Integer
        'returns random number
        Dim randomNum As Integer

        Randomize()
        randomNum = Int((HighNum - LowNum + 1) * Rnd()) + LowNum

        Return randomNum
    End Function

    Private Sub tmrMoveBall_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tmrMoveBall.Tick
        Static UDdirection As String
        Static LRdirection As String
        Static EndGame As Integer


        Static barBally As Double
        Static barBallx As Double
        Static boxBally As Double
        Static boxBallx As Double
        Static distanceFromBartoBox As Double
        Dim height As Double


        If Me.picBall.Bounds.IntersectsWith(Me.borderLeft.Bounds) Then
            LRdirection = "right"
        End If

        If Me.picBall.Bounds.IntersectsWith(Me.borderRight.Bounds) Then
            LRdirection = "left"
        End If

        If Me.picBall.Bounds.IntersectsWith(Me.borderTop.Bounds) Then
            UDdirection = "down"
        End If

        If Me.picBall.Bounds.IntersectsWith(Me.borderBottom.Bounds) Then
            picBall.Location = New Point(24, 171)
        End If

        For i = 1 To 20
            If Me.Controls("brick" & i).Visible = True Then
                If Me.picBall.Bounds.IntersectsWith(Me.Controls("brick" & i).Bounds) Then
                    Beep()
                    UDdirection = "down"
                    Me.Controls("brick" & i).Visible = False
                    EndGame += 1

                    boxBallx = picBall.Location.X
                    boxBally = picBall.Location.Y
                    Dim d As Double

                    d = (((boxBallx + barBallx) ^ 2) - ((boxBally + barBally) ^ 2))
                    distanceFromBartoBox = Sqrt(d)


                End If
            End If
        Next i

        Dim xbar As Double
        Dim xball As Double

        If picBall.Bounds.IntersectsWith(picBar.Bounds) Then
            UDdirection = "up"
            xbar = picBar.Location.X
            xball = picBall.Location.X
            Select Case xball
                Case xbar To xbar + 45
                    LRdirection = "left"
                Case xbar + 90 To xbar + 135
                    LRdirection = "right"
            End Select
            xbar = Nothing
            xball = Nothing

            barBally = picBall.Location.Y
            barBallx = picBall.Location.X
        End If

        If UDdirection = "up" Then
            picBall.Top -= 1
        Else
            picBall.Top += 1
        End If

        If LRdirection = "left" Then
            picBall.Left -= 1
        Else
            picBall.Left += 1
        End If

        If EndGame = 20 Then
            tmrMoveBall.Enabled = False
            MessageBox.Show("you won")
            Call createBricks()
            picBall.Location = New Point(24, 171)
            UDdirection = "down"
            LRdirection = "left"
            EndGame = 0
            tmrMoveBall.Enabled = True
        End If

    End Sub

    Sub createBricks()
        Dim color As Integer
        Dim i As Integer

        For i = 1 To 20
            Me.Controls("brick" & i).Visible = True
        Next

        color = RndInt(3, 1)
        For i = 1 To 20
            If color = 1 Then
                Me.Controls("brick" & i).BackColor = Drawing.Color.LemonChiffon
            ElseIf color = 2 Then
                Me.Controls("brick" & i).BackColor = Drawing.Color.Purple
            Else
                Me.Controls("brick" & i).BackColor = Drawing.Color.Pink
            End If
        Next i

        color = RndInt(3, 1)
        For i = 1 To 20 Step 2
            If color = 1 Then
                Me.Controls("brick" & i).BackColor = Drawing.Color.LimeGreen
            ElseIf color = 2 Then
                Me.Controls("brick" & i).BackColor = Drawing.Color.Orange
            Else
                Me.Controls("brick" & i).BackColor = Drawing.Color.SpringGreen
            End If
        Next i

        color = RndInt(3, 1)
        For i = 1 To 20 Step 3
            If color = 1 Then
                Me.Controls("brick" & i).BackColor = Drawing.Color.Yellow
            ElseIf color = 2 Then
                Me.Controls("brick" & i).BackColor = Drawing.Color.Lavender
            Else
                Me.Controls("brick" & i).BackColor = Drawing.Color.Red
            End If
        Next i

        'top row 



    End Sub

End Class
